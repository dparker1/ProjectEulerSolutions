using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerProblems
{
    public class Problem046
    {
        public static int Solve()
        {
            int compMinusTwoSquare = 0, square = 1;
            int answer = 0;
            bool found = false;
            for(int composite = 35; composite < int.MaxValue && !found; composite += 2)
            {
                if(EulerUtilities.IsPrime(composite))
                {
                    continue;
                }

                square = 1;
                do
                {
                    compMinusTwoSquare = composite - 2 * (int)Math.Pow(square, 2);
                    square++;
                    if(EulerUtilities.IsPrime(compMinusTwoSquare))
                    {
                        break;
                    }
                } while(compMinusTwoSquare > 0);

                if(compMinusTwoSquare < 0)
                {
                    found = true;
                    answer = composite;
                }
            }
            return answer;
        }
    }
}
