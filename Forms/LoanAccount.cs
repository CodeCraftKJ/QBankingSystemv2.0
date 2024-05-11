using QBankingSystemv2._0.Classes.DatabaseManager;
using QBankingSystemv2._0.Classes.Transactions;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QBankingSystemv2._0.Forms
{
    public partial class LoanAccount : Form
    {
        private int userID;
        private int loanAmount;
        private int loanInterestRate;

        public LoanAccount()
        {
            InitializeComponent();
            this.userID = CurrentUser.UserID; // Ustawienie ID bieżącego użytkownika
            this.loanAmount = loanAmountTrackBar.Value; // Początkowa wartość kwoty pożyczki pobierana z suwaka
            this.loanInterestRate = loanInterestRateTrackBar.Value; // Początkowa wartość oprocentowania pobierana z suwaka
            UpdateLoanAmountLabel();
            UpdateLoanInterestRateLabel();
        }

        private void takeLoanButton_Click(object sender, EventArgs e)
        {
            // Tworzymy nowe konto pożyczkowe dla użytkownika
            CreateLoanAccount();

            // Pobierz adres konta, na które ma być przelana pożyczka, wpisany przez użytkownika
            string toAccount = toAccount1.Text;

            // Zaciągnij pożyczkę przez wykonanie transferu na konto pożyczkowe
            decimal loanAmount = loanAmountTrackBar.Value;
            decimal loanInterestRate = loanInterestRateTrackBar.Value;

            // Tutaj wywołaj metodę do wykonania transferu na konto pożyczkowe
            // Zakładam, że masz odpowiednią metodę w TransactionManager, która wykonuje transfer na konto docelowe
            // Wartość kwoty pożyczki zostanie przelana na konto pożyczkowe użytkownika
            TransactionManager.ExecuteTransaction(new Transaction(toAccount, "Loan Account", "Loan", loanAmount, "Loan taken"), CurrentUser.UserID);
        }

        private void repayLoanButton_Click(object sender, EventArgs e)
        {
            // Sprawdź, czy użytkownik ma konto pożyczkowe, jeśli nie, wyświetl komunikat
            if (!HasLoanAccount())
            {
                MessageBox.Show("You don't have a loan account.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private decimal GetRemainingBalance()
        {
            // Pobierz pozostałe saldo pożyczki z bazy danych
            string connectionString = ConfigurationManager.GetConnectionString();
            string query = "SELECT RemainingBalance FROM QPayLoans WHERE UserID = @UserID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@UserID", CurrentUser.UserID);
                connection.Open();
                return (decimal)command.ExecuteScalar();
            }
        }

        private void UpdateLoanAmountLabel()
        {
            loanAmountLabel.Text = $"Loan Amount: {loanAmount:C}";
        }

        private void UpdateLoanInterestRateLabel()
        {
            loanInterestRateLabel.Text = $"Interest Rate: {loanInterestRate}%";
        }

        private bool HasLoanAccount()
        {
            string connectionString = ConfigurationManager.GetConnectionString();
            string query = "SELECT COUNT(*) FROM QPayLoans WHERE UserID = @UserID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@UserID", userID);
                connection.Open();
                int count = (int)command.ExecuteScalar();
                return count > 0;
            }
        }

        private void CreateLoanAccount()
        {
            // Utwórz nowe konto pożyczkowe dla użytkownika
            string connectionString = ConfigurationManager.GetConnectionString();
            string insertQuery = "INSERT INTO QPayLoans (UserID, LoanAmount, InterestRate, RemainingBalance) VALUES (@UserID, @LoanAmount, @InterestRate, 0)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(insertQuery, connection);
                command.Parameters.AddWithValue("@UserID", userID);
                command.Parameters.AddWithValue("@LoanAmount", loanAmount);
                command.Parameters.AddWithValue("@InterestRate", loanInterestRate);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
