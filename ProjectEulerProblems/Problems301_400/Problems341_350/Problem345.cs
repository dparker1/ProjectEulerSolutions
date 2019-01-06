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

            return MinAssignmentCost(adjustedNumbers, numbers);
        }

        public static int MinAssignmentCost(int[][] a, int[][] original)
        {
            HashSet<int> takenRows = new HashSet<int>();
            HashSet<int> takenCols = new HashSet<int>();
            List<Tuple<int, int>> assignments = new List<Tuple<int, int>>();
            while(takenRows.Count < a.Length)
            {
                Tuple<int, int> minIndex = MinimumFromRemaining(takenRows, takenCols, a);
                assignments.Add(minIndex);
                takenRows.Add(minIndex.Item1);
                takenCols.Add(minIndex.Item2);
            }
            int[][] temp = EulerUtilities.DeepCopy(a);
            foreach(var ass in assignments)
            {
                for(int c = 0; c < a[ass.Item1].Length; c++)
                {
                    temp[ass.Item1][c] -= a[ass.Item1][ass.Item2];
                }
            }
            Tuple<int, int> leastReducedCost = Minimum(temp);
            SwapAssignments(assignments, leastReducedCost.Item1, leastReducedCost.Item2);
            return 0;
        }

        public static Tuple<int, int> MinimumFromRemaining(HashSet<int> takenR, HashSet<int> takenC, int[][] a)
        {
            int min = int.MaxValue;
            Tuple<int, int> result = null;
            for(int r = 0; r < a.Length; r++)
            {
                if(!takenR.Contains(r))
                {
                    for(int c = 0; c < a[r].Length; c++)
                    {
                        if(!takenC.Contains(c) && a[r][c] < min)
                        {
                            result = new Tuple<int, int>(r, c);
                            min = a[r][c];
                        }
                    }
                }
            }
            return result;
        }

        public static Tuple<int, int> Minimum(int[][] a)
        {
            int min = int.MaxValue;
            Tuple<int, int> result = null;
            for(int r = 0; r < a.Length; r++)
            {
                for(int c = 0; c < a[r].Length; c++)
                {
                    if(a[r][c] < min)
                    {
                        min = a[r][c];
                        result = new Tuple<int, int>(r, c);
                    }
                }
            }
            return result;
        }

        public static void SwapAssignments(List<Tuple<int, int>> assignments, int source, int sink)
        {
            var ass1 = assignments.Find(x => x.Item1 == source);
            var ass2 = assignments.Find(x => x.Item2 == sink);
            var temp1 = new Tuple<int, int>(ass1.Item1, ass2.Item2);
            var temp2 = new Tuple<int, int>(ass2.Item1, ass1.Item2);
            int i1 = assignments.IndexOf(ass1), i2 = assignments.IndexOf(ass2);
            assignments[i1] = temp1;
            assignments[i2] = temp2;
        }
    }
}
