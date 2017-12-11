using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerProblems
{
    public class Problem030
    {
        public static int Solve()
        {
            //9^5 * 6 = 354294, which is outstripped by the value 999999, so 1M is a good limit
            int sum = 0;
            for(int number = 10; number < 1000000; number++)
            {
                int digitSum = 0;
                foreach(char c in number.ToString())
                {
                    digitSum += (int) Math.Pow(char.GetNumericValue(c), 5);
                }

                if(digitSum == number)
                {
                    sum += number;
                }
            }

            return sum;
        }
    }
}
