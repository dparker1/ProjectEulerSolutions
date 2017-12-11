using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerProblems
{
    public class Problem039
    {
        public static int Solve()
        {
            int max = 0, count, maxPerim = 0;
            double c, perimeter;
            for(int perim = 120; perim <= 1000; perim++)
            {
                count = 0;
                for(int a = 1; a <= perim / 2; a++)
                {
                    for(int b = 1; b <= perim / 2; b++)
                    {
                        c = Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2));
                        perimeter = a + b + c;
                        if(perimeter == perim && EulerUtilities.IsWholeNumber(perimeter))
                        {
                            count++;
                        }
                    }
                }
                if(count > max)
                {
                    max = count;
                    maxPerim = perim;
                }
            }
            return maxPerim;
        }
    }
}
