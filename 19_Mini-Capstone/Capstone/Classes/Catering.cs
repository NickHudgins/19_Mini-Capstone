using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class Catering
    {
        public decimal Balance { get; private set; } = 0;
        public List<CateringItem> items = new List<CateringItem>();
        List<CateringItem> shoppingCart = new List<CateringItem>();
        Catering catering = new Catering();
        FileAccess fileAccess = new FileAccess();
        decimal total = 0;

        public void ConvertList()
        {
            fileAccess.ConvertInfoToList();
            items.AddRange(fileAccess.menu);
        }

        //CONSTRUCTOR
        static Catering()
        {
            catering.ConvertList();
        }
        public Catering()
        {

        }


        //Methods

        public List<CateringItem> ReturnItemsList()
        {
            return items;
        }


        public string PrintItemMenu()
        {
            Console.WriteLine();
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


        public void AddToShoppingCart(string desiredItem, int desiredQty)
        {
            foreach (CateringItem listItem in items)
            {
                if (listItem.ItemCode.ToLower() == desiredItem.ToLower())
                {
                    string currentQty = listItem.ItemQty;

                    listItem.ItemQty = desiredQty.ToString();
                    shoppingCart.Add(listItem);

                    listItem.ItemQty = currentQty;
                    int ItemQtyConvert = int.Parse(listItem.ItemQty);
                    ItemQtyConvert -= desiredQty;
                    if (ItemQtyConvert == 0)
                    {
                        listItem.ItemQty = "SOLD OUT";
                    }
                    else
                    {
                        listItem.ItemQty = ItemQtyConvert.ToString();                        
                    }
                    
                }
            }
        }

        public string PrintReceipt()
        {


            Console.WriteLine();
            string itemQty = "Qty: ".PadRight(10);
            string itemName = "Item Name: ".PadRight(25);
            string itemClass = "Class: ".PadRight(15);
            string itemPrice = "Price Per Item: ".PadRight(25);
            string itemTotal = "Total Price: ".PadRight(15);


            Console.WriteLine(itemQty + itemName + itemClass + itemPrice + itemTotal);
            Console.WriteLine("----------------------------------------------------------------------------------------");

            foreach (CateringItem listItem in shoppingCart)
            {
                decimal itemTotalPrice = listItem.ItemPrice * int.Parse(listItem.ItemQty);

                Console.Write(listItem.ItemQty.ToString().PadRight(10));
                Console.Write(listItem.ItemName.ToString().PadRight(25));
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
                Console.Write($"${listItem.ItemPrice}".ToString().PadRight(25));
                Console.WriteLine($"${itemTotalPrice}".ToString().PadRight(15));

                total += itemTotalPrice;
            }
            Console.WriteLine();
            Console.WriteLine($"Total: {total}");
            return null;
        }

        public void PurchaseConfirmation()
        {
            Balance -= total;
            total = 0;
            foreach (CateringItem item in shoppingCart)
            {
                shoppingCart.Remove(item);
            }
            ConvertList();
        }
    }
}











