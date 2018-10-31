using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerProblems
{
    public class Problem122
    {
        /*
        1: 0
        2: 1
        3: 2
        4: 2
        5: 3
        6: 3
        7: 4
        8: 3
        9: 4
        10: 4
        */
        public static int Solve()
        {
            for(int i = 2; i < 30; i++)
            {
                Console.WriteLine(i + ": " + EfficientCount(i));
            }
            return 0;
        }

        static int EfficientCount(int k)
        {
            return EfficientCount(k, 1, 0, int.MaxValue, new List<int>(new int[] { 1 }));
        }

        static int EfficientCount(double k, double n, int count, int minCountSoFar, List<int> path)
        {
            if(count >= minCountSoFar)
            {
                return minCountSoFar;
            }
            if(k < n)
            {
                return minCountSoFar;
            }
            if(k == n)
            {
                return count;
            }
            if(k <= 2)
            {
                return (int)k - 1;
            }
            double div = k / n;
            if(div == 2.0)
            {
                return count + 1;
            }
            int minCount = minCountSoFar;
            int x;
            for(int i = 0; i < path.Count; i++)
            {
                if(n + path[i] > k)
                {
                    break;
                }
                List<int> newPath = new List<int>(path);
                newPath.Add((int)n + path[i]);
                x = EfficientCount(k, n + path[i], count + 1, minCountSoFar, newPath);
                minCount = Math.Min(x, minCount);
            }
            return minCount;
        }
    }
}
