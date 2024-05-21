using _2_1058_PISLARU_INGRID.Entities;
using _2_1058_PISLARU_INGRID.Repositories;
using Oracle.ManagedDataAccess.Client;
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
    public partial class AddClientForm : Form
    {
        private ClientRepository _clientRepository;

        public AddClientForm()
        {
            InitializeComponent();
            _clientRepository = new ClientRepository();
        }

        //de mutat metodele astea in repository
        private int GetNextAvailableID()
        {
            int newId = 0;

            using (OracleConnection conn = new OracleConnection(Constants.ConnectionString))
            {
                conn.Open();

                string sql = $"SELECT MAX(id) as max FROM client";

                using (OracleCommand cmd = new OracleCommand(sql, conn))
                {
                    OracleDataReader dataReader = cmd.ExecuteReader();
                    if (dataReader.Read())
                    {
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

        private void saveButton_Click(object sender, EventArgs e)
        {
            string nume = clientIdTextBox.Text;
            if (string.IsNullOrWhiteSpace(nume))
            {
                MessageBox.Show("Numele nu poate fi gol.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string email=tipAbonamentIdTextBox.Text;
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
            int id = GetNextAvailableID();

            _clientRepository.AddClient(new Client { Id = id, Nume = nume, Email=email, Telefon=telefon });
            var parentForm = (ClientiForm)this.Owner;
            parentForm.RefreshDataGridView();
            // Închide formularul
            this.Close();
        }
    }
}
