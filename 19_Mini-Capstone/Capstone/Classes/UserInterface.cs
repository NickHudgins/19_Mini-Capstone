﻿using System;
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
            bool done = false;
            while (!done)
            {
                Console.WriteLine("This is the UserInterface");
                Console.ReadLine();
            }

        }
    }
}