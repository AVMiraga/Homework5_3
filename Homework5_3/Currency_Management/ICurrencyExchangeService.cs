using Homework5_3.Enums;

namespace Homework5_3.Currency_Management
{
    internal interface ICurrencyExchangeService
    {
        void CurrencyExchange(int accountId, CurrencyType currencyType);
        void CurrencyConversion(int accountId, CurrencyType currencyType);
    }
}