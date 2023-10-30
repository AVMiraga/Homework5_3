using Homework5_3.Account_Management;
using Homework5_3.Classes;
using Homework5_3.Enums;
using Homework5_3.Exceptions;

namespace Homework5_3.Transfer_Management
{
    internal class TransferService : ITransferService
    {
        private static readonly Dictionary<(CurrencyType, CurrencyType), decimal> CurrencyRates = new Dictionary<(CurrencyType, CurrencyType), decimal>
        {
            { (CurrencyType.AZN, CurrencyType.USD), 0.59M },
            { (CurrencyType.USD, CurrencyType.AZN), 1.70M },
            { (CurrencyType.AZN, CurrencyType.EUR), 0.56M },
            { (CurrencyType.EUR, CurrencyType.AZN), 1.80M },
            { (CurrencyType.USD, CurrencyType.EUR), 0.94M },
            { (CurrencyType.EUR, CurrencyType.USD), 1.06M }
        };

        private AccountStorageService AccountStorageService;

        public TransferService(AccountStorageService accountStorageService)
        {
            AccountStorageService = accountStorageService;
        }

        public void Transfer(int accountId, int targetAccountId, decimal amount)
        {
            if (amount <= 0)
            {
                throw new InvalidAmountException("Amount must be greater than 0");
            }

            BankAccount account = AccountStorageService.FindAccount(accountId);
            BankAccount targetAccount = AccountStorageService.FindAccount(targetAccountId);

            if (account.Balance < amount)
            {
                throw new InsufficientFundsException("Insufficient funds");
            }

            if (account.CurrencyType != targetAccount.CurrencyType)
            {
                if (CurrencyRates.TryGetValue((account.CurrencyType, targetAccount.CurrencyType), out decimal currencyRate))
                {
                    amount *= currencyRate;
                }
            }

            account.Balance -= amount;
            targetAccount.Balance += amount;

            Transaction transaction = new Transaction
            {
                TransactionId = Transaction._nextTransactionId++,
                Amount = amount,
                TransactionDate = DateTime.Now,
                TransactionType = TransactionType.Transfer
            };

            account.Transactions.Add(transaction);
            targetAccount.Transactions.Add(transaction);
        }
    }
}