using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using ProjectEulerProblems.Mathematics;

namespace ProjectEulerProblems
{
    public class Problem080
    {
        public static int Solve()
        {
            List<int> sums = new List<int>();
            BigDecimal d;
            for(int i = 1; i < 100; i++)
            {
                d = BigDecimal.Sqrt(new BigDecimal(i, 0, 100));
                if(d.ToString().Length > 5)
                {
                    int sum = 0;
                    foreach(char c in d.ToString().Substring(0, 101))
                    {
                        if(c != '.')
                        {
                            sum += (c - 48);
                        }
                        
                    }
                    sums.Add(sum);
                }

            }
            return sums.Sum();
        }
    }
}
