using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachineProject
{
    public class Controller
    {
        PricingSystem moneyMachine = new PricingSystem();
        Printer printer = new Printer();
        static Item selectedItem;
        private const decimal acceptedCoins = 0.50m;
        private int userChoice = 0;

        //program entry point, starts item selection process.
        public void selectYourItem()
        {
            Printer.printHeader();
            if (handleUserInput())
            {
                checkSelectionInArray();
            }
            else
            {
                Console.WriteLine("Invalid Input");
                selectYourItem();
            }
        }

        public void selectYourCointype()
        {
            Printer.printcoinHeader();
            if (handleUserInput())
            {
                quantityCheck();
            }
            else
            {
                Console.WriteLine("Invalid Input");
                selectYourItem();
            }
        }
        //this method loops to allow the user to choose another item, exit the program or start paying
        public void mainMenu()
        {
            while (moneyMachine.transactionComplete == false)
            {
                Console.WriteLine(Environment.NewLine +
                " To choose another item: 1, or To cancel: 2");
                if (handleUserInput())
                {
                    selectionProcessing(userChoice);
                }
                else
                {
                    Console.WriteLine("Invalid Input");
                }
            }
        }

        //processes main menu selection
        private void selectionProcessing(int selection)
        {
            switch (selection)
            {
              
                case 1:
                    selectYourItem();
                    break;
                case 2:
                    Console.WriteLine("See you later!");
                    moneyMachine.transactionComplete = true;
                    break;
                default:
                    Console.WriteLine("You have made an invalid selection");
                    break;
            }
        }

        //checks that the item selected exists in the vending machine array
        private void checkSelectionInArray()
        {
            if (userChoice - 1 < Vendor.machine.Length && userChoice - 1 >= 0)
            {
                selectedItem = Vendor.machine[userChoice - 1];
                Console.WriteLine($"you have chosen {selectedItem.name}");
                selectYourCointype();
            }
            else
            {
                Console.WriteLine("the item number selected does not exist, please try again");
                selectYourItem();
            }
        }

        //checks the amount of an item required for purchase
        private void quantityCheck()
        {
            Console.WriteLine($"please select the amount of {selectedItem.name} you want? ");
            if (handleUserInput())
            {
                moneyMachine.totalAmount += selectedItem.price * userChoice;
                selectedItem.quantityToVend += userChoice;
                Console.WriteLine(Environment.NewLine +
                $"You have added {userChoice} {selectedItem.name} ||| Total: £{moneyMachine.totalAmount}");
            }
            else
            {
                Console.WriteLine("invalid selection");
                quantityCheck();
            }
        }

        //reads user input and attempts to convert it to and integer
        private Boolean handleUserInput()
        {
            return Int32.TryParse(Console.ReadLine(), out userChoice);
        }
    }
}
