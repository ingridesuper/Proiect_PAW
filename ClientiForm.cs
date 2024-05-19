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

            clientTotalCountTextBox.Text = _totalCount.ToString();
            currentPageTextBox.Text = $"{_currentPage} / {_totalPages}";

            EvaluateButtons();

            clientDataGridView.AutoGenerateColumns = true;
            clientDataGridView.DataSource = _clientRepository.FetchAllClients(_currentPage, _pageSize);
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

        private void viewOnlyCurrentClientsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _currentPage = 1;
            _viewOnlyCurrentClients = true;
            _viewOnlyPastClients = false;
            _totalCount = _clientRepository.GetTotalCurrentClientsCount(); 
            _totalPages = Convert.ToInt32(Math.Ceiling((double)_totalCount / _pageSize));

            clientTotalCountTextBox.Text = _totalCount.ToString();
            currentPageTextBox.Text = $"{_currentPage} / {_totalPages}";

            EvaluateButtons();
            clientDataGridView.AutoGenerateColumns = true;
            clientDataGridView.DataSource = _clientRepository.FetchCurrentClients(_currentPage, _pageSize);
        }

        private void viewAllClientsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _currentPage = 1;
            _viewOnlyCurrentClients = false;
            _viewOnlyPastClients = false;
            _totalCount = _clientRepository.GetTotalCount();
            _totalPages = Convert.ToInt32(Math.Ceiling((double)_totalCount / _pageSize));

            clientTotalCountTextBox.Text = _totalCount.ToString();
            currentPageTextBox.Text = $"{_currentPage} / {_totalPages}";

            EvaluateButtons();
            clientDataGridView.AutoGenerateColumns = true;
            clientDataGridView.DataSource = _clientRepository.FetchAllClients(_currentPage, _pageSize);
        }

        private void viewOnlyPastClientsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _currentPage = 1;
            _viewOnlyCurrentClients = false;
            _viewOnlyPastClients= true;
            _totalCount = _clientRepository.GetTotalPastClientsCount();
            _totalPages = Convert.ToInt32(Math.Ceiling((double)_totalCount / _pageSize));

            clientTotalCountTextBox.Text = _totalCount.ToString();
            currentPageTextBox.Text = $"{_currentPage} / {_totalPages}";

            EvaluateButtons();
            clientDataGridView.AutoGenerateColumns = true;
            clientDataGridView.DataSource = _clientRepository.FetchPastClients(_currentPage, _pageSize);
        }
    }
}
