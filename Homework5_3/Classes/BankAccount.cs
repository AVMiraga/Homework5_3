using Homework5_3.Enums;
using Homework5_3.Interface;

namespace Homework5_3.Classes
{
    internal class BankAccount : IAccount
    {
        public int AccountId { get; set; }
        public double Balance { get; set; }
        public AccountType AccountType { get; set; }
        public CurrencyType CurrencyType { get; set; }
        private Transaction[] Transactions { get; set; }

        //Add transactions to Transactions array
        public void Deposit(double amount)
        {

        }

        public void Withdraw(double amount)
        {

        }
    }
}
