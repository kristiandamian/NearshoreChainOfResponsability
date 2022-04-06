namespace ATM.Handlers
{
    internal interface IBasicHandler
    {
        decimal GetNumberOfBills(decimal amount);
        void NextLink(IBasicHandler? link);
    }
}
