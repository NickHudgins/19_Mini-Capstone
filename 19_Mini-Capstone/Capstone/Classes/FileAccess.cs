using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Capstone.Classes
{
    class FileAccess
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

<<<<<<< HEAD
        public bool ReadItemMenu(CateringItem item)
        {
            string sourceFile = "C:\\Users\\carters\\Team Exercises\\team1-c-sharp-week4-pair-exercises\\19_Mini-Capstone\\cateringsystem.csv";
            if (File.Exists(sourceFile))
            {
                using (StreamReader sr = new StreamReader(sourceFile))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        if (line.Contains(""))
                        {
                            return true;
                        }
                    }
                }
=======
>>>>>>> e6520bf3cd66d123f647ed7403bab21f7df8aee6


        }




    }
}










