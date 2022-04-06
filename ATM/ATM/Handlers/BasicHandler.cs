using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Handlers
{
    internal class BasicHandler : IBasicHandler
    {
        protected int Inventory;
        protected IBasicHandler? NextElement;
        public virtual int BillSize { get; protected set; }

        public BasicHandler(int inventory)
        {
            Inventory = inventory;
        }


        public decimal GetNumberOfBills(decimal amount)
        {
             var numOfBills = AdjustInventory(Math.Floor(amount / BillSize));

            if (numOfBills > 0) {
                GiveMeMoney(numOfBills, BillSize);
                amount = amount - (BillSize * numOfBills);
            }
            if(NextElement != null) 
                return NextElement.GetNumberOfBills(amount);
            else
                return amount;
        }

        public void NextLink(IBasicHandler? link)
        {
            NextElement = link;
        }

        protected decimal AdjustInventory(decimal numOfBills)
        {
            if(Inventory == 0)
                return 0;

            decimal newNumOfBills = numOfBills;
            if(Inventory < numOfBills)
                newNumOfBills = Inventory;

            Inventory -= (int)newNumOfBills;

            return newNumOfBills;
        }

        protected void GiveMeMoney(decimal numOfBills, int BillSize)
        {
            Console.WriteLine($"{numOfBills} bill(s) of ${BillSize}");
        }
    }
}
