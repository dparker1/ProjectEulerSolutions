using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerProblems
{
    public class Problem072
    {
        public static long Solve()
        {
            long count = 0;
            List<int> nums = Enumerable.Range(0, 1000001).ToList();
            for(int i = 2; i < nums.Count; i++)
            {
                if(i == nums[i])
                {
                    for(int z = i; z < nums.Count; z+=i)
                    {
                        nums[z] = nums[z] / i * (i - 1);
                    }
                }
                count += nums[i];
            }
            return count;
        }
    }
}
