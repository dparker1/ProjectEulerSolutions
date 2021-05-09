using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerProblems
{
    public class Problem285
    {
        public static double Solve()
        {
            double sum = 0;
            for(double k = 1; k <= 100000; k++)
            {
                double lower = k - 0.5;
                double upper = k + 0.5;
                double x_min = (Math.Sqrt(lower * lower - 1) - 1) / k;
                double x_max = (Math.Sqrt(upper * upper - 1) - 1) / k;
                double lower_area = 0;
                if(k > 1)
                {
                    lower_area = F_min(k, x_min) - F_min(k, 0);
                }
                double upper_area = F_max(k, x_max) - F_max(k, 0);
                double area = upper_area - lower_area;
                sum += k * area;
            }
            return sum;
        }

        public static double F_min(double k, double x)
        {
            double k2 = 2 * k - 1;
            double xkplus = x * k + 1;
            return (k2*k2*Math.Asin(2*xkplus/k2) + 2*xkplus*Math.Sqrt(-(2*k*(x-1)+3)*(2*k*(x+1)+1)) - 8*k*x) / (8 * k * k);
        }

        public static double F_max(double k, double x)
        {
            double k2 = 2 * k + 1;
            double xkplus = x * k + 1;
            return (k2 * k2 * Math.Asin(2 * xkplus / k2) + 2 * xkplus * Math.Sqrt(-(2 * k * (x - 1) + 1) * (2 * k * (x + 1) + 3)) - 8 * k * x) / (8 * k * k);
        }
    }
}
