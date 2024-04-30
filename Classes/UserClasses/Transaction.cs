using System;

namespace QBankingSystemv2._0.Classes.Transactions
{
    public class Transaction
    {
        public string TransactionID { get; private set; }
        public string SourceAccountID { get; private set; }
        public string DestinationAccountID { get; private set; }
        public string TransactionType { get; private set; }
        public decimal Amount { get; private set; }
        public DateTime TransactionDate { get; private set; }
        public string Description { get; private set; }

        public Transaction(string sourceAccountID, string destinationAccountID, string transactionType, decimal amount, string description)
        {
            TransactionID = GenerateTransactionID();
            SourceAccountID = sourceAccountID;
            DestinationAccountID = destinationAccountID;
            TransactionType = transactionType;
            Amount = amount;
            TransactionDate = DateTime.Now;
            Description = description;
        }

        private string GenerateTransactionID()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
