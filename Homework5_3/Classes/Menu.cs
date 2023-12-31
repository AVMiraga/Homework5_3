﻿/*
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

namespace Homework5_3.Classes
{
    internal class Menu
    {
        public void ShowMenu()
        {
            Console.WriteLine("===== [ Welcome! ] =====");
            Console.WriteLine("1. Create New Account");
            Console.WriteLine("2. Deposit Money");
            Console.WriteLine("3. Withdraw Money");
            Console.WriteLine("4. List Of Transactions");
            Console.WriteLine("5. List Of Accounts");
            Console.WriteLine("6. Transfer Money Between Accounts");
            Console.WriteLine("7. Currency Exchange");
            Console.WriteLine("8. Exit");
            Console.WriteLine("=======================");
            Console.WriteLine();
            Console.Write("Please select an option: <1-8> ");
        }
    }
}