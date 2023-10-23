using Homework5_3.Enums;
using Homework5_3.Exceptions;
using Homework5_3.Interface;

namespace Homework5_3.Classes
{
    internal class BankAccount : IAccount
    {
        private static int _nextAccountId = 1;
        public int AccountId { get; set; }
        public decimal Balance { get; set; }
        public AccountType AccountType { get; set; }
        public CurrencyType CurrencyType { get; set; }
        public Transaction[] Transactions { get; set; }

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
            Transaction[] tempTransactions = new Transaction[Transactions.Length + 1];
            for (int i = 0; i < Transactions.Length; i++)
            {
                tempTransactions[i] = Transactions[i];
            }

            tempTransactions[tempTransactions.Length - 1] = transaction;
            Transactions = tempTransactions;
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
            Transaction[] tempTransactions = new Transaction[Transactions.Length + 1];
            for (int i = 0; i < Transactions.Length; i++)
            {
                tempTransactions[i] = Transactions[i];
            }

            tempTransactions[tempTransactions.Length - 1] = transaction;
            Transactions = tempTransactions;
        }

        public BankAccount(AccountType accountType, CurrencyType currencyType)
        {
            AccountId = _nextAccountId++;
            Balance = 0;
            AccountType = accountType;
            CurrencyType = currencyType;
            Transactions = new Transaction[0];
        }

    }
}
