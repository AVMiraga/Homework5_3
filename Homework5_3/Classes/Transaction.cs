using Homework5_3.Enums;

namespace Homework5_3.Classes
{
    internal class Transaction
    {
        public int TransactionId { get; set; }
        public double Amount { get; set; }
        public DateTime TransactionDate { get; set; }
        public TransactionType TransactionType { get; set; }
    }
}
