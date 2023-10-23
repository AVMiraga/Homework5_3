namespace Homework5_3.Exceptions
{
    internal class AccountNotFoundException : Exception
    {
        //This exception is thrown when the account number entered by the user does not exist.
        public AccountNotFoundException(string message) : base(message)
        {
            
        }
    }
}
