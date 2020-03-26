using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerProblems
{
    public class Problem235
    {
        static double a = 897, b = 1, d = -3, n = 5000;
        public static double Solve()
        {
            double r = 1.00001;
            double val = Eval(r);
            double step = 0.01;
            double cutoff = -600000000000;
            while(step >= Math.Pow(10, -15))
            {
                r += step;
                val = Eval(r);
                if(val < cutoff)
                {
                    r -= step;
                    step /= 10;
                };
            }
            return r;
        }

        public static double Eval(double r)
        {
            double lessR = 1 - r;
            double powR = Math.Pow(r, n);
            return (a * b - (a + n * d) * b * powR) / lessR + (d * b * r * (1 - powR)) / (lessR * lessR); 
        }
    }
}
