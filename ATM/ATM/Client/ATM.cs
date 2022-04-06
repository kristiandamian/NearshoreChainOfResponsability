using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATM.Handlers;

namespace ATM.Client
{
    internal static class ATM
    {
        #region bills
        static Bill1000Handler Bill1000;
        static Bill500Handler Bill500;
        static Bill200Handler Bill200;
        static Bill100Handler Bill100;
        static Bill50Handler Bill50;
        #endregion
        internal static void SetupATM()
        {
            InitBills();
            CreateChain();
        }

        static void InitBills()
        {
            Bill1000 = new Bill1000Handler(10);
            Bill500 = new Bill500Handler(5);
            Bill200 = new Bill200Handler(4);
            Bill100 = new Bill100Handler(10);
            Bill50 = new Bill50Handler(10);
        }
        private static void CreateChain()
        {
            Bill1000.NextLink(Bill500);
            Bill500.NextLink(Bill200);
            Bill200.NextLink(Bill100);
            Bill100.NextLink(Bill50);
        }

        internal static void Greeting() => Console.WriteLine($"Welcome the bank N {Environment.NewLine}Capture the quantity in multiples of 100{Environment.NewLine}");

        internal static bool ReadQuantity()
        {
            bool exit = false;
            decimal quantity;
            bool validQuantity = false;
            do
            {
                Console.Write("Quantity: ");
                var quantityStr = Console.ReadLine();
                if(quantityStr?.ToLower() == "exit") { 
                    exit = true;
                    break;
                }
                validQuantity = decimal.TryParse(quantityStr, out quantity);
                if(validQuantity)
                {
                    validQuantity = ValidQuantity(quantity);
                    if(validQuantity) { 
                        var RemainingAmount = Bill1000.GetNumberOfBills(quantity);
                        if(RemainingAmount > 0) 
                            Console.Write("****  Sorry we don't have enougt money ****");
                        Console.WriteLine($"{Environment.NewLine}");
                    }
                }
                
                if(!validQuantity)
                    Console.WriteLine("Invalid quantity");
            } while(!validQuantity);

            return exit;
        }

        static bool ValidQuantity(decimal quantity) => (quantity % 100) == 0;
    }
}
