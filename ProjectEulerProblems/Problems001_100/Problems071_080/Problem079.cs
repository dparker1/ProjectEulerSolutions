using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ProjectEulerProblems
{
    public class Problem079
    {
        public static string Solve()
        {
            string text = File.ReadAllText(@"..\..\txt\Problem079Text.txt");
            string[] c = text.Split('\n');
            List<string> codes = (new HashSet<string>(c)).ToList();
            List<Node> nodes = new List<Node>();
            for(int i = 0; i < 10; i++)
            {
                nodes.Add(new Node(i));
            }
            foreach(string code in codes)
            {
                int val1 = code[0] - 48;
                int val2 = code[1] - 48;
                int val3 = code[2] - 48;
                nodes[val1].AddOut(nodes[val2]);
                nodes[val2].AddIn(nodes[val1]);
                nodes[val1].AddOut(nodes[val3]);
                nodes[val3].AddIn(nodes[val1]);
                nodes[val2].AddOut(nodes[val3]);
                nodes[val3].AddIn(nodes[val2]);
            }
            List<Node> result = new List<Node>();
            List<Node> nonIn = new List<Node>();
            foreach(Node n in nodes)
            {
                if(n.ins.Count == 0)
                {
                    nonIn.Add(n);
                }
            }
            while(nonIn.Count != 0)
            {
                Node n = nonIn.First();
                nonIn.Remove(n);
                result.Add(n);
                while(n.outs.Count != 0)
                {
                    Node m = n.outs[0];
                    n.outs.Remove(m);
                    m.ins.Remove(n);
                    if(m.ins.Count == 0)
                    {
                        nonIn.Add(m);
                    }
                }
            }
            result.RemoveAt(0);
            result.RemoveAt(0);

            return String.Concat(result);
        }

        public class Node
        {
            public int value;
            public List<Node> outs;
            public List<Node> ins;

            public Node(int v)
            {
                value = v;
                outs = new List<Node>();
                ins = new List<Node>();
            }

            public void AddOut(Node n)
            {
                if(!outs.Contains(n))
                {
                    outs.Add(n);
                }
            }

            public void AddIn(Node n)
            {
                if(!ins.Contains(n))
                {
                    ins.Add(n);
                }
            }

            public override string ToString()
            {
                return value.ToString();
            }
        }
    }

}