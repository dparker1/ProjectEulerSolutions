using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerProblems
{
    public class Problem074
    {
        public static int Solve()
        {
            List<int> successfulStarts = new List<int>();
            List<int> chain = new List<int>();
            for(int i = 3; i < 1000000; i++)
            {
                chain.Add(i);
                int current = (int) i.ToString().Sum(x => EulerUtilities.Factorial(x - 48));
                while(!chain.Contains(current))
                {
                    chain.Add(current);
                    current = (int) current.ToString().Sum(x => EulerUtilities.Factorial(x - 48));
                    if(chain.Count == 60 && chain.Contains(current))
                    {
                        successfulStarts.Add(i);
                    }
                    if(chain.Count > 60)
                    {
                        break;
                    }
                }
                chain.Clear();
            }
            return successfulStarts.Count;
        }
    }
}
