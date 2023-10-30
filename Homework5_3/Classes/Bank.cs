using Homework5_3.Account_Management;
using Homework5_3.Currency_Management;
using Homework5_3.Enums;
using Homework5_3.Exceptions;
using Homework5_3.Transaction_Management;
using Homework5_3.Transfer_Management;

namespace Homework5_3.Classes
{
    internal class Bank
    {

        private IBankAccountService _bankAccountService;
        private ITransactionService _transactionService;
        private ICurrencyExchangeService _currencyExchangeService;
        private ITransferService _transferService;

        public Bank(IBankAccountService bankAccountService, ITransactionService transactionService, ICurrencyExchangeService currencyExchangeService, ITransferService transferService)
        {
            _bankAccountService = bankAccountService;
            _transactionService = transactionService;
            _currencyExchangeService = currencyExchangeService;
            _transferService = transferService;
        }

        public void CreateAccount(AccountType accountType, CurrencyType currencyType)
        {
            _bankAccountService.CreateAccount(accountType, currencyType);
        }

        public void DepositMoney(int accountId, decimal amount)
        {
            _bankAccountService.DepositMoney(accountId, amount);
        }

        public void WithdrawMoney(int accountId, decimal amount)
        {
            _bankAccountService.WithdrawMoney(accountId, amount);
        }

        public void ListOfAccounts()
        {
            _bankAccountService.ListOfAccounts();
        }

        public void GetAllAccounts()
        {
            _bankAccountService.GetAllAccounts();
        }

        public void TransferMoney(int senderAccountId, int receiverAccountId, decimal amount)
        {
            _transferService.Transfer(senderAccountId, receiverAccountId, amount);
        }

        public void CurrencyExchange(int accountId, CurrencyType currencyType)
        {
            _currencyExchangeService.CurrencyExchange(accountId, currencyType);
        }

        public void CurrencyConversion(int accountId, CurrencyType currencyType)
        {
            _currencyExchangeService.CurrencyConversion(accountId, currencyType);
        }

        public void ListOfTransactions(int accountId)
        {
            _transactionService.ListOfTransactions(accountId);
        }
    }
}
