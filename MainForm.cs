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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void clientiButton_Click(object sender, EventArgs e)
        {
            var clientiForm = new ClientiForm();
            clientiForm.ShowDialog();
        }

        private void abonamenteButton_Click(object sender, EventArgs e)
        {
            var abonamenteForm = new AbonamenteForm();
            abonamenteForm.ShowDialog();
        }
    }
}
