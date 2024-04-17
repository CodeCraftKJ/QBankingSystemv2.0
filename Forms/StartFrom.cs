using QBankingSystemv2._0.Forms;
using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
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

            if (await TryDatabaseConnectionAsync())
            {
                OpenWelcomeForm();
            }
            else
            {
                MessageBox.Show("Failed to connect to the database. Please check your database connection settings.", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task<bool> TryDatabaseConnectionAsync()
        {
            string connectionString = ConfigurationManager.GetConnectionString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    await connection.OpenAsync();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
                finally
                {
                    await connection.CloseAsync();
                }
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

