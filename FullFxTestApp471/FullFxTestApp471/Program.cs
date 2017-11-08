using SharedLibrary;
using System;
using System.Runtime.InteropServices;
using static System.Console;

namespace FullFxTestApp471
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string message = "Dotnet-bot: Welcome to using .NET Framework!";

            if (args.Length > 0)
            {
                message = String.Join(" ", args);
            }

            WriteLine(Robot.GetBot(message));
            WriteLine("**Environment**");
            WriteLine($"Platform: .NET Framework 4.7.1");
            WriteLine($"OS: {RuntimeInformation.OSDescription}");
            WriteLine();
        }
    }
}
