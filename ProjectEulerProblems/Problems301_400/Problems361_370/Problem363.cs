using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerProblems
{
    public class Problem363
    {
        /*
         * x = (1-t)^3 + 3*t*(1-t)^2 + 3*t^2*(1-t)*v
         * y = t^3 + 3*t*v*(1-t)^2 + 3*t^2*(1-t)
         * dx/dt = -9*t^2*v + 6*t^2 + 6*t*v - 6*t
         * dy/dt = 9*t^2*v - 6*t^2 - 12*t*v + 6*t + 3*v
         * 
         * integral(y * dx/dt)dt from 1 to 0 = (-3*v^2 + 12v + 10) / 20
         * 
         * integral(sqrt((dx/dt)^2 + (dy/dt)^2))dt) from 0 to 1 = 1.570796911273925168510196517
         */
        public static double Solve()
        {
            double goal = Math.PI / 2;
            
            return 100 * (1.570796911273925168510196517 - goal) / goal;
        }
    }
}
