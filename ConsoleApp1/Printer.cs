using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachineProject
{
    class Printer
    {
        public static string howToSelect = Environment.NewLine + "Please select a Product by typing the Product's Selection Number:" + Environment.NewLine;
        public static string header = "item name | item price | Selection Number" + Environment.NewLine;
        public static string headercoin = "coin name |  CoinRange | Selection Number" + Environment.NewLine;
        public static string purchasedItems = "item name | quantity" + Environment.NewLine;
        public static int length = Vendor.machine.Length;

        public static void printHeader()
        {
            for (int i = 0; i < length; i++)
            {
                header += $"{Vendor.machine[i].name} | £{Vendor.machine[i].price} | {i + 1}" + Environment.NewLine;
            }
            Console.WriteLine(howToSelect + header);
            header = "";
        }
        public static void printcoinHeader()
        {
            for (int i = 0; i < length; i++)
            {
                headercoin += $"{CoinType.cointype[i].name} | ${CoinType.cointype[i].price} | {i + 1}" + Environment.NewLine;
            }
            Console.WriteLine(howToSelect + headercoin);
            header = "";
        }
        public static void vendRequestedItems()
        {
            for (int i = 0; i < length; i++)
            {
                if (Vendor.machine[i].quantityToVend > 0)
                {
                    purchasedItems += $"{Vendor.machine[i].name} | {Vendor.machine[i].quantityToVend}" + Environment.NewLine;
                }
            }
            Console.WriteLine(purchasedItems);
        }
    }
}
