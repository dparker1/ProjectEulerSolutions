using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerProblems
{
    public class Problem092
    {
        public static int Solve()
        {
            int count = 1;
            HashSet<int> chained = new HashSet<int>();
            chained.Add(89);
            for(int i = 2; i < 10000000; i++)
            {
                int z = i;
                while(z != 1 && z != 89)
                {
                    z = SquareSum(z);
                    if(chained.Contains(z))
                    {
                        chained.Add(i);
                        count++;
                        break;
                    }
                }
            }
            return count;
        }

        public static int SquareSum(int i)
        {
            int sum = 0;
            while(i > 0)
            {
                int digit = i % 10;
                sum += digit * digit;
                i /= 10;
            }
            return sum;
        }
    }
}
