using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics;


namespace ProjectEulerProblems
{
    public class Problem697
    {
        public static double Solve()
        {
            double n = 10000000;
            double x = n / 100;
            double val = F(x, n);
            double correction = 100000;
            while(Math.Abs(0.25 - val) > 0.000001)
            {
                val = F(x + correction, n);
                while(val < 0.25)
                {
                    correction /= 10;
                    val = F(x + correction, n);
                }
                x += correction;
            }
            return x * Math.Log10(Math.E);
        }

        public static double F(double x, double n)
        {
            return SpecialFunctions.GammaUpperRegularized(n, x);
        }
    }
}
