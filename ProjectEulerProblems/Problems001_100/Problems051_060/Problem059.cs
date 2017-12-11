using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ProjectEulerProblems
{
    public class Problem059
    {
        public static long Solve()
        {
            long sum = 46;
            string text = File.ReadAllText(@"..\..\txt\Problem059Text.txt");
            List<char> characters = new List<char>();
            foreach(string s in text.Split(','))
            {
                characters.Add((char) int.Parse(s));
            }
            char[] decoded = new char[characters.Count];
            string code = "";
            for(int charOne = 97; charOne < 123; charOne++)
            {
                for(int charTwo = 97; charTwo < 123; charTwo++)
                {
                    for(int charThree = 97; charThree < 123; charThree++)
                    {
                        code = "" + (char)charOne + (char)charTwo + (char)charThree;
                        for(int i = 0; i < characters.Count - 2; i += code.Length)
                        {
                            decoded[i] = (char)(characters[i] ^ code[0]);
                            decoded[i + 1] = (char)(characters[i + 1] ^ code[1]);
                            decoded[i + 2] = (char)(characters[i + 2] ^ code[2]);
                        }
                        if(ContainsEnglish(decoded))
                        {
                            foreach(char c in decoded)
                            {
                                sum += (int)c;
                            }
                        }
                    }
                }
            }
            return sum;
        }

        public static bool ContainsEnglish(char[] characters)
        {
            bool english = false;
            for(int i = 0; i < characters.Length - 2; i++)
            {
                if(characters[i] == 'a' && characters[i + 1] == 'n' && characters[i + 2] == 'd')
                {
                    english = true;
                }
            }
            for(int i = 0; i < characters.Length; i++)
            {
                if(characters[i] > 123)
                {
                    return false;
                }
                if(characters[i] == '#')
                {
                    return false;
                }
            }
            return english;
        }
    }
}
