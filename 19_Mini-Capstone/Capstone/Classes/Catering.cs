using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class Catering
    {
        public decimal Balance { get; private set; } = 0;
        List<CateringItem> items = new List<CateringItem>();
        List<CateringItem> shoppingCart = new List<CateringItem>();
        FileAccess fileAccess = new FileAccess();
       
        public void ConvertList()
        {
            fileAccess.ConvertInfoToList();
            items.AddRange(fileAccess.menu);
        }

        //CONSTRUCTOR
        public Catering()
        {
            ConvertList();
        }
  


        //Methods

        public string PrintItemMenu()
        {
            string itemCode = "Item Code: ".PadRight(10);
            string itemName = "Item Name: ".PadRight(25);
            string itemPrice = "Price: ".PadRight(15);
            string itemClass = "Class: ".PadRight(15);
            string itemQty = "Qty: ".PadRight(15);
            Console.WriteLine(itemCode + itemName + itemPrice + itemClass + itemQty);
            Console.WriteLine("----------------------------------------------------------------------");

            foreach (CateringItem listItem in items)
            {
                Console.Write(listItem.ItemCode.ToString().PadRight(10));
                Console.Write(listItem.ItemName.ToString().PadRight(25));
                Console.Write($"${listItem.ItemPrice}".ToString().PadRight(15));
                if (listItem.ItemClass == "A")
                {
                    Console.Write("Appetizer".PadRight(15));
                }
                if (listItem.ItemClass == "B")
                {
                    Console.Write("Beverage".PadRight(15));
                }
                if (listItem.ItemClass == "E")
                {
                    Console.Write("Entree".PadRight(15));
                }
                if (listItem.ItemClass == "D")
                {
                    Console.Write("Dessert".PadRight(15));
                }
                Console.WriteLine(listItem.ItemQty.ToString().PadRight(15));
            }
            return null;
        }


        public void AddMoneyEquation(int nums)
        {
            Balance += nums;
            return;
        }

        public void AddToShoppingCart(CateringItem item, int desiredQty)
        {
            foreach (CateringItem listItem in items)
            {
                if (listItem.ItemCode == item.ItemCode)
                {
                    shoppingCart.Add(item);
                    item.ItemQty -= desiredQty;
                }
            }
            
            return;
        }



    }
}

