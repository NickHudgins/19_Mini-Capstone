using System;
using System.IO;

namespace FindAndReplace
{
    class Program
    {
        static void Main(string[] args)
        {

            //Inputs
            Console.Write("Hello! What is the fully qualified name of the file would you like to search today? " );
            string sourceFile = Console.ReadLine();
            Console.WriteLine();
            if (!File.Exists(sourceFile))
            {
                Console.WriteLine("This is not a valid name. Please type in the fully qualified name of the desired file. " );
                sourceFile = Console.ReadLine();
            }
            if (File.Exists(sourceFile))
            {
                Console.Write("What phrase would you like to search? " );
                string searchPhrase = Console.ReadLine();
                Console.WriteLine();

                Console.Write("What would you like to replace this phrase with? " );
                string replacePhrase = Console.ReadLine();
                Console.WriteLine();

                Console.Write("What is the fully qualified name of the file would you like to copy the changed text into? " );
                string destinationFile = Console.ReadLine();
                Console.WriteLine();

                //Copying Over Source File --> Destination File w/Changes
                using (StreamReader sr = new StreamReader(sourceFile))
                {
                    using (StreamWriter sw = new StreamWriter(destinationFile, true))
                    {
                        while (!sr.EndOfStream)
                        {
                            string line = sr.ReadLine();
                            string fixedLine = line.Replace(searchPhrase, replacePhrase);
                            sw.Write(fixedLine);
                        }
                    }
                }
            }
            
            
            
        }


    }
}

