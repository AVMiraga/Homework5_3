using Homework5_3.Enums;

namespace Homework5_3.Classes
{
    internal class Transaction
    {
        public static int _nextTransactionId;
        public int TransactionId { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }
        public TransactionType TransactionType { get; set; }

        public override string ToString()
        {
            return $"TransactionId: {TransactionId}, Amount: {Amount}, TransactionDate: {TransactionDate}, TransactionType: {TransactionType}";
        }
    }
}
