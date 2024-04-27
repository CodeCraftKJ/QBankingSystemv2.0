using QBankingSystemv2._0.Classes.DatabaseManager;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace QBankingSystemv2._0.Forms
{
    public partial class ProfileAccountForm : Form
    {

        public ProfileAccountForm()
        {
            InitializeComponent();
        }

        private void ProfileForm_Load(object sender, EventArgs e)
        {
            textUserName.Text = CurrentUser.FirstName + " " + CurrentUser.LastName;
            textBoxUsername.Text = CurrentUser.Username;
            textMatrialStatus.Text = CurrentUser.MaterialStatus;
            textAddress.Text = CurrentUser.Address;
            textBirth.Text = CurrentUser.BirthDate;
            textEmail.Text = CurrentUser.Email;
            textPesel.Text = CurrentUser.Pesel;
            textPhone.Text = CurrentUser.Phone;
        }

        private void LoansBtn_Click(object sender, EventArgs e)
        {
            
        }

        private void TransfersBtn_Click(object sender, EventArgs e)
        {

        }

        private void CreateAccountBtn_Click(object sender, EventArgs e)
        {
            // Tworzenie formularza
            Form createAccountForm = new Form();
            createAccountForm.Text = "Create Account";
            createAccountForm.Size = new Size(300, 300);
            createAccountForm.BackColor = Color.White;

            // Dodawanie kontrolek do formularza
            Label accountNameLabel = new Label();
            accountNameLabel.Text = "Account Name:";
            accountNameLabel.Location = new Point(20, 20);
            createAccountForm.Controls.Add(accountNameLabel);

            TextBox accountNameTextBox = new TextBox();
            accountNameTextBox.Location = new Point(120, 20);
            createAccountForm.Controls.Add(accountNameTextBox);

            Label accountTypeLabel = new Label();
            accountTypeLabel.Text = "Account Type:";
            accountTypeLabel.Location = new Point(20, 50);
            createAccountForm.Controls.Add(accountTypeLabel);

            ComboBox accountTypeComboBox = new ComboBox();
            accountTypeComboBox.Location = new Point(120, 50);
            accountTypeComboBox.Items.Add("Savings Account");
            accountTypeComboBox.Items.Add("Checking Account");
            createAccountForm.Controls.Add(accountTypeComboBox);

            Label currencyLabel = new Label();
            currencyLabel.Text = "Currency:";
            currencyLabel.Location = new Point(20, 80);
            createAccountForm.Controls.Add(currencyLabel);

            ComboBox currencyComboBox = new ComboBox();
            currencyComboBox.Location = new Point(120, 80);
            currencyComboBox.Items.Add("USD");
            currencyComboBox.Items.Add("EUR");
            currencyComboBox.Items.Add("PLN");
            createAccountForm.Controls.Add(currencyComboBox);

            Label initialBalanceLabel = new Label();
            initialBalanceLabel.Text = "Initial Balance:";
            initialBalanceLabel.Location = new Point(20, 110);
            createAccountForm.Controls.Add(initialBalanceLabel);

            TextBox initialBalanceTextBox = new TextBox();
            initialBalanceTextBox.Location = new Point(120, 110);
            createAccountForm.Controls.Add(initialBalanceTextBox);

            Label depositLimitLabel = new Label();
            depositLimitLabel.Text = "Deposit Limit:";
            depositLimitLabel.Location = new Point(20, 140);
            createAccountForm.Controls.Add(depositLimitLabel);

            TextBox depositLimitTextBox = new TextBox();
            depositLimitTextBox.Location = new Point(120, 140);
            createAccountForm.Controls.Add(depositLimitTextBox);

            Label withdrawalLimitLabel = new Label();
            withdrawalLimitLabel.Text = "Withdrawal Limit:";
            withdrawalLimitLabel.Location = new Point(20, 170);
            createAccountForm.Controls.Add(withdrawalLimitLabel);

            TextBox withdrawalLimitTextBox = new TextBox();
            withdrawalLimitTextBox.Location = new Point(120, 170);
            createAccountForm.Controls.Add(withdrawalLimitTextBox);

            Label transferLimitLabel = new Label();
            transferLimitLabel.Text = "Transfer Limit:";
            transferLimitLabel.Location = new Point(20, 200);
            createAccountForm.Controls.Add(transferLimitLabel);

            TextBox transferLimitTextBox = new TextBox();
            transferLimitTextBox.Location = new Point(120, 200);
            createAccountForm.Controls.Add(transferLimitTextBox);

            Button createButton = new Button();
            createButton.Text = "Create";
            createButton.Location = new Point(120, 240);
            createButton.Click += (s, args) =>
            {
                string accountName = accountNameTextBox.Text;
                string accountType = accountTypeComboBox.SelectedItem.ToString();
                string currency = currencyComboBox.SelectedItem.ToString();
                decimal initialBalance = decimal.Parse(initialBalanceTextBox.Text);
                decimal depositLimit = decimal.Parse(depositLimitTextBox.Text);
                decimal withdrawalLimit = decimal.Parse(withdrawalLimitTextBox.Text);
                decimal transferLimit = decimal.Parse(transferLimitTextBox.Text);

                // Rejestracja konta bankowego w bazie danych
                int userID = CurrentUser.UserID;
                AccountRegistrationManager.RegisterAccount(accountName, accountType, currency, initialBalance,
                                                           depositLimit, withdrawalLimit, transferLimit, userID);

                MessageBox.Show("Account created successfully!");
                createAccountForm.Close(); // Zamknięcie formularza po utworzeniu konta
            };
            createAccountForm.Controls.Add(createButton);

            // Wyświetlenie formularza
            createAccountForm.ShowDialog();
        }




        private void LogOutBtn_Click(object sender, EventArgs e)
        {
            CurrentUser.Clear();
            WelcomeForm welcomeForm = new WelcomeForm();
            welcomeForm.Show();
            this.Close();
        }
    }
}
