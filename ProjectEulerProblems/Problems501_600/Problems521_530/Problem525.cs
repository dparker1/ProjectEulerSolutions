using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CenterSpace.NMath.Core;
using CenterSpace.NMath.Analysis;

namespace ProjectEulerProblems
{
    public class Problem525
    {
        static double a;
        static double b;
        public static double Solve()
        {
            a = 2;
            b = 4;
            Func<double, double> d = new Func<double, double>(ArcLength);
            OneVariableFunction f = new OneVariableFunction(d);
            double x = f.Integrate(0, 2 * Math.PI);
            return x;
        }

        private static double ArcLength(double t)
        {
            return Math.Sqrt(a * a * Math.Pow(Math.Sin(t), 2) + b * b * Math.Pow(Math.Cos(t), 2));
        }
    }
}
