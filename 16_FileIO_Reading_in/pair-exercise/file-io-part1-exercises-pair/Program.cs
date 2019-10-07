using System;
using System.IO;


namespace file_io_part1_exercises_pair
{
    class FilesAndDirectories
    {
        static void Main(string[] args)
        {
            //string currentDirectory = Directory.GetCurrentDirectory();
            // bool directoryExists = Directory.Exists(currentDirectory);

            Console.WriteLine("Please enter the fully qualified path for file name");
            string filename = Console.ReadLine();
            //filename = Path.Combine(filename);


            if (!File.Exists(filename))
            {
                Console.WriteLine("This is not a valid qualified file name. Please enter a valid file name.");
            }

            if (File.Exists(filename))
            {
                
                
                int wordCount = 0;
                int sentenceCount = 0;
                try
                {
                    using (StreamReader sr = new StreamReader(filename))
                    {
                        
                        while (!sr.EndOfStream)
                        {

                            string line = sr.ReadLine();

                           // string stringfile = filename.ToString();
                            string[] lineArray = line.Split(" ");
                            foreach (string item in lineArray)
                            {
                                
                                //string stringItem = item.ToString();
                                wordCount++;
                                if (item.Length >= 1)
                                {
                                    if (item.Substring(item.Length - 1, 1) == "." || item.Substring(item.Length - 1, 1) == "!" || item.Substring(item.Length - 1, 1) == "?")
                                    {
                                        sentenceCount++;
                                    }
                                }


                            }

                        }
                    }


                }
                catch (IOException e)
                {
                    Console.WriteLine("Error reading the file");
                    Console.WriteLine(e.Message);
                }
                Console.WriteLine("There are " + wordCount + " words in this file.");
                Console.WriteLine("There are " + sentenceCount + " sentences in this file.");
            }
            Console.ReadLine();
        }
    }
}
