using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerProblems
{
    public class Problem348
    {
        public static int Solve()
        {
            List<int> palins = EulerUtilities.GeneratePalindromes(1000000000);
            int largestPalin = palins.Max();
            List<int> squares = Squares(1000000000);
            List<int> cubes = Cubes(1000000000);
            Dictionary<int, byte> palinCounts = new Dictionary<int, byte>();
            foreach(int p in palins)
            {
                palinCounts[p] = 0;
            }
            foreach(int sqaure in squares)
            {
                foreach(int cube in cubes)
                {
                    int a = sqaure + cube;
                    if(a > largestPalin)
                    {
                        break;
                    }
                    if(palinCounts.ContainsKey(a))
                    {
                        palinCounts[a]++;
                    }
                }
            }
            int sum = 0;
            List<int> sortedKeys = new List<int>(palinCounts.Keys);
            sortedKeys.Sort();
            byte count = 0;
            foreach(int k in sortedKeys)
            {
                if(palinCounts[k] == 4)
                {
                    sum += k;
                    count++;
                }
                if(count == 5)
                {
                    break;
                }
            }
            return sum;
        }

        static List<int> Squares(int max)
        {
            List<int> result = new List<int>();
            result.Add(4);
            for(int i = 3; result.Last() < max; i++)
            {
                result.Add(i * i);
            }
            return result;
        }
        static List<int> Cubes(int max)
        {
            List<int> result = new List<int>();
            result.Add(8);
            for(int i = 3; result.Last() < max; i++)
            {
                result.Add(i * i * i);
            }
            return result;
        }
    }
}
