using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerProblems
{
    public class Problem085
    {
        public static int Solve()
        {
            int target = 2000000;
            int closestArea = 0, minDistance = 500;
            for(int height = 1; height < 100; height++)
            {
                int startingTerm = (height * height + height) / 2;
                for(int width = 1; width < 100; width++)
                {
                    int rectangles = startingTerm * (width * width + width) / 2;
                    if(Math.Abs(rectangles - target) < minDistance)
                    {
                        minDistance = Math.Abs(rectangles - target);
                        closestArea = height * width;
                    }
                    if(rectangles > 2001000)
                    {
                        break;
                    }
                }
            }
            
            return closestArea;
        }
    }
}
