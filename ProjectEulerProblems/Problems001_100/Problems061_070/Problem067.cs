using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerProblems
{
    public class Problem067
    {
        public static int Solve()
        {
            string[] lines = File.ReadAllLines(@"..\..\txt\Problem067Text.txt");
            int[][] triangle = new int[lines.Length][];
            for(int i = 0; i < lines.Length; i++)
            {
                triangle[i] = Array.ConvertAll(lines[i].Split(' '), int.Parse);
            }

            for(int vertical = triangle.Length - 2; vertical >= 0; vertical--)
            {
                for(int lateral = 0; lateral < triangle[vertical].Length; lateral++)
                {
                    int left = triangle[vertical + 1][lateral], right = triangle[vertical + 1][lateral + 1];
                    if(left > right)
                    {
                        triangle[vertical][lateral] += left;
                    }
                    else
                    {
                        triangle[vertical][lateral] += right;
                    }
                }
            }

            return triangle[0][0];
        }
    }
}
