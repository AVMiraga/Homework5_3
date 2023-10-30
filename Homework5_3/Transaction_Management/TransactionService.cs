using Homework5_3.Account_Management;
using Homework5_3.Classes;

namespace Homework5_3.Transaction_Management
{
    internal class TransactionService : ITransactionService
    {
        private AccountStorageService _accountStorageService;

        public TransactionService(AccountStorageService accountStorageService)
        {
            _accountStorageService = accountStorageService;
        }

        public void ListOfTransactions(int accountId)
        {
            _accountStorageService.FindAccount(accountId).Transactions.ForEach(transaction => Console.WriteLine(transaction));
        }
    }
}