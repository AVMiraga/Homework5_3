/*
    =====[ Welcome! ]=====
1. Create New Account
2. Deposit Money
3. Withdraw Money
4. List Of Transactions
5. List Of Accounts
6. Transfer Money Between Accounts
7. Currency Exchange
8. Exit
    ======================

Please select an option: <1-8>
 */

/*
    =====[ Create an Account ]=====
1. Choose Account Type - Default Account Type is Checking Account
2. Choose Currency Type - Default Currency Type is USD
3. Create Account
4. Exit
    ===============================
 */

/*
    =====[ Account Types ]=====
1. Checking Account
2. Savings Account
3. Business Account
    ===========================
*/

/*
    =====[ Currency Types ]=====
1. USD
2. EUR
3. AZN
    ===========================
*/


using Homework5_3.Classes;
using Homework5_3.Enums;
using Homework5_3.Exceptions;

namespace Homework5_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Bank bank = new Bank();
            Menu menu = new Menu();

            do
            {
                menu.ShowMenu();
                string option = Console.ReadLine();

                if (int.TryParse(option, out int result))
                {
                    switch (result)
                    {
                        case (int)Operation.CreateAccount:
                            CreateAccount(bank, AccountType.Checking, CurrencyType.USD);
                            break;

                        case (int)Operation.DepositMoney:
                            Console.Write("Please enter account id: ");
                            int accountId = int.Parse(Console.ReadLine());
                            Console.Write("Please enter amount: ");
                            decimal amount = decimal.Parse(Console.ReadLine());

                            try
                            {
                                bank.DepositMoney(accountId, amount);
                                Console.WriteLine("Money deposited successfully");
                            }
                            catch (InvalidAmountException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            catch (AccountNotFoundException ex)
                            {
                                Console.WriteLine(ex.Message);

                            }

                            break;
                        case (int)Operation.WithdrawMoney:
                            Console.Write("Please enter account id: ");
                            accountId = int.Parse(Console.ReadLine());
                            Console.Write("Please enter amount: ");
                            amount = decimal.Parse(Console.ReadLine());

                            //Use Try Catch block to handle exceptions

                            try
                            {
                                bank.WithdrawMoney(accountId, amount);
                            }
                            catch (InvalidAmountException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            catch (AccountNotFoundException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            catch (InsufficientFundsException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }

                            break;
                        case (int)Operation.ListTransactions:
                            Console.Write("Please enter account id: ");
                            accountId = int.Parse(Console.ReadLine());

                            try
                            {
                                bank.ListOfTransactions(accountId);
                            }
                            catch (AccountNotFoundException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            break;
                        case (int)Operation.ListAccounts:
                            bank.ListOfAccounts();
                            break;
                        case (int)Operation.TransferMoney:
                            Console.Write("Please enter sender account id: ");
                            int senderAccountId = int.Parse(Console.ReadLine());
                            Console.Write("Please enter receiver account id: ");
                            int receiverAccountId = int.Parse(Console.ReadLine());
                            Console.Write("Please enter amount: ");
                            amount = decimal.Parse(Console.ReadLine());

                            try
                            {
                                bank.TransferMoney(senderAccountId, receiverAccountId, amount);
                                Console.WriteLine("Money transferred successfully");
                            }
                            catch (AccountNotFoundException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            catch (InsufficientFundsException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            catch (InvalidAmountException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            break;
                        case (int)Operation.CurrencyConversion:
                            //CurrencyExchange(int accountId, CurrencyType currencyType)

                            Console.Write("Please enter account id: ");
                            accountId = int.Parse(Console.ReadLine());

                            Console.WriteLine("===== [ Currency Types ] =====");
                            Console.WriteLine("1. USD");
                            Console.WriteLine("2. EUR");
                            Console.WriteLine("3. AZN");
                            Console.WriteLine("==============================");

                            Console.Write("Please select an option: <1-3> ");
                            string currencyTypeOption = Console.ReadLine();

                            CurrencyType currencyType = CurrencyType.USD;

                            switch (currencyTypeOption)
                            {
                                case "1":
                                    currencyType = CurrencyType.USD;
                                    break;

                                case "2":
                                    currencyType = CurrencyType.EUR;
                                    break;

                                case "3":
                                    currencyType = CurrencyType.AZN;
                                    break;

                                default:
                                    Console.WriteLine("Invalid option");
                                    break;
                            }

                            try
                            {
                                bank.CurrencyExchange(accountId, currencyType);
                                Console.WriteLine("Currency exchanged successfully");
                            }
                            catch (AccountNotFoundException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            break;

                        default:
                            Console.WriteLine("Invalid option");
                            break;
                    }

                } 
            } while (true);
        }

        public static void CreateAccount(Bank bank, AccountType accountType, CurrencyType currencyType)
        {
            do
            {
                Console.WriteLine("===== [ Create an Account ] =====");
                Console.WriteLine("1. Choose Account Type - Default Account Type is Checking Account");
                Console.WriteLine("2. Choose Currency Type - Default Currency Type is USD");
                Console.WriteLine("3. Create Account");
                Console.WriteLine("4. Exit");
                Console.WriteLine("=================================");
                Console.WriteLine();
                Console.Write("Please select an option: <1-4> ");
                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        Console.WriteLine("=====[ Account Types ]=====");
                        Console.WriteLine("1. Checking Account");
                        Console.WriteLine("2. Savings Account");
                        Console.WriteLine("3. Business Account");
                        Console.WriteLine("============================");

                        Console.Write("Please select an option: <1-3> ");
                        string accountTypeOption = Console.ReadLine();

                        switch (accountTypeOption)
                        {
                            case "1":
                                accountType = AccountType.Checking;
                                break;

                            case "2":
                                accountType = AccountType.Savings;
                                break;

                            case "3":
                                accountType = AccountType.Business;
                                break;

                            default:
                                Console.WriteLine("Invalid option");
                                break;
                        }
                        break;

                    case "2":
                        Console.WriteLine("===== [ Currency Types ] =====");
                        Console.WriteLine("1. USD");
                        Console.WriteLine("2. EUR");
                        Console.WriteLine("3. AZN");
                        Console.WriteLine("==============================");

                        Console.Write("Please select an option: <1-3> ");
                        string currencyTypeOption = Console.ReadLine();

                        switch (currencyTypeOption)
                        {
                            case "1":
                                currencyType = CurrencyType.USD;
                                break;

                            case "2":
                                currencyType = CurrencyType.EUR;
                                break;

                            case "3":
                                currencyType = CurrencyType.AZN;
                                break;

                            default:
                                Console.WriteLine("Invalid option");
                                break;
                        }
                        break;

                    case "3":
                        bank.CreateAccount(accountType, currencyType);
                        Console.WriteLine("Account created successfully");
                        return;

                    case "4":
                        return;

                    default:
                        Console.WriteLine("Invalid option");
                        break;
                }

            } while (true);
        }
    }
}