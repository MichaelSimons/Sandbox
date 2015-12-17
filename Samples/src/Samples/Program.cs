using System;
using System.Threading.Tasks;

namespace Samples
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Tuple<string, bool>[] testInput = new Tuple<string, bool>[]
                {
                    Tuple.Create("", true),
                    Tuple.Create(" ", true),
                    Tuple.Create("a", true),
                    Tuple.Create("aa", true),
                    Tuple.Create("ab", false),
                    Tuple.Create("aba", true),
                    Tuple.Create("ab a", false),
                    Tuple.Create("rotator", true),
                    Tuple.Create("Rotator", false),
                    Tuple.Create("A nut for a jar of tuna.", false),
                };

            Task[] tasks = new Task[]
                {
                    Validator.ValidateAsync(nameof(IsPalindromeOption1), Program.IsPalindromeOption1, testInput),
                    Validator.ValidateAsync(nameof(IsPalindromeOption2), Program.IsPalindromeOption2, testInput),
                };

            Task.WaitAll(tasks);

            Console.ReadLine();
        }

        private static bool IsPalindromeOption1(string input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            string revInput = "";
            foreach (char c in input)
            {
                revInput = revInput.Insert(0, c.ToString());
            }

            return string.Equals(input, revInput, StringComparison.Ordinal);
        }

        private static bool IsPalindromeOption2(string input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            bool result = true;
            for (int i = 0; i < (input.Length / 2); i++)
            {
                if (input[i] != input[input.Length - 1 - i])
                {
                    result = false;
                    break;
                }
            }

            return result;
        }
    }
}
