using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerProblems
{
    public class Problem045
    {
        public static long Solve()
        {
            List<long> hexagons = new List<long>();
            hexagons.Add(41328); // Hexagon #144
            int index = 145;
            while(!EulerUtilities.IsTriangleNumber(hexagons.Last()) || !EulerUtilities.IsPentagonalNumber(hexagons.Last()))
            {
                hexagons.Add(index * (2 * index - 1));
                index++;
            }
            return hexagons.Last();
        }
    }
}
