using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;

namespace ProjectEulerProblems
{
    public class Problem062
    {
        public static double Solve()
        {
            List<string> cubes = new List<string>();
            for(int i = 0; i < 10000; i++)
            {
                cubes.Add(Math.Pow(i, 3).ToString());
            }
            for(int i = 0; i < cubes.Count; i++)
            {
                char[] cube = cubes[i].ToCharArray();
                Array.Sort(cube);
                cubes[i] = String.Join("",cube);
            }
            for(int i = 0; i < cubes.Count; i++)
            {
                if(cubes.Where(x => x.Equals(cubes[i])).Count() == 5)
                {
                    return Math.Pow(cubes.IndexOf(cubes[i]), 3);
                }
            }
            return 0;
        }
        
    }
}
