using SchoolManagement;
using SchoolManagement.Util;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace GestaoEscolaAula
{
    public partial class MenuMDIParent : Form
    {
        private SqlService _sqlService;
        private DateTime _time;
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
                _time = DateTime.Now;

                UpdateStatusMessage(
                    $"Banco de Dados: N/A | Sessão: N/A",
                    Color.Yellow
                );
            }
            catch (Exception)
            {
                UpdateStatusMessage("Não foi possível conectar ao banco de dados.", Color.Red);
                return;
            }
        }


        private void statusTimer_Tick(object sender, EventArgs e)
        {
            bool hasConnection = _sqlService.IsConnectionOpen();
            Color color = hasConnection ? Color.Green : Color.Red;

            UpdateStatusMessage(
                $"Banco de Dados: {(hasConnection ? "Conectado" : "Desconectado")} | Sessão: {DateUtil.FormatTime(_time, DateTime.Now)}",
                color
            );
        }

        private void listarCursoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListCourseForm form = new ListCourseForm(_sqlService);
            form.MdiParent = this;
            form.Show();
        }

        private void inserirCursoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateCourseForm form = new UpdateCourseForm(_sqlService);
            form.MdiParent = this;
            form.Show();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ListClassForm form = new ListClassForm(_sqlService);
            form.MdiParent = this;
            form.Show();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            UpdateClassForm form = new UpdateClassForm(_sqlService);
            form.MdiParent = this;
            form.Show();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            UpdateStudentForm form = new UpdateStudentForm(_sqlService);
            form.MdiParent = this;
            form.Show();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            ListStudentForm form = new ListStudentForm(_sqlService);
            form.MdiParent = this;
            form.Show();
        }

        private void UpdateStatusMessage(string s = "", Color? c = null)
        {
            if (string.IsNullOrEmpty(s))
                this.toolStripStatusLabel.Text = "";

            this.toolStripStatusLabel.Text = s;

            if (c.HasValue)
                this.toolStripStatusLabel.ForeColor = c.Value;
        }
    }
}