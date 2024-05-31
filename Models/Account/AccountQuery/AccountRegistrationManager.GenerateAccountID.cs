
using System;
using System.Text;

namespace QBankingSystemv2._0.Models.Account.AccountDB
{
    public static partial class AccountRegistrationManager
    {
        private static int GenerateAccountID(string accountType)
        {
            string prefix = GetAccountTypePrefix(accountType);
            string randomDigits = GenerateRandomDigits(8);

            string accountIDString = prefix + randomDigits;
            int accountID = int.Parse(accountIDString);

            return accountID;
        }

        private static string GenerateRandomDigits(int length)
        {
            Random random = new Random();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < length; i++)
            {
                sb.Append(random.Next(10).ToString());
            }
            return sb.ToString();
        }
    }
}
