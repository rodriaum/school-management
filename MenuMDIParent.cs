using SchoolManagement;
using System;
using System.IO;
using System.Windows.Forms;

namespace GestaoEscolaAula
{
    public partial class MenuMDIParent : Form
    {
        private int childFormNumber = 0;

        public MenuMDIParent()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Janela " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Arquivos de texto (*.txt)|*.txt|Todos os arquivos (*.*)|*.*";

            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void listarCursoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListCourseForm form = new ListCourseForm();
            form.MdiParent = this;
            form.Show();
        }

        private void inserirCursoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewCourseForm form = new NewCourseForm();
            form.MdiParent = this;
            form.Show();
        }
    }
}