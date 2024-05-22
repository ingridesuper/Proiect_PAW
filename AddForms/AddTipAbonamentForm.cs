using _2_1058_PISLARU_INGRID.Entities;
using _2_1058_PISLARU_INGRID.Repositories;
using _2_1058_PISLARU_INGRID.MainPageForms;
using System;

using System.Windows.Forms;

namespace _2_1058_PISLARU_INGRID.AddForms
{
    public partial class AddTipAbonamentForm : Form
    {
        private TipAbonamentRepository _tipAbonamentRepository;

        public AddTipAbonamentForm()
        {
            InitializeComponent();
            _tipAbonamentRepository = new TipAbonamentRepository();
        }
       
        private void saveButton_Click(object sender, EventArgs e)
        {
            string nume = numeTextBox.Text;
            double pret;

            if (!double.TryParse(pretTextBox.Text, out pret))
            {
                MessageBox.Show("Prețul introdus nu este valid.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(nume))
            {
                MessageBox.Show("Numele nu poate fi gol.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int id = _tipAbonamentRepository.GetNextAvailableID(); 

            _tipAbonamentRepository.AddTipAbonament(new TipAbonament { Id = id, Nume = nume, Pret = pret });
            var parentForm = (AbonamenteForm)this.Owner;
            parentForm.RefreshDataGridView();
            // Închide formularul
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
