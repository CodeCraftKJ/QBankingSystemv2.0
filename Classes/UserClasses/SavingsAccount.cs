using QBankingSystemv2._0.Interfaces;
using System;

namespace QBankingSystemv2._0.Classes.Accounts
{
    public class SavingsAccount : IAccount
    {
        public string AccountName { get; private set; }
        public string AccountID { get; private set; }
        public string AccountType { get; private set; }
        public string Currency { get; private set; }
        public decimal Balance { get; private set; }
        public decimal DepositLimit { get; private set; }
        public decimal WithdrawalLimit { get; private set; }
        public decimal TransferLimit { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public string Status { get; private set; }

        public SavingsAccount(string accountName,string accountID, string currency, decimal balance, decimal depositLimit, decimal withdrawalLimit, decimal transferLimit)
        {
            AccountName = accountName;
            AccountID = accountID;
            AccountType = "Savings Account";
            Currency = currency;
            Balance = balance;
            DepositLimit = depositLimit;
            WithdrawalLimit = withdrawalLimit;
            TransferLimit = transferLimit;
            CreatedAt = DateTime.Now;
            Status = "Active";
        }

        public void Deposit(decimal amount)
        {
            Balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            if (amount <= WithdrawalLimit && amount <= Balance)
            {
                Balance -= amount;
            }
            else
            {
                throw new InvalidOperationException("Withdrawal amount exceeds limits or insufficient balance.");
            }
        }

        public void Transfer(decimal amount, string recipientAccountID)
        {
            if (amount <= TransferLimit && amount <= Balance)
            {
                Balance -= amount;
                // Logic to transfer amount to recipient account
            }
            else
            {
                throw new InvalidOperationException("Transfer amount exceeds limits or insufficient balance.");
            }
        }
    }
}
