using Homework5_3.Classes;
using Homework5_3.Enums;
using Homework5_3.Exceptions;
using Homework5_3.Account_Management;

namespace Homework5_3.Account_Management
{
    internal class BankAccountService : IBankAccountService
    {
        private AccountStorageService _accountStorageService;
        public BankAccountService(AccountStorageService accountStorageService)
        {
            _accountStorageService = accountStorageService;
        }

        public void DepositMoney(int accountId, decimal amount)
        {

            if (amount <= 0)
            {
                throw new InvalidAmountException("Amount must be greater than 0");
            }

            BankAccount Account = _accountStorageService.FindAccount(accountId);
            if (Account != null)
            {
                Account.Deposit(amount);
            }
            else
            {
                throw new AccountNotFoundException("Account not found");
            }
        }

        //WithdrawMoney(int accountId, double amount)

        public void WithdrawMoney(int accountId, decimal amount)
        {
            if (amount <= 0)
            {
                throw new InvalidAmountException("Amount must be greater than 0");
            }

            BankAccount Account = _accountStorageService.FindAccount(accountId);
            if (Account != null)
            {
                Account.Withdraw(amount);
            }
            else
            {
                throw new AccountNotFoundException("Account not found");
            }
        }

        public List<BankAccount> GetAllAccounts()
        {
            return _accountStorageService.GetAllAccounts();
        }

        public void ListOfAccounts()
        {
            _accountStorageService.GetAllAccounts().ForEach(account =>
            {
                Console.WriteLine($"Account ID: {account.AccountId}");
                Console.WriteLine($"Account Balance: {account.Balance}");
                Console.WriteLine($"Account Type: {account.AccountType}");
                Console.WriteLine($"Account Currency Type: {account.CurrencyType}");
                Console.WriteLine();
            });
        }

        public void CreateAccount(AccountType accountType, CurrencyType currencyType)
        {
            BankAccount bankAccount = new BankAccount(accountType, currencyType);
            _accountStorageService.AddAccount(bankAccount);
        }
    }
}