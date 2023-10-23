namespace Homework5_3.Exceptions
{
    internal class InvalidAmountException : Exception
    {
        //This exception is thrown when the user tries to deposit or withdraw an amount that is less than or equal to zero.
        public InvalidAmountException(string message) : base(message)
        {
            
        }
    }
}
