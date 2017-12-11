using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace ProjectEulerProblems
{
    public class EulerUtilities
    {
        public static List<long> Primes;
        public static int processors= Environment.ProcessorCount;

        public static void LoadPrimes()
        {
            Primes = GeneratePrimes(int.MaxValue / 10);
        }

        public static int SumRange(int low, int high)
        {
            return (int) (((low + high) / 2.0) * (high - low + 1));
        }

        public static List<long> GeneratePrimes(int limit)
        {
            long[] primes = new long[limit];
            BitArray primeBits = new BitArray(limit, false);
            List<long> returned = new List<long>();

            primeBits[2] = true;
            for(int i = 3; i < limit; i += 2)
            {
                primeBits[i] = true;
            }

            for(int i = 0; i < limit; i++)
            {
                primes[i] = i;
            }
            for(int i = 2; i <= Math.Sqrt(limit); i++)
            {
                if(primeBits[i])
                {
                    for(int j = 2; i*j < limit; j++)
                    {
                        primeBits[i * j] = false;
                    }
                }
            }
            for(int i = 2; i < limit; i++)
            {
                if(primeBits[i])
                {
                    returned.Add(primes[i]);
                }
            }
            
            return returned;
        }

        public static bool IsPrime(Int64 possiblePrime)
        {
            if(possiblePrime < 2)
            {
                return false;
            }
            for(Int64 i = 2; i <= Math.Sqrt(possiblePrime); i++)
            {
                if(possiblePrime % i == 0)
                {
                    return false;
                }
            }
            return true;
        }

        public static bool IsPalindrome(String text)
        {
            for(int i = 0; i < text.Length / 2; i++)
            {
                if(text[i] != text[text.Length - i - 1])
                {
                    return false;
                }
            }
            return true;
        }

        public static bool IsWholeNumber(double d)
        {
            return Math.Abs(d % 1) <= Double.Epsilon * 100;
        }

        public static bool IsTriangleNumber(int n)
        {
            return IsTriangleNumber((long)n);
        }

        public static bool IsTriangleNumber(long n)
        {
            return IsWholeNumber((Math.Sqrt(8 * n + 1) - 1) / 2);
        }

        public static bool IsPentagonalNumber(int n)
        {
            return IsPentagonalNumber((long)n);
        }

        public static bool IsPentagonalNumber(long n)
        {
            return IsWholeNumber((Math.Sqrt(24 * n + 1) + 1) / 6);
        }

        public static bool IsNthPower(long num, int root)
        {
            return IsWholeNumber(Math.Pow(num,((double) 1)/root));
        }

        public static List<int> GetDivisorList(int number)
        {
            List<int> returned = new List<int>();
            for(int divisor = 1; divisor <= Math.Sqrt(number); divisor++)
            {
                if(number % divisor == 0)
                {
                    returned.Add(divisor);
                    returned.Add(number / divisor);
                }
            }

            return returned;
        }

        public static long[] GetBinomialCoefficients(int row)
        {
            long[][] rows = new long[row + 1][];
            for(int i = 0; i <= row; i++)
            {
                if(i == 0)
                {
                    rows[i] = new long[] { 1 };
                }
                else if(i == 1)
                {
                    rows[i] = new long[] { 1, 1 };
                }
                else
                {
                    rows[i] = new long[i + 1];
                    rows[i][0] = 1;
                    rows[i][i] = 1;
                    for(long z = 1; z < i; z++)
                    {
                        rows[i][z] = rows[i - 1][z - 1] + rows[i - 1][z];
                    }
                }
                
            }

            return rows[row];
        }

        public static BigInteger[][] GetBigPascalsTriangle(int row)
        {
            BigInteger[][] rows = new BigInteger[row + 1][];
            for(int i = 0; i <= row; i++)
            {
                if(i == 0)
                {
                    rows[i] = new BigInteger[] { 1 };
                }
                else if(i == 1)
                {
                    rows[i] = new BigInteger[] { 1, 1 };
                }
                else
                {
                    rows[i] = new BigInteger[i + 1];
                    rows[i][0] = 1;
                    rows[i][i] = 1;
                    for(long z = 1; z < i; z++)
                    {
                        rows[i][z] = rows[i - 1][z - 1] + rows[i - 1][z];
                    }
                }

            }

            return rows;
        }

        public static List<int> FindProperDivisors(int n)
        {
            List<int> result = new List<int>() { 1 };
            for(int i = 2; i <= Math.Sqrt(n); i++)
            {
                if(n % i == 0)
                {
                    result.Add(i);
                    if(i != (n / i))
                    {
                        result.Add(n / i);
                    }
                }
            }

            return result;
        }

        public static List<string> Permute(string s)
        {
            List<string> result = new List<string>();
            if(s.Length == 0)
            {
                return result;
            }

            Permute(s, "", result);
            return result;
        }

        public static List<string> Circulate(string s)
        {
            string[] result = new string[s.Length];
            result[0] = s;
            for(int i = 1; i < result.Length; i++)
            {
                result[i] = result[i - 1].Substring(1, result.Length - 1) + result[i - 1][0];
            }

            return new List<string>(result);
        }

        private static void Permute(string remaining, string current, List<string> temp)
        {
            if(remaining.Length == 0)
            {
                temp.Add(current);
                return;
            }

            int remainingLength = remaining.Length;
            for(int i = 0; i < remainingLength; i++)
            {
                Permute(remaining.Substring(0, i) + remaining.Substring(i + 1), current + remaining[i], temp);
            }
        }

        public static int GreatestCommonDivisor(int a, int b)
        {
            if(a == 0)
            {
                return b;
            }

            if(b == 0)
            {
                return a;
            }

            return GreatestCommonDivisor(b, a % b);
        }

        public static long Factorial(int n)
        {
            if(n == 0)
            {
                return 1;
            }
            if(n == 1)
            {
                return 1;
            }
            if(n == 2)
            {
                return 2;
            }
            return n * Factorial(n - 1);
        }

        public static BigInteger BigFactorial(long n)
        {
            Task<BigInteger>[] tasks = Enumerable.Range(1, processors).Select(x => Task.Factory.StartNew(
                                        () => Multiply(x, n), TaskCreationOptions.LongRunning)).ToArray();
            Task.WaitAll(tasks);
            BigInteger result = 1;
            foreach(Task<BigInteger> task in tasks)
            {
                result *= task.Result;
            }

            return result;
        }

        private static BigInteger Multiply(int lower, long upper)
        {
            BigInteger result = 1;
            for(int i = lower; i <= upper; i += processors)
            {
                result *= i;
            }
            return result;
        }

        public static HashSet<long> UniquePrimeFactors(long n)
        {
            return new HashSet<long>(PrimeFactors(n));
        }

        public static List<long> PrimeFactors(long n)
        {
            List<long> result = new List<long>();
            for(int i = 0; i < Primes.Count; i++)
            {
                if(Primes[i] > n)
                {
                    break;
                }
                if(n % Primes[i] == 0)
                {
                    result.Add(Primes[i]);
                    n /= Primes[i];
                    i = -1;
                }
            }
            return result;
        }

    }
}
