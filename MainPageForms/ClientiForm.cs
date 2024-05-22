using _2_1058_PISLARU_INGRID.Repositories;
using System;
using System.Windows.Forms;
using _2_1058_PISLARU_INGRID.Entities;
using _2_1058_PISLARU_INGRID.EditForms;
using _2_1058_PISLARU_INGRID.AddForms;

namespace _2_1058_PISLARU_INGRID.MainPageForms
{
    public partial class ClientiForm : Form
    {
        private int _totalCount;
        private int _currentPage;
        private int _pageSize = 25;
        private int _totalPages;
        private bool _viewOnlyCurrentClients;
        private bool _viewOnlyPastClients;

        private ClientRepository _clientRepository;

        public ClientiForm()
        {
            InitializeComponent();
            _clientRepository = new ClientRepository();
            viewAllClients();
            CreateButtonColumn("Delete", "Delete", "Delete");
            CreateButtonColumn("Edit", "Edit", "Edit");
        }


        //astea sunt la fel?
        private void viewAllClients()
        {
            _currentPage = 1;
            _viewOnlyCurrentClients = false;
            _viewOnlyPastClients = false;
            _totalCount = _clientRepository.GetTotalCount();
            _totalPages = Convert.ToInt32(Math.Ceiling((double)_totalCount / _pageSize));
            totalCountTextBox.Text = _totalCount.ToString();
            currentPageTextBox.Text = $"{_currentPage} / {_totalPages}";

            EvaluateButtons();
            clientDataGridView.AutoGenerateColumns = true;
            clientDataGridView.DataSource = _clientRepository.FetchAllClients(_currentPage, _pageSize);
        }

        public void RefreshDataGridView()
        {
            _currentPage = 1;
            _totalCount = _clientRepository.GetTotalCount();
            _totalPages = Convert.ToInt32(Math.Ceiling((double)_totalCount / _pageSize));

            totalCountTextBox.Text = _totalCount.ToString();
            currentPageTextBox.Text = $"{_currentPage} / {_totalPages}";

            EvaluateButtons();
            clientDataGridView.DataSource = _clientRepository.FetchAllClients(_currentPage, _pageSize);
        }

        private void CreateButtonColumn(string headerText, string buttonText, string columnName) //de mutat
        {
            DataGridViewButtonColumn column = new DataGridViewButtonColumn();
            column.HeaderText = headerText;
            column.Text = buttonText;
            column.UseColumnTextForButtonValue = true; //toate sa aiba acelasi text
            column.Name = columnName;

            clientDataGridView.Columns.Add(column);
        }

        private void viewAllClientsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            viewAllClients();
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

        private void previousPageButton_Click(object sender, EventArgs e)
        {
            if (_currentPage > 1)
            {
                _currentPage--;
                currentPageTextBox.Text = $"{_currentPage} / {_totalPages}";
                EvaluateButtons();

                if (_viewOnlyCurrentClients)
                {
                    clientDataGridView.DataSource = _clientRepository.FetchCurrentClients(_currentPage, _pageSize);
                }
                else if (_viewOnlyPastClients)
                {
                    clientDataGridView.DataSource = _clientRepository.FetchPastClients(_currentPage, _pageSize);
                }
                else
                {
                    clientDataGridView.DataSource = _clientRepository.FetchAllClients(_currentPage, _pageSize);
                }
            }
        }

        private void nextPageButton_Click(object sender, EventArgs e)
        {
            if (_currentPage < _totalPages)
            {
                _currentPage++;
                currentPageTextBox.Text = $"{_currentPage} / {_totalPages}";
                EvaluateButtons();

                if (_viewOnlyCurrentClients)
                {
                    clientDataGridView.DataSource = _clientRepository.FetchCurrentClients(_currentPage, _pageSize);
                }
                else if (_viewOnlyPastClients)
                {
                    clientDataGridView.DataSource = _clientRepository.FetchPastClients(_currentPage, _pageSize);
                }
                else
                {
                    clientDataGridView.DataSource = _clientRepository.FetchAllClients(_currentPage, _pageSize);
                }
            }
        }

        //astea doua nu pot deveni o singura functie??

        private void viewOnlyCurrentClientsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _currentPage = 1;
            _viewOnlyCurrentClients = true;
            _viewOnlyPastClients = false;
            _totalCount = _clientRepository.GetTotalCurrentClientsCount();
            _totalPages = Convert.ToInt32(Math.Ceiling((double)_totalCount / _pageSize));

            totalCountTextBox.Text = _totalCount.ToString();
            currentPageTextBox.Text = $"{_currentPage} / {_totalPages}";

            EvaluateButtons();
            clientDataGridView.AutoGenerateColumns = true;
            clientDataGridView.DataSource = _clientRepository.FetchCurrentClients(_currentPage, _pageSize);
        }

        private void viewOnlyPastClientsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _currentPage = 1;
            _viewOnlyCurrentClients = false;
            _viewOnlyPastClients = true;
            _totalCount = _clientRepository.GetTotalPastClientsCount();
            _totalPages = Convert.ToInt32(Math.Ceiling((double)_totalCount / _pageSize));

            totalCountTextBox.Text = _totalCount.ToString();
            currentPageTextBox.Text = $"{_currentPage} / {_totalPages}";

            EvaluateButtons();
            clientDataGridView.AutoGenerateColumns = true;
            clientDataGridView.DataSource = _clientRepository.FetchPastClients(_currentPage, _pageSize);
        }

        private void addClientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var addClientForm = new AddClientForm();
            addClientForm.Owner = this;
            addClientForm.ShowDialog();
        }

        private void clientDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var grid = (DataGridView)sender;
            var columnName = grid.Columns[e.ColumnIndex].Name;
            var client = (Client)grid.Rows[e.RowIndex].DataBoundItem;
            if (columnName == "Delete")
            {
                ClientAbonamentRepository clientAbonamentRepository = new ClientAbonamentRepository();
                if (clientAbonamentRepository.ClientulAreAbonament(client.Id))
                {
                    MessageBox.Show("Acest client are un abonament. Intai trebuie dezabonat.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                var result = MessageBox.Show($"Esti sigur ca vrei sa stergi clientul {client.Id}?",
                    "Please confirm your action",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.OK)
                {
                    _clientRepository.DeleteClient(client);
                    RefreshDataGridView();
                }
            }
            if (columnName == "Edit")
            {
                var editClientForm = new EditClientForm(client);
                editClientForm.Owner = this;
                editClientForm.ShowDialog();
                RefreshDataGridView();
            }
        }
    }
}