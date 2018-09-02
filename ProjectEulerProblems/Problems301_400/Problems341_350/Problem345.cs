using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using ProjectEulerProblems.Structures;

namespace ProjectEulerProblems
{
    public class Problem345
    {
        public static int Solve()
        {
            // http://hungarianalgorithm.com/examplehungarianalgorithm.php
            // https://brilliant.org/wiki/hungarian-matching/
            string[] lines = File.ReadAllLines(@"..\..\txt\Problem345Text.txt");
            int[][] numbers = new int[lines.Length][];
            for(int i = 0; i < lines.Length; i++)
            {
                string[] nums = lines[i].Split(' ');
                numbers[i] = new int[nums.Length];
                for(int j = 0; j < nums.Length; j++)
                {
                    numbers[i][j] = int.Parse(nums[j]);
                }
            }
            int[][] adjustedNumbers = EulerUtilities.DeepCopy(numbers);
            int max = 0;
            for(int i = 0; i < adjustedNumbers.Length; i++)
            {
                for(int j = 0; j < adjustedNumbers[i].Length; j++)
                {
                    if(adjustedNumbers[i][j] > max)
                    {
                        max = adjustedNumbers[i][j];
                    }
                }
            }

            for(int i = 0; i < adjustedNumbers.Length; i++)
            {
                for(int j = 0; j < adjustedNumbers[i].Length; j++)
                {
                    adjustedNumbers[i][j] = max - adjustedNumbers[i][j];
                }
            }

            BipartiteGraph g = new BipartiteGraph();
            g.ConstructFromMatrix(adjustedNumbers);
            return g.MinCost();
        }

        
    }
}
