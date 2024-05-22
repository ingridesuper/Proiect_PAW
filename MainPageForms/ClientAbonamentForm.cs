using _2_1058_PISLARU_INGRID.Repositories;
using _2_1058_PISLARU_INGRID.AddForms;
using System;
using System.Windows.Forms;
using _2_1058_PISLARU_INGRID.Entities;
using _2_1058_PISLARU_INGRID.EditForms;

namespace _2_1058_PISLARU_INGRID.MainPageForms
{
    public partial class ClientAbonamentForm : Form
    {
        private int _totalCount;
        private int _currentPage = 1;
        private int _pageSize = 25;
        private int _totalPages;

        private ClientAbonamentRepository _clientAbonamentRepository;
        public ClientAbonamentForm()
        {
            InitializeComponent();
            _clientAbonamentRepository = new ClientAbonamentRepository();

            _totalCount = _clientAbonamentRepository.GetTotalCount();
            _totalPages = Convert.ToInt32(Math.Ceiling((double)_totalCount / _pageSize));

            totalCountTextBox.Text = _totalCount.ToString();
            currentPageTextBox.Text = $"{_currentPage} / {_totalPages}";

            EvaluateButtons();

            clientAbonamentDataGridView.AutoGenerateColumns = true;
            clientAbonamentDataGridView.DataSource = _clientAbonamentRepository.FetchAllClientAbonament(_currentPage, _pageSize);

            CreateButtonColumn("Dezaboneaza", "Dezaboneaza", "Delete");
            CreateButtonColumn("Edit", "Edit", "Edit");
        }

        private void CreateButtonColumn(string headerText, string buttonText, string columnName) //de mutat
        {
            DataGridViewButtonColumn column = new DataGridViewButtonColumn();
            column.HeaderText = headerText;
            column.Text = buttonText;
            //This means that all buttons in the column will have the same text
            column.UseColumnTextForButtonValue = true;
            column.Name = columnName;

            clientAbonamentDataGridView.Columns.Add(column);
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

        private void previousPageButton_Click(object sender, EventArgs e) //de mutat
        {
            _currentPage--;
            currentPageTextBox.Text = $"{_currentPage} / {_totalPages}";

            EvaluateButtons();

            clientAbonamentDataGridView.DataSource = _clientAbonamentRepository.FetchAllClientAbonament(_currentPage, _pageSize);
        }

        private void nextPageButton_Click(object sender, EventArgs e) //de mutat
        {
            _currentPage++;
            currentPageTextBox.Text = $"{_currentPage} / {_totalPages}";

            EvaluateButtons();

            clientAbonamentDataGridView.DataSource = _clientAbonamentRepository.FetchAllClientAbonament(_currentPage, _pageSize);
        }

        private void addClientAbonamentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var addClientAbonamentForm = new AddClientAbonamentForm();
            addClientAbonamentForm.Owner = this;
            addClientAbonamentForm.ShowDialog();
        }

        public void RefreshDataGridView() //fct care sa ia ca par repoul (sau tipul lui) si sa faca refresh 
        {
            _currentPage = 1;
            _totalCount = _clientAbonamentRepository.GetTotalCount();
            _totalPages = Convert.ToInt32(Math.Ceiling((double)_totalCount / _pageSize));

            totalCountTextBox.Text = _totalCount.ToString();
            currentPageTextBox.Text = $"{_currentPage} / {_totalPages}";

            EvaluateButtons();
            clientAbonamentDataGridView.DataSource = _clientAbonamentRepository.FetchAllClientAbonament(_currentPage, _pageSize);
        }

        
        private void clientAbonamentDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var grid = (DataGridView)sender;
            var columnName = grid.Columns[e.ColumnIndex].Name;
            var clientAbonament = (ClientAbonament)grid.Rows[e.RowIndex].DataBoundItem;

            if (columnName == "Delete")
            {
                PlatiRepository platiRepository = new PlatiRepository();
                if(platiRepository.ClientulAreDeExecutatPlati(clientAbonament.ClientId, clientAbonament.TipAbonamentId))
                {
                    MessageBox.Show("Clientul intai trebuie sa-si execute plata inainte sa fie dezabonat.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                var result = MessageBox.Show($"Sunteti sigur ca vreti sa dezabonati clientul {clientAbonament.ClientId}?",
                    "Please confirm your action",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.OK)
                {
                    _clientAbonamentRepository.DeleteClientAbonament(clientAbonament);
                    RefreshDataGridView();
                }

            }
            if (columnName == "Edit")
            {
                var editClientAbonamentForm = new EditClientAbonamentForm(clientAbonament);
                editClientAbonamentForm.Owner = this;
                editClientAbonamentForm.ShowDialog();
                RefreshDataGridView();
            }
        }
    }
}
