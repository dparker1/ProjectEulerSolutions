using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerProblems
{
    public class Problem042
    {
        public static int Solve()
        {
            int count = 0;
            string text = File.ReadAllText(@"..\..\txt\Problem042Text.txt");
            string[] words = text.Split(',');
            for(int i = 0; i < words.Length; i++)
            {
                words[i] = words[i].Replace("\"", "");
            }

            int wordSum;
            foreach(string word in words)
            {
                wordSum = 0;
                foreach(char c in word)
                {
                    wordSum += ((int)c) - 64;
                }
                if(EulerUtilities.IsTriangleNumber(wordSum))
                {
                    count++;
                }
            }
            return count;
        }
    }
}
