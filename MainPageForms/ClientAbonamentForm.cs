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

namespace _2_1058_PISLARU_INGRID
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
    }
}
