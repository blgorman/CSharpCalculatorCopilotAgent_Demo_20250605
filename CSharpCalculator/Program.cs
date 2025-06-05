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

            bool continueCalculating = true;

            while (continueCalculating)
            {
                // Display menu
                DisplayMenu();

                // Get user choice
                int choice = GetUserChoice();

                // Check if user wants to quit
                if (choice == 6)
                {
                    continueCalculating = false;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Thank you for using the CSharp Calculator!");
                    Console.ResetColor();
                    break;
                }

                // Get two numbers from user
                double n1, n2;
                GetTwoNumbers(out n1, out n2);

                // Perform calculation
                try
                {
                    double result = PerformCalculation(choice, n1, n2);
                    
                    // Display result
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"Result: {result}");
                    Console.ResetColor();
                }
                catch (DivideByZeroException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Error: {ex.Message}");
                    Console.ResetColor();
                }

                Console.WriteLine(); // Add blank line for readability
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

        private static void DisplayMenu()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("**************************************");
            Console.WriteLine("Welcome To the CSharp Calculator");
            Console.WriteLine("**************************************");
            Console.WriteLine("* What would you like to do today? ");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("1) Add");
            Console.WriteLine("2) Subtract");
            Console.WriteLine("3) Multiply");
            Console.WriteLine("4) Divide");
            Console.WriteLine("5) Remainder");
            Console.WriteLine("6) Quit");
            Console.WriteLine("**************************************");
            Console.ResetColor();
        }

        private static int GetUserChoice()
        {
            int choice = 0;
            bool validChoice = false;

            while (!validChoice)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Please enter your choice (1-6): ");
                Console.ForegroundColor = ConsoleColor.Yellow;

                string? input = Console.ReadLine();
                if (int.TryParse(input, out choice) && choice >= 1 && choice <= 6)
                {
                    validChoice = true;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 6.");
                    Console.ResetColor();
                }
            }

            Console.ResetColor();
            return choice;
        }

        private static void GetTwoNumbers(out double n1, out double n2)
        {
            bool success = false;

            do
            {
                n1 = GetUserInputAsDouble("Please enter the first number: ");
                n2 = GetUserInputAsDouble("Please enter the second number: ");

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"You entered: Number 1: {n1} and Number 2: {n2}");

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Is this correct (y/n)");
                Console.ForegroundColor = ConsoleColor.Yellow;

                success = Console.ReadLine()?.StartsWith("y", StringComparison.OrdinalIgnoreCase) ?? false;
                Console.ResetColor();
            }
            while (!success);
        }

        private static double PerformCalculation(int choice, double n1, double n2)
        {
            return choice switch
            {
                1 => Calculations.Add(n1, n2),
                2 => Calculations.Subtract(n1, n2),
                3 => Calculations.Multiply(n1, n2),
                4 => Calculations.Divide(n1, n2),
                5 => Calculations.Remainder(n1, n2),
                _ => throw new ArgumentException("Invalid operation choice")
            };
        }
    }
}
