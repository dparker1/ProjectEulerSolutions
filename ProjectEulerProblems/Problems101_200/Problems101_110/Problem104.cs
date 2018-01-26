using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace ProjectEulerProblems
{
    public class Problem104
    {
        static string pan = "123456789";
        public static int Solve()
        {
            BigInteger b1 = 1;
            BigInteger b2 = 1;
            BigInteger temp;
            bool found = false;
            int digits;
            int k = 2;
            while(!found)
            {
                temp = b1 + b2;
                b1 = b2;
                b2 = temp;
                k++;
                if(IsPandigital((temp % 1000000000).ToString()))
                {
                    digits = (int)(1 + BigInteger.Log10(temp));
                    if(digits > 18)
                    {
                        if(IsPandigital((temp / BigInteger.Pow(10, digits - 9)).ToString()))
                        {
                            found = true;
                        }
                    }
                }
            }
            return k;

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
