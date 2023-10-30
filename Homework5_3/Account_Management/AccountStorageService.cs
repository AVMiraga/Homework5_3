using Homework5_3.Classes;
using Homework5_3.Exceptions;

namespace Homework5_3.Account_Management
{
    internal class AccountStorageService
    {
        private List<BankAccount> BankAccounts = new List<BankAccount>();

        public void AddAccount(BankAccount bankAccount)
        {
            BankAccounts.Add(bankAccount);
        }

        public BankAccount FindAccount(int accountId)
        {
            BankAccount? account = BankAccounts.Find(account => account.AccountId == accountId);
            if (account != null)
            {
                return account;
            }
            else
            {
                throw new AccountNotFoundException("Account not found");
            }
        }

        public List<BankAccount> GetAllAccounts()
        {
            return BankAccounts;
        }

    }
}