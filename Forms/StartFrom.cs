using QBankingSystemv2._0.Configuration;
using QBankingSystemv2._0.Forms;
using System;
using System.IO;
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
            try
            {
                var (isReady, error) = await DatabaseHelper.IsDatabaseReadyAsync();
                if (isReady)
                {
                    OpenWelcomeForm();
                }
                else
                {
                    switch (error)
                    {
                        case DatabaseHelper.DatabaseError.ConnectionError:
                            MessageBox.Show("Cannot connect to the database. Please check your database connection settings.", "Database Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        case DatabaseHelper.DatabaseError.StructureError:
                            MessageBox.Show("The database does not meet the required structure. Please check the database structure.", "Database Structure Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        case DatabaseHelper.DatabaseError.IPPermissionError:
                            MessageBox.Show("The IP does not have permission to access the database. Please check your database permissions.", "IP Permission Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        case DatabaseHelper.DatabaseError.UnknownError:
                            MessageBox.Show("An unknown error occurred while connecting to the database.", "Unknown Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                    }
                }
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("The appsettings.json file was not found. Please ensure the configuration file is in the correct location.", "Configuration File Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

