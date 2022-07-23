using System;

namespace VendingMachineProject
{
    class Program
    {
        public static void Main(string[] args)
        {
            var vendingMachineRunner = new Controller();
            vendingMachineRunner.selectYourItem();
            vendingMachineRunner.mainMenu();
        }
    }
}