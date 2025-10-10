using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchoolManagement
{
    public partial class UpdateClassForm : Form
    {
        private SqlService _sqlService;

        private int _id;

        public UpdateClassForm(SqlService sqlService, int classId = -1, string code = null, DateTime? year = null, int courseId = -1)
        {
            InitializeComponent();

            this._sqlService = sqlService;
            this._id = courseId;

            DateTime fixDateTime = year.HasValue ? year.Value : DateTime.Today;

            if (!codeTextBox.IsDisposed)
                codeTextBox.Text = code;

            if (!courseComboBox.IsDisposed)
                courseComboBox.Text = courseId.ToString();

            if (!yearDateTimePicker.IsDisposed)
                yearDateTimePicker.Value = fixDateTime;
        }

        private async void UpdateClassForm_Load(object sender, EventArgs e)
        {
            Dictionary<int, string> table = await _sqlService.GetCourseIdAndName();

            var courseList = table.Select(x => new
            {
                Id = x.Key,
                Name = x.Value
            }).ToList();

            courseComboBox.DisplayMember = "Name";
            courseComboBox.ValueMember = "Id";
            courseComboBox.DataSource = courseList;
        }

        private async void sendButton_Click(object sender, EventArgs e)
        {
            string code = codeTextBox.Text;
            object course = courseComboBox.SelectedValue;

            DateTime year = yearDateTimePicker.Value;

            // WTF CODE
            if (!int.TryParse(course.ToString(), out int courseId))
            {
                this.Log("O id do curso precisa ser um número.", Color.Red);
                return;
            }

            if (string.IsNullOrWhiteSpace(code) || year == null)
            {
                this.Log("Um ou mais dos parametros obrigatórios não estão preenchidos.", Color.Red);
                return;
            }

            if (courseId == -1)
            {
                this.Log("O ID do curso não pode ser -1.", Color.Red);
                return;
            }

            if (await _sqlService.HasClassByCode(code.ToUpper()))
            {
                int id = this._id;

                // Caso não seja atribuido um ID de atualização ele vai pensar que o form foi aberto normalmente sem pedido de atualização.
                if (id == -1)
                {
                    this.Log($"Já existe uma turma com esse nome!", Color.Red);
                    return;
                }

                if (await _sqlService.UpdateClass(id, code, year, courseId) > 0)
                {
                    this.Log($"Turma atualizado com sucesso!", Color.Green);
                    this.SubLog(CreateUpdateElements(id: id, code: code, courseId: courseId, year: year));
                    return;
                }

                this.Log($"Não foi possível inserir a turma!", Color.Red);
                return;
            }

            try
            {
                if (await _sqlService.NewClass(code, year, courseId) > 0)
                {
                    this.codeTextBox.Clear();
                    this.yearDateTimePicker.Value = DateTime.Now;

                    this.Log($"Turma adicionada com sucesso!", Color.Green);
                    this.SubLog(CreateUpdateElements(code: code, courseId: courseId, year: year));
                }
                else
                {
                    this.Log($"Não foi possível inserir a turma!", Color.Red);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Não foi possível inserir a turma!");
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Hide();

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

        private string CreateUpdateElements(int id = -1, string code = null, int courseId = -1, DateTime? year = null)
        {
            StringBuilder sb = new StringBuilder();

            if (id != -1)
                sb.Append($"ID: {id} | ");


            if (!string.IsNullOrWhiteSpace(code))
                sb.Append($"Código Turma: {code} | ");


            if (courseId != -1)
                sb.Append($"ID de Curso: {courseId} | ");

            if (year.HasValue)
                sb.Append($"Ano de Referência: {year.Value.ToShortDateString()} | ");

            string final = sb.ToString();

            if (final.EndsWith("| "))
                final = final.Substring(0, final.Length - 2);

            return final;
        }
    }
}
