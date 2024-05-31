
namespace QBankingSystemv2._0.Models.Account.AccountDB
{
    public static partial class AccountRegistrationManager
    {
        private static string GetAccountTypePrefix(string accountType)
        {
            switch (accountType)
            {
                case "Savings Account":
                    return "1";
                case "Checking Account":
                    return "2";
                case "Loan Account":
                    return "9";
                default:
                    return "0";
            }
        }
    }
}
