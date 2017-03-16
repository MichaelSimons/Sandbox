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
            long targetWorkingSet = long.Parse(args[0]);
            long growthFactor = long.Parse(args[1]);
            bool consumeMemory = bool.Parse(args[2]);
            List<string[]> heldRefs = new List<string[]>();

            while (true)
            {
                Process currentProcess = Process.GetCurrentProcess();
                long currentWorkingSet = currentProcess.WorkingSet64;
                Console.WriteLine($"Current Working Set:  {currentWorkingSet}");

                if (currentWorkingSet >= targetWorkingSet)
                {
                    break;
                }

                Console.WriteLine("Consuming Memory...");
                string[] strArray = new string[growthFactor];
                for (int i = 0; i < strArray.Length; i++)
                {
                    strArray[i] = $"{i}{DateTime.Now}";
                }

                if (consumeMemory)
                {
                    heldRefs.Add(strArray);
                }
            };

            Console.WriteLine("Done Consuming Memory...Sleeping");
            Thread.Sleep(60000);
        }
    }
}
