﻿namespace _2_1058_PISLARU_INGRID.EditForms
{
    partial class EditClientAbonamentForm
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
            this.dataEndDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.dataStartDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.dataEndLabel = new System.Windows.Forms.Label();
            this.dataStartLabel = new System.Windows.Forms.Label();
            this.discountTextBox = new System.Windows.Forms.TextBox();
            this.discountLabel = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.editClientAbonamentLabel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.panel1.Controls.Add(this.dataEndDateTimePicker);
            this.panel1.Controls.Add(this.dataStartDateTimePicker);
            this.panel1.Controls.Add(this.dataEndLabel);
            this.panel1.Controls.Add(this.dataStartLabel);
            this.panel1.Controls.Add(this.discountTextBox);
            this.panel1.Controls.Add(this.discountLabel);
            this.panel1.Controls.Add(this.cancelButton);
            this.panel1.Controls.Add(this.saveButton);
            this.panel1.Controls.Add(this.editClientAbonamentLabel);
            this.panel1.Location = new System.Drawing.Point(275, -1);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(694, 821);
            this.panel1.TabIndex = 7;
            // 
            // dataEndDateTimePicker
            // 
            this.dataEndDateTimePicker.Location = new System.Drawing.Point(259, 375);
            this.dataEndDateTimePicker.Margin = new System.Windows.Forms.Padding(2);
            this.dataEndDateTimePicker.Name = "dataEndDateTimePicker";
            this.dataEndDateTimePicker.Size = new System.Drawing.Size(288, 26);
            this.dataEndDateTimePicker.TabIndex = 19;
            // 
            // dataStartDateTimePicker
            // 
            this.dataStartDateTimePicker.Location = new System.Drawing.Point(259, 315);
            this.dataStartDateTimePicker.Margin = new System.Windows.Forms.Padding(2);
            this.dataStartDateTimePicker.Name = "dataStartDateTimePicker";
            this.dataStartDateTimePicker.Size = new System.Drawing.Size(288, 26);
            this.dataStartDateTimePicker.TabIndex = 18;
            this.dataStartDateTimePicker.Value = new System.DateTime(2024, 5, 21, 11, 42, 21, 0);
            // 
            // dataEndLabel
            // 
            this.dataEndLabel.AutoSize = true;
            this.dataEndLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.82081F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataEndLabel.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataEndLabel.Location = new System.Drawing.Point(137, 375);
            this.dataEndLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.dataEndLabel.Name = "dataEndLabel";
            this.dataEndLabel.Size = new System.Drawing.Size(111, 26);
            this.dataEndLabel.TabIndex = 17;
            this.dataEndLabel.Text = "Data End";
            // 
            // dataStartLabel
            // 
            this.dataStartLabel.AutoSize = true;
            this.dataStartLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.82081F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataStartLabel.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataStartLabel.Location = new System.Drawing.Point(128, 312);
            this.dataStartLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.dataStartLabel.Name = "dataStartLabel";
            this.dataStartLabel.Size = new System.Drawing.Size(120, 26);
            this.dataStartLabel.TabIndex = 15;
            this.dataStartLabel.Text = "Data Start";
            // 
            // discountTextBox
            // 
            this.discountTextBox.Location = new System.Drawing.Point(259, 256);
            this.discountTextBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.discountTextBox.Name = "discountTextBox";
            this.discountTextBox.Size = new System.Drawing.Size(288, 26);
            this.discountTextBox.TabIndex = 13;
            // 
            // discountLabel
            // 
            this.discountLabel.AutoSize = true;
            this.discountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.82081F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.discountLabel.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.discountLabel.Location = new System.Drawing.Point(143, 254);
            this.discountLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.discountLabel.Name = "discountLabel";
            this.discountLabel.Size = new System.Drawing.Size(105, 26);
            this.discountLabel.TabIndex = 12;
            this.discountLabel.Text = "Discount";
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(379, 458);
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
            this.saveButton.Location = new System.Drawing.Point(474, 458);
            this.saveButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(73, 34);
            this.saveButton.TabIndex = 10;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // editClientAbonamentLabel
            // 
            this.editClientAbonamentLabel.AutoSize = true;
            this.editClientAbonamentLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.06936F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editClientAbonamentLabel.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.editClientAbonamentLabel.Location = new System.Drawing.Point(189, 146);
            this.editClientAbonamentLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.editClientAbonamentLabel.Name = "editClientAbonamentLabel";
            this.editClientAbonamentLabel.Size = new System.Drawing.Size(329, 29);
            this.editClientAbonamentLabel.TabIndex = 9;
            this.editClientAbonamentLabel.Text = "Editati acest pachet activ!";
            // 
            // EditClientAbonamentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(1244, 819);
            this.Controls.Add(this.panel1);
            this.Name = "EditClientAbonamentForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EditClientAbonamentForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker dataEndDateTimePicker;
        private System.Windows.Forms.DateTimePicker dataStartDateTimePicker;
        private System.Windows.Forms.Label dataEndLabel;
        private System.Windows.Forms.Label dataStartLabel;
        private System.Windows.Forms.TextBox discountTextBox;
        private System.Windows.Forms.Label discountLabel;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Label editClientAbonamentLabel;
    }
}