using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerProblems
{
    public class Problem090
    {
        public static int Solve()
        {
            List<int> nums = new List<int>() {0, 1, 2, 3, 4, 5, 6, 7, 8, 6 };
            List<IEnumerable<int>> combos = nums.Combinations(6).ToList();
            List<Tuple<int, int>> goals = new List<Tuple<int, int>>(){new Tuple<int, int>(0, 1),
                                                                      new Tuple<int, int>(0, 4),
                                                                      new Tuple<int, int>(0, 6),
                                                                      new Tuple<int, int>(1, 6),
                                                                      new Tuple<int, int>(2, 5),
                                                                      new Tuple<int, int>(3, 6),
                                                                      new Tuple<int, int>(4, 6),
                                                                      new Tuple<int, int>(6, 4),
                                                                      new Tuple<int, int>(8, 1)};
            int count = 0;
            for(int i = 0; i < combos.Count - 1; i++)
            {
                for(int j = i + 1; j < combos.Count; j++)
                {
                    bool canMake = true;
                    foreach(Tuple<int, int> goal in goals)
                    {
                        if((!combos[i].Contains(goal.Item1) || !combos[j].Contains(goal.Item2)) && (!combos[j].Contains(goal.Item1) || !combos[i].Contains(goal.Item2)))
                        {
                            canMake = false;
                            break;
                        }
                    }
                    if(canMake)
                    {
                        count++;
                    }
                }
            }
            return count;
        }
    }
}
