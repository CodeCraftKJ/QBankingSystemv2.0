using QBankingSystemv2._0.Forms;
using System;
using System.Data.SqlClient;
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

        private void StartForm_Load(object sender, EventArgs e)
        {
            if (TryDatabaseConnection())
            {
                OpenWelcomeForm();
            }
            else
            {
                MessageBox.Show("Failed to connect to the database. Please check your database connection settings.", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    private bool TryDatabaseConnection()
    {
        string connectionString = ConfigurationManager.GetConnectionString();

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error connecting to the database: " + ex.Message);
                return false;
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
