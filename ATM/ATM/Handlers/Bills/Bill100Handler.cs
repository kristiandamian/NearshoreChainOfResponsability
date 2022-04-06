namespace ATM.Handlers
{
    internal class Bill100Handler : BasicHandler
    {
        public override int BillSize { get; protected set; } = 100;

        public Bill100Handler(int inventory) : base(inventory)
        {
        }
    }
}
