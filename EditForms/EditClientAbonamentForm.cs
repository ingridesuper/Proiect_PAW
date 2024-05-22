using _2_1058_PISLARU_INGRID.Entities;
using _2_1058_PISLARU_INGRID.Repositories;
using System;
using System.Windows.Forms;

namespace _2_1058_PISLARU_INGRID.EditForms
{
    public partial class EditClientAbonamentForm : Form
    {
        private ClientAbonament _clientAbonament;
        private ClientAbonamentRepository _clientAbonamentRepository;
        private PlatiRepository _platiRepository;
        public EditClientAbonamentForm(ClientAbonament clientAbonament)
        {
            InitializeComponent();
            _clientAbonament = clientAbonament;
            _clientAbonamentRepository=new ClientAbonamentRepository();
            _platiRepository = new PlatiRepository();
            discountTextBox.Text=_clientAbonament.Discount.ToString();
            dataStartDateTimePicker.Value= _clientAbonament.DataStart;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            double? discount = null;
            if (string.IsNullOrEmpty(discountTextBox.Text))
            {
                discount = null;
            }
            else if (!double.TryParse(discountTextBox.Text, out double discount_nenul))
            {
                MessageBox.Show("Format invalid pentru discount", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;  // Adaugă return pentru a opri execuția dacă există o eroare
            }
            else
            {
                discount = discount_nenul;
            }
            var dataStart = dataStartDateTimePicker.Value.Date;
            PlatiRepository platiRepository = new PlatiRepository();
            if(platiRepository.ClientulAreOPlataPtAbonamentulInainteDeDataDe(_clientAbonament, dataStart))
            {
                MessageBox.Show("Acest client are de efectuat plati pentru acest abonament, inainte de data introdusa!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (discount != _clientAbonament.Discount)
            {
                var option = MessageBox.Show($"Esti sigur ca vrei sa modifici discountul acestui client? Acest lucru va duce si la schimbarea sumei de platit.",
                    "Please confirm your action",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Warning);

                if (option == DialogResult.OK)
                {
                    _clientAbonamentRepository.EditClientAbonament(_clientAbonament.ClientId, _clientAbonament.TipAbonamentId, discount, dataStart);
                    _platiRepository.RecalculeazaSumaPentruDiscountSchimbat(_clientAbonament.ClientId, _clientAbonament.TipAbonamentId, discount);
                    this.Close();
                }
            }
            else
            {
                _clientAbonamentRepository.EditClientAbonament(_clientAbonament.ClientId, _clientAbonament.TipAbonamentId, discount, dataStart);
                this.Close();
            }
        }
    }
}
