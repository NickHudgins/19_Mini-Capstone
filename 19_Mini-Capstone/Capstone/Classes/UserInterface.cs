using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{

    public class UserInterface
    {
        //internal FileAccess FileAccess { get => fileAccess; set => fileAccess = value; }

        //**ALL USER INTERACTION HAPPENS HERE**
        // This class provides all user communications, but not much else.
        // All the "work" of the application should be done elsewhere
        // All instance of Console.ReadLine and Console.WriteLine should be in this class.

        private Catering catering = new Catering();
        //public CateringItem cateringItem = new CateringItem();
        public FileAccess fileAccess = new FileAccess();
     


        public void RunInterface()
        {
            
            MainMenu();
        }

        public void MainMenu()
        {
            Console.WriteLine();
            PrintMenu();
            Console.WriteLine();
            string userInput = Console.ReadLine();
            while (userInput != "3")
            {
                switch (userInput)
                {
                    case "1":
                        catering.PrintItemMenu();
                        Console.WriteLine();
                        Console.WriteLine("(1) Return To Main Menu ");
                        string if1 = Console.ReadLine();
                        switch (if1)
                        {
                            case "1":
                                MainMenu();
                                break;
                            default:
                                Console.WriteLine("This is not a valid answer. Please type '1' to return to main menu.");
                                return;
                        }
                        return;
                    case "2":
                        OrderingInterface();
                        break;
                    case "3":
                        Environment.Exit(0);
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
            Console.WriteLine();
            Console.WriteLine("(1) Add Money");
            Console.WriteLine("(2) Select Products");
            Console.WriteLine("(3) Complete Transaction");
            Console.WriteLine("Current Account Balance: $" + catering.Balance);
            Console.WriteLine();

            string selection = Console.ReadLine();
            switch (selection)
            {
                case "1":
                    AddMoney();
                    break;

                case "2":
                    ProductSelection();
                    break;
                case "3":
                    CompleteTransaction();
                    break;

                default:
                    Console.WriteLine("Please Enter Valid Selection. ");
                    break;
            }
            Console.WriteLine();

        }

        public void AddMoney()
        {
            int maxBalance = 5000;
            Console.WriteLine();
            Console.Write("Please enter amount to desposit: ");
            string amountDeposited = Console.ReadLine();
            if (int.Parse(amountDeposited) + catering.Balance > maxBalance)
            {
                Console.WriteLine("Your account balance cannot exceed $5000.");
            }
            if (int.Parse(amountDeposited) + catering.Balance <= maxBalance)
            {
                catering.AddMoneyEquation(int.Parse(amountDeposited));
                fileAccess.WriteAddMoney(int.Parse(amountDeposited), catering);
                Console.WriteLine($"The money was sucessfully deposited into you account. Your current balance is now ${catering.Balance}.");
            }
            Console.WriteLine();
            Console.WriteLine("(1) Return To Main Menu");
            Console.WriteLine("(2) Add More Money");
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    MainMenu();
                    break;
                case "2":
                    AddMoney();
                    break;
                default:
                    {
                        Console.WriteLine("This is not a valid answer. Please type in '1' or '2'.");
                    }
                    break;
            }

        }

        public void ProductSelection()
        {
            Console.WriteLine();
            Console.Write("Please enter the product code you'd like to add to your cart: ");
            string desiredItem = Console.ReadLine();
            foreach (CateringItem listItem in catering.fileAccess.menu)
            {
                if (listItem.ItemCode.ToLower() == desiredItem.ToLower())
                {
                    Console.Write("Please enter the quantity you would like to purchase: ");
                    int desiredQty = int.Parse(Console.ReadLine());
                    Console.WriteLine();
                    if (listItem.ItemQty != "SOLD OUT")
                    {
                        if (int.Parse(listItem.ItemQty) >= desiredQty)
                        {
                            catering.AddToShoppingCart(desiredItem, desiredQty);
                            fileAccess.WriteReceipt(desiredItem, desiredQty, catering);
                            Console.WriteLine($"You have successfully added {listItem.ItemName} (Qty {desiredQty}) to your cart.");
                            Console.WriteLine("(1) Return To Main Menu");
                            Console.WriteLine("(2) Add Another Item");
                            string userInput = Console.ReadLine();
                            switch (userInput)
                            {
                                case "1":
                                    MainMenu();
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
                        else if (int.Parse(listItem.ItemQty) < desiredQty)
                        {
                            Console.WriteLine("There is not enough of this product in stock to purchase.");
                            Console.WriteLine("(1) Return To Main Menu");
                            Console.WriteLine("(2) Add Another Item");
                            string userInput = Console.ReadLine();
                            switch (userInput)
                            {
                                case "1":
                                    MainMenu();
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
                    }
                    else { Console.WriteLine("This item is sold out.");
                        Console.WriteLine("(1) Return To Main Menu");
                        Console.WriteLine("(2) Add Another Item");
                        string userInput = Console.ReadLine();
                        switch (userInput)
                        {
                            case "1":
                                MainMenu();
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
                }

            }
        }


        public void CompleteTransaction()
        {
            catering.PrintReceipt();
            Console.WriteLine();
            Console.WriteLine("Are you sure you would like to make this purchase?");
            Console.WriteLine("(1) Yes");
            Console.WriteLine("(2) No");
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    if (catering.Balance < catering.total)
                    {
                        Console.WriteLine("You do not have sufficient funds. Please add more money to your account.");
                        Console.WriteLine("(1) Return To Main Menu");
                        Console.ReadLine();
                    }
                    else
                    {
                        catering.PurchaseConfirmation();
                        Console.WriteLine("Thank you for your business! ");
                    }
                    MainMenu(); 
                    break;
                case "2":
                    MainMenu();
                    break;
                default:
                    {
                        Console.WriteLine("That is not a valid answer. Please enter '1' or '2'.");
                    }
                    break;
            }
            Console.ReadLine();
        }

    }
}

