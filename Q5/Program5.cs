using static System.Console;
using System.Linq;

namespace Ex01_05
{
    class Program
    {
        public static void Main()
        {
            string userInput = ReadAndValidateInput();
            calculateStatistics(userInput);
        }

        private static string ReadAndValidateInput()
        {
            bool validInput;
            string userInput;
            
            WriteLine("Enter an 8-digit positive integer:");
            do
            {
                userInput = ReadLine();
                validInput = isInputValid(userInput);
                if (!validInput)
                {
                    WriteLine("Invalid input! Please enter an 8-digit positive integer:");
                }
            } while (!validInput);
            return userInput;
        }

        private static bool isInputValid(string i_UserInput)
        {
            return (isEightDigit(i_UserInput) && isPositiveNumber(i_UserInput));
        }

        private static bool isEightDigit(string i_UserInput)
        {
            return (i_UserInput.Length == 8);
        }

        private static bool isPositiveNumber(string i_UserInput)
        {
            return i_UserInput.All(c => char.IsDigit(c));
        }

        private static void calculateStatistics(string i_Number)
        {
            int numberOfDigitsSmallerThanUnitsDigit = countSmallerDigitsThanUnitsDigit(i_Number);
            int numberOfDigitsDivisibleBy3 = countDigitsDivisibleBy3(i_Number);
            int largestDigit = getLargestDigit(i_Number);
            double averageValueOfDigits = getAverageOfDigitsInNumber(i_Number);

            WriteLine($"1. Number of digits that are smaller then units digit: {numberOfDigitsSmallerThanUnitsDigit}");
            WriteLine($"2. Number of digits divisible by 3: {numberOfDigitsDivisibleBy3}");
            WriteLine($"3. Largest digit: {largestDigit}");
            WriteLine($"4. Average of digits in the number: {averageValueOfDigits}");
        }

        private static int countSmallerDigitsThanUnitsDigit(string i_Number)
        {
            int numberOfDigitsSmallerFromUnitsDigit = 0;

            for (int i = 0; i < i_Number.Length; ++i)
            {
                if (i_Number[0] > i_Number[i])
                {
                    numberOfDigitsSmallerFromUnitsDigit++;
                }
            }

            return numberOfDigitsSmallerFromUnitsDigit;
        }

        private static int countDigitsDivisibleBy3(string i_Number)
        {
            int countAmountOfDigitsDivisibleBy3 = 0;

            for (int i = 0; i < i_Number.Length; i++)
            {
                if (int.TryParse(i_Number[i].ToString(), out int currentDigit))
                {
                    if (currentDigit % 3 == 0)
                    {
                        countAmountOfDigitsDivisibleBy3++;
                    }
                }
            }

            return countAmountOfDigitsDivisibleBy3;
        }

        private static int getLargestDigit(string i_Number)
        {
            int maxDigitInNumber = 0;

            for (int i = 0; i < i_Number.Length; i++)
            {
                if (int.TryParse(i_Number[i].ToString(), out int digit))
                {
                    if (maxDigitInNumber < digit)
                    {
                        maxDigitInNumber = digit;
                    }
                }
            }

            return maxDigitInNumber;
        }

        private static double getAverageOfDigitsInNumber(string i_Number)
        {
            double average;
            int sumOfDigitsInInput = 0;

            for (int i = 0; i < i_Number.Length; i++)
            {
                int.TryParse(i_Number[i].ToString(), out int digit);
                sumOfDigitsInInput += digit;
            }

            average = ((double)sumOfDigitsInInput / i_Number.Length);
            return average;
        }
    }
}