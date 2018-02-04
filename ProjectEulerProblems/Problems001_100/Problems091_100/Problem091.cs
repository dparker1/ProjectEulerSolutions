using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerProblems
{
    public class Problem091
    {
        public static int Solve()
        {
            int sum = 0;
            int limit = 50;
            for(int x1 = 0; x1 <= limit; x1++)
            {
                for(int y1 = 0; y1 <= limit; y1++)
                {
                    for(int x2 = 0; x2 <= limit; x2++)
                    {
                        for(int y2 = 0; y2 <= limit; y2++)
                        {
                            sum += (IsRightTriangle(x1, y1, x2, y2) ? 1 : 0);
                        }
                    }
                }
            }
            return sum;
        }

        public static bool IsRightTriangle(int x1, int y1, int x2, int y2)
        {
            int dX = Math.Abs(x2 - x1), dY = Math.Abs(y2 - y1);
            if((x1 + y1 == 0) || (x2 + y2 == 0))
            {
                return false;
            }
            if(x2 > x1 && y2 < y1)
            {
                return DistanceSquared(x1, y1) + DistanceSquared(x2, y2) == DistanceSquared(dX, dY);
            }
            if(x1 == x2 && y1 < y2)
            {
                return dY * dY + x1 * x1 == DistanceSquared(x2, y2);
            }
            if(x1 > x2 && y1 == y2)
            {
                return dX * dX + y1 * y1 == DistanceSquared(x1, y1);
            }
            if(x2 < x1 && y2 > y1)
            {   
                return (DistanceSquared(dX, dY) + DistanceSquared(x2, y2) == DistanceSquared(x1, y1) || DistanceSquared(dX, dY) + DistanceSquared(x1, y1) == DistanceSquared(x2, y2));
            }
            return false;
        }

        public static double DistanceSquared(int x, int y)
        {
            return (x * x) + (y * y);
        }
    }
}
