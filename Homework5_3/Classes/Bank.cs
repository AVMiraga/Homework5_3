using Homework5_3.Enums;
using Homework5_3.Exceptions;
using System.Security.Cryptography.X509Certificates;

namespace Homework5_3.Classes
{
    internal class Bank
    {
        private BankAccount[] BankAccounts;

        //Constructor

        public Bank()
        {
            BankAccounts = new BankAccount[0];
        }

        //Methods
        //CreateAccount(AccountType accountType, CurrencyType currencyType)
        
        public void CreateAccount(AccountType accountType, CurrencyType currencyType)
        {
            BankAccount bankAccount = new BankAccount(accountType, currencyType);
            BankAccount[] tempBankAccounts = new BankAccount[BankAccounts.Length + 1];
            for (int i = 0; i < BankAccounts.Length; i++)
            {
                tempBankAccounts[i] = BankAccounts[i];
            }

            tempBankAccounts[tempBankAccounts.Length - 1] = bankAccount;
            BankAccounts = tempBankAccounts;
        }

        //DepositMoney(int accountId, double amount)

        public void DepositMoney(int accountId, decimal amount)
        {

            if (amount <= 0)
            {
                throw new InvalidAmountException("Amount must be greater than 0");
            }

            bool AccountExists = false;

            for (int i = 0; i < BankAccounts.Length; i++)
            {
                if (BankAccounts[i].AccountId == accountId)
                {
                    AccountExists = true;
                    BankAccounts[i].Deposit(amount);
                }
            }

            if (!AccountExists)
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

            bool AccountExists = false;


            for (int i = 0; i < BankAccounts.Length; i++)
            {
                if (BankAccounts[i].AccountId == accountId)
                {
                    if (BankAccounts[i].Balance < amount)
                    {
                        throw new InsufficientFundsException("Insufficient funds");
                    }
                    AccountExists = true;
                    BankAccounts[i].Withdraw(amount);
                }
            }

            if (!AccountExists)
            {
                throw new AccountNotFoundException("Account not found");
            }


        }

        //ListOfTransactions(int accountId)
        public void ListOfTransactions(int accountId)
        {
            bool AccountExists = false;

            for (int i = 0; i < BankAccounts.Length; i++)
            {
                if (BankAccounts[i].AccountId == accountId)
                {
                    AccountExists = true;
                    for (int j = 0; j < BankAccounts[i].Transactions.Length; j++)
                    {
                        Console.WriteLine($"Transaction ID: {BankAccounts[i].Transactions[j].TransactionId}");
                        Console.WriteLine($"Transaction Amount: {BankAccounts[i].Transactions[j].Amount}");
                        Console.WriteLine($"Transaction Date: {BankAccounts[i].Transactions[j].TransactionDate}");
                        Console.WriteLine($"Transaction Type: {BankAccounts[i].Transactions[j].TransactionType}");
                        Console.WriteLine();
                    }
                }
            }

            if (!AccountExists)
            {
                throw new AccountNotFoundException("Account not found");
            }
        }

        //ListOfAccounts()
        public void ListOfAccounts()
        {
            for (int i = 0; i < BankAccounts.Length; i++)
            {
                Console.WriteLine($"Account ID: {BankAccounts[i].AccountId}");
                Console.WriteLine($"Account Balance: {BankAccounts[i].Balance}");
                Console.WriteLine($"Account Type: {BankAccounts[i].AccountType}");
                Console.WriteLine($"Account Currency Type: {BankAccounts[i].CurrencyType}");
                Console.WriteLine();
            }
        }

        //CurrencyExchange(int accountId, CurrencyType currencyType)

        public void CurrencyExchange(int accountId, CurrencyType currencyType)
        {
            bool AccountExists = false;

            decimal CurrencyRate = 0;

            for (int i = 0; i < BankAccounts.Length; i++)
            {
                if (BankAccounts[i].AccountId == accountId)
                {
                    AccountExists = true;
                    if (BankAccounts[i].CurrencyType == CurrencyType.AZN && currencyType == CurrencyType.USD)
                    {
                        CurrencyRate = 0.59M;
                    }
                    else if (BankAccounts[i].CurrencyType == CurrencyType.AZN && currencyType == CurrencyType.EUR)
                    {
                        CurrencyRate = 0.56M;
                    }
                    else if (BankAccounts[i].CurrencyType == CurrencyType.USD && currencyType == CurrencyType.AZN)
                    {
                        CurrencyRate = 1.7M;
                    }
                    else if (BankAccounts[i].CurrencyType == CurrencyType.USD && currencyType == CurrencyType.EUR)
                    {
                        CurrencyRate = 0.94M;
                    }
                    else if (BankAccounts[i].CurrencyType == CurrencyType.EUR && currencyType == CurrencyType.AZN)
                    {
                        CurrencyRate = 1.80M;
                    }
                    else if (BankAccounts[i].CurrencyType == CurrencyType.EUR && currencyType == CurrencyType.USD)
                    {
                        CurrencyRate = 1.06M;
                    }
                    BankAccounts[i].Balance *= CurrencyRate;
                    BankAccounts[i].CurrencyType = currencyType;
                }
            }


            if (!AccountExists)
            {
                throw new AccountNotFoundException("Account not found");
            }
        }

        //TransferMoney(int fromAccountId, int toAccountId, double amount) - Make sure to check for the account balance and throw an exception if there is not enough money. Also Check if CurrencyType is the same for both accounts if not do conversion.
        //Conversion rates: 1 USD = 1.7 AZN, 1 USD = 0.94 EUR, 1 EUR = 1.8 AZN, 1 EUR = 1.06 USD, 1 AZN = 0.59 USD, 1 AZN = 0.56 EUR

        public void TransferMoney(int fromAccountId, int toAccountId, decimal amount)
        {
            if (amount <= 0)
            {
                throw new InvalidAmountException("Amount must be greater than 0");
            }

            bool AccountExists = false;
            int Account1ID = 0;


            for (int i = 0; i < BankAccounts.Length; i++)
            {
                if (BankAccounts[i].AccountId == fromAccountId)
                {
                    Account1ID = i;
                    AccountExists = true;
                }
            }

            if (!AccountExists)
            {
                throw new AccountNotFoundException("Account not found");
            }

            AccountExists = false;
            int Account2ID = 0;

            for (int i = 0; i < BankAccounts.Length; i++)
            {
                if (BankAccounts[i].AccountId == toAccountId)
                {
                    Account2ID = i;
                    AccountExists = true;
                }
            }

            if (!AccountExists)
            {
                throw new AccountNotFoundException("Account not found");
            }

            if (BankAccounts[Account1ID].CurrencyType != BankAccounts[Account2ID].CurrencyType)
            {
                decimal CurrencyRate = 0;

                if (BankAccounts[Account1ID].CurrencyType == CurrencyType.AZN && BankAccounts[Account2ID].CurrencyType == CurrencyType.USD)
                {
                    CurrencyRate = 0.59M;
                }
                else if (BankAccounts[Account1ID].CurrencyType == CurrencyType.AZN && BankAccounts[Account2ID].CurrencyType == CurrencyType.EUR)
                {
                    CurrencyRate = 0.56M;
                }
                else if (BankAccounts[Account1ID].CurrencyType == CurrencyType.USD && BankAccounts[Account2ID].CurrencyType == CurrencyType.AZN)
                {
                    CurrencyRate = 1.7M;
                }
                else if (BankAccounts[Account1ID].CurrencyType == CurrencyType.USD && BankAccounts[Account2ID].CurrencyType == CurrencyType.EUR)
                {
                    CurrencyRate = 0.94M;
                }
                else if (BankAccounts[Account1ID].CurrencyType == CurrencyType.EUR && BankAccounts[Account2ID].CurrencyType == CurrencyType.AZN)
                {
                    CurrencyRate = 1.80M;
                }
                else if (BankAccounts[Account1ID].CurrencyType == CurrencyType.EUR && BankAccounts[Account2ID].CurrencyType == CurrencyType.USD)
                {
                    CurrencyRate = 1.06M;
                }

                amount *= CurrencyRate;
            }

            if (BankAccounts[Account1ID].Balance < amount)
            {
                throw new InsufficientFundsException("Insufficient funds");
            }

            BankAccounts[Account1ID].Balance -= amount;
            BankAccounts[Account2ID].Balance += amount;

        }

        //GetAllAccounts()

        public BankAccount[] GetAllAccounts()
        {
            return BankAccounts;
        }

        //CurrencyConversion(int accountId, CurrencyType currencyType)

        public void CurrencyConversion(int accountId, CurrencyType currencyType)
        {
            for (int i = 0; i < BankAccounts.Length; i++)
            {
                if (BankAccounts[i].AccountId == accountId)
                {
                    BankAccounts[i].CurrencyType = currencyType;
                }
            }
        }

    }
}
