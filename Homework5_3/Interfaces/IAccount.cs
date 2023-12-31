﻿namespace Homework5_3.Account_Management
{
    internal interface IAccount
    {
        int AccountId { get; set; }
        decimal Balance { get; set; }
        Enums.AccountType AccountType { get; set; }
        Enums.CurrencyType CurrencyType { get; set; }

        void Deposit(decimal amount);
        void Withdraw(decimal amount);
    }
}
