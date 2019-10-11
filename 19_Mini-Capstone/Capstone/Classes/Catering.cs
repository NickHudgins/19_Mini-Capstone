using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class Catering
    {
        // This class should contain all the "work" for catering

        private List<CateringItem> items = new List<CateringItem>();
        double balance = 0;

        private string filePath = @"C:\Catering";


        public string AddMoneyEquation(int nums)
        {
            if (balance + nums > 5000)
            {
                Console.WriteLine("Your account balance cannot exceed $5000. Please enter a different amount to deposit.");
            }
            balance += nums;
            string success = "You deposit was successful! You new balance is $";
            return success + balance + ".";
        }

        public string AddToShoppingCart(CateringItem item, int desiredQty)
        {
            string filepath =
            if (item.ItemCode == "a")
            {
                if (item.ItemQty < desiredQty)
                {
                    Console.WriteLine("There are currently Qty " + item.ItemQty + " of this product in stock. Please add a different item to the shopping cart.");
                }
                items.Add(item);
                item.ItemQty -= desiredQty;
                string messageOne = "You have successfully added ";
                string messageTwo = " of the ";
                string messageThree = " in your shopping cart.";

                return messageOne + desiredQty + messageTwo + item.ItemName + messageThree;
            }

        }
        public string OnScreenReport()
        {

            string code = "Total Qty: ".PadRight(10);
            string itemClass = "Class: ".PadRight(25);
            string item = "Item: ".PadRight(15);
            string individual = "Price Per Item: ".PadRight(15);
            string itemTotal = "Item Total Price: ".PadRight(15);
            string amountDue = "Your total amount due is: ";
            Console.WriteLine(code + itemClass + item + individual + item);
            Console.WriteLine("----------------------------------------------------------------------");

            Console.WriteLine(amountDue + "");
            

        }
    }
