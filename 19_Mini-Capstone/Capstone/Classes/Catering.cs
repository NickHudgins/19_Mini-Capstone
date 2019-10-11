using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class Catering
    {
        public decimal Balance { get; private set; } = 0;
        private List<CateringItem> items = new List<CateringItem>();

        //Methods
        public string AddMoneyEquation(int nums)
        {
            if (Balance + nums > 5000)
            {
                Console.Write("Your account balance cannot exceed $5000. Please enter a different amount to deposit. ");
                nums = int.Parse(Console.ReadLine());
            }
            else if (Balance + nums <= 5000)
            {
                Balance += nums; 
            }
            return $"You deposit was successful! You new balance is ${Balance}";
        }

        public string AddToShoppingCart(CateringItem item, int desiredQty)
        {
            FileAccess fileAccess = new FileAccess();
            if (fileAccess.ReadItemMenu(item) == true) 
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
            return "We currently do not have your desired amount of this product. Please enter in a different amount, or try to purchase a different item.";

        }
    }
}
