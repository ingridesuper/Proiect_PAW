namespace _2_1058_PISLARU_INGRID
{
    partial class ClientAbonamentForm
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
            this.clientAbonamentDataGridView = new System.Windows.Forms.DataGridView();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addClientAbonamentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.clientAbonamentDataGridView)).BeginInit();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // currentPageTextBox
            // 
            this.currentPageTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.currentPageTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.currentPageTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.907515F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentPageTextBox.ForeColor = System.Drawing.SystemColors.Control;
            this.currentPageTextBox.Location = new System.Drawing.Point(126, 613);
            this.currentPageTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.currentPageTextBox.Name = "currentPageTextBox";
            this.currentPageTextBox.ReadOnly = true;
            this.currentPageTextBox.Size = new System.Drawing.Size(73, 15);
            this.currentPageTextBox.TabIndex = 20;
            // 
            // currentPageLabel
            // 
            this.currentPageLabel.AutoSize = true;
            this.currentPageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.907515F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentPageLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.currentPageLabel.Location = new System.Drawing.Point(16, 611);
            this.currentPageLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.currentPageLabel.Name = "currentPageLabel";
            this.currentPageLabel.Size = new System.Drawing.Size(100, 16);
            this.currentPageLabel.TabIndex = 19;
            this.currentPageLabel.Text = "Current page:";
            // 
            // nextPageButton
            // 
            this.nextPageButton.Location = new System.Drawing.Point(1001, 608);
            this.nextPageButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.nextPageButton.Name = "nextPageButton";
            this.nextPageButton.Size = new System.Drawing.Size(86, 23);
            this.nextPageButton.TabIndex = 18;
            this.nextPageButton.Text = "Next";
            this.nextPageButton.UseVisualStyleBackColor = true;
            this.nextPageButton.Click += new System.EventHandler(this.nextPageButton_Click);
            // 
            // previousPageButton
            // 
            this.previousPageButton.Location = new System.Drawing.Point(895, 608);
            this.previousPageButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.previousPageButton.Name = "previousPageButton";
            this.previousPageButton.Size = new System.Drawing.Size(86, 23);
            this.previousPageButton.TabIndex = 17;
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
            this.totalCountTextBox.Location = new System.Drawing.Point(1041, 89);
            this.totalCountTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.totalCountTextBox.Name = "totalCountTextBox";
            this.totalCountTextBox.ReadOnly = true;
            this.totalCountTextBox.Size = new System.Drawing.Size(48, 15);
            this.totalCountTextBox.TabIndex = 16;
            // 
            // totalCountLabel
            // 
            this.totalCountLabel.AutoSize = true;
            this.totalCountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.907515F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalCountLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.totalCountLabel.Location = new System.Drawing.Point(944, 87);
            this.totalCountLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.totalCountLabel.Name = "totalCountLabel";
            this.totalCountLabel.Size = new System.Drawing.Size(88, 16);
            this.totalCountLabel.TabIndex = 15;
            this.totalCountLabel.Text = "Total count:";
            // 
            // clientAbonamentDataGridView
            // 
            this.clientAbonamentDataGridView.AllowUserToAddRows = false;
            this.clientAbonamentDataGridView.AllowUserToDeleteRows = false;
            this.clientAbonamentDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.clientAbonamentDataGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.clientAbonamentDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.clientAbonamentDataGridView.GridColor = System.Drawing.SystemColors.Control;
            this.clientAbonamentDataGridView.Location = new System.Drawing.Point(9, 115);
            this.clientAbonamentDataGridView.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.clientAbonamentDataGridView.Name = "clientAbonamentDataGridView";
            this.clientAbonamentDataGridView.ReadOnly = true;
            this.clientAbonamentDataGridView.RowHeadersWidth = 74;
            this.clientAbonamentDataGridView.RowTemplate.Height = 31;
            this.clientAbonamentDataGridView.Size = new System.Drawing.Size(1089, 481);
            this.clientAbonamentDataGridView.TabIndex = 14;
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(19, 19);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1106, 28);
            this.menuStrip.TabIndex = 21;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addClientAbonamentToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // addClientAbonamentToolStripMenuItem
            // 
            this.addClientAbonamentToolStripMenuItem.Name = "addClientAbonamentToolStripMenuItem";
            this.addClientAbonamentToolStripMenuItem.Size = new System.Drawing.Size(249, 26);
            this.addClientAbonamentToolStripMenuItem.Text = "Add Client-Abonament ";
            this.addClientAbonamentToolStripMenuItem.Click += new System.EventHandler(this.addClientAbonamentToolStripMenuItem_Click);
            // 
            // ClientAbonamentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(1106, 655);
            this.Controls.Add(this.currentPageTextBox);
            this.Controls.Add(this.currentPageLabel);
            this.Controls.Add(this.nextPageButton);
            this.Controls.Add(this.previousPageButton);
            this.Controls.Add(this.totalCountTextBox);
            this.Controls.Add(this.totalCountLabel);
            this.Controls.Add(this.clientAbonamentDataGridView);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "ClientAbonamentForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pachete Active";
            ((System.ComponentModel.ISupportInitialize)(this.clientAbonamentDataGridView)).EndInit();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
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
        private System.Windows.Forms.DataGridView clientAbonamentDataGridView;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addClientAbonamentToolStripMenuItem;
    }
}