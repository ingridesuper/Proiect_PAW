using _2_1058_PISLARU_INGRID.Entities;
using _2_1058_PISLARU_INGRID.Repositories;
using _2_1058_PISLARU_INGRID.MainPageForms;
using System;
using System.Linq;
using System.Windows.Forms;

namespace _2_1058_PISLARU_INGRID.AddForms
{
    public partial class AddClientForm : Form
    {
        private ClientRepository _clientRepository;

        public AddClientForm()
        {
            InitializeComponent();
            _clientRepository = new ClientRepository();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void saveButton_Click(object sender, EventArgs e) //de adaugat vaidarile intr-un tip special
        {
            string nume = numeTextBox.Text;
            if (string.IsNullOrWhiteSpace(nume))
            {
                MessageBox.Show("Numele nu poate fi gol.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string email=emailTextBox.Text;
            if (string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("Emailul nu poate fi gol.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string telefon=telefonTextBox.Text;
            if (string.IsNullOrWhiteSpace(telefon))
            {
                MessageBox.Show("Telefonul nu poate fi gol.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!telefon.All(char.IsDigit))
            {
                MessageBox.Show("Numarul de telefon trebuie sa fie format doar din cifre.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int id = _clientRepository.GetNextAvailableID();
            _clientRepository.AddClient(new Client { Id = id, Nume = nume, Email=email, Telefon=telefon });
            var parentForm = (ClientiForm)this.Owner;
            parentForm.RefreshDataGridView();
            this.Close();
        }
    }
}
