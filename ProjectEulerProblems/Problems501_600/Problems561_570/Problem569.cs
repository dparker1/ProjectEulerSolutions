using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerProblems
{
    public class Problem569
    {
        public static int Solve()
        {
            int size = 2500000;
            List<int> primes = EulerUtilities.GeneratePrimesSmall(100000000);
            primes = primes.Take(2 * size + 1).ToList();
            long[] xs = new long[size + 1];
            int[] ys = new int[size + 1];
            xs[0] = 2;
            ys[0] = 2;
            for(int i = 1; i <= size; i++)
            {
                xs[i] = xs[i - 1] + primes[2 * i - 1] + primes[2 * i];
                ys[i] = ys[i - 1] - primes[2 * i - 1] + primes[2 * i];
            }
            int[] counts = new int[size + 1];
            Parallel.For(1, size, i =>
                counts[i] = P(i, ys, xs)
            );

            return counts.Sum();
        }

        public static int P(int i, int[] ys, long[] xs)
        {
            double min = ((double)(ys[i] - ys[i - 1])) / (xs[i] - xs[i - 1]);
            int count = 1;
            double temp;
            for (int j = i - 2; j >= i / 2; j--)
            {
                temp = ((double)(ys[i] - ys[j])) / (xs[i] - xs[j]);
                if (temp <= min)
                {
                    min = temp;
                    count++;
                }
            }
            return count;
        }
    }
}
