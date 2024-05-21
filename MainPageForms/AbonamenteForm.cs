using _2_1058_PISLARU_INGRID.Entities;
using _2_1058_PISLARU_INGRID.Repositories;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2_1058_PISLARU_INGRID
{
    public partial class AbonamenteForm : Form
    {
        private int _totalCount;
        private int _currentPage = 1;
        private int _pageSize = 25;
        private int _totalPages;


        private TipAbonamentRepository _tipAbonamentRepository;
        public AbonamenteForm()
        {
            InitializeComponent();

            _tipAbonamentRepository = new TipAbonamentRepository();

            _totalCount = _tipAbonamentRepository.GetTotalCount();
            _totalPages = Convert.ToInt32(Math.Ceiling((double)_totalCount / _pageSize));

            totalCountTextBox.Text = _totalCount.ToString();
            currentPageTextBox.Text = $"{_currentPage} / {_totalPages}";

            EvaluateButtons();

            tipAbonamentDataGridView.AutoGenerateColumns = true;
            tipAbonamentDataGridView.DataSource = _tipAbonamentRepository.FetchAllTipAbonament(_currentPage, _pageSize);
            CreateButtonColumn("Delete", "Delete", "Delete");
        }

        private void CreateButtonColumn(string headerText, string buttonText, string columnName)
        {
            DataGridViewButtonColumn column = new DataGridViewButtonColumn();
            column.HeaderText = headerText;
            column.Text = buttonText;
            //This means that all buttons in the column will have the same text
            column.UseColumnTextForButtonValue = true;
            column.Name = columnName;

            tipAbonamentDataGridView.Columns.Add(column);
        }

        private void EvaluateButtons()
        {
            previousPageButton.Enabled = true;
            nextPageButton.Enabled = true;
            if (_currentPage == 1)
            {
                previousPageButton.Enabled = false;
            }
            if (_currentPage == _totalPages)
            {
                nextPageButton.Enabled = false;
            }
        }

        private void previousPageButton_Click(object sender, EventArgs e)
        {
            _currentPage--;
            currentPageTextBox.Text = $"{_currentPage} / {_totalPages}";

            EvaluateButtons();

            tipAbonamentDataGridView.DataSource = _tipAbonamentRepository.FetchAllTipAbonament(_currentPage, _pageSize);
        }

        private void nextPageButton_Click(object sender, EventArgs e)
        {
            _currentPage++;
            currentPageTextBox.Text = $"{_currentPage} / {_totalPages}";

            EvaluateButtons();

            tipAbonamentDataGridView.DataSource = _tipAbonamentRepository.FetchAllTipAbonament(_currentPage, _pageSize);
        }

        
        private void addNewAbonamentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var addTipAbonamentForm = new AddTipAbonamentForm();
            addTipAbonamentForm.Owner = this;
            addTipAbonamentForm.ShowDialog();
        }

        public void RefreshDataGridView()
        {
            _currentPage = 1;
            _totalCount = _tipAbonamentRepository.GetTotalCount();
            _totalPages = Convert.ToInt32(Math.Ceiling((double)_totalCount / _pageSize));

            totalCountTextBox.Text = _totalCount.ToString();
            currentPageTextBox.Text = $"{_currentPage} / {_totalPages}";

            EvaluateButtons();
            tipAbonamentDataGridView.DataSource = _tipAbonamentRepository.FetchAllTipAbonament(_currentPage, _pageSize);
        }


        public bool SuntClientiCuAcestAbonament(int abonamentId)
        {
            using (OracleConnection conn = new OracleConnection(Constants.ConnectionString))
            {
                conn.Open();
                string sql = "SELECT COUNT(*) FROM clientabonament WHERE tipabonamentid = :abonament";
                using (OracleCommand cmd = new OracleCommand(sql, conn))
                {
                    cmd.Parameters.Add("abonament", OracleDbType.Int32).Value = abonamentId;
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;
                }
            }
        }

        private void tipAbonamentDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //It gets the name of the column that was clicked based on the ColumnIndex property
            //of the DataGridViewCellEventArgs. This allows us to determine which button column
            //was clicked.
            var grid = (DataGridView)sender;
            var columnName = grid.Columns[e.ColumnIndex].Name;

            // This line retrieves the Product object associated with the clicked row. It uses
            // the DataBoundItem property of the DataGridViewRow to get the underlying data object
            // bound to the row.
            var tipAbonament = (TipAbonament)grid.Rows[e.RowIndex].DataBoundItem;


            if (columnName == "Delete")
            {
                if (SuntClientiCuAcestAbonament(tipAbonament.Id))
                {
                    MessageBox.Show("Sunt clienti care au acest abonament.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                var result = MessageBox.Show($"Esti sigur ca vrei sa stergi abonamentul {tipAbonament.Id}?",
                    "Please confirm your action",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.OK)
                {
                    _tipAbonamentRepository.DeleteTipAbonament(tipAbonament);
                    RefreshDataGridView();
                }

            }
            if (columnName == "EditColumn")
            {
                //edit
            }
        }
    }
}
