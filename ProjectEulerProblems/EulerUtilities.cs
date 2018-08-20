using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace ProjectEulerProblems
{
    public static class EulerUtilities
    {
        public static List<long> Primes;
        public static int processors= Environment.ProcessorCount;

        public static void LoadPrimes(int max)
        {
            Primes = GeneratePrimes(max);
        }

        public static int SumRange(int low, int high)
        {
            return (int) (((low + high) / 2.0) * (high - low + 1));
        }

        public static long ModularExponent(long b, long e, long mod)
        {
            long curr = 1, eCount = 0;
            while(eCount < e)
            {
                curr *= b;
                curr %= mod;
                eCount++;
            }
            return curr;
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
            double sqrt = Math.Sqrt(possiblePrime);
            for(Int64 i = 2; i <= sqrt; i++)
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

        public static bool IsPower(long num, long divisor)
        {
            long exp = divisor;
            int i = 1;
            while(exp < num)
            {
                exp *= exp;
                i *= 2;
            }
            if(num == exp)
            {
                return true;
            }
            long[] powers = new long[i / 2];
            powers[powers.Length - 1] = exp;
            for(int j = powers.Length - 2; j >= 0; j--)
            {
                powers[j] = powers[j + 1] / divisor;
            }
            return (Array.BinarySearch(powers, num) >= 0);
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

        public static long[][] GetPascalsTriangle(int row)
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

            return rows;
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

        public static List<long> FindProperDivisors(long n)
        {
            List<long> result = new List<long>() { 1 };
            for(long i = 2; i <= Math.Sqrt(n); i++)
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

        public static int CountDivisors(int n)
        {
            int r = 0;
            if(n == 1)
            {
                return 1;
            }
            int i;
            for(i = 1; i < Math.Sqrt(n); i++)
            {
                if(n % i == 0)
                {
                    r += 2;
                }
            }
            if(i * i == n)
            {
                r++;
            }
            return r;
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

        public static List<List<T>> Permute<T>(List<T> list)
        {
            List<List<T>> result = new List<List<T>>();
            if(list.Count == 0)
            {
                return null;
            }

            Permute(list, new List<T>(), result);
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

        private static void Permute<T>(List<T> remaining, List<T> current, List<List<T>> temp)
        {
            if(remaining.Count == 0)
            {
                temp.Add(current);
                return;
            }
            int remainingLength = remaining.Count;
            for(int i = 0; i < remainingLength; i++)
            {
                List<T> newRemaining = new List<T>(remaining);
                List<T> newCurrent = new List<T>(current);
                newCurrent.Add(remaining[i]);
                newRemaining.RemoveAt(i);
                Permute(newRemaining, newCurrent, temp);
            }
        }

        public static IEnumerable<IEnumerable<T>> Combinations<T>(this IEnumerable<T> elements, int k)
        {
            return k == 0 ? new[] { new T[0] } :
              elements.SelectMany((e, i) =>
                elements.Skip(i + 1).Combinations(k - 1).Select(c => (new[] { e }).Concat(c)));
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

        public static int LeastCommonMultiple(int a, int b)
        {
            return (a * b) / GreatestCommonDivisor(a, b);
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
                if(Primes.Contains(n))
                {
                    result.Add(n);
                    return result;
                }
            }
            return result;
        }

        public static List<int> Totient(int n)
        {
            List<int> result = Enumerable.Range(1, n).ToList();
            for(int i = 2; i <= n; i++)
            {
                if(n % i == 0)
                {
                    result.RemoveAll(x => ((x % i) == 0));
                }
            }
            return result;
        }

        public static bool IsPermutation(string s1, string s2)
        {
            if(s1.Length != s2.Length)
            {
                return false;
            }
            char[] c1 = s1.ToCharArray(), c2 = s2.ToCharArray();
            Array.Sort(c1);
            Array.Sort(c2);
            for(int i = 0; i < c1.Length; i++)
            {
                if(c1[i] != c2[i])
                {
                    return false;
                }
            }
            return true;

        }

        public static void Shuffle<T>(T[] array)
        {
            Random r = new Random();
            for(int i = 0; i < array.Length; i++)
            {
                Swap(array, i, r.Next(array.Length));
            }
        }

        public static void Swap<T>(T[] array, int i1, int i2)
        {
            T temp = array[i1];
            array[i1] = array[i2];
            array[i2] = temp;
        }

        public static T[][] DeepCopy<T>(T[][] array)
        {
            T[][] copied = new T[array.Length][];
            for(int r = 0; r < copied.Length; r++)
            {
                copied[r] = new T[array[r].Length];
                for(int c = 0; c < copied[r].Length; c++)
                {
                    var copy = array[r][c] as ICloneable;
                    if(copy == null)
                    {
                        copied[r][c] = array[r][c];
                    }
                    else
                    {
                        copied[r][c] = (T)copy.Clone();
                    }
                    
                }
            }
            return copied;
        }

        public static long ModFactorial(long n, long mod)
        {
            long result = 1;
            for(long i = n + 1; i < mod; i++)
            {
                result = (result * i) % mod;
            }
            result = ModInverse(result, mod);
            result = mod - result;
            return result;
        }

        public static long ModInverse(long n, long mod)
        {
            long t = 0;
            long r = mod;
            long newT = 1;
            long newR = n;
            while(newR != 0)
            {
                long quo = r / newR;

                long tmp = t;
                t = newT;
                newT = tmp - quo * newT;

                tmp = r;
                r = newR;
                newR = tmp - quo * newR;
            }
            return t < 0 ? t + mod : t;
        }


    }
}
