using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerProblems
{
    public class Problem641
    {
        public static int Solve()
        {
            List<int> primes = EulerUtilities.GeneratePrimesSmall(600000000);
            primes = primes.Take(30000000).ToList();
            List<double> logPrimes = primes.Select(x => Math.Log10(x)).ToList();
            int result = 1;
            int limit = 36;
            for(int i = 1; ; i++)
            {
                List<List<int>> combinations = GenerateFactorCombinations(0, i, 0, limit, logPrimes);
                if(combinations.Count == 0)
                {
                    break;
                }
                foreach(List<int> combination in combinations)
                {
                    result += Count(combination, 0, limit, 0, logPrimes);
                }
            }
            return result;
        }

        public static int Count(List<int> combination, double curr, double max, int min, List<double> logPrimes)
        {
            double k = combination[0];
            if(combination.Count == 1)
            {
                int i = min;
                while(curr + k * logPrimes[i] <= max)
                {
                    i++;
                }
                return i - min;
            }
            else
            {
                int count = 0;
                for(int i = min; ; i++)
                {
                    double f = curr + logPrimes[i] * k;
                    double m = 0;
                    for(int j = 1; j + 1 < logPrimes.Count && j < combination.Count; j++)
                    {
                        m += logPrimes[i + j] * combination[j];
                    }
                    if(f + m > max)
                    {
                        break;
                    }
                    count += Count(combination.Skip(1).ToList(), f, max, i + 1, logPrimes);
                }
                return count;
            }
        }

        public static List<List<int>> GenerateFactorCombinations(int i, int length, double curr, double max, List<double> logPrimes)
        {
            if(i == length)
            {
                return new List<List<int>>() { new List<int>() };
            }

            double lp = logPrimes[i];
            double min = 0;
            for(int j = i + 1; j < length; j++)
            {
                min += 4 * logPrimes[j];
            }

            List<List<int>> result = new List<List<int>>();
            for(int m = 1; ; m++)
            {
                int k = 2 * m;
                double f = curr + lp * k;
                if(f + min > max)
                {
                    break;
                }
                foreach(List<int> combination in GenerateFactorCombinations(i + 1, length, f, max, logPrimes))
                {
                    List<int> temp = new List<int>(combination);
                    temp.Add(k);
                    if(i == 0)
                    {
                        int divisors = 1;
                        foreach(int x in temp)
                        {
                            divisors *= (x + 1);
                        }
                        if(divisors % 6 != 1)
                        {
                            continue;
                        }
                        temp.Reverse();
                    }
                    result.Add(temp);
                }
            }
            return result;
        }

    }
}
