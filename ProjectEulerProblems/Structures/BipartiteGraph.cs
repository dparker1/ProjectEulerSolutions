using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerProblems.Structures
{
    public class BipartiteGraph
    {
        List<Node> sources;
        List<Node> destinations;

        public BipartiteGraph()
        {
            sources = new List<Node>();
            destinations = new List<Node>();
        }

        public void ConstructFromMatrix(int[][] array)
        {
            for(int c = 0; c < array[0].Length; c++)
            {
                destinations.Add(new Node("c" + c));
            }
            for(int r = 0; r < array.Length; r++)
            {
                Node row = new Node("r" + r);
                for(int c = 0; c < array[r].Length; c++)
                {
                    Node col = destinations.Find(x => x.id.Equals("c" + c));
                    Edge e = new Edge(array[r][c], row, col);
                    row.edges.Add(e);
                    col.edges.Add(e);
                }
                sources.Add(row);
            }

            return;
        }

        public int MinCost()
        {
            foreach(Node n in sources)
            {
                int min = MinEdge(n.edges);
                for(int i = 0; i < n.edges.Count; i++)
                {
                    n.edges[i].cost -= min;
                }
            }
            foreach(Node n in destinations)
            {
                int min = MinEdge(n.edges);
                for(int i = 0; i < n.edges.Count; i++)
                {
                    n.edges[i].cost -= min;
                }
            }

            return 0;
        }

        private int MinEdge(List<Edge> edges)
        {
            return edges.Min(x => x.cost);
        }

        private class Node
        {
            public string id;
            public List<Edge> edges; 

            public Node(string id)
            {
                this.id = id;
                edges = new List<Edge>();
            }
        }

        private class Edge
        {
            public int cost;
            public Node source;
            public Node destination;

            public Edge(int cost, Node s, Node d)
            {
                this.cost = cost;
                source = s;
                destination = d;
            }
            
        }
    }
}
