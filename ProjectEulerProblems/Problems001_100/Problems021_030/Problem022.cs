using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ProjectEulerProblems
{
    public class Problem022
    {
        public static int Solve()
        {
            string text = File.ReadAllText(@"..\..\txt\Problem022Text.txt");
            string[] names = text.Split(',');
            for(int i = 0; i < names.Length; i++)
            {
                names[i] = names[i].Replace("\"", "");
            }
            Array.Sort(names);
            int totalSum = 0, nameSum = 0;
            for(int i = 0; i < names.Length; i++)
            {
                foreach(char character in names[i])
                {
                    nameSum += (int)character - 64;
                }
                totalSum += nameSum * (i + 1);
                nameSum = 0;
            }
            return totalSum;
        }
    }
}
