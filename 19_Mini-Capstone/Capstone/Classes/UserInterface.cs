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
                        catering.PrintItemMenu();
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
            List<CateringItem> list = new List<CateringItem>();
            list.AddRange(catering.items);
            Console.Write("Please enter the product code you'd like to add to your cart: ");

            string itemCodeEntered = Console.ReadLine();

           // if (fileAccess.ContentsTest(itemCodeEntered) == true)
            {
                Console.WriteLine("Please enter the quantity you would like to purchase today: ");
                int desiredQty = int.Parse(Console.ReadLine());
             //   if (desiredQty > cateringItem.) { }
            }
            



            string desiredItem = Console.ReadLine();
            foreach (CateringItem listItem in list)
            {
                if (listItem.ItemCode == desiredItem)
                {
                    Console.Write("Please enter the quantity you would like to purchase: ");
                    int desiredQty = int.Parse(Console.ReadLine());

                    if (listItem.ItemQty >= desiredQty)
                    {
                        catering.AddToShoppingCart(desiredItem, desiredQty);
                        Console.WriteLine($"You have successfully added {listItem.ItemName} (Qty {desiredQty}) to your cart.");
                        Console.WriteLine("(1) Return To Main Menu");
                        Console.WriteLine("(2) Add Another Item");
                        string userInput = Console.ReadLine();
                        switch(userInput)
                        {
                            case "1":
                                RunInterface();
                                break;
                            case "2":
                                ProductSelection();
                                break;
                            default:
                                {
                                    Console.WriteLine("This not a valid selection. Please type '1' or '2'.");
                                }
                                break;
                        }
                    }
                    else if (listItem.ItemQty < desiredQty) { Console.WriteLine($"There are only {listItem.ItemQty} of this product in stock. Please type in a different quantity."); }
                }
                else if (listItem.ItemCode == desiredItem) { Console.WriteLine("This is not a valid product code. Please type in a correct product code."); }
            }
        }


        public void CompleteTrasaction()
        {
            Console.WriteLine("Thank you for your business! ");
            Console.ReadLine();
        }
    }
}

