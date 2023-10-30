namespace Homework5_3.Transfer_Management
{
    internal interface ITransferService
    {
        void Transfer(int accountId, int targetAccountId, decimal amount);
    }
}