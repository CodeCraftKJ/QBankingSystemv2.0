using System;

namespace QBankingSystemv2._0.Models.Transfer.Transfer
{
    public class Transfer
    {
        public string TransactionID { get; private set; }
        public string SourceAccountID { get; private set; }
        public string DestinationAccountID { get; private set; }
        public string TransactionType { get; private set; }
        public decimal Amount { get; private set; }
        public DateTime TransactionDate { get; private set; }
        public string Description { get; private set; }

        public Transfer(string sourceAccountID, string destinationAccountID, string transactionType, decimal amount, string description, DateTime date)
        {
            TransactionID = GenerateTransactionID().ToString();
            SourceAccountID = sourceAccountID;
            DestinationAccountID = destinationAccountID;
            TransactionType = transactionType;
            Amount = amount;
            TransactionDate = date;
            Description = description;
        }

        private int GenerateTransactionID()
        {
            Random random = new Random();
            return random.Next();
        }
    }
}
