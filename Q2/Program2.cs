using static System.Console;
using System.Text;

namespace Ex01_Q02
{
    public class Program
    {
        public const int k_DefaultDiamondHeight = 9;

        public static void Main()
        {
            printDiamond();
        }

        private static void printDiamond()
        {
            StringBuilder diamondStringBuilder = new StringBuilder();
            const int firstLine = 0;

            PrintDiamondRecursion(diamondStringBuilder, (k_DefaultDiamondHeight + 1) / 2, firstLine);
            WriteLine(diamondStringBuilder.ToString());
        }

        public static void PrintDiamondRecursion(StringBuilder i_StringBuilder, int i_NumOfRows, int i_CurrentRow)
        {
            if (i_NumOfRows == 0)
            {
                return;
            }

            // Handling a single line of the upper half of the diamond
            // concatenate spaces before stars
            i_StringBuilder.Append(' ', i_NumOfRows - 1);
            // concatenate stars for the current row
            i_StringBuilder.Append('*', 2 * i_CurrentRow + 1);
            i_StringBuilder.AppendLine();
            PrintDiamondRecursion(i_StringBuilder, i_NumOfRows - 1, i_CurrentRow + 1);
            // Handling lower part of the diamond, excluding the last row
            if (i_CurrentRow != 0)
            {
                i_StringBuilder.Append(' ', i_NumOfRows);
                i_StringBuilder.Append('*', (2 * i_CurrentRow) - 1);
                i_StringBuilder.AppendLine();
            }
        }
    }
}

