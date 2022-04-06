namespace ATM.Handlers
{
    internal class Bill500Handler : BasicHandler
    {
         public override int BillSize { get; protected set; } = 500;

        public Bill500Handler(int inventory) : base(inventory)
        {
        }
    }
}
