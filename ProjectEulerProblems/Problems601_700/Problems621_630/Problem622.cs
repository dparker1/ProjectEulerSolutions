using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//http://mathworld.wolfram.com/RiffleShuffle.html
//http://oeis.org/A002326

namespace ProjectEulerProblems
{
    public class Problem622
    {
        public static long Solve()
        {
            int goal = 60;
            List<long> powers = new List<long>();
            List<long> powersLessOne = new List<long>();
            for(int i = 0; i <= goal; i++)
            {
                powers.Add((long)Math.Pow(2, i));
                powersLessOne.Add(powers.Last() - 1);
            }
            long sum = 0;
            
            for(long mod = 5; mod < 1000000000L; mod += 2)
            {
                int count = goal - 1;
                if(powersLessOne[goal] % mod != 0)
                {
                    continue;
                }
                bool broken = false;
                do
                {
                    if(powersLessOne[count--] % mod == 0)
                    {
                        broken = true;
                        break;
                    }
                } while(powers[count] > mod);
                if(!broken)
                {
                    Console.WriteLine(mod);
                    sum += mod + 1;
                }
            }
            return sum;

        }
    }
}
