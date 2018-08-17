using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerProblems
{
    public class Problem086
    {
        public static int Solve()
        {
            int M = 2;
            int count = 0;
            while(count < 1000000)
            {
                M++;
                int M2 = M * M;
                int wh;
                double d;
                for(int w = 1; w <= M; w++)
                {
                    for(int h = 1; h <= w; h++)
                    {
                        wh = w + h;
                        d = Math.Sqrt(M2 + wh * wh);
                        if(d == (int)d)
                        {
                            count++;
                        }
                    }
                }
            }
            return M;
        }
    }
}
