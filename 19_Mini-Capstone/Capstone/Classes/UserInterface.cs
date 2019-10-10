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
    }
}
