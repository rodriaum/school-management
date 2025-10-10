namespace SchoolManagement
{
    partial class UpdateCourseForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateCourseForm));
            this.titleLabel = new System.Windows.Forms.Label();
            this.sendButton = new System.Windows.Forms.Button();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.descriptionTextBox = new System.Windows.Forms.TextBox();
            this.statusLabel = new System.Windows.Forms.Label();
            this.subStatusLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold);
            this.titleLabel.ForeColor = System.Drawing.Color.MediumSlateBlue;
            this.titleLabel.Location = new System.Drawing.Point(127, 52);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(258, 33);
            this.titleLabel.TabIndex = 5;
            this.titleLabel.Text = "INSERIR CURSO";
            // 
            // sendButton
            // 
            this.sendButton.BackColor = System.Drawing.SystemColors.Control;
            this.sendButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("sendButton.BackgroundImage")));
            this.sendButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.sendButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.sendButton.Location = new System.Drawing.Point(624, 348);
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
            this.nameLabel.Text = "Nome do Curso";
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.AutoSize = true;
            this.descriptionLabel.Location = new System.Drawing.Point(130, 138);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(100, 13);
            this.descriptionLabel.TabIndex = 9;
            this.descriptionLabel.Text = "Descrição do Curso";
            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.BackColor = System.Drawing.Color.Beige;
            this.descriptionTextBox.Location = new System.Drawing.Point(133, 154);
            this.descriptionTextBox.Multiline = true;
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.Size = new System.Drawing.Size(541, 188);
            this.descriptionTextBox.TabIndex = 8;
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
            // UpdateCourseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.subStatusLabel);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.descriptionLabel);
            this.Controls.Add(this.descriptionTextBox);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.sendButton);
            this.Name = "UpdateCourseForm";
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
        private System.Windows.Forms.TextBox descriptionTextBox;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.Label subStatusLabel;
    }
}