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
using _2_1058_PISLARU_INGRID.Repositories;

namespace _2_1058_PISLARU_INGRID.EditForms
{
    public partial class EditPlataForm : Form
    {
        private Plata _plata;
        private PlatiRepository _platiRepository;
        public EditPlataForm(Plata plata)
        {
            InitializeComponent();
            _plata = plata;
            _platiRepository = new PlatiRepository();
            dueDateDateTimePicker.Value = plata.DueDate;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        public string GetStatut(DateTime dueDate) //pune astea in alte foldere
        {
            if (dueDate < DateTime.Today)
            {
                return "Restanta";
            }
            return "Upcoming";
        }

        //de schimbat si statutul!
        private void saveButton_Click(object sender, EventArgs e)
        {
            var dueDate = dueDateDateTimePicker.Value.Date;
            string statut=GetStatut(dueDate);
            _platiRepository.EditPlata(_plata.Id, dueDate, statut);
            this.Close();
        }
    }
}
