using Homework5_3.Classes;
using Homework5_3.Enums;

namespace Homework5_3.Account_Management
{
    internal interface IBankAccountService
    {
        void CreateAccount(AccountType accountType, CurrencyType currencyType);
        void DepositMoney(int accountId, decimal amount);
        void WithdrawMoney(int accountId, decimal amount);
        void ListOfAccounts();
        List<BankAccount> GetAllAccounts();
    }
}