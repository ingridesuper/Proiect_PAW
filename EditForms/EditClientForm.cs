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
using _2_1058_PISLARU_INGRID.Repositories;

namespace _2_1058_PISLARU_INGRID.EditForms
{
    public partial class EditClientForm : Form
    {
        private Client _client; 
        private ClientRepository _clientRepository;
        public EditClientForm(Client client)
        {
            InitializeComponent();
            _clientRepository = new ClientRepository();
            _client = client;
            numeTextBox.Text = client.Nume;
            telefonTextBox.Text = client.Telefon;
            emailTextBox.Text = client.Email;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            string nume=numeTextBox.Text;
            if (string.IsNullOrWhiteSpace(nume))
            {
                MessageBox.Show("Numele nu poate fi gol.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string email = emailTextBox.Text;
            if (string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("Emailul nu poate fi gol.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string telefon = telefonTextBox.Text;
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

            _clientRepository.ModificaDateleClientului(_client.Id, nume, telefon, email);
            this.Close();
        }
    }
}
