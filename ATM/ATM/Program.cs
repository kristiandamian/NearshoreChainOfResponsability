ATM.Client.ATM.SetupATM();
ATM.Client.ATM.Greeting();
var exit = false;
do
{
    exit = ATM.Client.ATM.ReadQuantity();
} while(!exit);
