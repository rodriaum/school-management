using System;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchoolManagement
{
    public partial class UpdateCourseForm : Form
    {
        private SqlService _sqlService;

        private int _courseId;
        private string _courseName;
        private string _courseDescription;

        public UpdateCourseForm(SqlService sqlService, int courseId = -1, string couseName = "", string courseDescription = "")
        {
            InitializeComponent();

            this._sqlService = sqlService;

            this._courseId = courseId;
            this._courseName = couseName;
            this._courseDescription = courseDescription;

            if (!nameTextBox.IsDisposed)
                nameTextBox.Text = couseName;

            if (!descriptionTextBox.IsDisposed)
                descriptionTextBox.Text = courseDescription;
        }

        private async void sendButton_Click(object sender, EventArgs e)
        {
            string name = nameTextBox.Text;
            string description = descriptionTextBox.Text;

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(description))
            {
                this.Log("Um ou mais dos parametros obrigatórios não estão preenchidos.", Color.Red);
                return;
            }

            if (await _sqlService.HasCourseByName(name.ToUpper()))
            {
                int courseId = this._courseId;

                // Caso não seja atribuido um ID de atualização ele vai pensar que o form foi aberto normalmente sem pedido de atualização.
                if (courseId == -1)
                {
                    this.Log($"Já existe um curso com esse nome!", Color.Red);
                    return;
                }

                if (await _sqlService.UpdateCourse(courseId, name, description) > 0)
                {
                    this.Log($"Curso atualizado com sucesso!", Color.Green);
                    this.SubLog(CreateUpdateElements(courseId, name, description));
                    return;
                }

                this.Log($"Não foi possível inserir o curso!", Color.Red);
                return;
            }

            if (await _sqlService.NewCourse(name.ToUpper(), description) > 0)
            {
                this.nameTextBox.Clear();
                this.descriptionTextBox.Clear();

                this.Log($"Curso adicionado com sucesso!", Color.Green);
                this.SubLog(CreateUpdateElements(name: name, description: description));
            }
            else
            {
                this.Log($"Não foi possível inserir o curso!", Color.Red);
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

        private string CreateUpdateElements(int courseId = -1, string name = null, string description = null)
        {
            StringBuilder sb = new StringBuilder();

            if (courseId != -1)
                sb.Append($"ID: {courseId} | ");


            if (!string.IsNullOrWhiteSpace(name))
                sb.Append($"Name: {name} | ");


            if (!string.IsNullOrWhiteSpace(description))
                sb.Append($"Descrição: {description} | ");

            string final = sb.ToString();

            if (final.EndsWith("| "))
                final = final.Substring(0, final.Length - 2);

            return final;
        }
    }
}
