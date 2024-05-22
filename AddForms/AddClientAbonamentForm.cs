using _2_1058_PISLARU_INGRID.Repositories;
using _2_1058_PISLARU_INGRID.Entities;
using System;
using System.Windows.Forms;

namespace _2_1058_PISLARU_INGRID.AddForms
{
    public partial class AddClientAbonamentForm : Form
    {
        private ClientAbonamentRepository _clientAbonamentRepository;
        public AddClientAbonamentForm()
        {
            InitializeComponent();
            _clientAbonamentRepository = new ClientAbonamentRepository();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void saveButton_Click(object sender, EventArgs e) //maybe de adaugat toate validarile intr-un singur loc si pur si simplu sa fie runvalidari(int, double etc)
        {
            int clientId, abonamentId;
            double? discount = null;  
            var dataStart = dataStartDateTimePicker.Value.Date;

            if (!int.TryParse(clientIdTextBox.Text, out clientId))
            {
                MessageBox.Show("Id-ul clientului trebuie sa fie un numar intreg!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;  
            }

            if (!int.TryParse(tipAbonamentIdTextBox.Text, out abonamentId))
            {
                MessageBox.Show("Id-ul abonamentului trebuie sa fie un numar intreg!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;  // Adaugă return pentru a opri execuția dacă există o eroare
            }
            ClientRepository clientRepository = new ClientRepository();

            if (!clientRepository.ClientExists(clientId))
            {
                MessageBox.Show("Acest client nu exista.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            TipAbonamentRepository tipAbonamentRepository= new TipAbonamentRepository();

            if (!tipAbonamentRepository.TipAbonamentExists(abonamentId))
            {
                MessageBox.Show("Acest tip de abonament nu exista.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_clientAbonamentRepository.ClientTipAbonamentExists(clientId, abonamentId))
            {
                MessageBox.Show("Acest client deja are acest tip de abonament!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (string.IsNullOrEmpty(discountTextBox.Text)) //validari de date intr-un singur loc
            {
                discount = null;
            }
            else if (!double.TryParse(discountTextBox.Text, out double discount_nenul))
            {
                MessageBox.Show("Format invalid pentru discount", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; 
            }
            else
            {
                discount = discount_nenul;
            }

            _clientAbonamentRepository.AddClientTipAbonament(new ClientAbonament
            {
                ClientId = clientId,
                TipAbonamentId = abonamentId,
                Discount = discount,
                DataStart = dataStart,
            });
            var parentForm = (ClientAbonamentForm)this.Owner;
            parentForm.RefreshDataGridView();
            this.Close();
        }

    }
}
