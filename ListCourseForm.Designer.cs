namespace SchoolManagement
{
    partial class ListCourseForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListCourseForm));
            this.coursesDataGridView = new System.Windows.Forms.DataGridView();
            this.refreshButton = new System.Windows.Forms.Button();
            this.titleLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.coursesDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // coursesDataGridView
            // 
            this.coursesDataGridView.BackgroundColor = System.Drawing.Color.Beige;
            this.coursesDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.coursesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.coursesDataGridView.Location = new System.Drawing.Point(124, 95);
            this.coursesDataGridView.Name = "coursesDataGridView";
            this.coursesDataGridView.Size = new System.Drawing.Size(541, 253);
            this.coursesDataGridView.TabIndex = 0;
            // 
            // refreshButton
            // 
            this.refreshButton.BackColor = System.Drawing.SystemColors.Control;
            this.refreshButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("refreshButton.BackgroundImage")));
            this.refreshButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.refreshButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.refreshButton.Location = new System.Drawing.Point(615, 354);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(50, 50);
            this.refreshButton.TabIndex = 1;
            this.refreshButton.UseVisualStyleBackColor = false;
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Bodoni MT", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.ForeColor = System.Drawing.Color.MediumSlateBlue;
            this.titleLabel.Location = new System.Drawing.Point(118, 58);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(250, 34);
            this.titleLabel.TabIndex = 2;
            this.titleLabel.Text = "LISTA DE CURSOS";
            // 
            // ListCourseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.refreshButton);
            this.Controls.Add(this.coursesDataGridView);
            this.Name = "ListCourseForm";
            this.Text = "ListCourseForm";
            ((System.ComponentModel.ISupportInitialize)(this.coursesDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView coursesDataGridView;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.Label titleLabel;
    }
}