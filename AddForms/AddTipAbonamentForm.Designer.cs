namespace _2_1058_PISLARU_INGRID.AddForms
{
    partial class AddTipAbonamentForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.cancelButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.addAbonamentLabel = new System.Windows.Forms.Label();
            this.pretTextBox = new System.Windows.Forms.TextBox();
            this.numeTextBox = new System.Windows.Forms.TextBox();
            this.numeLabel = new System.Windows.Forms.Label();
            this.pretLabel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.panel1.Controls.Add(this.cancelButton);
            this.panel1.Controls.Add(this.saveButton);
            this.panel1.Controls.Add(this.addAbonamentLabel);
            this.panel1.Controls.Add(this.pretTextBox);
            this.panel1.Controls.Add(this.numeTextBox);
            this.panel1.Controls.Add(this.numeLabel);
            this.panel1.Controls.Add(this.pretLabel);
            this.panel1.Location = new System.Drawing.Point(285, -2);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(494, 657);
            this.panel1.TabIndex = 4;
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(235, 355);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(2);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(65, 27);
            this.cancelButton.TabIndex = 11;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(319, 355);
            this.saveButton.Margin = new System.Windows.Forms.Padding(2);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(65, 27);
            this.saveButton.TabIndex = 10;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // addAbonamentLabel
            // 
            this.addAbonamentLabel.AutoSize = true;
            this.addAbonamentLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.06936F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addAbonamentLabel.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.addAbonamentLabel.Location = new System.Drawing.Point(113, 80);
            this.addAbonamentLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.addAbonamentLabel.Name = "addAbonamentLabel";
            this.addAbonamentLabel.Size = new System.Drawing.Size(307, 25);
            this.addAbonamentLabel.TabIndex = 9;
            this.addAbonamentLabel.Text = "Adaugati un tip de abonament!";
            // 
            // pretTextBox
            // 
            this.pretTextBox.Location = new System.Drawing.Point(225, 283);
            this.pretTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.pretTextBox.Name = "pretTextBox";
            this.pretTextBox.Size = new System.Drawing.Size(155, 22);
            this.pretTextBox.TabIndex = 8;
            // 
            // numeTextBox
            // 
            this.numeTextBox.Location = new System.Drawing.Point(225, 205);
            this.numeTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.numeTextBox.Name = "numeTextBox";
            this.numeTextBox.Size = new System.Drawing.Size(155, 22);
            this.numeTextBox.TabIndex = 7;
            // 
            // numeLabel
            // 
            this.numeLabel.AutoSize = true;
            this.numeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.82081F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numeLabel.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.numeLabel.Location = new System.Drawing.Point(131, 203);
            this.numeLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.numeLabel.Name = "numeLabel";
            this.numeLabel.Size = new System.Drawing.Size(61, 22);
            this.numeLabel.TabIndex = 5;
            this.numeLabel.Text = "Nume";
            // 
            // pretLabel
            // 
            this.pretLabel.AutoSize = true;
            this.pretLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.82081F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pretLabel.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.pretLabel.Location = new System.Drawing.Point(147, 283);
            this.pretLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.pretLabel.Name = "pretLabel";
            this.pretLabel.Size = new System.Drawing.Size(47, 22);
            this.pretLabel.TabIndex = 6;
            this.pretLabel.Text = "Pret";
            // 
            // AddTipAbonamentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(1106, 655);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "AddTipAbonamentForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddTipAbonamentForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox pretTextBox;
        private System.Windows.Forms.TextBox numeTextBox;
        private System.Windows.Forms.Label numeLabel;
        private System.Windows.Forms.Label pretLabel;
        private System.Windows.Forms.Label addAbonamentLabel;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
    }
}