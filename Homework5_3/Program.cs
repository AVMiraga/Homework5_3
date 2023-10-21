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


using Homework5_3.Classes;

namespace Homework5_3
{
    internal class Program
    {
        static void Main(string[] args)
        {      
            Menu menu = new Menu();
            menu.ShowMenu();
        }
    }
}