using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchoolManagement
{
    public partial class ListCourseForm : Form
    {
        private SqlService _sqlService;

        private DateTime _lastUpdate;
        private DateTime _lastDelete;

        private int delayTime = 5;

        public ListCourseForm(SqlService sqlService)
        {
            InitializeComponent();

            this._sqlService = sqlService;
            this.RefreshTable();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            if (_lastUpdate == null)
            {
                _lastUpdate = DateTime.Now;

                if (this.RefreshTable())
                {
                    this.Log("Atualizado com sucesso.", Color.Green);
                }
                return;
            }

            if (DateTime.Now > _lastUpdate.AddSeconds(delayTime))
            {
                _lastUpdate = DateTime.Now;

                if (this.RefreshTable())
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

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (_lastDelete == null || DateTime.Now > _lastDelete.AddSeconds(delayTime))
            {
                _lastDelete = DateTime.Now;
                this.RefreshTable();

                int rows = 0;

                foreach (DataGridViewRow row in coursesDataGridView.SelectedRows)
                {
                    DataGridViewCell courseCell = row.Cells["curso_id"];

                    if (!row.IsNewRow && courseCell != null)
                        rows += this.DeleteLine(courseCell.Value.ToString());
                }

                if (rows > 0)
                {
                    this.Log($"'{rows}' curso(s) eliminado(s) com sucesso.", Color.Green);
                }
                else
                {
                    this.Log($"Nenhum curso encontrado ou eliminado.", Color.Red);
                }
            }
            else
            {
                int time = (_lastDelete.AddSeconds(delayTime) - DateTime.Now).Seconds;
                this.Log($"Você está a eliminar muito rápido. (Aguarde {time}s)", Color.Red);
            }
        }

        private int DeleteLine(string cursoId)
        {
            try
            {
                Dictionary<string, string> parameters = new Dictionary<string, string>
                {
                    { "@curso_id", cursoId }
                };

                int rows = _sqlService.ExecuteNonQuery("DELETE FROM Cursos WHERE curso_id = @curso_id", parameters);

                if (rows > 0)
                {
                    this.RefreshTable();
                    return rows;
                }

                return 0;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        private bool RefreshTable()
        {
            try
            {
                DataTable data = _sqlService.ExecuteQueryDataTable("SELECT * FROM Cursos");

                coursesDataGridView.DataSource = data;
                coursesDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                coursesDataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

                coursesDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                coursesDataGridView.MultiSelect = true;
                coursesDataGridView.ReadOnly = true;
                coursesDataGridView.AllowUserToAddRows = false;

                return true;
            }
            catch (Exception)
            {
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

        private void coursesDataGridView_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
