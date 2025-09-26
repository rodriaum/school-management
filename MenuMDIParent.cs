using SchoolManagement;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace GestaoEscolaAula
{
    public partial class MenuMDIParent : Form
    {
        private SqlService _sqlService;
        private int childFormNumber = 0;

        public MenuMDIParent()
        {
            InitializeComponent();
        }

        private void MenuMDIParent_Load(object sender, EventArgs e)
        {
            try
            {
                UpdateStatusMessage("A carregar...", Color.Yellow);
                _sqlService = new SqlService();
                UpdateStatusMessage("Conectado com o banco de dados.", Color.Green);
            }
            catch (Exception)
            {
                UpdateStatusMessage("Não foi possível conectar ao banco de dados.", Color.Red);
                return;
            }
        }

        private void listarCursoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListCourseForm form = new ListCourseForm(_sqlService);
            form.MdiParent = this;
            form.Show();
        }

        private void inserirCursoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewCourseForm form = new NewCourseForm(_sqlService);
            form.MdiParent = this;
            form.Show();
        }

        private async void UpdateStatusMessage(string s = "", Color? c = null)
        {
            if (string.IsNullOrEmpty(s))
                this.toolStripStatusLabel.Text = "";

            this.toolStripStatusLabel.Text = s;

            if (c.HasValue)
                this.toolStripStatusLabel.ForeColor = c.Value;
        }
    }
}