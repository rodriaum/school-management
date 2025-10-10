using System;
using System.Data;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchoolManagement
{
    public partial class ListClassForm : Form
    {
        private SqlService _sqlService;

        private DateTime _lastUpdate;
        private DateTime _lastDelete;

        private int delayTime = 5;

        public ListClassForm(SqlService sqlService)
        {
            InitializeComponent();

            this._sqlService = sqlService;
            this.RefreshTable().GetAwaiter().GetResult();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private async void refreshButton_Click(object sender, EventArgs e)
        {
            if (_lastUpdate == null)
            {
                _lastUpdate = DateTime.Now;

                if (await this.RefreshTable())
                {
                    this.Log("Atualizado com sucesso.", Color.Green);
                }
                return;
            }

            if (DateTime.Now > _lastUpdate.AddSeconds(delayTime))
            {
                _lastUpdate = DateTime.Now;

                if (await this.RefreshTable())
                {
                    this.Log("Atualizado com sucesso.", Color.Green);
                }
            }
            else
            {
                int time = (_lastUpdate.AddSeconds(delayTime) - DateTime.Now).Seconds;
                this.Log($"Você está a atualizar muito rápido. (Aguarde {time}s)", Color.Red);
            }
        }

        private async void deleteButton_Click(object sender, EventArgs e)
        {
            if (_lastDelete == null || DateTime.Now > _lastDelete.AddSeconds(delayTime))
            {
                _lastDelete = DateTime.Now;

                int rows = 0;

                foreach (DataGridViewRow row in classDataGridView.SelectedRows)
                {
                    DataGridViewCell classCell = row.Cells["turma_id"];

                    if (!row.IsNewRow && classCell != null)
                        rows += await this.DeleteLine(Convert.ToInt32(classCell.Value));
                }

                if (rows > 0)
                {
                    this.Log($"'{rows}' turma(s) eliminado(s) com sucesso.", Color.Green);
                }
                else
                {
                    this.Log($"Nenhuma turma encontrado ou eliminado.", Color.Red);
                }

                await this.RefreshTable();
            }
            else
            {
                int time = (_lastDelete.AddSeconds(delayTime) - DateTime.Now).Seconds;
                this.Log($"Você está a eliminar muito rápido. (Aguarde {time}s)", Color.Red);
            }
        }

        private void studentsDataGridView_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > 0)
            {
                DataGridViewRow selected = classDataGridView.Rows[e.RowIndex];

                int classId = Convert.ToInt32(selected.Cells["turma_id"].Value);
                string code = selected.Cells["codigo_turma"].Value.ToString();
                string year = selected.Cells["ano_referencia"].Value.ToString();
                int courseId = Convert.ToInt32(selected.Cells["curso_id"].Value);

                // date can be null
                DateTime.TryParse(year, out DateTime date);

                // date is always null in constructor
                UpdateClassForm form = new UpdateClassForm(
                    this._sqlService,
                    classId: classId,
                    code: code,
                    year: date,
                    courseId: courseId
                );

                form.Show();
                form.FormClosed += async (s, args) => await this.RefreshTable();
                // form.ShowDialog();
            }
        }

        private async Task<int> DeleteLine(int id)
        {
            try
            {
                int rows = await _sqlService.DeleteClass(id);

                if (rows > 0)
                {
                    await this.RefreshTable();
                    return rows;
                }

                return 0;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        private async Task<bool> RefreshTable()
        {
            try
            {
                DataTable data = await _sqlService.DataTableFromClasses();

                classDataGridView.DataSource = data;
                classDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                classDataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

                classDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                classDataGridView.MultiSelect = true;
                classDataGridView.ReadOnly = true;
                classDataGridView.AllowUserToAddRows = false;

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO!");
                return false;
            }
        }

        private async void Log(string s = "", Color? c = null)
        {
            if (string.IsNullOrEmpty(s))
                this.statusLabel.Text = "";

            this.subStatusLabel.ResetText();
            this.statusLabel.Text = s;

            if (c.HasValue)
                this.statusLabel.ForeColor = c.Value;

            await Task.Delay(1500);

            this.statusLabel.ResetText();
        }

        private async void SubLog(string s = "", Color? c = null)
        {
            if (string.IsNullOrEmpty(s))
                this.statusLabel.Text = "";

            this.subStatusLabel.Text = s;

            if (c.HasValue)
                this.subStatusLabel.ForeColor = c.Value;

            await Task.Delay(1500);

            this.subStatusLabel.ResetText();
        }
    }
}