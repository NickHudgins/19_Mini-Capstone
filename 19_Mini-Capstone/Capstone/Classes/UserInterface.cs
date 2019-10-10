using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class UserInterface
    {
        // This class provides all user communications, but not much else.
        // All the "work" of the application should be done elsewhere
        // All instance of Console.ReadLine and Console.WriteLine should be in this class.

        private Catering catering = new Catering();

        public void RunInterface()
        {
            Console.WriteLine("To display available Catering Items: press 1 ");
            Console.WriteLine("To Order: press 2 ");
            Console.WriteLine("To quit: press 3 ");

            string selection = Console.ReadLine();

            while (selection != "3")
            {
                switch (selection)
                {
                    case "1":
                        CateringItem();
                        break;

                    case "2":
                        Catering();
                        break;

                    default:
                        Console.WriteLine("Please Enter Valid Selection. ");
                        break;
                }

            }

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

            while
            {

            }

        }
        public void ProductSelection()
        {
            Console.WriteLine("Please enter the product code you'd like to add to your cart. ");
            string codeEntered = Console.ReadLine();


        }
    }
}

