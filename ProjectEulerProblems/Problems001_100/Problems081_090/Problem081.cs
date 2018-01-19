using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectEulerProblems.Structures;
using System.IO;

namespace ProjectEulerProblems
{
    public class Problem081
    {
        public static double Solve()
        {
            Graph graph = new Graph();
            string[] text = File.ReadAllLines(@"..\..\txt\Problem081Text.txt");
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
            graph.DoDijkstra(names[0][0]);
            return graph.vertexNames[names[79][79]].distance + array[0][0];
        }
    }
}
