using QBankingSystemv2._0.Models.Account.AccountDB;
using System;
using System.Data.SqlClient;

namespace QBankingSystemv2._0.Models.Loan.Loan
{
    public static partial class LoanDatabaseManager
    {
        private static int userID;

        public static void Initialize(int currentUserID)
        {
            userID = currentUserID;
        }

        private static int CreateLoanAccount(SqlConnection connection, SqlTransaction transaction, string currency, decimal loanAmount)
        {
            try
            {
                int loanAccountID = AccountRegistrationManager.RegisterAccount("Loan Account", "Loan Account", currency, loanAmount, 999999, 999999, 999999, userID);
                return loanAccountID;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to create loan account: " + ex.Message);
            }
        }
    }
}
