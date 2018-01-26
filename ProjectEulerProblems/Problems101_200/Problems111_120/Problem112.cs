using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectEulerProblems.Mathematics;

namespace ProjectEulerProblems
{
    public class Problem112
    {
        public static int Solve()
        {
            Rational proportion = new Rational(0, 100);
            Rational limit = new Rational(99, 100);
            int number = 101;
            while(proportion < limit)
            {
                if(IsBouncy(number))
                {
                    proportion = new Rational(proportion.Numerator + 1, proportion.Denominator + 1);
                }
                else
                {
                    proportion = new Rational(proportion.Numerator, proportion.Denominator + 1);
                }
                number++;
            }
            return number - 1;
        }

        public static bool IsBouncy(int n)
        {
            string s = n.ToString();
            bool isIncreasing = false, isDecreasing = false;
            for(int i = 0; i < s.Length - 1; i++)
            {
                if(s[i] < s[i + 1])
                {
                    isIncreasing = true;
                }
                if(s[i] > s[i + 1])
                {
                    isDecreasing = true;
                }
                if(isIncreasing && isDecreasing)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
