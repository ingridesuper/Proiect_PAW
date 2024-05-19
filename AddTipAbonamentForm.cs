﻿using _2_1058_PISLARU_INGRID.Entities;
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

            int id = GetNextAvailableID(); 

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