using System;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchoolManagement
{
    public partial class UpdateStudentForm : Form
    {
        private SqlService _sqlService;

        private int _studentId;

        public UpdateStudentForm(SqlService sqlService, int id = -1, string name = "", string email = "", string phone = "", DateTime? birth = null)
        {
            InitializeComponent();

            this._sqlService = sqlService;
            this._studentId = id;

            DateTime fixDateTime = birth.HasValue ? birth.Value : DateTime.Today;

            if (!nameTextBox.IsDisposed)
                nameTextBox.Text = name;

            if (!emailTextBox.IsDisposed)
                emailTextBox.Text = email;

            if (!numberTextBox.IsDisposed)
                numberTextBox.Text = email;

            if (!birthDateTimePicker.IsDisposed)
                birthDateTimePicker.Value = fixDateTime;

        }

        private async void sendButton_Click(object sender, EventArgs e)
        {
            string name = nameTextBox.Text;
            string email = emailTextBox.Text;
            string phone = numberTextBox.Text;

            DateTime birth = birthDateTimePicker.Value;

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(email) || birth == null)
            {
                this.Log("Um ou mais dos parametros obrigatórios não estão preenchidos.", Color.Red);
                return;
            }

            if (await _sqlService.HasStudentByName(name.ToUpper()))
            {
                int studentId = this._studentId;

                // Caso não seja atribuido um ID de atualização ele vai pensar que o form foi aberto normalmente sem pedido de atualização.
                if (studentId == -1)
                {
                    this.Log($"Já existe um aluno com esse nome!", Color.Red);
                    return;
                }

                if (await _sqlService.UpdateCourse(studentId, name, email) > 0)
                {
                    this.Log($"Aluno atualizado com sucesso!", Color.Green);
                    this.SubLog(CreateUpdateElements(studentId:  studentId, name: name, email: email, phone: phone, birth: birth)); return;
                }

                this.Log($"Não foi possível inserir o aluno!", Color.Red);
                return;
            }

            if (await _sqlService.NewStudent(name, email, phone, birth) > 0)
            {
                this.nameTextBox.Clear();
                this.emailTextBox.Clear();
                this.numberTextBox.Clear();
                this.birthDateTimePicker.Value = DateTime.Now;

                this.Log($"Aluno adicionado com sucesso!", Color.Green);
                this.SubLog(CreateUpdateElements(name: name, email: email, phone: phone, birth: birth));
            }
            else
            {
                this.Log($"Não foi possível inserir o aluno!", Color.Red);
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

        private string CreateUpdateElements(int studentId = -1, string name = null, string email = null, string phone = null, DateTime? birth = null)
        {
            StringBuilder sb = new StringBuilder();

            if (studentId != -1)
                sb.Append($"ID: {studentId} | ");


            if (!string.IsNullOrWhiteSpace(name))
                sb.Append($"Name: {name} | ");


            if (!string.IsNullOrWhiteSpace(email))
                sb.Append($"E-mail: {email} | ");


            if (!string.IsNullOrWhiteSpace(phone))
                sb.Append($"Telefone: {phone} | ");

            if (birth.HasValue)
                sb.Append($"Nascimento: {birth.Value.ToShortDateString()} | ");

            string final = sb.ToString();

            if (final.EndsWith("| "))
                final = final.Substring(0, final.Length - 2);

            return final;
        }
    }
}
