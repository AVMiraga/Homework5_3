using Homework5_3.Enums;
using Homework5_3.Account_Management;
using Homework5_3.Classes;

namespace Homework5_3.Currency_Management
{
    internal class CurrencyExchangeService : ICurrencyExchangeService
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
        private AccountStorageService _accountStorageService;

        public CurrencyExchangeService(AccountStorageService accountStorageService)
        {
            _accountStorageService = accountStorageService;
        }

        public void CurrencyConversion(int accountId, CurrencyType currencyType)
        {
            BankAccount account = _accountStorageService.FindAccount(accountId);
            account.CurrencyType = currencyType;
        }

        public void CurrencyExchange(int accountId, CurrencyType currencyType)
        {
            BankAccount account = _accountStorageService.FindAccount(accountId);

            if (CurrencyRates.TryGetValue((account.CurrencyType, currencyType), out decimal currencyRate))
            {
                account.Balance *= currencyRate;
                account.CurrencyType = currencyType;
            }
        }
    }
}