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
        public static int n;
        public static int[] lrows;
        public static int[] lcols;
        public static bool[] s;
        public static bool[] t;
        public static int[] matchRow;
        public static int[] matchCol;
        public static int maxMatch;
        public static int[] slack1;
        public static int[] slack2;
        public static int[] prev;
        public static int[][] a;
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
            a = EulerUtilities.DeepCopy(numbers);
            int max = 0;
            for(int i = 0; i < a.Length; i++)
            {
                for(int j = 0; j < a[i].Length; j++)
                {
                    if(a[i][j] > max)
                    {
                        max = a[i][j];
                    }
                }
            }

            for(int i = 0; i < a.Length; i++)
            {
                for(int j = 0; j < a[i].Length; j++)
                {
                    a[i][j] = max - a[i][j];
                }
            }
            int[] assignments = MinAssignmentCost();
            int sum = 0;
            for(int i = 0; i < numbers.Length; i++)
            {
                sum += numbers[i][assignments[i]];
            }
            return sum;
        }

        // https://github.com/antifriz/hungarian-algorithm-n3/blob/master/src/HungarianAlgorithm.cs
        public static int[] MinAssignmentCost()
        {
            n = a.Length;
            lrows = new int[n];
            lcols = new int[n];
            s = new bool[n];
            t = new bool[n];
            matchRow = new int[n];
            matchCol = new int[n];
            maxMatch = 0;
            slack1 = new int[n];
            slack2 = new int[n];
            prev = new int[n];

            InitMatch();
            InitLabels();
            maxMatch = 0;
            InitMatching();
            Queue<int> q = new Queue<int>();
            while(maxMatch != n)
            {
                q.Clear();
                InitST();
                int root = 0;
                int x = 0, y = 0;
                for(x = 0; x < n; x++)
                {
                    if(matchRow[x] != -1)
                    {
                        continue;
                    }
                    q.Enqueue(x);
                    root = x;
                    prev[x] = -2;
                    s[x] = true;
                    break;
                }
                for(int i = 0; i < n; i++)
                {
                    slack1[i] = a[root][i] - lrows[root] - lcols[i];
                    slack2[i] = root;
                }

                while(true)
                {
                    while(q.Count != 0)
                    {
                        x = q.Dequeue();
                        int lRow = lrows[x];
                        for(y = 0; y < n; y++)
                        {
                            if(a[x][y] != lRow + lcols[y] || t[y])
                            {
                                continue;
                            }
                            if(matchCol[y] == -1)
                            {
                                break;
                            }
                            t[y] = true;
                            q.Enqueue(matchCol[y]);
                            AddTree(matchCol[y], x);
                        }
                        if(y < n)
                        {
                            break;
                        }
                    }
                    if(y < n)
                    {
                        break;
                    }
                    Update();
                    for(y = 0; y < n; y++)
                    {
                        if(t[y] || slack1[y] != 0)
                        {
                            continue;
                        }
                        if(matchCol[y] == -1)
                        {
                            x = slack2[y];
                            break;
                        }
                        t[y] = true;
                        if(s[matchCol[y]])
                        {
                            continue;
                        }
                        q.Enqueue(matchCol[y]);
                        AddTree(matchCol[y], slack2[y]);
                    }
                    if(y < n)
                    {
                        break;
                    }
                }
                maxMatch++;

                int ty;
                for(int cx = x, cy = y; cx != -2; cx = prev[cx], cy = ty)
                {
                    ty = matchRow[cx];
                    matchCol[cy] = cx;
                    matchRow[cx] = cy;
                }
            }

            return matchRow;
        }

        public static void InitMatch()
        {
            for(int i = 0; i < n; i++)
            {
                matchRow[i] = -1;
                matchCol[i] = -1;
            }
        }

        public static void InitST()
        {
            for(int i = 0; i < n; i++)
            {
                s[i] = false;
                t[i] = false;
            }
        }

        public static void InitLabels()
        {
            for(int i = 0; i < n; i++)
            {
                int minRow = a[i][0];
                for(int j = 0; j < n; j++)
                {
                    if(a[i][j] < minRow)
                    {
                        minRow = a[i][j];
                    }
                    if(minRow == 0)
                    {
                        break;
                    }
                }
                lrows[i] = minRow;
            }
            for(int j = 0; j < n; j++)
            {
                int minColumn = a[0][j] - lrows[0];
                for(int i = 0; i < n; i++)
                {
                    if(a[i][j] - lrows[i] < minColumn)
                    {
                        minColumn = a[i][j] - lrows[i];
                    }
                    if(minColumn == 0)
                    {
                        break;
                    }
                }
                lcols[j] = minColumn;
            }
        }

        public static void InitMatching()
        {
            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < n; j++)
                {
                    if(a[i][j] != lrows[i] + lcols[j] || matchCol[j] != -1)
                    {
                        continue;
                    }
                    matchRow[i] = j;
                    matchCol[j] = i;
                    maxMatch++;
                    break;
                }
            }
        }

        public static void Update()
        {
            int delta = int.MaxValue;
            for(int i = 0; i < n; i++)
            {
                if(!t[i])
                {
                    if(delta > slack1[i])
                    {
                        delta = slack1[i];
                    }
                }
            }
            for(int i = 0; i < n; i++)
            {
                if(s[i])
                {
                    lrows[i] = lrows[i] + delta;
                }
                if(t[i])
                {
                    lcols[i] = lcols[i] - delta;
                }
                else
                {
                    slack1[i] = slack1[i] - delta;
                }
            }
        }

        public static void AddTree(int x, int prevX)
        {
            s[x] = true;
            prev[x] = prevX;

            int lRow = lrows[x];
            for(int i = 0; i < n; i++)
            {
                if(a[x][i] - lRow - lcols[i] >= slack1[i])
                {
                    continue;
                }
                slack1[i] = a[x][i] - lRow - lcols[i];
                slack2[i] = x;
            }
        }
    }
}
