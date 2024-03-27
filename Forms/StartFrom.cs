using QBankingSystemv2._0.Forms;
using System;
using System.Windows.Forms;

namespace QBankingSystemv2._0
{
    public partial class StartFrom : Form
    {
        public StartFrom()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyPress += new KeyPressEventHandler(StartForm_KeyPress);
        }

        private void StartForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13) // Sprawdza, czy wciśnięty klawisz to Enter
            {
                OpenWelcomeForm();
            }
        }

        private void OpenWelcomeForm()
        {
            WelcomeForm welcomeForm = new WelcomeForm();
            welcomeForm.Activated += (sender, e) => this.Hide();
            welcomeForm.ShowDialog();
        }
    }
}
