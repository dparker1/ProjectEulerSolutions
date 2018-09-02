using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerProblems
{
    public class Problem346
    {
        public static long Solve()
        {
            long limit = 1000000000000L;
            long inter, power;
            HashSet<long> strong = new HashSet<long>(), maybeStrong = new HashSet<long>();
            long lesserLimit = (long)Math.Sqrt(limit) + 1;
            for(long b = 2; b < lesserLimit; b++)
            {
                inter = b + 1;
                power = b * b;
                while(inter < limit)
                {
                    if(!strong.Contains(inter))
                    {
                        if(maybeStrong.Contains(inter) || inter  > lesserLimit)
                        {
                            strong.Add(inter);
                            maybeStrong.Remove(inter);
                        }
                        else
                        {
                            maybeStrong.Add(inter);
                        }
                    }
                    inter += power;
                    power *= b;
                }

            }
            return strong.Sum() + 1;
        }
    }
}
