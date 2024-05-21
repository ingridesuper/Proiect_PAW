using _2_1058_PISLARU_INGRID.Repositories;
using _2_1058_PISLARU_INGRID.AddForms;
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
    //STERGE COLOANA PT DATA END, CA TE INCURCA LA CLIENTI ACTUALI SAU FOSTI CLIENTI SI LA PLATI ETC
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
        }

        private void CreateButtonColumn(string headerText, string buttonText, string columnName)
        {
            DataGridViewButtonColumn column = new DataGridViewButtonColumn();
            column.HeaderText = headerText;
            column.Text = buttonText;
            //This means that all buttons in the column will have the same text
            column.UseColumnTextForButtonValue = true;
            column.Name = columnName;

            clientAbonamentDataGridView.Columns.Add(column);
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

            clientAbonamentDataGridView.DataSource = _clientAbonamentRepository.FetchAllClientAbonament(_currentPage, _pageSize);
        }

        private void nextPageButton_Click(object sender, EventArgs e)
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

        public void RefreshDataGridView()
        {
            _currentPage = 1;
            _totalCount = _clientAbonamentRepository.GetTotalCount();
            _totalPages = Convert.ToInt32(Math.Ceiling((double)_totalCount / _pageSize));

            totalCountTextBox.Text = _totalCount.ToString();
            currentPageTextBox.Text = $"{_currentPage} / {_totalPages}";

            EvaluateButtons();
            clientAbonamentDataGridView.DataSource = _clientAbonamentRepository.FetchAllClientAbonament(_currentPage, _pageSize);
        }

        private bool ClientulAreDeExecutatPlati(int clientId, int abonamentId)
        {
            using (OracleConnection conn = new OracleConnection(Constants.ConnectionString))
            {
                conn.Open();
                string sql = "SELECT COUNT(*) FROM plata WHERE clientid = :clientId and tipabonamentid=:tipabonament";
                using (OracleCommand cmd = new OracleCommand(sql, conn))
                {
                    cmd.Parameters.Add("clientId", OracleDbType.Int32).Value = clientId;
                    cmd.Parameters.Add("tipabonament", OracleDbType.Int32).Value = abonamentId;
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;
                }
            }
        }

        private void clientAbonamentDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //It gets the name of the column that was clicked based on the ColumnIndex property
            //of the DataGridViewCellEventArgs. This allows us to determine which button column
            //was clicked.
            var grid = (DataGridView)sender;
            var columnName = grid.Columns[e.ColumnIndex].Name;

            // This line retrieves the Product object associated with the clicked row. It uses
            // the DataBoundItem property of the DataGridViewRow to get the underlying data object
            // bound to the row.
            var clientAbonament = (ClientAbonament)grid.Rows[e.RowIndex].DataBoundItem;

            if (columnName == "Delete")
            {
                if(ClientulAreDeExecutatPlati(clientAbonament.ClientId, clientAbonament.TipAbonamentId))
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
            if (columnName == "EditColumn")
            {
                //edit
            }
        }
    }
}
