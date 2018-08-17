using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerProblems
{
    public class Problem144
    {
        public static int Solve()
        {
            Tuple<double, double> point = new Tuple<double, double>(0, 10.1);
            double slope = (-9.6 - 10.1) / 1.4;
            int count = -1;
            do
            {
                count++;
                point = NewPoint(slope, point);
                slope = NewSlope(slope, point);
            } while((point.Item1 > 0.01 || point.Item1 < -0.01) || point.Item2 < 0);
            return count;
        }

        public static double NewSlope(double slope, Tuple<double, double> point)
        {
            double tangentSlope = -4 * point.Item1 / point.Item2;
            double tangentAngle = (slope - tangentSlope) / (1 + tangentSlope * slope);
            return (tangentSlope - tangentAngle) / (1 + tangentAngle * tangentSlope);
        }

        public static Tuple<double, double> NewPoint(double slope, Tuple<double, double> point)
        {
            double m = slope;
            double x1 = point.Item1;
            double y1 = point.Item2;
            double y0 = y1 - m * x1;
            double a = 4 + m * m;
            double b = 2 * m * y0;
            double c = y0 * y0 - 100;
            double xPlus = (-b + Math.Sqrt(b * b - 4 * a * c)) / (2 * a);
            double xNeg = (-b - Math.Sqrt(b * b - 4 * a * c)) / (2 * a);
            double xPlusDiff = Math.Abs(x1 - xPlus);
            double xNegDiff = Math.Abs(x1 - xNeg);
            if(xPlusDiff > xNegDiff)
            {
                return new Tuple<double, double>(xPlus, (m * xPlus) + y0);
            }
            else
            {
                return new Tuple<double, double>(xNeg, (m * xNeg) + y0);
            }
        }
    }
}
