using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Capstone.Classes
{
    public class FileAccess
    {
        public List<CateringItem> menu = new List<CateringItem>();
        // This class should contain any and all details of access to files

        public void ConvertInfoToList()
        {
            string sourceFile = "C:\\Users\\carters\\Team Exercises\\team1-c-sharp-week4-pair-exercises\\19_Mini-Capstone\\cateringsystem.csv";

            if (File.Exists(sourceFile))
            {
                using (StreamReader sr = new StreamReader(sourceFile))
                {
                    while (!sr.EndOfStream)
                    {

                        string line = sr.ReadLine();
                        string[] itemArray = line.Split("|");
                        CateringItem cateringItem = new CateringItem();
                        cateringItem.ItemCode = itemArray[0];
                        cateringItem.ItemName = itemArray[1];
                        cateringItem.ItemPrice = decimal.Parse(itemArray[2]);
                        cateringItem.ItemClass = itemArray[3];
                        menu.Add(cateringItem);
                    }
                }

            }

        }

        public void WriteAddMoney(int amount, Catering catering)
            
        {
            string sourceFile = "C:\\Users\\carters\\Team Exercises\\team1-c-sharp-week4-pair-exercises\\19_Mini-Capstone\\Log.txt";
            if (File.Exists(sourceFile))
            {
                using (StreamWriter sw = new StreamWriter(sourceFile))
                {
                    sw.Write(DateTime.Now + " ");
                    sw.Write("ADD MONEY: ");
                    sw.Write(amount + " ");
                    sw.WriteLine(catering.Balance + amount);

                }
            }
        }

        public void WriteReceipt(string desiredItem, int desiredQty, Catering catering)
        {
            foreach (CateringItem item in menu)
            {
                if (item.ItemCode == desiredItem)
                {
                    decimal totalCost = item.ItemPrice * desiredQty;

                    string sourceFile = "C:\\Users\\carters\\Team Exercises\\team1-c-sharp-week4-pair-exercises\\19_Mini-Capstone\\Log.txt";
                    if (File.Exists(sourceFile))
                    {
                        using (StreamWriter sw = new StreamWriter(sourceFile))
                        {
                            sw.Write(DateTime.Now + " ");
                            sw.Write(item.ItemQty + " ");
                            sw.Write(item.ItemName + " ");
                            sw.Write(item.ItemCode + " ");
                            sw.Write(totalCost + " ");
                            sw.WriteLine(catering.Balance - totalCost);

                        }
                    }
            }
            
            }
        }
    }
}










