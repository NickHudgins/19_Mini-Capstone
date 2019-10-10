using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Capstone.Classes
{
    public class CateringItem
    {
        // This class should contain the definition for one catering item

        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string ItemPrice { get; set; }
        public string ItemClass { get; set; }
        public int ItemQty { get; set; } = 50;


        public string PrintItemMenu()
        {
            string sourceFile = "C:\\Users\\carters\\Team Exercises\\team1-c-sharp-week4-pair-exercises\\19_Mini-Capstone\\cateringsystem.csv";
            if (File.Exists(sourceFile))
            {
                string code = "Code: ".PadRight(10);
                string item = "Item: ".PadRight(25);
                string price = "Price: ".PadRight(15);
                string itemClass = "Class: ".PadRight(15);
                string quantity = "Quantity: ".PadRight(15);
                Console.WriteLine(code + item + price + itemClass + quantity);
                Console.WriteLine("----------------------------------------------------------------------");
                using (StreamReader sr = new StreamReader(sourceFile))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        string[] itemArray = line.Split("|");
                        CateringItem cateringItem = new CateringItem();

                        cateringItem.ItemCode = itemArray[0];
                        cateringItem.ItemName = itemArray[1];
                        cateringItem.ItemPrice = itemArray[2];
                        cateringItem.ItemClass = itemArray[3];
                        cateringItem.ItemQty = 50;

                        Console.Write(cateringItem.ItemCode.PadRight(10));
                        Console.Write(cateringItem.ItemName.PadRight(25));
                        Console.Write($"${cateringItem.ItemPrice}".PadRight(15));
                        if (cateringItem.ItemClass == "A")
                        {
                            Console.Write("Appetizer".PadRight(15));
                        }
                        if (cateringItem.ItemClass == "B")
                        {
                            Console.Write("Beverage".PadRight(15));
                        }
                        if (cateringItem.ItemClass == "E")
                        {
                            Console.Write("Entree".PadRight(15));
                        }
                        if (cateringItem.ItemClass == "D")
                        {
                            Console.Write("Dessert".PadRight(15));
                        }
                        Console.WriteLine(cateringItem.ItemQty.ToString().PadRight(15));




                    }
                }
                Console.ReadLine();
            }
            return null;
        }

    }
}
