using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Threading;

namespace MemoryUser
{
    public static class MemoryUser
    {
        public static void Main(string[] args)
        {
            long targetMemoryUsage = long.Parse(args[0]);
            long memoryUsageGrowthFactor = long.Parse(args[1]);
            bool consumeMemory = bool.Parse(args[2]);
            List<string[]> arrays = new List<string[]>();

            while (true)
            {
                Process currentProcess = Process.GetCurrentProcess();
                long currentMemoryUsage = currentProcess.WorkingSet64;
                Console.WriteLine($"Current Memory Usage:  {currentMemoryUsage}");

                if (currentMemoryUsage >= targetMemoryUsage)
                {
                    break;
                }

                Console.WriteLine("Consuming Memory...");
                string[] strArray = new string[memoryUsageGrowthFactor];
                for (int i = 0; i < strArray.Length; i++)
                {
                    strArray[i] = $"{i}{DateTime.Now}";
                }
                if (consumeMemory)
                {
                    arrays.Add(strArray);
                }
            };

            Thread.Sleep(60000);
        }
    }
}
