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
    }
}
