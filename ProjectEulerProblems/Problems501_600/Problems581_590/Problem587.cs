using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerProblems
{
    public class Problem587
    {
        public static int Solve()
        {
            double cutoff = 0.001;
            int n = 15;
            while(AreaPercent(n) > cutoff)
            {
                n++;
            }
            return n;
        }

        private static double AreaPercent(double n)
        {
            double full = 1 - Math.PI / 4;
            int x1 = -1;
            int y1 = -1;
            int x2 = x1 + 2 * (int)n;
            int y2 = 1;
            int r = 1;
            double dx = x2 - x1;
            double dy = y2 - y1;
            double dr = Math.Sqrt(dx * dx + dy * dy);
            double D = x1 * y2 - x2 * y1;
            double xInter = (D * dy - Math.Sign(dy) * dx * Math.Sqrt(r * r * dr * dr - D * D)) / (dr * dr);

            double m = dy / dx;
            double b = -((n - 1) / n);
            double lineIntegral = 0.5 * (1 + xInter)*(2 + 2 * b + (-1 + xInter) * m);
            double circleIntegral = 0.5 * xInter * Math.Sqrt(1 - xInter * xInter) - xInter + 0.5 * Math.Asin(xInter);
            return (lineIntegral + circleIntegral) / full;
        }
    }
}
