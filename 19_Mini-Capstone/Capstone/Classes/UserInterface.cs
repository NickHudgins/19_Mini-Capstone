using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{

    public class UserInterface
    {
        internal FileAccess FileAccess { get => fileAccess; set => fileAccess = value; }

        //**ALL USER INTERACTION HAPPENS HERE**
        // This class provides all user communications, but not much else.
        // All the "work" of the application should be done elsewhere
        // All instance of Console.ReadLine and Console.WriteLine should be in this class.

        private Catering catering = new Catering();
        public CateringItem cateringItem = new CateringItem();
        private FileAccess fileAccess = new FileAccess();

        public void RunInterface()
        {
            PrintMenu();
            string userInput = Console.ReadLine();
            while (userInput != "3")
            {
                switch (userInput)
                {
                    case "1":
                        FileAccess.PrintItemMenu();
                        Console.WriteLine();
                        Console.WriteLine("(1) Return To Main Menu");
                        string if1 = Console.ReadLine();
                        switch (if1)
                        {
                            case "1":
                                UserInterface userInterface = new UserInterface();
                                userInterface.RunInterface();
                                break;
                            default:
                                Console.WriteLine("This is not a valid answer. Please type '1' to return to main menu.");
                                return;
                        }
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

            Console.WriteLine("Your current balance is: " + catering.Balance);

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
            double currentBalance = 0;
            Console.WriteLine("Your current balance is " + currentBalance);
            Console.WriteLine();
        }

        public void AddMoney()
        {
            Console.WriteLine($"Current Balance: {catering.Balance}");
            Console.Write("Please enter amount to desposit: ");
            string amountDeposited = Console.ReadLine();

            int maxBalance = 5000;
            if (int.Parse(amountDeposited) + catering.Balance > maxBalance)
            {
                Console.WriteLine("Balance cannot exceed $5000");
            }
            if (int.Parse(amountDeposited) + catering.Balance <= maxBalance)
            {
                catering.AddMoneyEquation(int.Parse(amountDeposited));
            }
            Console.ReadLine();


            bool repeat = false;
            Console.WriteLine($"Current Balance: {catering.Balance}");
            Console.WriteLine("To return to the Main Menu, press the X key. " );
            string returnToMainMenu = Console.ReadLine();

            if (returnToMainMenu == "X" || returnToMainMenu == "x")
            {
                Console.Clear();
            }
            while (true)
            {
                Console.Clear();
                this.RunInterface();
                break;
            }
            return;
        }
        public void ProductSelection()
        {
            Console.WriteLine("Please enter the product code you'd like to add to your cart. ");
            string itemCodeEntered = Console.ReadLine();

            if (itemCodeEntered != cateringItem.ItemCode)
            {
                Console.WriteLine("Please enter a valid Item Code. ");
                itemCodeEntered = Console.ReadLine();
            }
            
            //FileAccess fileAccess = new FileAccess();
            //if (fileAccess.ReadItemMenu(itemCodeEntered) == true)
            //{
            //    if (item.ItemQty < desiredQty)
            //    {
            //        Console.WriteLine("There are currently Qty " + item.ItemQty + " of this product in stock. Please add a different item to the shopping cart.");
            //    }
            //    string messageOne = "You have successfully added ";
            //    string messageTwo = " of the ";
            //    string messageThree = " in your shopping cart.";

            //    return messageOne + desiredQty + messageTwo + item.ItemName + messageThree;
            }
        public void CompleteTrasaction()
        {
            Console.WriteLine("Thank you for your business! ");
            Console.ReadLine();
        }
    }
}

