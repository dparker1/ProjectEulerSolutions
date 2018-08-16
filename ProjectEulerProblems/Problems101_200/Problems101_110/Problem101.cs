using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerProblems
{
    // 1 − n + n2 − n3 + n4 − n5 + n6 − n7 + n8 − n9 + n10
    public class Problem101
    {
        public static long Solve()
        {
            List<long> sequence = new List<long>();
            for(long n = 1; n < 11; n++)
            {
                long val = 1 - n + (long)Math.Pow(n, 2) - (long)Math.Pow(n, 3) + (long)Math.Pow(n, 4) - (long)Math.Pow(n, 5) + (long)Math.Pow(n, 6) - (long)Math.Pow(n, 7) + (long)Math.Pow(n, 8) - (long)Math.Pow(n, 9) + (long)Math.Pow(n, 10);
                sequence.Add(val);
            }

            List<List<long>> rows = new List<List<long>>();
            rows.Add(sequence);
            long sum = sequence.Sum();
            while(rows.Last().Count > 1)
            {
                List<long> row = new List<long>();
                for(int i = 0; i < rows.Last().Count - 1; i++)
                {
                    row.Add(rows.Last()[i + 1] - rows.Last()[i]);
                }
                rows.Add(row);
                sum += row.Sum();
            }
            return sum;
        }
    }
}
