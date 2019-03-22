using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerProblems
{
    public class Problem317
    {
        public static double Solve()
        {
            double v0 = 20;
            double h0 = 100;
            double g = 9.81;
            double c = g / (2 * v0 * v0);
            double maxHeight = v0 * v0 / (2 * g) + h0;
            // y = maxHeight - c * x^2 -> x = sqrt((maxHeight - y)/c)
            //x^2 = (maxHeight - y)/c
            //integral(x^2 dy) -> (maxHeight * y - 0.5*y^2)/c
            double result = Math.PI * (0.5 * maxHeight * maxHeight) / c;
            return result;
        }
    }
}
