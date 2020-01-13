using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerProblems
{
    public class Problem607
    {
        static double[] speeds = new double[] { 10, 9, 8, 7, 6, 5, 10 };
        static double verticalGoal = 50 * Math.Sqrt(2);
        static double distanceToMarsh = 25 * (Math.Sqrt(2) - 1);
        public static double Solve()
        {
            double x = 0;
            double delta = 1;
            while(delta > 0.00000001)
            {
                double val = CalculateTime(x);
                if(CalculateTime(x + delta) < val)
                {
                    x += delta;
                }
                else
                {
                    x -= delta;
                    delta /= 10;
                }
            }
            return CalculateTime(x);
        }

        public static double CalculateTime(double startAngle)
        {
            double y = distanceToMarsh * Math.Tan(startAngle);
            double time = distanceToMarsh / Math.Cos(startAngle) / speeds[0];
            double angle = startAngle;

            for(int i = 1; i <= 5; i++)
            {
                angle = Math.Asin(speeds[i] / speeds[i - 1] * Math.Sin(angle));
                y += 10 * Math.Tan(angle);
                time += 10 / Math.Cos(angle) / speeds[i];
            }

            time += Math.Sqrt(Math.Pow(verticalGoal - y, 2) + Math.Pow(distanceToMarsh, 2)) / speeds[6];
            return time;
        }
    }
}
