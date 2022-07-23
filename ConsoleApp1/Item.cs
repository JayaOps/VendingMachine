using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachineProject
{
    public class Item
    {
        public string name;
        public decimal price;
        public int quantityToVend;

        public Item(string itemName, decimal itemPrice)
        {
            name = itemName;
            price = itemPrice;
        }
    }
    public class Coin
    {
        public string name;
        public string price;
        public int quantityToVend;

        public Coin(string CoinName, string Quantity)
        {
            name = CoinName;
            price = Quantity;
        }
    }
}
