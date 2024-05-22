using _2_1058_PISLARU_INGRID.Entities;
using _2_1058_PISLARU_INGRID.Repositories;
using System;
using System.Windows.Forms;
using _2_1058_PISLARU_INGRID.EditForms;
using _2_1058_PISLARU_INGRID.AddForms;

namespace _2_1058_PISLARU_INGRID.MainPageForms
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
            CreateButtonColumn("Edit", "Edit", "Edit");
        }

        private void CreateButtonColumn(string headerText, string buttonText, string columnName) //de mutat
        {
            DataGridViewButtonColumn column = new DataGridViewButtonColumn();
            column.HeaderText = headerText;
            column.Text = buttonText;
            column.UseColumnTextForButtonValue = true;
            column.Name = columnName;

            tipAbonamentDataGridView.Columns.Add(column);
        }

        private void EvaluateButtons() //de mutat
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

        private void previousPageButton_Click(object sender, EventArgs e) //mutat, gen
        {
            _currentPage--;
            currentPageTextBox.Text = $"{_currentPage} / {_totalPages}";

            EvaluateButtons();

            tipAbonamentDataGridView.DataSource = _tipAbonamentRepository.FetchAllTipAbonament(_currentPage, _pageSize);
        }

        private void nextPageButton_Click(object sender, EventArgs e) //mutat, gen
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

        public void RefreshDataGridView() //same
        {
            _currentPage = 1;
            _totalCount = _tipAbonamentRepository.GetTotalCount();
            _totalPages = Convert.ToInt32(Math.Ceiling((double)_totalCount / _pageSize));

            totalCountTextBox.Text = _totalCount.ToString();
            currentPageTextBox.Text = $"{_currentPage} / {_totalPages}";

            EvaluateButtons();
            tipAbonamentDataGridView.DataSource = _tipAbonamentRepository.FetchAllTipAbonament(_currentPage, _pageSize);
        }

        private void tipAbonamentDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var grid = (DataGridView)sender;
            var columnName = grid.Columns[e.ColumnIndex].Name;
            var tipAbonament = (TipAbonament)grid.Rows[e.RowIndex].DataBoundItem;

            if (columnName == "Delete")
            {
                ClientAbonamentRepository clientAbonamentRepository = new ClientAbonamentRepository();
                if (clientAbonamentRepository.SuntClientiCuAcestAbonament(tipAbonament.Id))
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
            if (columnName == "Edit")
            {
                var editTAbonamentForm=new EditTipAbonamentForm(tipAbonament);
                editTAbonamentForm.Owner = this;
                editTAbonamentForm.ShowDialog();
                RefreshDataGridView();
            }
        }
    }
}
