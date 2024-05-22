using System;
using System.Windows.Forms;

namespace _2_1058_PISLARU_INGRID
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
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

        private void platiButton_Click(object sender, EventArgs e)
        {
            var platiForm = new PlatiForm();
            platiForm.ShowDialog();
        }

        private void pacheteActiveButton_Click(object sender, EventArgs e)
        {
            var pacheteActive=new ClientAbonamentForm();
            pacheteActive.ShowDialog();
        }
    }
}
