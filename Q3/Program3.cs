using static System.Console;
using System.Text;

namespace Ex01_Q03
{
    internal class Program
    {
        public static void Main()
        {
            string userInput = getUserInput(out int inputAsInteger);
            
            printDiamondBySize(inputAsInteger);
        }

        private static string getUserInput(out int o_InputAsInteger)
        {
            string userInput;
            bool validInput;

            WriteLine("Insert the desired height for the diamond: ");
                do
                {
                    userInput = ReadLine();
                    validInput = isUserInputValid(ref userInput, out o_InputAsInteger);
                    if (!validInput)
                    {
                        WriteLine("Invalid input! Please Insert a positive number: ");
                    }
                } while (!validInput);

            return userInput;
        }

        private static bool isUserInputValid(ref string io_UserInput, out int o_InputAsInteger)
        {
            const bool v_InputIsValid = true;
            bool isInputValid;

            if (int.TryParse(io_UserInput, out o_InputAsInteger) && o_InputAsInteger > 0)
            {
                isInputValid = v_InputIsValid;
            }
            else
            {
                isInputValid = !v_InputIsValid;
            }

            return isInputValid;
        }
        
        private static void printDiamondBySize(int i_DiamondSize)
        {
            StringBuilder diamondStringBuilder = new StringBuilder();
            int diamondSizeSentToRecursion;
            const int firstLine = 0;

            if (isEven(i_DiamondSize))
            {
                diamondSizeSentToRecursion = i_DiamondSize / 2;
            }
            else
            {
                diamondSizeSentToRecursion = (i_DiamondSize + 1) / 2;
            }

            Ex01_Q02.Program.PrintDiamondRecursion(diamondStringBuilder, diamondSizeSentToRecursion, firstLine);
            WriteLine(diamondStringBuilder.ToString());
        }

        private static bool isEven(int i_Number)
        {
            const bool v_NumberIsEven = true;
            bool isEven;

            if(i_Number % 2 == 0)
            {
                isEven = v_NumberIsEven;
            }
            else
            {
                isEven = !v_NumberIsEven;
            }

            return isEven;
        }
    }
}
