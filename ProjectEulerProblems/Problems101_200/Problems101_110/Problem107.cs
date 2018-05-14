using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectEulerProblems.Structures;
using System.IO;

namespace ProjectEulerProblems
{
    public class Problem107
    {
        public static int Solve()
        {
            Graph graph = new Graph();
            string[] text = File.ReadAllLines(@"..\..\txt\Problem107Text.txt");
            for(int i = 0; i < text.Length; i++)
            {
                graph.AddVertex(i.ToString());
            }
            for(int i = 0; i < text.Length; i++)
            {
                string[] line = text[i].Split(',');
                for(int j = 0; j < line.Length; j++)
                {
                    if(!line[j].Equals("-"))
                    {
                        graph.AddEdge(i.ToString(), j.ToString(), int.Parse(line[j]));
                    }
                }
            }
            int oldTotal = graph.edges.Sum(x => x.cost)/ 2;
            List<Graph.Edge> r = graph.DoKruskal();

            return oldTotal - r.Sum(x => x.cost);
            

        }
    }
}
