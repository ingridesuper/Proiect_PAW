using _2_1058_PISLARU_INGRID.Entities;
using _2_1058_PISLARU_INGRID.Repositories;
using Oracle.ManagedDataAccess.Client;
using System;

using System.Windows.Forms;

namespace _2_1058_PISLARU_INGRID
{
    public partial class AddTipAbonamentForm : Form
    {
        private TipAbonamentRepository _tipAbonamentRepository;

        public AddTipAbonamentForm()
        {
            InitializeComponent();
            _tipAbonamentRepository = new TipAbonamentRepository();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string nume = numeTextBox.Text;
            double pret;

            // Verifică dacă prețul este un număr valid
            if (!double.TryParse(pretTextBox.Text, out pret))
            {
                MessageBox.Show("Prețul introdus nu este valid.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Verifică dacă toate câmpurile sunt completate
            if (string.IsNullOrWhiteSpace(nume))
            {
                MessageBox.Show("Numele nu poate fi gol.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Verifică unicătatea ID-ului
            int id = GetNextAvailableID(); // Presupunând că ai o metodă care găsește următorul ID disponibil


            // Adaugă tipul de abonament în baza de date
            _tipAbonamentRepository.AddTipAbonament(new TipAbonament { Id = id, Nume = nume, Pret = pret });

            // Închide formularul
            this.Close();
        }

        // Metoda pentru a genera un ID disponibil
        private int GetNextAvailableID()
        {
            int newId = 0;

            using (OracleConnection conn = new OracleConnection(Constants.ConnectionString))
            {
                conn.Open();

                string sql = $"SELECT MAX(id) as max FROM tipabonament";

                using (OracleCommand cmd = new OracleCommand(sql, conn))
                {
                    OracleDataReader dataReader = cmd.ExecuteReader();
                    if (dataReader.Read())
                    {
                        // verifica daca sunt valori în tabel
                        if (dataReader["max"] != DBNull.Value)
                        {
                            newId = int.Parse(dataReader["max"].ToString()) + 1;
                        }
                        else
                        {
                            newId = 1;
                        }
                    }
                }
            }

            return newId;
        }


        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
