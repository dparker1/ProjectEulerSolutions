using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerProblems
{
    public class Problem009
    {
        public static int Solve()
        {
            for(int a = 10; a < 1000; a++)
            {
                for(int b = 10; b < 1000; b++)
                {
                    double c = Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2));
                    if(a + b + c > 1000)
                    {
                        break;
                    }
                    else if(a + b + c == 1000)
                    {
                        Console.WriteLine(a + " " + b + " " + c);
                        return a * b * (int) c;
                    }
                }
            }
            return 0;
        }
    }
}
