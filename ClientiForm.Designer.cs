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
            this.clientTotalCountLabel = new System.Windows.Forms.Label();
            this.clientTotalCountTextBox = new System.Windows.Forms.TextBox();
            this.previousPageButton = new System.Windows.Forms.Button();
            this.nextPageButton = new System.Windows.Forms.Button();
            this.currentPageLabel = new System.Windows.Forms.Label();
            this.currentPageTextBox = new System.Windows.Forms.TextBox();
            this.clientMenuStrip = new System.Windows.Forms.MenuStrip();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewOnlyCurrentClientsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewOnlyPastClientsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewAllClientsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.clientDataGridView.Location = new System.Drawing.Point(12, 182);
            this.clientDataGridView.Name = "clientDataGridView";
            this.clientDataGridView.ReadOnly = true;
            this.clientDataGridView.RowHeadersWidth = 74;
            this.clientDataGridView.RowTemplate.Height = 31;
            this.clientDataGridView.Size = new System.Drawing.Size(1497, 721);
            this.clientDataGridView.TabIndex = 0;
            // 
            // clientTotalCountLabel
            // 
            this.clientTotalCountLabel.AutoSize = true;
            this.clientTotalCountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.907515F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clientTotalCountLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.clientTotalCountLabel.Location = new System.Drawing.Point(1298, 140);
            this.clientTotalCountLabel.Name = "clientTotalCountLabel";
            this.clientTotalCountLabel.Size = new System.Drawing.Size(127, 25);
            this.clientTotalCountLabel.TabIndex = 1;
            this.clientTotalCountLabel.Text = "Total count:";
            // 
            // clientTotalCountTextBox
            // 
            this.clientTotalCountTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.clientTotalCountTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.clientTotalCountTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.907515F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clientTotalCountTextBox.ForeColor = System.Drawing.SystemColors.Control;
            this.clientTotalCountTextBox.Location = new System.Drawing.Point(1431, 142);
            this.clientTotalCountTextBox.Name = "clientTotalCountTextBox";
            this.clientTotalCountTextBox.ReadOnly = true;
            this.clientTotalCountTextBox.Size = new System.Drawing.Size(66, 22);
            this.clientTotalCountTextBox.TabIndex = 2;
            // 
            // previousPageButton
            // 
            this.previousPageButton.Location = new System.Drawing.Point(1231, 921);
            this.previousPageButton.Name = "previousPageButton";
            this.previousPageButton.Size = new System.Drawing.Size(118, 35);
            this.previousPageButton.TabIndex = 3;
            this.previousPageButton.Text = "Previous";
            this.previousPageButton.UseVisualStyleBackColor = true;
            this.previousPageButton.Click += new System.EventHandler(this.previousPageButton_Click);
            // 
            // nextPageButton
            // 
            this.nextPageButton.Location = new System.Drawing.Point(1376, 921);
            this.nextPageButton.Name = "nextPageButton";
            this.nextPageButton.Size = new System.Drawing.Size(118, 35);
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
            this.currentPageLabel.Location = new System.Drawing.Point(22, 926);
            this.currentPageLabel.Name = "currentPageLabel";
            this.currentPageLabel.Size = new System.Drawing.Size(138, 24);
            this.currentPageLabel.TabIndex = 5;
            this.currentPageLabel.Text = "Current page:";
            // 
            // currentPageTextBox
            // 
            this.currentPageTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.currentPageTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.currentPageTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.907515F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentPageTextBox.ForeColor = System.Drawing.SystemColors.Control;
            this.currentPageTextBox.Location = new System.Drawing.Point(173, 929);
            this.currentPageTextBox.Name = "currentPageTextBox";
            this.currentPageTextBox.ReadOnly = true;
            this.currentPageTextBox.Size = new System.Drawing.Size(100, 22);
            this.currentPageTextBox.TabIndex = 6;
            // 
            // clientMenuStrip
            // 
            this.clientMenuStrip.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.clientMenuStrip.ImageScalingSize = new System.Drawing.Size(29, 29);
            this.clientMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewToolStripMenuItem});
            this.clientMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.clientMenuStrip.Name = "clientMenuStrip";
            this.clientMenuStrip.Size = new System.Drawing.Size(1521, 39);
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
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(81, 35);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // viewOnlyCurrentClientsToolStripMenuItem
            // 
            this.viewOnlyCurrentClientsToolStripMenuItem.Name = "viewOnlyCurrentClientsToolStripMenuItem";
            this.viewOnlyCurrentClientsToolStripMenuItem.Size = new System.Drawing.Size(383, 42);
            this.viewOnlyCurrentClientsToolStripMenuItem.Text = "View only current clients";
            this.viewOnlyCurrentClientsToolStripMenuItem.Click += new System.EventHandler(this.viewOnlyCurrentClientsToolStripMenuItem_Click);
            // 
            // viewOnlyPastClientsToolStripMenuItem
            // 
            this.viewOnlyPastClientsToolStripMenuItem.Name = "viewOnlyPastClientsToolStripMenuItem";
            this.viewOnlyPastClientsToolStripMenuItem.Size = new System.Drawing.Size(383, 42);
            this.viewOnlyPastClientsToolStripMenuItem.Text = "View only past clients";
            this.viewOnlyPastClientsToolStripMenuItem.Click += new System.EventHandler(this.viewOnlyPastClientsToolStripMenuItem_Click);
            // 
            // viewAllClientsToolStripMenuItem
            // 
            this.viewAllClientsToolStripMenuItem.Name = "viewAllClientsToolStripMenuItem";
            this.viewAllClientsToolStripMenuItem.Size = new System.Drawing.Size(383, 42);
            this.viewAllClientsToolStripMenuItem.Text = "View all clients";
            this.viewAllClientsToolStripMenuItem.Click += new System.EventHandler(this.viewAllClientsToolStripMenuItem_Click);
            // 
            // ClientiForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(1521, 982);
            this.Controls.Add(this.currentPageTextBox);
            this.Controls.Add(this.currentPageLabel);
            this.Controls.Add(this.nextPageButton);
            this.Controls.Add(this.previousPageButton);
            this.Controls.Add(this.clientTotalCountTextBox);
            this.Controls.Add(this.clientTotalCountLabel);
            this.Controls.Add(this.clientDataGridView);
            this.Controls.Add(this.clientMenuStrip);
            this.MainMenuStrip = this.clientMenuStrip;
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
        private System.Windows.Forms.Label clientTotalCountLabel;
        private System.Windows.Forms.TextBox clientTotalCountTextBox;
        private System.Windows.Forms.Button previousPageButton;
        private System.Windows.Forms.Button nextPageButton;
        private System.Windows.Forms.Label currentPageLabel;
        private System.Windows.Forms.TextBox currentPageTextBox;
        private System.Windows.Forms.MenuStrip clientMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewOnlyCurrentClientsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewOnlyPastClientsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewAllClientsToolStripMenuItem;
    }
}