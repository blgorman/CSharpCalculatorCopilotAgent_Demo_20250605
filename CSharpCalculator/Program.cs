using Microsoft.Extensions.Configuration;
using Operations;

namespace CSharpCalculator
{
    public class Program
    {
        private static IConfigurationRoot _configuration;

        public static void Main(string[] args)
        {
            BuildOptions();

            var configTest = _configuration["AppSettingsTest"];
            var secretsTest = _configuration["SimpleSecretTest"];
            Console.WriteLine($"App Settings: {configTest}");
            Console.WriteLine($"Secrets: {secretsTest}");

            bool success = false;
            double n1, n2;

            //get user input for two numbers
            while (!success)
            {
                n1 = GetUserInputAsDouble("Please enter the first number: ");
                n2 = GetUserInputAsDouble("Please enter the second number: ");

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"You entered: Number 1: {n1} and Number 2: {n2}");

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Is this correct (y/n)");
                Console.ForegroundColor = ConsoleColor.Yellow;

                success = Console.ReadLine()?.StartsWith("y", StringComparison.OrdinalIgnoreCase) ?? false;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Press any key to exit...");
            Console.ResetColor();
            Console.ReadLine();
        }

        private static double GetUserInputAsDouble(string prompt)
        {
            bool success = false;
            double result = double.MinValue;
            while (!success)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(prompt);
                Console.ForegroundColor = ConsoleColor.Yellow;

                success = double.TryParse(Console.ReadLine(), out result);
                if (!success)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
            }
            return result;
        }

        private static void BuildOptions()
        {
            _configuration = ConfigurationBuilderSingleton.ConfigurationRoot;
        }
    }
}
