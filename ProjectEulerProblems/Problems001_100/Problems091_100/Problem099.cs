using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerProblems
{
    public class Problem099
    {
        public static int Solve()
        {
            string[] lines = File.ReadAllLines(@"..\..\txt\Problem099Text.txt");
            int[] nums = new int[lines.Length];
            int[] pows = new int[lines.Length];
            for(int i = 0; i < lines.Length; i++)
            {
                string[] split = lines[i].Split(',');
                nums[i] = int.Parse(split[0]);
                pows[i] = int.Parse(split[1]);
            }
            double max = 0;
            int maxIndex = 0;
            for(int i = 0; i < nums.Length; i++)
            {
                double curr = Math.Log(nums[i]) * pows[i];
                if(curr > max)
                {
                    max = curr;
                    maxIndex = i + 1;
                }
            }

            return maxIndex;
        }
    }
}
