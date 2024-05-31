using QBankingSystemv2._0.Configuration;
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
            this.Load += new EventHandler(StartForm_Load);
        }

        private async void StartForm_Load(object sender, EventArgs e)
        {
            if (await DatabaseHelper.IsDatabaseReadyAsync())
            {
                OpenWelcomeForm();
            }
            else
            {
                MessageBox.Show("The database is not ready. Please check your database connection settings or the structure of the database.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

