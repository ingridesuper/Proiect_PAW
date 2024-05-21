namespace _2_1058_PISLARU_INGRID
{
    partial class ClientiForm
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
            this.clientDataGridView = new System.Windows.Forms.DataGridView();
            this.totalCountLabel = new System.Windows.Forms.Label();
            this.totalCountTextBox = new System.Windows.Forms.TextBox();
            this.previousPageButton = new System.Windows.Forms.Button();
            this.nextPageButton = new System.Windows.Forms.Button();
            this.currentPageLabel = new System.Windows.Forms.Label();
            this.currentPageTextBox = new System.Windows.Forms.TextBox();
            this.clientMenuStrip = new System.Windows.Forms.MenuStrip();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewOnlyCurrentClientsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewOnlyPastClientsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewAllClientsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addClientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.clientDataGridView)).BeginInit();
            this.clientMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // clientDataGridView
            // 
            this.clientDataGridView.AllowUserToAddRows = false;
            this.clientDataGridView.AllowUserToDeleteRows = false;
            this.clientDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.clientDataGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.clientDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.clientDataGridView.GridColor = System.Drawing.SystemColors.Control;
            this.clientDataGridView.Location = new System.Drawing.Point(10, 151);
            this.clientDataGridView.Margin = new System.Windows.Forms.Padding(2);
            this.clientDataGridView.Name = "clientDataGridView";
            this.clientDataGridView.ReadOnly = true;
            this.clientDataGridView.RowHeadersWidth = 74;
            this.clientDataGridView.RowTemplate.Height = 31;
            this.clientDataGridView.Size = new System.Drawing.Size(1225, 601);
            this.clientDataGridView.TabIndex = 0;
            this.clientDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.clientDataGridView_CellContentClick);
            // 
            // totalCountLabel
            // 
            this.totalCountLabel.AutoSize = true;
            this.totalCountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.907515F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalCountLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.totalCountLabel.Location = new System.Drawing.Point(1062, 116);
            this.totalCountLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.totalCountLabel.Name = "totalCountLabel";
            this.totalCountLabel.Size = new System.Drawing.Size(104, 20);
            this.totalCountLabel.TabIndex = 1;
            this.totalCountLabel.Text = "Total count:";
            // 
            // totalCountTextBox
            // 
            this.totalCountTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.totalCountTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.totalCountTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.907515F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalCountTextBox.ForeColor = System.Drawing.SystemColors.Control;
            this.totalCountTextBox.Location = new System.Drawing.Point(1171, 119);
            this.totalCountTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.totalCountTextBox.Name = "totalCountTextBox";
            this.totalCountTextBox.ReadOnly = true;
            this.totalCountTextBox.Size = new System.Drawing.Size(54, 18);
            this.totalCountTextBox.TabIndex = 2;
            // 
            // previousPageButton
            // 
            this.previousPageButton.Location = new System.Drawing.Point(1007, 768);
            this.previousPageButton.Margin = new System.Windows.Forms.Padding(2);
            this.previousPageButton.Name = "previousPageButton";
            this.previousPageButton.Size = new System.Drawing.Size(97, 29);
            this.previousPageButton.TabIndex = 3;
            this.previousPageButton.Text = "Previous";
            this.previousPageButton.UseVisualStyleBackColor = true;
            this.previousPageButton.Click += new System.EventHandler(this.previousPageButton_Click);
            // 
            // nextPageButton
            // 
            this.nextPageButton.Location = new System.Drawing.Point(1126, 768);
            this.nextPageButton.Margin = new System.Windows.Forms.Padding(2);
            this.nextPageButton.Name = "nextPageButton";
            this.nextPageButton.Size = new System.Drawing.Size(97, 29);
            this.nextPageButton.TabIndex = 4;
            this.nextPageButton.Text = "Next";
            this.nextPageButton.UseVisualStyleBackColor = true;
            this.nextPageButton.Click += new System.EventHandler(this.nextPageButton_Click);
            // 
            // currentPageLabel
            // 
            this.currentPageLabel.AutoSize = true;
            this.currentPageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.907515F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentPageLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.currentPageLabel.Location = new System.Drawing.Point(18, 771);
            this.currentPageLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.currentPageLabel.Name = "currentPageLabel";
            this.currentPageLabel.Size = new System.Drawing.Size(119, 20);
            this.currentPageLabel.TabIndex = 5;
            this.currentPageLabel.Text = "Current page:";
            // 
            // currentPageTextBox
            // 
            this.currentPageTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.currentPageTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.currentPageTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.907515F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentPageTextBox.ForeColor = System.Drawing.SystemColors.Control;
            this.currentPageTextBox.Location = new System.Drawing.Point(142, 774);
            this.currentPageTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.currentPageTextBox.Name = "currentPageTextBox";
            this.currentPageTextBox.ReadOnly = true;
            this.currentPageTextBox.Size = new System.Drawing.Size(82, 18);
            this.currentPageTextBox.TabIndex = 6;
            // 
            // clientMenuStrip
            // 
            this.clientMenuStrip.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.clientMenuStrip.ImageScalingSize = new System.Drawing.Size(29, 29);
            this.clientMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewToolStripMenuItem,
            this.fileToolStripMenuItem});
            this.clientMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.clientMenuStrip.Name = "clientMenuStrip";
            this.clientMenuStrip.Padding = new System.Windows.Forms.Padding(4, 1, 0, 1);
            this.clientMenuStrip.Size = new System.Drawing.Size(1244, 31);
            this.clientMenuStrip.TabIndex = 7;
            this.clientMenuStrip.Text = "menuStrip1";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewOnlyCurrentClientsToolStripMenuItem,
            this.viewOnlyPastClientsToolStripMenuItem,
            this.viewAllClientsToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(65, 29);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // viewOnlyCurrentClientsToolStripMenuItem
            // 
            this.viewOnlyCurrentClientsToolStripMenuItem.Name = "viewOnlyCurrentClientsToolStripMenuItem";
            this.viewOnlyCurrentClientsToolStripMenuItem.Size = new System.Drawing.Size(304, 34);
            this.viewOnlyCurrentClientsToolStripMenuItem.Text = "View only current clients";
            this.viewOnlyCurrentClientsToolStripMenuItem.Click += new System.EventHandler(this.viewOnlyCurrentClientsToolStripMenuItem_Click);
            // 
            // viewOnlyPastClientsToolStripMenuItem
            // 
            this.viewOnlyPastClientsToolStripMenuItem.Name = "viewOnlyPastClientsToolStripMenuItem";
            this.viewOnlyPastClientsToolStripMenuItem.Size = new System.Drawing.Size(304, 34);
            this.viewOnlyPastClientsToolStripMenuItem.Text = "View only past clients";
            this.viewOnlyPastClientsToolStripMenuItem.Click += new System.EventHandler(this.viewOnlyPastClientsToolStripMenuItem_Click);
            // 
            // viewAllClientsToolStripMenuItem
            // 
            this.viewAllClientsToolStripMenuItem.Name = "viewAllClientsToolStripMenuItem";
            this.viewAllClientsToolStripMenuItem.Size = new System.Drawing.Size(304, 34);
            this.viewAllClientsToolStripMenuItem.Text = "View all clients";
            this.viewAllClientsToolStripMenuItem.Click += new System.EventHandler(this.viewAllClientsToolStripMenuItem_Click);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addClientToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(54, 29);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // addClientToolStripMenuItem
            // 
            this.addClientToolStripMenuItem.Name = "addClientToolStripMenuItem";
            this.addClientToolStripMenuItem.Size = new System.Drawing.Size(194, 34);
            this.addClientToolStripMenuItem.Text = "Add client";
            this.addClientToolStripMenuItem.Click += new System.EventHandler(this.addClientToolStripMenuItem_Click);
            // 
            // ClientiForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(1244, 819);
            this.Controls.Add(this.currentPageTextBox);
            this.Controls.Add(this.currentPageLabel);
            this.Controls.Add(this.nextPageButton);
            this.Controls.Add(this.previousPageButton);
            this.Controls.Add(this.totalCountTextBox);
            this.Controls.Add(this.totalCountLabel);
            this.Controls.Add(this.clientDataGridView);
            this.Controls.Add(this.clientMenuStrip);
            this.MainMenuStrip = this.clientMenuStrip;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ClientiForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ClientiForm";
            ((System.ComponentModel.ISupportInitialize)(this.clientDataGridView)).EndInit();
            this.clientMenuStrip.ResumeLayout(false);
            this.clientMenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView clientDataGridView;
        private System.Windows.Forms.Label totalCountLabel;
        private System.Windows.Forms.TextBox totalCountTextBox;
        private System.Windows.Forms.Button previousPageButton;
        private System.Windows.Forms.Button nextPageButton;
        private System.Windows.Forms.Label currentPageLabel;
        private System.Windows.Forms.TextBox currentPageTextBox;
        private System.Windows.Forms.MenuStrip clientMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewOnlyCurrentClientsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewOnlyPastClientsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewAllClientsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addClientToolStripMenuItem;
    }
}