using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerProblems
{
    public class Problem024
    {
        public static string Solve()
        {
            List<string> permutations = EulerUtilities.Permute("0123456789");
            return permutations[999999];
        }
    }
}
