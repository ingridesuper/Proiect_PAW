namespace _2_1058_PISLARU_INGRID
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
            this.pretTextBox = new System.Windows.Forms.TextBox();
            this.numeTextBox = new System.Windows.Forms.TextBox();
            this.pretLabel = new System.Windows.Forms.Label();
            this.numeLabel = new System.Windows.Forms.Label();
            this.addingProductLabel = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.panel1.Controls.Add(this.cancelButton);
            this.panel1.Controls.Add(this.saveButton);
            this.panel1.Controls.Add(this.addingProductLabel);
            this.panel1.Controls.Add(this.pretTextBox);
            this.panel1.Controls.Add(this.numeTextBox);
            this.panel1.Controls.Add(this.numeLabel);
            this.panel1.Controls.Add(this.pretLabel);
            this.panel1.Location = new System.Drawing.Point(392, -3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(679, 985);
            this.panel1.TabIndex = 4;
            // 
            // pretTextBox
            // 
            this.pretTextBox.Location = new System.Drawing.Point(309, 425);
            this.pretTextBox.Name = "pretTextBox";
            this.pretTextBox.Size = new System.Drawing.Size(211, 29);
            this.pretTextBox.TabIndex = 8;
            // 
            // numeTextBox
            // 
            this.numeTextBox.Location = new System.Drawing.Point(309, 307);
            this.numeTextBox.Name = "numeTextBox";
            this.numeTextBox.Size = new System.Drawing.Size(211, 29);
            this.numeTextBox.TabIndex = 7;
            // 
            // pretLabel
            // 
            this.pretLabel.AutoSize = true;
            this.pretLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.82081F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pretLabel.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.pretLabel.Location = new System.Drawing.Point(202, 425);
            this.pretLabel.Name = "pretLabel";
            this.pretLabel.Size = new System.Drawing.Size(64, 30);
            this.pretLabel.TabIndex = 6;
            this.pretLabel.Text = "Pret";
            // 
            // numeLabel
            // 
            this.numeLabel.AutoSize = true;
            this.numeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.82081F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numeLabel.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.numeLabel.Location = new System.Drawing.Point(180, 305);
            this.numeLabel.Name = "numeLabel";
            this.numeLabel.Size = new System.Drawing.Size(86, 30);
            this.numeLabel.TabIndex = 5;
            this.numeLabel.Text = "Nume";
            // 
            // addingProductLabel
            // 
            this.addingProductLabel.AutoSize = true;
            this.addingProductLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.06936F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addingProductLabel.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.addingProductLabel.Location = new System.Drawing.Point(203, 122);
            this.addingProductLabel.Name = "addingProductLabel";
            this.addingProductLabel.Size = new System.Drawing.Size(293, 33);
            this.addingProductLabel.TabIndex = 9;
            this.addingProductLabel.Text = "Adaugati un produs!";
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(438, 532);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(90, 40);
            this.saveButton.TabIndex = 10;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(323, 532);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(90, 40);
            this.cancelButton.TabIndex = 11;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // AddTipAbonamentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(1521, 982);
            this.Controls.Add(this.panel1);
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
        private System.Windows.Forms.Label addingProductLabel;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
    }
}