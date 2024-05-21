﻿using _2_1058_PISLARU_INGRID.Repositories;
using _2_1058_PISLARU_INGRID.AddForms;
using _2_1058_PISLARU_INGRID.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace _2_1058_PISLARU_INGRID.AddForms
{
    public partial class AddClientAbonamentForm : Form
    {
        //de sters variabila asta
        //si de adaugat toate metodele care au treaba cu ea in alt folder
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

        private void saveButton_Click(object sender, EventArgs e)
        {
            int clientId, abonamentId;
            double? discount = null;  
            var dataStart = dataStartDateTimePicker.Value.Date;
            var dataEnd = dataEndDateTimePicker.Value.Date;

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

            if (!_clientAbonamentRepository.ClientExists(clientId))
            {
                MessageBox.Show("Acest client nu exista.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!_clientAbonamentRepository.TipAbonamentExists(abonamentId))
            {
                MessageBox.Show("Acest tip de abonament nu exista.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_clientAbonamentRepository.ClientTipAbonamentExists(clientId, abonamentId))
            {
                MessageBox.Show("Acest client deja are acest tip", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (dataStart > dataEnd)
            {
                MessageBox.Show("Data de inceput nu poate fi mai mare decat data de final!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

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

            _clientAbonamentRepository.AddClientTipAbonament(new ClientAbonament
            {
                ClientId = clientId,
                TipAbonamentId = abonamentId,
                Discount = discount,
                DataStart = dataStart,
                DataEnd = dataEnd
            });
            var parentForm = (ClientAbonamentForm)this.Owner;
            parentForm.RefreshDataGridView();
            // Închide formularul
            this.Close();
        }

    }
}