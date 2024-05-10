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
            // Sprawdź, czy użytkownik ma już konto pożyczkowe, jeśli nie, utwórz je
            if (!HasLoanAccount())
            {
                CreateLoanAccount();
            }

            // Tutaj umieść kod na zaciągnięcie pożyczki z wykorzystaniem TransactionManager.ExecuteTransaction
        }

        private void repayLoanButton_Click(object sender, EventArgs e)
        {
            // Tutaj umieść kod na spłacenie pożyczki z wykorzystaniem TransactionManager.ExecuteTransaction
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
            // Sprawdź, czy użytkownik ma już konto pożyczkowe
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
