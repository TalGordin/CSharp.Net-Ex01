using static System.Console;
using System.Linq;

namespace Ex01_04
{
    public class Program
    {
        static void Main()
        {
            string userInput = getUserInput();

            processUserInput(userInput);
        }

        private static string getUserInput()
        {
            string userInput;
            bool isValidInput;

            WriteLine("Enter a string of 10 characters containing only letters or only digits:");
            do
            {
                userInput = ReadLine();

                isValidInput = isStringValid(userInput);
                if (!isValidInput)
                {
                    WriteLine("Invalid input! Please enter a string of 10 characters containing only letters or only digits:");
                }
            } while (!isValidInput);

            return userInput;
        }

        private static void processUserInput(string i_UserInput)
        {
           WriteLine($"The string {i_UserInput} is {(isStringAPalindrome(i_UserInput) ? "" : "not ")}a palindrome.");

            if (i_UserInput.All(c => char.IsLetter(c)))
            {
                int numOfLowercaseLettersInInput = checkAmountOfLowercaseLettersInString(i_UserInput);
                WriteLine($"The number of lowercase letters is {numOfLowercaseLettersInInput}.");
            }
            else
            {
                bool isInputDivisibleBy4 = isStringDivisibleBy4(i_UserInput);
                WriteLine($"The string is {(isInputDivisibleBy4? "" : "not ")}divisible by 4.");
            }
        }
        
        public static bool isStringAPalindrome(string i_String)
        {
            const bool v_StringIsAPalindrome = true;
            bool isStringAPalindrome = v_StringIsAPalindrome;

            for(int i = 0; i < i_String.Length / 2; ++i)
            {
                if (i_String[i] != i_String[i_String.Length - 1 - i])
                {
                    isStringAPalindrome = !v_StringIsAPalindrome;
                    break;
                }
            }

            return isStringAPalindrome;
        }
        
        public static bool isStringDivisibleBy4(string i_String)
        {
            const bool v_StringIsDivisibleBy4 = true;
            bool isStringDivisibleBy4 = v_StringIsDivisibleBy4;

            long.TryParse(i_String, out long stringAsInteger);
            if (stringAsInteger % 4 != 0)
            {
                isStringDivisibleBy4 = !v_StringIsDivisibleBy4;
            }

            return isStringDivisibleBy4;
        }
        
        public static int checkAmountOfLowercaseLettersInString(string i_String)
        {
            int countLowercaseLetters = 0;

            for (int i = 0; i < i_String.Length; i++)
            {
                if (char.IsLower(i_String[i]))
                    countLowercaseLetters++;
            }

            return countLowercaseLetters;
        }
        
        public static bool isStringValid(string i_String)
        {
            const bool v_StringIsValid = true;
            bool isStringValid = v_StringIsValid;

            if (i_String.Length != 10)
            {
                isStringValid = !v_StringIsValid;
            }
            else
            {
                bool containsOnlyLetters = i_String.All(c => char.IsLetter(c));
                bool containsOnlyDigits = i_String.All(c => char.IsDigit(c));

                //No need to check if both conditions are true, that's impossible
                if (!(containsOnlyLetters || containsOnlyDigits))
                {
                    isStringValid = !v_StringIsValid;
                }
            }

            return isStringValid;
        }
    }
}
