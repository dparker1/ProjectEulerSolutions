using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerProblems
{
    public class Problem197
    {
        static double div = Math.Pow(10, -9);
        public static double Solve()
        {
            double u = -1;
            double u2 = .71;
            for(long i = 0; i <= 1002; i++)
            {
                u2 = F(u);
                u = u2;
            }
            return u + F(u);
        }

        private static double F(double x)
        {
            return Math.Floor(Math.Pow(2, 30.403243784 - x * x)) * div;
        }
    }
}
