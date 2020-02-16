using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerProblems
{
    public class Problem122
    {
        /*
        1: 0
        2: 1
        3: 2
        4: 2
        5: 3
        6: 3
        7: 4
        8: 3
        9: 4
        10: 4
        11: 5
        12: 4
        13: 5
        */
        public static Dictionary<int, int> p = new Dictionary<int, int>();
        public static List<List<int>> lvl = new List<List<int>>();


        public static int Solve()
        {
            p.Add(1, 0);
            List<int> temp = new List<int>();
            temp.Add(1);
            lvl.Add(temp);

            int sum = 5;
            for(int i = 5; i <= 200; i++)
            {
                List<int> z = Path(i);
                sum += z.Count - 1;
            }
            return sum - 2;
        }

        public static List<int> Path(int n)
        {
            if(n == 0)
            {
                return new List<int>();
            }
            
            while(!p.ContainsKey(n))
            {
                List<int> q = new List<int>();
                foreach(int x in lvl[0])
                {
                    foreach(int y in Path(x))
                    {
                        int z = x + y;
                        if(!p.ContainsKey(z))
                        {
                            p.Add(z, x);
                            q.Add(z);
                        }
                    }
                }
                lvl[0].Clear();
                lvl[0].AddRange(q);
            }
            List<int> t = Path(p[n]);
            t.Add(n);
            return t;
        }
    }
}
