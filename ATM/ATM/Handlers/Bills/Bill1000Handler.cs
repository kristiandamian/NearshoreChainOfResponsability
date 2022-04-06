namespace ATM.Handlers
{
    internal class Bill1000Handler : BasicHandler
    {
        public override int BillSize { get; protected set; } = 1000;

        public Bill1000Handler(int inventory) : base(inventory)
        {
        }
    }
}
