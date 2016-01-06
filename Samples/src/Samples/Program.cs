using System;
using System.Threading.Tasks;

namespace Samples
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Tuple<string, bool, bool>[] testInput = new Tuple<string, bool, bool>[]
                {
                    Tuple.Create("", false, true),
                    Tuple.Create(" ", false, true),
                    Tuple.Create("a", false, true),
                    Tuple.Create("aa", false, true),
                    Tuple.Create("ab", false, false),
                    Tuple.Create("aba", false, true),
                    Tuple.Create("ab a", false, false),
                    Tuple.Create("ab a", true, true),
                    Tuple.Create("rotator", false, true),
                    Tuple.Create("Rotator", false, false),
                    Tuple.Create("A nut for a jar of tuna.", false, false),
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
            return Program.IsPalindromeOption1(input, false);
        }

        private static bool IsPalindromeOption1(string input, bool ignoreSpace)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            string processedInput = string.Empty;
            if (ignoreSpace)
            {
                for (int i = 0; i < input.Length; i++)
                {
                    if (Char.IsWhiteSpace(input[i]))
                    {
                        continue;
                    }

                    processedInput += input[i];
                }
            }
            else
            {
                processedInput = input;
            }

            string reversedInput = string.Empty;
            for (int i = processedInput.Length - 1; i >= 0; i--)
            {
                reversedInput += processedInput[i];
            }

            return string.Equals(processedInput, reversedInput, StringComparison.Ordinal);
        }

        private static bool IsPalindromeOption2(string input, bool ignoreSpace)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            bool isPalindrome = true;

            for (int i = 0, j = input.Length - 1; i < j;)
            {
                char iChar = input[i];
                char jChar = input[j];

                if (ignoreSpace)
                {
                    if (char.IsWhiteSpace(iChar))
                    {
                        i++;
                        continue;
                    }
                    if (char.IsWhiteSpace(jChar))
                    {
                        j--;
                        continue;
                    }
                }

                if (iChar != jChar)
                {
                    isPalindrome = false;
                    break;
                }

                i++;
                j--;
            }

            return isPalindrome;
        }

        //for (int i = 0; i < (input.Length / 2); i++)
        //{
        //    if (input[i] != input[input.Length - 1 - i])
        //    {
        //        result = false;
        //        break;
        //    }
        //}
    }
}
