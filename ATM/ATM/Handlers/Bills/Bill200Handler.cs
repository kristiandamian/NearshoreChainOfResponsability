namespace ATM.Handlers
{
    internal class Bill200Handler : BasicHandler
    {
        public override int BillSize { get; protected set; } = 200;

        public Bill200Handler(int inventory) : base(inventory)
        {
        }
    }
}
