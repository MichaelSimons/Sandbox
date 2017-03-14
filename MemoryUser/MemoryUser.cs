using System;
using System.Diagnostics;
using System.Collections.Generic;

namespace MemoryUser
{
    public static class MemoryUser
    {
        public static void Main(string[] args)
        {
            long targetMemoryUsage = long.Parse(args[0]);
            long currentMemoryUsage;
            List<string[]> arrays = new List<string[]>();

            while(true)
            {
                Process currentProcess = Process.GetCurrentProcess();
                currentMemoryUsage = currentProcess.WorkingSet64;
                Console.WriteLine($"Current Memory Usage:  {currentMemoryUsage}");

                if(currentMemoryUsage >= targetMemoryUsage)
                {
                    break;
                }

                Console.WriteLine("Consuming Memory...");
                string[] strArray = new string[100000];
                for (int i = 0; i < strArray.Length; i++)
                {
                    strArray[i] = $"{i}{DateTime.Now}";
                }
                arrays.Add(strArray);
            };

            Console.WriteLine("Press 'Enter' to exit");
            Console.ReadLine();
        }
    }
}
