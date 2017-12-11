using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerProblems
{
    public class Problem038
    {
        static string pan = "123456789";
        public static int Solve()
        {
            int largest = 0;
            string concated;
            for(int i = 1; i <= 9999; i++)
            {
                concated = "";
                for(int multiplier = 1; multiplier < 10; multiplier++)
                {
                    concated += i * multiplier;
                    if(concated.Length > 9)
                    {
                        break;
                    }
                    else if(concated.Length == 9 && IsPandigital(concated) && int.Parse(concated) > largest)
                    {
                        largest = int.Parse(concated);
                        break;
                    }
                }
            }
            return largest;
        }

        public static bool IsPandigital(string s)
        {
            foreach(char c in pan)
            {
                if(!s.Contains(c))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
