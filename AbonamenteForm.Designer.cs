namespace _2_1058_PISLARU_INGRID
{
    partial class AbonamenteForm
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
            this.currentPageTextBox = new System.Windows.Forms.TextBox();
            this.currentPageLabel = new System.Windows.Forms.Label();
            this.nextPageButton = new System.Windows.Forms.Button();
            this.previousPageButton = new System.Windows.Forms.Button();
            this.totalCountTextBox = new System.Windows.Forms.TextBox();
            this.totalCountLabel = new System.Windows.Forms.Label();
            this.tipAbonamentDataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.tipAbonamentDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // currentPageTextBox
            // 
            this.currentPageTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.currentPageTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.currentPageTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.907515F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentPageTextBox.ForeColor = System.Drawing.SystemColors.Control;
            this.currentPageTextBox.Location = new System.Drawing.Point(173, 927);
            this.currentPageTextBox.Name = "currentPageTextBox";
            this.currentPageTextBox.ReadOnly = true;
            this.currentPageTextBox.Size = new System.Drawing.Size(100, 22);
            this.currentPageTextBox.TabIndex = 13;
            // 
            // currentPageLabel
            // 
            this.currentPageLabel.AutoSize = true;
            this.currentPageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.907515F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentPageLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.currentPageLabel.Location = new System.Drawing.Point(22, 924);
            this.currentPageLabel.Name = "currentPageLabel";
            this.currentPageLabel.Size = new System.Drawing.Size(138, 24);
            this.currentPageLabel.TabIndex = 12;
            this.currentPageLabel.Text = "Current page:";
            // 
            // nextPageButton
            // 
            this.nextPageButton.Location = new System.Drawing.Point(1376, 919);
            this.nextPageButton.Name = "nextPageButton";
            this.nextPageButton.Size = new System.Drawing.Size(118, 35);
            this.nextPageButton.TabIndex = 11;
            this.nextPageButton.Text = "Next";
            this.nextPageButton.UseVisualStyleBackColor = true;
            this.nextPageButton.Click += new System.EventHandler(this.nextPageButton_Click);
            // 
            // previousPageButton
            // 
            this.previousPageButton.Location = new System.Drawing.Point(1231, 919);
            this.previousPageButton.Name = "previousPageButton";
            this.previousPageButton.Size = new System.Drawing.Size(118, 35);
            this.previousPageButton.TabIndex = 10;
            this.previousPageButton.Text = "Previous";
            this.previousPageButton.UseVisualStyleBackColor = true;
            this.previousPageButton.Click += new System.EventHandler(this.previousPageButton_Click);
            // 
            // totalCountTextBox
            // 
            this.totalCountTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.totalCountTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.totalCountTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.907515F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalCountTextBox.ForeColor = System.Drawing.SystemColors.Control;
            this.totalCountTextBox.Location = new System.Drawing.Point(1431, 140);
            this.totalCountTextBox.Name = "totalCountTextBox";
            this.totalCountTextBox.ReadOnly = true;
            this.totalCountTextBox.Size = new System.Drawing.Size(66, 22);
            this.totalCountTextBox.TabIndex = 9;
            // 
            // totalCountLabel
            // 
            this.totalCountLabel.AutoSize = true;
            this.totalCountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.907515F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalCountLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.totalCountLabel.Location = new System.Drawing.Point(1298, 138);
            this.totalCountLabel.Name = "totalCountLabel";
            this.totalCountLabel.Size = new System.Drawing.Size(127, 25);
            this.totalCountLabel.TabIndex = 8;
            this.totalCountLabel.Text = "Total count:";
            // 
            // tipAbonamentDataGridView
            // 
            this.tipAbonamentDataGridView.AllowUserToAddRows = false;
            this.tipAbonamentDataGridView.AllowUserToDeleteRows = false;
            this.tipAbonamentDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tipAbonamentDataGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.tipAbonamentDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tipAbonamentDataGridView.GridColor = System.Drawing.SystemColors.Control;
            this.tipAbonamentDataGridView.Location = new System.Drawing.Point(12, 180);
            this.tipAbonamentDataGridView.Name = "tipAbonamentDataGridView";
            this.tipAbonamentDataGridView.ReadOnly = true;
            this.tipAbonamentDataGridView.RowHeadersWidth = 74;
            this.tipAbonamentDataGridView.RowTemplate.Height = 31;
            this.tipAbonamentDataGridView.Size = new System.Drawing.Size(1497, 721);
            this.tipAbonamentDataGridView.TabIndex = 7;
            // 
            // AbonamenteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(1521, 982);
            this.Controls.Add(this.currentPageTextBox);
            this.Controls.Add(this.currentPageLabel);
            this.Controls.Add(this.nextPageButton);
            this.Controls.Add(this.previousPageButton);
            this.Controls.Add(this.totalCountTextBox);
            this.Controls.Add(this.totalCountLabel);
            this.Controls.Add(this.tipAbonamentDataGridView);
            this.Name = "AbonamenteForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AbonamenteForm";
            ((System.ComponentModel.ISupportInitialize)(this.tipAbonamentDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox currentPageTextBox;
        private System.Windows.Forms.Label currentPageLabel;
        private System.Windows.Forms.Button nextPageButton;
        private System.Windows.Forms.Button previousPageButton;
        private System.Windows.Forms.TextBox totalCountTextBox;
        private System.Windows.Forms.Label totalCountLabel;
        private System.Windows.Forms.DataGridView tipAbonamentDataGridView;
    }
}