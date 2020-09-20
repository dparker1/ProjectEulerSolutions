using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerProblems
{
    public class Problem689
    {
        static double ToRad = Math.PI / 180;
        static double TwoPi = Math.PI * 2;
        static double PiSq = Math.PI * Math.PI;
        public static double Solve()
        {
            double result = 0;
            for(int i = 0; i < 200; i++)
            {
                int t = 2 * i + 1;
                result += Math.Sin(TwoPi * t * PiSq / 12) * g(TwoPi * t) / t;
            }
            result /= Math.PI;
            result += 0.25;
            return 1 - result;
        }

        public static double g(double t)
        {
            double res = 1;
            for(int i = 1; i < 500; i++)
            {
                res *= Math.Cos(t / (2 * i * i));
            }
            return res;
        }
    }
}
