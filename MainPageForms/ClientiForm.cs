using _2_1058_PISLARU_INGRID.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _2_1058_PISLARU_INGRID.Entities;
using Oracle.ManagedDataAccess.Client;

namespace _2_1058_PISLARU_INGRID
{
    public partial class ClientiForm : Form
    {
        private int _totalCount;
        private int _currentPage = 1;
        private int _pageSize = 25;
        private int _totalPages;
        private bool _viewOnlyCurrentClients = false;
        private bool _viewOnlyPastClients = false;


        private ClientRepository _clientRepository;

        public ClientiForm()
        {
            InitializeComponent();

            _clientRepository = new ClientRepository();

            _totalCount = _clientRepository.GetTotalCount();
            _totalPages = Convert.ToInt32(Math.Ceiling((double)_totalCount / _pageSize));

            totalCountTextBox.Text = _totalCount.ToString();
            currentPageTextBox.Text = $"{_currentPage} / {_totalPages}";

            EvaluateButtons();

            clientDataGridView.AutoGenerateColumns = true;
            clientDataGridView.DataSource = _clientRepository.FetchAllClients(_currentPage, _pageSize);
            CreateButtonColumn("Delete", "Delete", "DeleteClient");
        }

        private void CreateButtonColumn(string headerText, string buttonText, string columnName)
        {
            DataGridViewButtonColumn column = new DataGridViewButtonColumn();
            column.HeaderText = headerText;
            column.Text = buttonText;
            //This means that all buttons in the column will have the same text
            column.UseColumnTextForButtonValue = true;
            column.Name = columnName;

            clientDataGridView.Columns.Add(column);
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

        
        //de comasat in constructor formului - adaugat apel la metoda asta
        private void viewAllClientsToolStripMenuItem_Click(object sender, EventArgs e)
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
            _viewOnlyPastClients= true;
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


        public bool ClientulAreAbonament(int clientId)
        {
            using (OracleConnection conn = new OracleConnection(Constants.ConnectionString))
            {
                conn.Open();
                string sql = "SELECT COUNT(*) FROM clientabonament WHERE clientid = :clientId";
                using (OracleCommand cmd = new OracleCommand(sql, conn))
                {
                    cmd.Parameters.Add("clientId", OracleDbType.Int32).Value = clientId;
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;
                }
            }
        }
        private void clientDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //It gets the name of the column that was clicked based on the ColumnIndex property
            //of the DataGridViewCellEventArgs. This allows us to determine which button column
            //was clicked.
            var grid = (DataGridView)sender;
            var columnName = grid.Columns[e.ColumnIndex].Name;

            // This line retrieves the Product object associated with the clicked row. It uses
            // the DataBoundItem property of the DataGridViewRow to get the underlying data object
            // bound to the row.
            var client = (Client)grid.Rows[e.RowIndex].DataBoundItem;

            if (columnName == "DeleteClient")
            {
                //de verificat ca nu apare in clientabonament
                if(ClientulAreAbonament(client.Id))
                {
                    MessageBox.Show("Acest client este asignat unui abonament si intai trebuie dezabonat.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error );
                    return;
                }
                var result = MessageBox.Show($"Are you sure you want to delete client {client.Id}?",
                    "Please confirm your action",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.OK)
                {
                    _clientRepository.DeleteClient(client);
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
