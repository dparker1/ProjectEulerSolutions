using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerProblems
{
    public class Problem124
    {
        public static List<int> primes;
        public static int Solve()
        {
            int limit = 100000;
            primes = EulerUtilities.GeneratePrimes(limit).ConvertAll(x => (int)x);
            
            RadPair[] radPairs = new RadPair[limit + 1];
            radPairs[0] = new RadPair(0, 0);
            radPairs[1] = new RadPair(1, 1);
            for(int i = 2; i <= limit; i++)
            {
                radPairs[i] = new RadPair(i, SumDistinctPrimeDivisors(i));
            }
            Array.Sort(radPairs);
            return radPairs[10000].Num;
        }

        public static int SumDistinctPrimeDivisors(int i)
        {
            HashSet<int> divisors = new HashSet<int>();
            for(int divisor = 0; primes[divisor] <= i; divisor++)
            {
                if(i % primes[divisor] == 0)
                {
                    divisors.Add(primes[divisor]);
                    i /= primes[divisor];
                    divisor = 0;
                }
                if(i == 1)
                {
                    break;
                }
            }
            int product = 1;
            foreach(int n in divisors)
            {
                product *= n;
            }
            return product;
        }
    }

    public struct RadPair : IComparable<RadPair>
    {
        public int Num;
        public int Rad;
        public RadPair(int num, int rad)
        {
            this.Num = num;
            this.Rad = rad;
        }

        public int CompareTo(RadPair o)
        {
            if(o.Rad < this.Rad)
            {
                return 1;
            }
            else if(o.Rad == this.Rad)
            {
                if(o.Num < this.Num)
                {
                    return 1;
                }
                else if(o.Num == this.Num)
                {
                    return 0;
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                return -1;
            }
        }

        public override string ToString()
        {
            return "(" + Num + " : " + Rad + ")";
        }
    }

    
}
