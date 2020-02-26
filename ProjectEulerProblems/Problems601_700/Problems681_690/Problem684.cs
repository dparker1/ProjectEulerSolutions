using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerProblems
{
    public class Problem684
    {
        public static int Solve()
        {
            long mod = 1000000007;
            List<long> fibonacci = EulerUtilities.FibonacciLimit(91);
            fibonacci.RemoveAt(0);
            return fibonacci.Count;
        }
    }
}
