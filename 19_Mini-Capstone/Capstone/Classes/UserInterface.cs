using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class UserInterface
    {
        //**ALL USER INTERACTION HAPPENS HERE**
        // This class provides all user communications, but not much else.
        // All the "work" of the application should be done elsewhere
        // All instance of Console.ReadLine and Console.WriteLine should be in this class.

        private Catering catering = new Catering();

        public void RunInterface()
        {
            CateringItem cateringItem = new CateringItem();
            PrintMenu();
            string userInput = Console.ReadLine();
            while (userInput != "3")
            {
                    switch(userInput)
                {
                    case "1":
                        cateringItem.PrintItemMenu();
                        return;
                    case "2":
                        OrderingInterface();
                        break;
                    default:
                        Console.WriteLine();
                        Console.WriteLine("Please make a valid selection.");
                        Console.WriteLine();
                        return;
                }
            }

        }
        private void PrintMenu()
        {
            Console.WriteLine("(1) Display Catering Items");
            Console.WriteLine("(2) Order");
            Console.WriteLine("(3) Quit");

        }


        public void OrderingInterface()
        {
            Console.WriteLine("To add money: press 1 ");
            Console.WriteLine("To select products: press 2 ");
            Console.WriteLine("To complete transaction, press 3 ");
            Console.WriteLine("Your current balance is: ");

            string selection = Console.ReadLine();

            while (selection != "3")
            {
                switch (selection)
                {
                    case "1":
                        AddMoney();
                        break;

                    case "2":
                        ProductSelection();
                        break;

                    default:
                        Console.WriteLine("Please Enter Valid Selection. ");
                        break;
                }
            }
        }
        public void AddMoney()
        {
            Console.WriteLine("Please enter amount to desposit. ");
            string amountDeposited = Console.ReadLine();

            
        }
        public void ProductSelection()
        {
            Console.WriteLine("Please enter the product code you'd like to add to your cart. ");
            string itemCodeEntered = Console.ReadLine();
            CateringItem cateringItem = new CateringItem();

            while (itemCodeEntered != cateringItem.ItemCode)
            {
                Console.WriteLine("Please enter a valid Item Code. ");
                itemCodeEntered = Console.ReadLine();
            }
        }

    }
}

