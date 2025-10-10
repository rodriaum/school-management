namespace SchoolManagement
{
    partial class UpdateStudentForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateClassForm));
            this.titleLabel = new System.Windows.Forms.Label();
            this.sendButton = new System.Windows.Forms.Button();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.statusLabel = new System.Windows.Forms.Label();
            this.subStatusLabel = new System.Windows.Forms.Label();
            this.emailTextBox = new System.Windows.Forms.TextBox();
            this.birthDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.numberTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold);
            this.titleLabel.ForeColor = System.Drawing.Color.MediumSlateBlue;
            this.titleLabel.Location = new System.Drawing.Point(127, 52);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(253, 33);
            this.titleLabel.TabIndex = 5;
            this.titleLabel.Text = "INSERIR ALUNO";
            // 
            // sendButton
            // 
            this.sendButton.BackColor = System.Drawing.SystemColors.Control;
            this.sendButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("sendButton.BackgroundImage")));
            this.sendButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.sendButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.sendButton.Location = new System.Drawing.Point(624, 280);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(50, 50);
            this.sendButton.TabIndex = 4;
            this.sendButton.UseVisualStyleBackColor = false;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // nameTextBox
            // 
            this.nameTextBox.BackColor = System.Drawing.Color.Beige;
            this.nameTextBox.Location = new System.Drawing.Point(133, 105);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(541, 20);
            this.nameTextBox.TabIndex = 6;
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.nameLabel.Location = new System.Drawing.Point(130, 89);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(80, 13);
            this.nameLabel.TabIndex = 7;
            this.nameLabel.Text = "Nome do Aluno";
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.AutoSize = true;
            this.descriptionLabel.Location = new System.Drawing.Point(130, 138);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(77, 13);
            this.descriptionLabel.TabIndex = 9;
            this.descriptionLabel.Text = "Email do Aluno";
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusLabel.ForeColor = System.Drawing.Color.DarkGreen;
            this.statusLabel.Location = new System.Drawing.Point(135, 362);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(0, 20);
            this.statusLabel.TabIndex = 11;
            this.statusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // subStatusLabel
            // 
            this.subStatusLabel.AutoSize = true;
            this.subStatusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subStatusLabel.ForeColor = System.Drawing.Color.DimGray;
            this.subStatusLabel.Location = new System.Drawing.Point(136, 382);
            this.subStatusLabel.Name = "subStatusLabel";
            this.subStatusLabel.Size = new System.Drawing.Size(0, 13);
            this.subStatusLabel.TabIndex = 12;
            this.subStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // emailTextBox
            // 
            this.emailTextBox.BackColor = System.Drawing.Color.Beige;
            this.emailTextBox.Location = new System.Drawing.Point(133, 154);
            this.emailTextBox.Name = "emailTextBox";
            this.emailTextBox.Size = new System.Drawing.Size(541, 20);
            this.emailTextBox.TabIndex = 13;
            // 
            // birthDateTimePicker
            // 
            this.birthDateTimePicker.Location = new System.Drawing.Point(133, 254);
            this.birthDateTimePicker.Name = "birthDateTimePicker";
            this.birthDateTimePicker.Size = new System.Drawing.Size(541, 20);
            this.birthDateTimePicker.TabIndex = 14;
            // 
            // numberTextBox
            // 
            this.numberTextBox.BackColor = System.Drawing.Color.Beige;
            this.numberTextBox.Location = new System.Drawing.Point(133, 205);
            this.numberTextBox.Name = "numberTextBox";
            this.numberTextBox.Size = new System.Drawing.Size(541, 20);
            this.numberTextBox.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(130, 238);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Data de Nascimento do Aluno";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(130, 189);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Nº de Telefone do Aluno";
            // 
            // UpdateStudentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numberTextBox);
            this.Controls.Add(this.birthDateTimePicker);
            this.Controls.Add(this.emailTextBox);
            this.Controls.Add(this.subStatusLabel);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.descriptionLabel);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.sendButton);
            this.Name = "UpdateStudentForm";
            this.Text = "Inserir Curso";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label descriptionLabel;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.Label subStatusLabel;
        private System.Windows.Forms.TextBox emailTextBox;
        private System.Windows.Forms.DateTimePicker birthDateTimePicker;
        private System.Windows.Forms.TextBox numberTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}