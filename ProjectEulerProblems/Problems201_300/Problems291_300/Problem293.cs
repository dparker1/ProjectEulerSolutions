using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerProblems
{
    public class Problem293
    {
        static List<int> primes;
        public static long Solve()
        {
            int limit = 1000000000;
            primes = EulerUtilities.GeneratePrimesSmall(limit);
            HashSet<long> admissibles = GenerateAdmissible(limit);
            BitArray primeBits = new BitArray(limit, false);
            foreach(int p in primes)
            {
                primeBits[p] = true;
            }
            HashSet<int> uniques = new HashSet<int>();
            foreach(long admiss in admissibles)
            {
                for(int i = 2; i < int.MaxValue; i++)
                {
                    if(primeBits[(int)admiss + i])
                    {
                        uniques.Add(i);
                        break;
                    }
                }
            }
            return uniques.Sum();
        }

        public static HashSet<long> GenerateAdmissible(int limit)
        {
            HashSet<long> result = new HashSet<long>();
            HashSet<Tuple<long, int>> current = new HashSet<Tuple<long, int>>(new Tuple<long, int>[] { new Tuple<long, int>(2, 1) });
            GenerateAdmissibleRecur(result, current, limit, 2);
            return result;
        }

        public static void GenerateAdmissibleRecur(HashSet<long> result, HashSet<Tuple<long, int>> current, int limit, int maxPrimeI)
        {
            current.RemoveWhere(x => x.Item1 >= limit);
            foreach(Tuple<long, int> x in current)
            {
                result.Add(x.Item1);
            }
            if(current.Count == 0)
            {
                return;
            }
            HashSet<Tuple<long, int>> nextCurrent = new HashSet<Tuple<long, int>>();
            int primeMax = Math.Min(primes.Count, maxPrimeI);
            foreach(Tuple<long, int> curr in current)
            {
                for(int primeI = 0; primeI < primeMax; primeI++)
                {
                    if(primeI > curr.Item2)
                    {
                        break;
                    }
                    nextCurrent.Add(new Tuple<long, int>(curr.Item1 * primes[primeI], primeI + 1));
                }
            }
            GenerateAdmissibleRecur(result, nextCurrent, limit, maxPrimeI + 1);
        }
    }
}
