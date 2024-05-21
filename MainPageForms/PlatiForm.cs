using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _2_1058_PISLARU_INGRID.AddForms;
using _2_1058_PISLARU_INGRID.Entities;
using _2_1058_PISLARU_INGRID.Repositories;

namespace _2_1058_PISLARU_INGRID
{
    public partial class PlatiForm : Form
    {
        private int _totalCount;
        private int _currentPage = 1;
        private int _pageSize = 25;
        private int _totalPages;

        private PlatiRepository _platiRepository;
        public PlatiForm()
        {
            InitializeComponent();

            _platiRepository = new PlatiRepository();

            _totalCount = _platiRepository.GetTotalCount();
            _totalPages = Convert.ToInt32(Math.Ceiling((double)_totalCount / _pageSize));

            totalCountTextBox.Text = _totalCount.ToString();
            currentPageTextBox.Text = $"{_currentPage} / {_totalPages}";

            EvaluateButtons();

            platiDataGridView.AutoGenerateColumns = true;
            platiDataGridView.DataSource = _platiRepository.FetchAllPlati(_currentPage, _pageSize);
            CreateButtonColumn("Plateste", "Platita", "Delete");
        }

        private void CreateButtonColumn(string headerText, string buttonText, string columnName)
        {
            DataGridViewButtonColumn column = new DataGridViewButtonColumn();
            column.HeaderText = headerText;
            column.Text = buttonText;
            //This means that all buttons in the column will have the same text
            column.UseColumnTextForButtonValue = true;
            column.Name = columnName;

            platiDataGridView.Columns.Add(column);
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

            platiDataGridView.DataSource = _platiRepository.FetchAllPlati(_currentPage, _pageSize);
        }

        private void nextPageButton_Click(object sender, EventArgs e)
        {
            _currentPage++;
            currentPageTextBox.Text = $"{_currentPage} / {_totalPages}";

            EvaluateButtons();

            platiDataGridView.DataSource = _platiRepository.FetchAllPlati(_currentPage, _pageSize);
        }

        public void RefreshDataGridView()
        {
            _currentPage = 1;
            _totalCount = _platiRepository.GetTotalCount();
            _totalPages = Convert.ToInt32(Math.Ceiling((double)_totalCount / _pageSize));

            totalCountTextBox.Text = _totalCount.ToString();
            currentPageTextBox.Text = $"{_currentPage} / {_totalPages}";

            EvaluateButtons();
            platiDataGridView.DataSource = _platiRepository.FetchAllPlati(_currentPage, _pageSize);
        }

        private void addPlataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var addPlataForm=new AddPlataForm();
            addPlataForm.Owner=this;
            addPlataForm.ShowDialog();
        }

        private void platiDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //It gets the name of the column that was clicked based on the ColumnIndex property
            //of the DataGridViewCellEventArgs. This allows us to determine which button column
            //was clicked.
            var grid = (DataGridView)sender;
            var columnName = grid.Columns[e.ColumnIndex].Name;

            // This line retrieves the Product object associated with the clicked row. It uses
            // the DataBoundItem property of the DataGridViewRow to get the underlying data object
            // bound to the row.
            var plata = (Plata)grid.Rows[e.RowIndex].DataBoundItem;

            if (columnName == "Delete")
            {
     
                var result = MessageBox.Show($"Sunteti sigur ca s-a efectuat plata?",
                    "Please confirm your action",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.OK)
                {
                    _platiRepository.DeletePlata(plata);
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
