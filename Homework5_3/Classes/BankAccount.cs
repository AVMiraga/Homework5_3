using Homework5_3.Enums;
using Homework5_3.Exceptions;
using Homework5_3.Account_Management;

namespace Homework5_3.Classes
{
    internal class BankAccount : IAccount
    {
        private static int _nextAccountId = 1;
        public int AccountId { get; set; }
        public decimal Balance { get; set; }
        public AccountType AccountType { get; set; }
        public CurrencyType CurrencyType { get; set; }
        public List<Transaction> Transactions { get; set; }

        //Deposit(decimal amount) - DepositMoney method will be ran in Bank class and add a new transaction to the Transactions array with this method.
        public void Deposit(decimal amount)
        {

            Balance += amount;
            Transaction transaction = new Transaction
            {
                TransactionId = Transaction._nextTransactionId++,
                Amount = amount,
                TransactionDate = DateTime.Now,
                TransactionType = TransactionType.Deposit
            };
            Transactions.Add(transaction);
        }

        //Withdraw(decimal amount) - WithdrawMoney method will be ran in Bank class and add a new transaction to the Transactions array with this method.

        public void Withdraw(decimal amount)
        {
            Balance -= amount;
            Transaction transaction = new Transaction
            {
                TransactionId = Transaction._nextTransactionId++,
                Amount = amount,
                TransactionDate = DateTime.Now,
                TransactionType = TransactionType.Withdraw
            };
            Transactions.Add(transaction);
        }

        public BankAccount(AccountType accountType, CurrencyType currencyType)
        {
            AccountId = _nextAccountId++;
            Balance = 0;
            AccountType = accountType;
            CurrencyType = currencyType;
            Transactions = new List<Transaction>();
        }

    }
}
