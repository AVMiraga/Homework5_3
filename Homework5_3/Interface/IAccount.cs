using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework5_3.Interface
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
