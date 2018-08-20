using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerProblems
{
    public class Problem387
    {
        public static long Solve()
        {
            List<List<Tuple<long, int>>> numbers = new List<List<Tuple<long, int>>>();
            List<Tuple<long, int>> first = new List<Tuple<long, int>>();
            for(int i = 1; i < 10; i++)
            {
                first.Add(new Tuple<long, int>(i, i));
            }
            numbers.Add(first);
            for(int magnitude = 0; magnitude < 14; magnitude++)
            {
                numbers.Add(new List<Tuple<long, int>>());
                foreach(Tuple<long, int> pair in numbers[magnitude])
                {
                    for(int n = 0; n < 10; n++)
                    {
                        long pos = 10 * pair.Item1 + n;
                        int newSum = pair.Item2 + n;
                        if(pos % newSum == 0)
                        {
                            numbers[magnitude + 1].Add(new Tuple<long, int>(pos, newSum));
                        }
                    }
                }
            }
            long sum = 0;
            long limit = 100000000000000L;
            for(int i = 0; i < numbers.Count; i++)
            {
                foreach(Tuple<long, int> n in numbers[i])
                {
                    if(EulerUtilities.IsPrime(n.Item1 / n.Item2))
                    {
                        for(int digit = 1; digit < 10; digit += 2)
                        {
                            long p = n.Item1 * 10 + digit;
                            if(p < limit && EulerUtilities.IsPrime(p))
                            {
                                sum += p;
                            }
                        }
                    }
                    
                }
            }
            
            return sum;

        }
    }
}
