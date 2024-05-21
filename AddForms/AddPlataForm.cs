using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _2_1058_PISLARU_INGRID.Repositories;
using _2_1058_PISLARU_INGRID.Entities;
using Oracle.ManagedDataAccess.Client;


namespace _2_1058_PISLARU_INGRID.AddForms
{
    public partial class AddPlataForm : Form
    {
        private PlatiRepository _plataRepository;
        public AddPlataForm()
        {
            InitializeComponent();
            _plataRepository = new PlatiRepository();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }


        private int GetNextAvailableID()
        {
            int newId = 0;

            using (OracleConnection conn = new OracleConnection(Constants.ConnectionString))
            {
                conn.Open();

                string sql = $"SELECT MAX(id) as max FROM plata";

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

        //alta idee - de adaugat 10% daca plata e restanta (dar tb sa dai update si la tabela sql)
        public int GetSuma(int clientId, int abonamentId)
        {
            int suma = 0; //nu o sa ajungem la 0 pt ca deja am verificat ca exista, dar sa nu tipe
            var sql = "select (1-nvl(discount, 0)/100)* pret as s from tipabonament join clientabonament on tipabonament.id=clientabonament.tipabonamentid where clientid=:clientId and tipabonamentid=:abonamentId";

            using (OracleConnection conn = new OracleConnection(Constants.ConnectionString))
            {
                conn.Open();

                using (OracleCommand cmd = new OracleCommand(sql, conn))
                {
                    // Adăugarea parametrilor pentru a preveni SQL injection
                    cmd.Parameters.Add(new OracleParameter("clientId", clientId));
                    cmd.Parameters.Add(new OracleParameter("abonamentId", abonamentId));

                    using (OracleDataReader dataReader = cmd.ExecuteReader())
                    {
                        if (dataReader.Read())
                        {
                            // Asigură-te că tratezi corect valoarea null
                            if (!dataReader.IsDBNull(dataReader.GetOrdinal("s")))
                            {
                                suma = Convert.ToInt32(dataReader["s"]);
                            }
                        }
                    }
                }
            }

            return suma;
        }


        public string GetStatut(DateTime dueDate)
        {
            if (dueDate < DateTime.Today)
            {
                return "Restanta";
            }
            return "Upcoming";
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            int clientId;
            int abonamentId;
            var dueDate = dueDateDateTimePicker.Value.Date;
            if (string.IsNullOrEmpty(clientIdTextBox.Text) || string.IsNullOrEmpty(tipAbonamentIdTextBox.Text))
            {
                MessageBox.Show("Trebuie sa introduceti un id si un tip de abonament!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(clientIdTextBox.Text, out clientId))
            {
                MessageBox.Show("Id-ul clientului trebuie sa fie un numar intreg.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(tipAbonamentIdTextBox.Text, out abonamentId))
            {
                MessageBox.Show("Id-ul clientului trebuie sa fie un numar intreg.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //de adaugat si cazurile in care clientul si abonamentul nu exista, dar ca functionalitate merge si asa

            if (!_plataRepository.ClientulAreAbonamentul(clientId, abonamentId))
            {
                MessageBox.Show("Acest client nu are acest abonament, deci nu putem cere plata.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int id = GetNextAvailableID();

            _plataRepository.AddPlata(new Plata
            {
                Id = id,
                ClientId = clientId,
                TipAbonamentId = abonamentId,
                DueDate = dueDate,
                Suma = GetSuma(clientId, abonamentId),
                Statut =GetStatut(dueDate)
                });
            //refresh baza
            var parentForm = (PlatiForm)this.Owner;
            parentForm.RefreshDataGridView();
            this.Close();
        }
    }
}
