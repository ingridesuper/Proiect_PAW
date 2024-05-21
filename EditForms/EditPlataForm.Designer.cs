namespace _2_1058_PISLARU_INGRID.EditForms
{
    partial class EditPlataForm
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
            this.panel = new System.Windows.Forms.Panel();
            this.dueDateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.dueDateLabel = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.editPlataLabel = new System.Windows.Forms.Label();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.panel.Controls.Add(this.dueDateDateTimePicker);
            this.panel.Controls.Add(this.dueDateLabel);
            this.panel.Controls.Add(this.cancelButton);
            this.panel.Controls.Add(this.saveButton);
            this.panel.Controls.Add(this.editPlataLabel);
            this.panel.Location = new System.Drawing.Point(275, -1);
            this.panel.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(694, 821);
            this.panel.TabIndex = 8;
            // 
            // dueDateDateTimePicker
            // 
            this.dueDateDateTimePicker.Location = new System.Drawing.Point(290, 262);
            this.dueDateDateTimePicker.Margin = new System.Windows.Forms.Padding(2);
            this.dueDateDateTimePicker.Name = "dueDateDateTimePicker";
            this.dueDateDateTimePicker.Size = new System.Drawing.Size(288, 26);
            this.dueDateDateTimePicker.TabIndex = 18;
            this.dueDateDateTimePicker.Value = new System.DateTime(2024, 5, 21, 11, 42, 21, 0);
            // 
            // dueDateLabel
            // 
            this.dueDateLabel.AutoSize = true;
            this.dueDateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.82081F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dueDateLabel.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.dueDateLabel.Location = new System.Drawing.Point(159, 262);
            this.dueDateLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.dueDateLabel.Name = "dueDateLabel";
            this.dueDateLabel.Size = new System.Drawing.Size(112, 26);
            this.dueDateLabel.TabIndex = 15;
            this.dueDateLabel.Text = "Due Date";
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(410, 347);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(73, 34);
            this.cancelButton.TabIndex = 11;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(505, 347);
            this.saveButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(73, 34);
            this.saveButton.TabIndex = 10;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // editPlataLabel
            // 
            this.editPlataLabel.AutoSize = true;
            this.editPlataLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.06936F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editPlataLabel.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.editPlataLabel.Location = new System.Drawing.Point(234, 141);
            this.editPlataLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.editPlataLabel.Name = "editPlataLabel";
            this.editPlataLabel.Size = new System.Drawing.Size(271, 29);
            this.editPlataLabel.TabIndex = 9;
            this.editPlataLabel.Text = "Editati aceasta plata!";
            // 
            // EditPlataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(1244, 819);
            this.Controls.Add(this.panel);
            this.Name = "EditPlataForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EditPlataForm";
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.DateTimePicker dueDateDateTimePicker;
        private System.Windows.Forms.Label dueDateLabel;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Label editPlataLabel;
    }
}