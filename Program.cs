using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
  
namespace TextFileReader 
{  
    class Program 
    {  
        
        static void Main(string[] args)
        {  
            //Text File Location
            //Change file path as required (For this example I will simply use a Desktop folder)
            //When running change this filePath to the location of the src file
            string filePath = @"C:\Users\J_Zza\Desktop\src";
            var textFile = Directory.GetFiles(filePath, "*.txt");

            List<Program> list = new List<Program>();
            string[] lines;

            foreach (var item in textFile)
            {  
                // Read a text file line by line.
                lines = File.ReadAllLines(item);
                
                //Places all elements of a file into a Dictionary and returns the occurences of each Key Value
                Dictionary<string, int> listCount = new Dictionary<string,int>();
                
                foreach (string num in lines)
                    if (!listCount.ContainsKey(num))
                        listCount.Add(num, 1);
                    else
                        listCount[num]++;

                var s = String.Empty;
                var min = Int32.MaxValue;

                foreach (KeyValuePair<string, int> num in listCount) 
                {
                    //Check for minimum occurrence
                    if (num.Value < min)
                    {
                        s = num.Key;
                        min = num.Value;
                    }

                    //if 2 numbers have occurred the same number of times, return the lower of the two numbers
                    if (num.Value == min)
                    {
                        if (Int32.Parse(num.Key) < Int32.Parse(s))
                        {
                            s = num.Key;
                            min = num.Value;
                        }

                    }
                }

                Console.WriteLine();
                Console.WriteLine("File: " + item);
                Console.WriteLine("Number: " + s);
                Console.WriteLine("Repeated: " + min + " times");
                Console.WriteLine("===================");
            } 

            Console.ReadKey();  
        }  
    }  
} 