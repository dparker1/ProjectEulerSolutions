using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerProblems
{
    public class Problem088
    {
        public static int Solve()
        {
            int limit = 12000;
            Dictionary<int, int> map = Build(2 * limit);
            HashSet<int> uniques = new HashSet<int>();
            for(int i = 2; i <= limit; i++)
            {
                uniques.Add(map[i]);
            }
            return uniques.Sum();
        }

        public static Dictionary<int, int> Build(int limit)
        {
            List<int> nums = new List<int>();
            Dictionary<int, int> result = new Dictionary<int, int>();
            bool stop = false;
            nums.Add(2);
            nums.Add(2);
            while(!stop)
            {
                int product = 1;
                int sum = 0;
                foreach(int x in nums)
                {
                    product *= x;
                    sum += x;
                }
                int ones = product - sum;
                int length = nums.Count + ones;
                if(result.ContainsKey(length))
                {
                    int oldValue = result[length];
                    if(oldValue > product)
                    {
                        result[length] = product;
                    }
                }
                else
                {
                    result.Add(length, product);
                }
                List<int> numsTemp = new List<int>(nums);
                for(int i = numsTemp.Count - 1; i >= 0; i--)
                {
                    int productTemp = 1;
                    numsTemp[i]++;
                    foreach(int x in numsTemp)
                    {
                        productTemp *= x;
                    }
                    if(productTemp <= limit)
                    {
                        break;
                    }
                    else
                    {
                        int val = 2;
                        int s = 0;
                        if(i > 0)
                        {
                            val = numsTemp[i - 1] + 1;
                            s = i - 1;
                        }
                        else
                        {
                            numsTemp.Insert(0, val);
                        }
                        for(int j = s; j < numsTemp.Count; j++)
                        {
                            numsTemp[j] = val;
                        }
                        productTemp = 1;
                        foreach(int x in numsTemp)
                        {
                            productTemp *= x;
                        }
                        if(productTemp <= limit)
                        {
                            break;
                        }
                        else if(i == 0)
                        {
                            stop = true;
                            break;
                        }
                    }
                }
                nums = numsTemp;
            }
            return result;
        }
    }
}
