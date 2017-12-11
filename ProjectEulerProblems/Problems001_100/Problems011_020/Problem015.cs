using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerProblems
{
    public class Problem015
    {
        public static long Solve()
        {
            long[] fortiethRowPacalTriangle = EulerUtilities.GetBinomialCoefficients(40);

            return fortiethRowPacalTriangle[fortiethRowPacalTriangle.Length / 2];
        }
    }
}
