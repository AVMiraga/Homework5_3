namespace Homework5_3.Exceptions
{
    internal class InsufficientFundsException : Exception
    {
        //This exception is thrown when the user tries to withdraw more money than they have in their account.
        public InsufficientFundsException(string message) : base(message)
        {
            
        }
    }
}
