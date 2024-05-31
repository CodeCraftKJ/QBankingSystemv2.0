using QBankingSystemv2._0.Models.Transfer.Transfer;
using System;
using System.Data.SqlClient;

namespace QBankingSystemv2._0.Models.Loan.Loan
{
    public static partial class LoanDatabaseManager
    {
        public static void TakeLoan(string toAccount, decimal loanAmount, decimal loanInterestRate, string currency)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.GetConnectionString()))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    int loanAccountID = CreateLoanAccount(connection, transaction, currency, loanAmount);
                    CreateNewLoan(connection, transaction, loanAccountID, loanAmount, loanInterestRate);
                    TransferManager.ExecuteTransaction(new Transfer.Transfer.Transfer(loanAccountID.ToString(), toAccount, "Loan", loanAmount, "Loan taken", DateTime.Now), userID);
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception("Failed to take loan: " + ex.Message);
                }
            }
        }
    }
}
