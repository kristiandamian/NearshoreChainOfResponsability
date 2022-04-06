namespace ATM.Handlers
{
    internal class Bill50Handler : BasicHandler
    {
         public override int BillSize { get; protected set; } = 50;

        public Bill50Handler(int inventory) : base(inventory)
        {
        }
    }
}
