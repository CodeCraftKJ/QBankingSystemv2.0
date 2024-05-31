using System;

namespace QBankingSystemv2._0.Models.Account.Account
{
    public interface IAccount
    {
        string AccountName { get; }
        string AccountID { get; }
        string AccountType { get; }
        string Currency { get; }
        decimal Balance { get; }
        decimal DepositLimit { get; }
        decimal WithdrawalLimit { get; }
        decimal TransferLimit { get; }
        DateTime CreatedAt { get; }
        string Status { get; }

        void Deposit(decimal amount);
        void Withdraw(decimal amount);
        void Transfer(decimal amount, string recipientAccountID);
    }
}
