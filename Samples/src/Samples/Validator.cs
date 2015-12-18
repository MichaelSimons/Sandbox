using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Samples
{
    public class Validator
    {
        public static async Task ValidateAsync(
            string implementationName,
            Func<string, bool, bool> implementation,
            Tuple<string, bool, bool>[] testInput)
        {
            StringBuilder outputBuilder = new StringBuilder();
            outputBuilder.AppendLine(implementationName);
            outputBuilder.AppendLine("----------------------------");

            foreach (Tuple<string, bool, bool> input in testInput)
            {
                bool isPalindrome;
                try
                {
                    isPalindrome = implementation(input.Item1, input.Item2);
                }
                catch (Exception ex)
                {
                    outputBuilder.AppendLine($"Unhandled exception while processing '{input.Item1}'");
                    outputBuilder.AppendLine(ex.ToString());
                    continue;
                }

                string result = isPalindrome == input.Item3 ? "Success" : "Failure";
                outputBuilder.AppendLine($"'{input.Item1}' - {result}");
            }

            string output = outputBuilder.ToString();
            Console.WriteLine(output);
            string filename = implementationName + ".txt";
            await Validator.WriteTextAsync(filename, output);
            Console.WriteLine($"'{filename}' created.");
        }

        private static async Task WriteTextAsync(string filePath, string text)
        {
            byte[] encodedText = Encoding.Unicode.GetBytes(text);

            using (FileStream sourceStream = new FileStream(
                filePath,
                FileMode.Create,
                FileAccess.Write,
                FileShare.None,
                bufferSize: 4096,
                useAsync: true))
            {
                await sourceStream.WriteAsync(encodedText, 0, encodedText.Length);
            };
        }
    }
}
