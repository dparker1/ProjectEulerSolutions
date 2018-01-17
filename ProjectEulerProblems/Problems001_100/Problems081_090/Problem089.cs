using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ProjectEulerProblems
{
    public class Problem089
    {
        public static Dictionary<char, int> numerals;
        public static Dictionary<int, string> inverseNumerals;
        public static int Solve()
        {
            numerals = new Dictionary<char, int>();
            inverseNumerals = new Dictionary<int, string>();
            numerals.Add('I', 1);
            numerals.Add('V', 5);
            numerals.Add('X', 10);
            numerals.Add('L', 50);
            numerals.Add('C', 100);
            numerals.Add('D', 500);
            numerals.Add('M', 1000);
            inverseNumerals.Add(1, "I");
            inverseNumerals.Add(4, "IV");
            inverseNumerals.Add(5, "V");
            inverseNumerals.Add(9, "IX");
            inverseNumerals.Add(10, "X");
            inverseNumerals.Add(40, "XL");
            inverseNumerals.Add(50, "L");
            inverseNumerals.Add(90, "XC");
            inverseNumerals.Add(100, "C");
            inverseNumerals.Add(400, "CD");
            inverseNumerals.Add(500, "D");
            inverseNumerals.Add(900, "CM");
            inverseNumerals.Add(1000, "M");
            int totalDifference = 0;
            string[] text = File.ReadAllLines(@"..\..\txt\Problem089Text.txt");
            for(int i = 0; i < text.Length; i++)
            {
                totalDifference += text[i].Length - ArabicToRoman(RomanToArabic(text[i])).Length;
            }
            return totalDifference;
        }

        public static int RomanToArabic(string roman)
        {
            char currentSymbol, previousSymbol;
            int result = 0;
            for(int i = 0; i < roman.Length; i++)
            {
                currentSymbol = roman[i];
                previousSymbol = i > 0 ? roman[i - 1] : '\0';
                if(((currentSymbol == 'V' || currentSymbol == 'X') && previousSymbol == 'I') || ((currentSymbol == 'C' || currentSymbol == 'L') && previousSymbol == 'X') || ((currentSymbol == 'M' || currentSymbol == 'D') && previousSymbol == 'C'))
                {
                    result -= 2 * numerals[previousSymbol];
                }
                result += numerals[currentSymbol];
            }

            return result;

        }

        public static string ArabicToRoman(int number)
        {
            string result = "";
            while(number > 0)
            {
                foreach(int i in inverseNumerals.Keys.Reverse())
                {
                    if(number >= i)
                    {
                        result += inverseNumerals[i];
                        number -= i;
                        break;
                    }
                }
            }
            return result;
        }
    }
}
