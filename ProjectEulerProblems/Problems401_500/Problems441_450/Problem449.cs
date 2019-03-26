using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CenterSpace.NMath.Core;

namespace ProjectEulerProblems
{
    public class Problem449
    {
        static double a = 1;
        static double b = 3;
        static double d = 1;
        public static double Solve()
        {
            Func<double, double> d = new Func<double, double>(function);
            OneVariableFunction f = new OneVariableFunction(d);
            double x = f.Integrate(0, Math.PI / 2);
            double outVolume = -2 * Math.PI * x;
            double inVolume = 4 * Math.PI * b * b * a / 3;
            return outVolume - inVolume;
        }

        public static double function(double t)
        {
            return Math.Pow(b * Math.Sin(t) + (a * d * Math.Sin(t) / Math.Sqrt(b * b * Math.Pow(Math.Cos(t), 2) + a * a * Math.Pow(Math.Sin(t), 2))), 2) * a * Math.Sin(t) * (-2 * Math.Sqrt(2) * a * b * d / (Math.Pow(a * a + b * b + (b * b - a * a) * Math.Cos(2 * t), (3.0 / 2.0)))-1);
        }
        
    }
}
