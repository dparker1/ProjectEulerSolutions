using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerProblems
{
    public class Problem493
    {
        public static double Solve()
        {
            int n = 7, m = 20, balls = 70;
            double probability = 1;
            for(int i = 0; i < m; i++)
            {
                probability *= (double)(balls - 10) / balls;
                balls--;
            }
            return n * (1 - probability);
        }
    }
}
