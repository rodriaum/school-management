using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchoolManagement
{
    public partial class NewCourseForm : Form
    {
        private SqlService _sqlService;

        public NewCourseForm(SqlService sqlService)
        {
            InitializeComponent();
            this._sqlService = sqlService;
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            string name = nameTextBox.Text;
            string description = descriptionTextBox.Text;

            if (string.IsNullOrWhiteSpace(name) && string.IsNullOrWhiteSpace(description))
            {
                this.Log("O nome e a descrição são obrigatórios.", Color.Red);
                return;
            }

            if (string.IsNullOrWhiteSpace(name))
            {
                this.Log("O nome é obrigatório.", Color.Red);
                return;
            }

            if (string.IsNullOrWhiteSpace(description))
            {
                this.Log("A descrição é obrigatório.", Color.Red);
                return;
            }

            if (_sqlService.HasCourseByName(name.ToUpper()))
            {
                this.Log($"Parece que já existe um curso com esse nome!", Color.Red);
                return;
            }
            
            if (_sqlService.NewCourse(name.ToUpper(), description) > 0)
            {
                this.nameTextBox.Clear();
                this.descriptionTextBox.Clear();

                this.Log($"Sucesso!", Color.Green);
                this.SubLog($"Curso: {name} | Descrição: {description}");
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
    }
}
