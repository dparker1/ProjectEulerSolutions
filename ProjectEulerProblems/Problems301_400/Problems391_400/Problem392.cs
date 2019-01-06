using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerProblems
{
    public class Problem392
    {
        public static double Solve()
        {
            double area = 100;
            double minX = 0, minY = 0, minZ = 0, minQ = 0;
            for(double x = 20; x <= 30; x += 0.1)
            {
                for(double y = 35; y <= 41; y += 0.1)
                {
                    for(double z = 50; z <= 60; z += 0.1)
                    {
                        for(double q = 60; q <= 70; q += 0.1)
                        {
                            double xRad = ToRad(x);
                            double yRad = ToRad(y);
                            double zRad = ToRad(z);
                            double qRad = ToRad(q);
                            double temp = Math.Sin(xRad) + Math.Cos(xRad) * (Math.Sin(yRad) - Math.Sin(xRad)) + Math.Cos(yRad) * (Math.Sin(zRad) - Math.Sin(yRad)) + Math.Cos(zRad) * (Math.Sin(qRad) - Math.Sin(zRad)) + Math.Cos(qRad) * (1 - Math.Sin(qRad));
                            if(temp < area)
                            {
                                minX = x;
                                minY = y;
                                minZ = z;
                                minQ = q;
                                area = temp;
                            }
                        }
                    }
                }
            }
            Console.WriteLine(minX);
            Console.WriteLine(minY);
            Console.WriteLine(minZ);
            Console.WriteLine(minQ);
            return area * 4;
        }

        private static double ToRad(double x)
        {
            return Math.PI * x / 180.0d;
        }
    }
}
