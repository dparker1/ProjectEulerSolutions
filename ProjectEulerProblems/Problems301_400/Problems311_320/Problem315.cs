using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerProblems
{
    public class Problem315
    {
        static List<Tuple<List<bool>, int>> digitalBars; 
        public static int Solve()
        {
            int totalDiff = 0;
            List<int> primes = EulerUtilities.GeneratePrimes(20000000).Where(x => x > 10000000).ToList().ConvertAll(x => (int)x);

            //top left, top, top right, middle, bottom left, bottom, bottom right
            digitalBars = new List<Tuple<List<bool>, int>>();
            digitalBars.Add(new Tuple<List<bool>, int>(new List<bool>(new bool[] { true, true, true, false, true, true, true }), 6));
            digitalBars.Add(new Tuple<List<bool>, int>(new List<bool>(new bool[] { false, false, true, false, false, false, true }), 2));
            digitalBars.Add(new Tuple<List<bool>, int>(new List<bool>(new bool[] { false, true, true, true, true, true, false }), 5));
            digitalBars.Add(new Tuple<List<bool>, int>(new List<bool>(new bool[] { false, true, true, true, false, true, true }), 5));
            digitalBars.Add(new Tuple<List<bool>, int>(new List<bool>(new bool[] { true, false, true, true, false, false, true }), 4));
            digitalBars.Add(new Tuple<List<bool>, int>(new List<bool>(new bool[] { true, true, false, true, false, true, true }), 5));
            digitalBars.Add(new Tuple<List<bool>, int>(new List<bool>(new bool[] { true, true, false, true, true, true, true }), 6));
            digitalBars.Add(new Tuple<List<bool>, int>(new List<bool>(new bool[] { true, true, true, false, false, false, true }), 4));
            digitalBars.Add(new Tuple<List<bool>, int>(new List<bool>(new bool[] { true, true, true, true, true, true, true }), 7));
            digitalBars.Add(new Tuple<List<bool>, int>(new List<bool>(new bool[] { true, true, true, true, false, true, true }), 6));
            foreach(int p in primes)
            {
                totalDiff += SamClock(p);
                totalDiff -= MaxClock(p);
            }
            return totalDiff;
        }

        private static int BarDifference(List<bool> s, List<bool> t)
        {
            int count = 0;
            for(int i = 0; i < s.Count; i++)
            {
                if(s[i] && !t[i])
                {
                    count++;
                }
                if(!s[i] && t[i])
                {
                    count++;
                }
            }
            return count;
        }

        private static int BarCount(List<bool> l)
        {
            int count = 0;
            foreach(bool b in l)
            {
                if(b)
                {
                    count++;
                }
            }
            return count;
        }

        private static Tuple<int, int> DigitalRootAndCount(int n)
        {
            int root = 0;
            int count = 0;
            int rem = 0;
            while(n != 0)
            {
                rem = n % 10;
                root += rem;
                count += digitalBars[rem].Item2;
                n /= 10;
            }
            return new Tuple<int, int>(root, count);
        }

        private static int MaxClock(int n)
        {
            int total = 0;
            List<List<bool>> bars = new List<List<bool>>();
            List<List<bool>> nextBars = new List<List<bool>>();
            int rem;
            int temp = n;
            int nextN;
            bool singleDigit = false;
            while(n / 10 != 0 || !singleDigit)
            {
                if(n / 10 == 0)
                {
                    singleDigit = true;
                }
                nextN = 0;
                temp = n;
                nextBars = new List<List<bool>>();
                while(temp != 0)
                {
                    rem = temp % 10;
                    nextN += rem;
                    temp /= 10;
                    nextBars.Insert(0, digitalBars[rem].Item1);
                    if(bars.Count == 0)
                    {
                        total += digitalBars[rem].Item2;
                    }
                    else
                    {
                        total += BarDifference(bars.Last(), nextBars.First());
                        bars.RemoveAt(bars.Count - 1);
                    }
                }
                
                if(bars.Count != 0)
                {
                    foreach(List<bool> bar in bars)
                    {
                        total += BarCount(bar);
                    }
                }
                bars = nextBars;
                n = nextN;
            }
            total += digitalBars[n].Item2;
            return total;
        }

        private static int SamClock(int n)
        {
            int total = 0;
            while(n / 10 != 0)
            {
                Tuple<int, int> t = DigitalRootAndCount(n);
                total += t.Item2 * 2;
                n = t.Item1;
            }
            total += digitalBars[n].Item2 * 2;
            return total;
        }
    }
}
