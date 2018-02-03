using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ProjectEulerProblems
{
    public class Problem096
    {
        public static int Solve()
        {
            int sum = 0;
            string[] lines = File.ReadAllLines(@"..\..\txt\Problem096Text.txt");
            List<int[][]> grids = new List<int[][]>();
            int gridNumber = -1, rowNumber = 0;
            foreach(string line in lines)
            {
                if(line.StartsWith("Grid"))
                {
                    rowNumber = 0;
                    gridNumber++;
                    grids.Add(new int[9][]);
                    continue;
                }
                grids[gridNumber][rowNumber] = Array.ConvertAll(line.ToCharArray(), x => x - 48);
                rowNumber++;
            }
            for(int i = 0; i < grids.Count; i++)
            {
                grids[i] = SudokuSolve(grids[i], null);
                sum += (grids[i][0][0] * 100) + (grids[i][0][1] * 10) + grids[i][0][2];
            }
            return sum;
        }

        public static int[][] SudokuSolve(int[][] solved, string[][] viableNumbers)
        {
            if(viableNumbers == null)
            {
                viableNumbers = new string[9][];
                for(int r = 0; r < 9; r++)
                {
                    viableNumbers[r] = new string[9];
                    for(int c = 0; c < 9; c++)
                    {
                        if(solved[r][c] == 0)
                        {
                            viableNumbers[r][c] = "123456789";
                        }
                        else
                        {
                            viableNumbers[r][c] = null;
                        }
                    }
                }
                for(int r = 0; r < 9; r++)
                {
                    for(int c = 0; c < 9; c++)
                    {
                        if(solved[r][c] != 0)
                        {
                            RemoveViables(solved, viableNumbers, r, c);
                        }
                    }
                }
            }

            return SudokuSolveRecur(solved, viableNumbers);

            
        }

        public static int[][] SudokuSolveRecur(int[][] solved, string[][] viableNumbers)
        {
            while(ContainsBlank(solved))
            {
                int row, column, viables;
                FindMinimumViable(solved, viableNumbers).Deconstruct(out row, out column, out viables);
                if(viables == 1)
                {
                    solved[row][column] = int.Parse(viableNumbers[row][column]);
                    viableNumbers[row][column] = null;
                    RemoveViables(solved, viableNumbers, row, column);
                }
                else if(viables > 1)
                {
                    foreach(char num in viableNumbers[row][column])
                    {
                        int[][] solvedTemp = EulerUtilities.DeepCopy(solved);
                        string[][] viablesTemp = EulerUtilities.DeepCopy(viableNumbers);
                        solved[row][column] = (num - 48);
                        viableNumbers[row][column] = null;
                        RemoveViables(solved, viableNumbers, row, column);
                        solved = SudokuSolve(solved, viableNumbers);
                        if(!ContainsBlank(solved))
                        {
                            return solved;
                        }
                        else
                        {
                            solved = solvedTemp;
                            viableNumbers = viablesTemp;
                        }
                    }
                    return solved;
                }
                else
                {
                    return solved;
                }
            }
            return solved;


        }

        public static void RemoveViables(int[][] solved, string[][] viableNumbers, int row, int column)
        {
            RemoveViableRow(solved, viableNumbers, row);
            RemoveViableColumn(solved, viableNumbers, column);
            RemoveViableBlock(solved, viableNumbers, row, column);
        }

        public static void RemoveViableRow(int[][] solved, string[][] viableNumbers, int row)
        {
            for(int column = 0; column < 9; column++)
            {
                if(solved[row][column] != 0)
                {
                    for(int c = 0; c < 9; c++)
                    {
                        if(solved[row][c] == 0 && viableNumbers[row][c] != null)
                        {
                            viableNumbers[row][c] = viableNumbers[row][c].Replace(solved[row][column].ToString(), "");
                        }
                    }
                }
            }
        }

        public static void RemoveViableColumn(int[][] solved, string[][] viableNumbers, int column)
        {
            for(int row = 0; row < 9; row++)
            {
                if(solved[row][column] != 0)
                {
                    for(int r = 0; r < 9; r++)
                    {
                        if(solved[r][column] == 0 && viableNumbers[r][column] != null)
                        {
                            viableNumbers[r][column] = viableNumbers[r][column].Replace(solved[row][column].ToString(), "");
                        }
                    }
                }
            }
        }

        public static void RemoveViableBlock(int[][] solved, string[][] viableNumbers, int row, int column)
        {
            RemoveViableSpecifiedBlock(solved, viableNumbers, (row / 3) * 3 + (column / 3), solved[row][column]);
        }

        public static void RemoveViableSpecifiedBlock(int[][] solved, string[][] viableNumbers, int block, int number)
        {
            for(int row = (block / 3) * 3; row < (block / 3) * 3 + 3; row++)
            {
                for(int column = (block % 3) * 3; column < (block % 3) * 3 + 3; column++)
                {
                    if(solved[row][column] != number && viableNumbers[row][column] != null)
                    {
                        viableNumbers[row][column] = viableNumbers[row][column].Replace(number.ToString(), "");
                    }
                }
            }
        }

        public static Tuple<int, int, int> FindMinimumViable(int[][] solved, string[][] viableNumbers)
        {
            Tuple<int, int, int> result = null;
            int min = 10;
            for(int r = 0; r < 9; r++)
            {
                for(int c = 0; c < 9; c++)
                {
                    if(viableNumbers[r][c] != null && viableNumbers[r][c].Length < min)
                    {
                        min = viableNumbers[r][c].Length;
                        result = new Tuple<int, int, int>(r, c, min);
                    }
                }
            }
            return result;
        }

        public static bool ContainsBlank(int[][] array)
        {
            foreach(int[] row in array)
            {
                foreach(int i in row)
                {
                    if(i == 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public static void PrintArray<T>(T[][] array)
        {
            for(int r = 0; r < array.Length; r++)
            {
                for(int c = 0; c < array[r].Length - 1; c++)
                {
                    Console.Write(array[r][c] + " ");
                }
                Console.WriteLine(array[r][array[r].Length - 1]);
            }
        }

    }
}
