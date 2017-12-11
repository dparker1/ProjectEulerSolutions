using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerProblems
{
    public class Problem031
    {
        public static int Solve()
        {
            int target = 200;
            int[] coins = new int[] { 1, 2, 5, 10, 20, 50, 100, 200 };
            int[] combos = new int[target + 1];
            combos[0] = 1;

            for(int index = 0; index < coins.Length; index++)
            {
                for(int way = coins[index]; way <= target; way++)
                {
                    combos[way] += combos[way - coins[index]];
                }
            }

            return combos[target];
        }
    }
}
