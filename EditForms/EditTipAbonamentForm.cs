using _2_1058_PISLARU_INGRID.Entities;
using System;
using System.Windows.Forms;
using _2_1058_PISLARU_INGRID.Repositories;

namespace _2_1058_PISLARU_INGRID.EditForms
{
    public partial class EditTipAbonamentForm : Form
    {
        private TipAbonament _tipAbonament;
        private TipAbonamentRepository _tipAbonamentRepository;
        public EditTipAbonamentForm(TipAbonament tipAbonament)
        {
            InitializeComponent();
            _tipAbonament= tipAbonament;
            _tipAbonamentRepository=new TipAbonamentRepository();
            numeTextBox.Text = tipAbonament.Nume;
            pretTextBox.Text=tipAbonament.Pret.ToString();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            string nume= numeTextBox.Text;
            if(string.IsNullOrEmpty(nume))
            {
                MessageBox.Show("Numele nu poate fi gol!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(string.IsNullOrEmpty(pretTextBox.Text))
            {
                MessageBox.Show("Pretul nu poate fi gol!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(!double.TryParse(pretTextBox.Text, out var result))
            {
                MessageBox.Show("Pretul trebuie sa fie un numar!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (result != _tipAbonament.Pret)
            {
                var option = MessageBox.Show($"Esti sigur ca vrei sa modifici suma abonamentului {_tipAbonament.Id}? Acest lucru va duce si la schimbarea sumei de platit.",
                    "Please confirm your action",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Warning);

                if (option == DialogResult.OK)
                {
                    _tipAbonamentRepository.EditTipAbonament(_tipAbonament.Id, nume, result);
                    PlatiRepository platiRepository = new PlatiRepository();
                    platiRepository.RecalculeazaSuma(_tipAbonament.Id, result);
                    this.Close();
                }
            }
            else
            {
                _tipAbonamentRepository.EditTipAbonament(_tipAbonament.Id, nume, result);
                this.Close();
            }
            
        }
    }
}
