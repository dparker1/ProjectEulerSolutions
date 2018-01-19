using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerProblems.Structures
{
    public class Graph
    {
        public Dictionary<string, Vertex> vertexNames { get; }
        
        public Graph()
        {
            vertexNames = new Dictionary<string, Vertex>();
        }

        public void AddVertex(Vertex v)
        {
            if(vertexNames.ContainsKey(v.name))
            {
                throw new ArgumentException("Vertex name already exists");
            }
            vertexNames.Add(v.name, v);
        }

        public void AddEdge(string start, string end, int cost)
        {
            if(!vertexNames.ContainsKey(start))
            {
                throw new ArgumentException("Vertex name does not exist");
            }
            if(!vertexNames.ContainsKey(end))
            {
                throw new ArgumentException("Vertex name does not exist");
            }
            Vertex sourceVertex = vertexNames[start];
            Vertex targetVertex = vertexNames[end];
            Edge newEdge = new Edge(sourceVertex, targetVertex, cost);
            sourceVertex.AddEdge(newEdge);
        }

        public Vertex GetVertex(string name)
        {
            return vertexNames[name];
        }

        public void DoDijkstra(string start)
        {
            Vertex startVertex = vertexNames[start];
            LinkedList<Vertex> unknownVertices = new LinkedList<Vertex>(vertexNames.Values);
            startVertex.distance = 0;
            Vertex minV;
            double minD;
            while(unknownVertices.Count > 0)
            {
                minV = null;
                minD = double.PositiveInfinity;
                foreach(Vertex v in unknownVertices)
                {
                    if(v.distance < minD)
                    {
                        minV = v;
                        minD = v.distance;
                    }
                }
                minV.known = true;
                unknownVertices.Remove(minV);
                foreach(Edge e in minV.edges)
                {
                    if(!e.end.known)
                    {
                        double posMin = e.cost + e.start.distance;
                        if(e.end.distance > posMin)
                        {
                            e.end.prev = e.start;
                            e.end.distance = posMin;
                        }
                    }
                }
            }
        }

        public void Reset()
        {
            foreach(Vertex v in vertexNames.Values)
            {
                v.distance = double.PositiveInfinity;
                v.known = false;
                v.prev = null;
            }
        }

        public class Edge
        {
            public int cost;
            public Vertex start, end;

            public Edge(Vertex start, Vertex end, int cost)
            {
                this.start = start;
                this.end = end;
                this.cost = cost;
            }

            public override string ToString()
            {
                return start + " - " + end + ": " + cost;
            }
        }

        public class Vertex
        {
            public string name;
            public List<Edge> edges;
            public bool known;
            public double distance;
            public Vertex prev;

            public Vertex(string name)
            {
                this.name = name;
                edges = new List<Edge>();
                known = false;
                prev = null;
                distance = double.PositiveInfinity;
            }

            public override int GetHashCode()
            {
                return base.GetHashCode();
            }

            public override bool Equals(object obj)
            {
                if(obj is Vertex)
                {
                    Vertex o = (Vertex)obj;
                    if(o.name.Equals(this.name))
                    {
                        return true;
                    }
                }
                return false;
            }

            public override string ToString()
            {
                return name;
            }

            public void AddEdge(Edge e)
            {
                edges.Add(e);
            }

        }
        
        
    }

}
