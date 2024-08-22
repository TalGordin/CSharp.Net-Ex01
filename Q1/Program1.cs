using System;
using static System.Console;
using System.Text;

namespace Ex01_Q01
{
    class Program
    {
        public const int k_NumOfBinaryNumbers = 3;
        public const int k_SizeOfBinaryNumber = 9;

        public static void Main()
        {
            string[] binaryNumbers;

            binaryNumbers = getUserInput();
            printStatsForBinaryNumbers(ref binaryNumbers);
        }

        private static string[] getUserInput()
        {
            string[] binaryNumbersAsStrings = new string[k_NumOfBinaryNumbers];

            WriteLine($"Enter {k_NumOfBinaryNumbers} binary numbers that are {k_SizeOfBinaryNumber} digits long:");
            for (int s = 0; s < k_NumOfBinaryNumbers; ++s)
            {
                bool validInput;

                do
                {
                    WriteLine($"Enter binary number {s + 1}: ");
                    string input = ReadLine();
                    validInput = isBinaryInputValid(ref input);
                    if (!validInput)
                    {
                        WriteLine($"Invalid input! Please enter a binary number that's {k_SizeOfBinaryNumber} digits long.");
                    }
                    else
                    {
                        binaryNumbersAsStrings[s] = input;
                    }
                } while (!validInput);
            }

            return binaryNumbersAsStrings;
        }

        private static bool isBinaryInputValid(ref string io_Input)
        {
            const bool v_BinaryInputIsValid = true;
            bool isInputValid = v_BinaryInputIsValid;

            if (io_Input.Length != k_SizeOfBinaryNumber)
            {
                isInputValid = !v_BinaryInputIsValid;
            }

            if (isInputValid)
            {
                // Checking if string is binary
                string cleanedInput = io_Input.Replace("0", "").Replace("1", "");
                // If the cleaned input is empty, it means the original string contained only '0's and '1's
                isInputValid = string.IsNullOrEmpty(cleanedInput);
            }

            return isInputValid;
        }

        private static void printStatsForBinaryNumbers(ref string[] io_NumbersAsBinaryStrings)
        {
            int[] binaryNumbersIntegersInAscendingOrder = convertStringsToIntegers(ref io_NumbersAsBinaryStrings);
            
            Array.Sort(binaryNumbersIntegersInAscendingOrder);
            printNumbers(ref binaryNumbersIntegersInAscendingOrder);
            printAverageOnesAndZeros(ref io_NumbersAsBinaryStrings);
            printHowManyNumbersArePowersOfTwo(ref io_NumbersAsBinaryStrings);
            printHowManyNumbersAreARisingSequence(ref binaryNumbersIntegersInAscendingOrder);
            printLargestAndSmallestNumbers(ref binaryNumbersIntegersInAscendingOrder);
        }

        private static int[] convertStringsToIntegers(ref string[] io_BinaryNumbersStrings)
        {
            int[] binaryNumbersIntegers = new int[io_BinaryNumbersStrings.Length];

            for (int i = 0; i < io_BinaryNumbersStrings.Length; ++i)
            {
                binaryNumbersIntegers[i] = convertBinaryStringToInt(ref io_BinaryNumbersStrings[i]);
            }

            return binaryNumbersIntegers;
        }

        private static int convertBinaryStringToInt(ref string io_BinaryString)
        {
            int decimalNumber = 0;
            for (int i = io_BinaryString.Length - 1; i >= 0; --i)
            {
                // Start from the rightmost digit
                int currentDigit = io_BinaryString[i] - '0';

                // Multiply the current digit by 2 raised to the power of its position
                int powerOfTwo = io_BinaryString.Length - 1 - i;
                decimalNumber += currentDigit * (int)Math.Pow(2, powerOfTwo);
            }
            return decimalNumber;
        }

        private static void printNumbers(ref int[] io_Numbers)
        {
            WriteLine("The three numbers are:");

            for (int i = 0; i < io_Numbers.Length; ++i)
            {
                WriteLine($"{i + 1}: {io_Numbers[i]}");
            }
        }
        private static void printAverageOnesAndZeros(ref string[] io_NumbersAsBinaryStrings)
        {
            for (int i = 0; i <= 1; ++i)
            {
                int sumOfChars = 0;

                foreach (string s in io_NumbersAsBinaryStrings)
                {
                    sumOfChars += countCharsInString(s, (char)(i + '0'));
                }

                WriteLine($"The average number of '{i}'s is {(float)sumOfChars / k_NumOfBinaryNumbers}");
            }
        }

        private static int countCharsInString(string i_String, char i_RequestedChar)
        {
            int charCounter = 0;

            foreach (char c in i_String)
            {
                if (c == i_RequestedChar)
                {
                    charCounter++;
                }
            }

            return charCounter;
        }

        private static void printHowManyNumbersArePowersOfTwo(ref string[] io_NumbersAsBinaryStrings)
        {
            int powersOfTwoCounter = 0;

            foreach (string s in io_NumbersAsBinaryStrings)
            {
                if (countCharsInString(s, '1') == 1)
                {
                    powersOfTwoCounter++;
                }
            }

            StringBuilder methodOutput = new StringBuilder();
            methodOutput.Append("There ")
                        .Append((powersOfTwoCounter == 1 ? "is" : "are"))
                        .Append(" ")
                        .Append((powersOfTwoCounter == 0 ? "no" : powersOfTwoCounter.ToString()))
                        .Append(" ")
                        .Append((powersOfTwoCounter == 1 ? "number" : "numbers"))
                        .Append(" which ")
                        .Append((powersOfTwoCounter == 1 ? "is" : "are"))
                        .Append(" a power of 2.");
            WriteLine(methodOutput.ToString());
        }

        private static void printHowManyNumbersAreARisingSequence(ref int[] io_Numbers)
        {
            int risingSequenceCounter = 0;

            foreach (int i in io_Numbers)
            {
                if (isRisingSequence(i))
                {
                    risingSequenceCounter++;
                }
            }

            StringBuilder methodOutput = new StringBuilder();
            methodOutput.Append("There ")
                        .Append((risingSequenceCounter == 1 ? "is" : "are"))
                        .Append(" ")
                        .Append((risingSequenceCounter == 0 ? "no" : risingSequenceCounter.ToString()))
                        .Append(" ")
                        .Append((risingSequenceCounter == 1 ? "number" : "numbers"))
                        .Append(" which ")
                        .Append((risingSequenceCounter == 1 ? "is" : "are"))
                        .Append(" a rising sequence.");
            WriteLine(methodOutput.ToString());
        }

        private static bool isRisingSequence(int i_Number)
        {
            string numberAsString = i_Number.ToString();
            const bool RisingSequence = true;
            bool isRisingSequence = RisingSequence;

            for (int i = 0; i < numberAsString.Length - 1; i++)
            {
                if (numberAsString[i] >= numberAsString[i + 1])
                {
                    isRisingSequence = !RisingSequence;
                    break;
                }
            }

            return isRisingSequence;
        }

        private static void printLargestAndSmallestNumbers(ref int[] io_Numbers)
        {
            WriteLine($"The smallest number is {io_Numbers[0]}");
            WriteLine($"The largest number is {io_Numbers[2]}");
        }
    }
}