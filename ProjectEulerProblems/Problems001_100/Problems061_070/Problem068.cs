using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerProblems
{
    public class Problem068
    {
        public static string Solve()
        {
            List<string> results = new List<string>();
            int[][] array = new int[5][];
            array[0] = new int[3];
            array[1] = new int[3];
            array[2] = new int[3];
            array[3] = new int[3];
            array[4] = new int[3];
            List<int> remaining = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            foreach(IEnumerable<int> combo1 in remaining.Combinations(3))
            {
                List<List<int>> permutations1 = EulerUtilities.Permute(combo1.ToList());
                List<int> temp1 = new List<int>(remaining);
                temp1.RemoveAll(x => combo1.Contains(x));
                int targetSum = combo1.Sum();
                foreach(List<int> s1 in permutations1)
                {
                    array[0][0] = s1[0];
                    array[0][1] = s1[1];
                    array[0][2] = s1[2];
                    array[1][1] = array[0][2];
                    foreach(IEnumerable<int> combo2 in temp1.Combinations(2))
                    {
                        List<List<int>> permutations2 = EulerUtilities.Permute(combo2.ToList());
                        List<int> temp2 = new List<int>(temp1);
                        temp2.RemoveAll(x => combo2.Contains(x));
                        foreach(List<int> s2 in permutations2)
                        {
                            array[1][0] = s2[0];
                            array[1][2] = s2[1];
                            array[2][1] = array[1][2];
                            if(array[1].Sum() != targetSum)
                            {
                                break;
                            }
                            foreach(IEnumerable<int> combo3 in temp2.Combinations(2))
                            {
                                List<List<int>> permutations3 = EulerUtilities.Permute(combo3.ToList());
                                List<int> temp3 = new List<int>(temp2);
                                temp3.RemoveAll(x => combo3.Contains(x));
                                foreach(List<int> s3 in permutations3)
                                {
                                    array[2][0] = s3[0];
                                    array[2][2] = s3[1];
                                    array[3][1] = array[2][2];
                                    
                                    if(array[2].Sum() != targetSum)
                                    {
                                        break;
                                    }
                                    foreach(IEnumerable<int> combo4 in temp3.Combinations(2))
                                    {
                                        List<List<int>> permutations4 = EulerUtilities.Permute(combo4.ToList());
                                        List<int> temp4 = new List<int>(temp3);
                                        temp4.RemoveAll(x => combo4.Contains(x));
                                        foreach(List<int> s4 in permutations4)
                                        {
                                            array[3][0] = s4[0];
                                            array[3][2] = s4[1];
                                            array[4][1] = array[3][2];
                                            array[4][0] = temp4.First();
                                            array[4][2] = array[0][1];
                                            if(array[3].Sum() != targetSum)
                                            {
                                                break;
                                            }
                                            if(array[4].Sum() == targetSum)
                                            {
                                                results.Add(Concatenate(array));
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                
            }
            BigInteger max = 0;
            foreach(string s in results)
            {
                if(s.Length == 16)
                {
                    Console.WriteLine(s);
                    BigInteger l = BigInteger.Parse(s);
                    if(l > max)
                    {
                        max = l;
                    }
                }
            }
            return max.ToString();
        }

        public static string Concatenate(int[][] arrays)
        {
            string result = "";
            int minOuterNode = 11, minIndex = 0;
            for(int i = 0; i < arrays.Length; i++)
            {
                if(arrays[i][0] < minOuterNode)
                {
                    minOuterNode = arrays[i][0];
                    minIndex = i;
                }
            }
            for(int i = 0; i < arrays.Length; i++)
            {
                for(int j = 0; j < arrays[i].Length; j++)
                {
                    result += arrays[(minIndex + i) % arrays.Length][j];
                }
            }
            return result;
        }

    }
}
