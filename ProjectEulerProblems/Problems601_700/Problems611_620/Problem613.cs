using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerProblems
{
    public class Problem613
    {
        public static double Solve()
        {
            double upper = function(3);
            double lower = function(0.00000000000001);
            return (upper - lower) / (24 * Math.PI);
        }

        public static double function(double t)
        {
            double t2 = t * t;
            return 8*Math.PI*t - 4*Math.PI*t2/3 - 0.5*t2*Math.Log(t2/(t2+16)) - 8*Math.Log(t2+16) - t*Math.Log(15625.0/729) + 8*t*(Math.Atan(4.0/3) - Math.Atan(4/t));
        }
    }
}
