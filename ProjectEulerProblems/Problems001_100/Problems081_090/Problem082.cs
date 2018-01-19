using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectEulerProblems.Structures;
using System.IO;

namespace ProjectEulerProblems
{
    public class Problem082
    {
        public static double Solve()
        {
            Graph graph = new Graph();
            string[] text = File.ReadAllLines(@"..\..\txt\Problem082Text.txt");
            int[][] array = new int[text.Length][];
            string[][] names = new string[text.Length][];
            for(int i = 0; i < text.Length; i++)
            {
                string[] splitLine = text[i].Split(',');
                array[i] = new int[splitLine.Length];
                names[i] = new string[splitLine.Length];
                for(int j = 0; j < splitLine.Length; j++)
                {
                    array[i][j] = int.Parse(splitLine[j]);
                    names[i][j] = array[i][j] + " " + i + " " + j;
                    graph.AddVertex(new Graph.Vertex(names[i][j]));
                }
            }
            for(int i = 0; i < 80; i++)
            {
                for(int j = 0; j < 80; j++)
                {
                    if(i != 0)
                    {
                        graph.AddEdge(names[i][j], names[i - 1][j], array[i - 1][j]);
                    }
                    if(i != 79)
                    {
                        graph.AddEdge(names[i][j], names[i + 1][j], array[i + 1][j]);
                    }
                    if(j != 79)
                    {
                        graph.AddEdge(names[i][j], names[i][j + 1], array[i][j + 1]);
                    }
                }
            }

            double minDistance = double.PositiveInfinity;
            int minRow = 0;
            for(int row = 0; row < names.Length; row++)
            {
                Console.WriteLine(row);
                graph.DoDijkstra(names[row][0]);
                for(int oppRow = 0; oppRow < names.Length; oppRow++)
                {
                    double pMin = graph.GetVertex(names[oppRow][79]).distance;
                    if(pMin < minDistance)
                    {
                        minDistance = pMin;
                        minRow = row;
                    }
                }
                graph.Reset();
            }

            return minDistance + array[minRow][0];
        }
    }
}
