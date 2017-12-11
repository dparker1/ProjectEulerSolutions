using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerProblems
{
    public class Problem061
    {
        public static int Solve()
        {
            List<int> triags = new List<int>();
            List<int> squares = new List<int>();
            List<int> pentags = new List<int>();
            List<int> hexags = new List<int>();
            List<int> heptags = new List<int>();
            List<int> octags = new List<int>();
            HashSet<string> checkedEndings = new HashSet<string>();
            for(int n = 1; n < 141;n++)
            {
                triags.Add(n * (n + 1) / 2);
                squares.Add(n * n);
                pentags.Add(n * (3 * n - 1) / 2);
                hexags.Add(n * (2 * n - 1));
                heptags.Add(n * (5 * n - 3) / 2);
                octags.Add(n * (3 * n - 2));
            }
            triags = triags.Where(x => x >= 1000 && x < 10000).ToList();
            squares = squares.Where(x => x >= 1000 && x < 10000).ToList();
            pentags = pentags.Where(x => x >= 1000 && x < 10000).ToList();
            hexags = hexags.Where(x => x >= 1000 && x < 10000).ToList();
            heptags = heptags.Where(x => x >= 1000 && x < 10000).ToList();
            octags = octags.Where(x => x >= 1000 && x < 10000).ToList();

            List<int>[] masterList = new List<int>[6];
            masterList[0] = triags;
            masterList[1] = squares;
            masterList[2] = pentags;
            masterList[3] = hexags;
            masterList[4] = heptags;
            masterList[5] = octags;
            List<List<int>> results = new List<List<int>>();
            foreach(int octagonal in octags)
            {
                string ending = octagonal.ToString().Substring(2);
                if(!checkedEndings.Contains(ending))
                {
                    checkedEndings.Add(ending);
                    List<int> result = CheckCycle(ending, masterList, new bool[] { false, false, false, false, false, false}, new List<int>());
                    results.Add(result);
                    foreach(int n in result)
                    {
                        Console.WriteLine(n);
                    }
                }
                
                
            }

            return -1;
        }

        public static List<int> CheckCycle(string ending, List<int>[] master, bool[] checkedLists, List<int> cycle)
        {
            if(checkedLists.Where(x => x == true).ToList().Count == 6 && cycle.Last().ToString().Substring(2).Equals(cycle.First().ToString().Substring(0,2)))
            {
                Console.WriteLine(cycle.Sum());
                Console.WriteLine("____");
                return cycle;
            }
            List<int>[] newMaster = new List<int>[6];
            
            for(int i = 0; i < master.Length; i++)
            {
                List<int> temp = new List<int>();
                foreach(int n in master[i])
                {
                    temp.Add(n);
                }
                newMaster[i] = temp;
                newMaster[i] = newMaster[i].Where(x => x.ToString().StartsWith(ending)).ToList();
            }
            for(int i = 0; i < newMaster.Length; i++)
            {
                if(newMaster[i].Count > 0 && !checkedLists[i])
                {
                    bool[] newCheckedLists = new bool[6];
                    checkedLists.CopyTo(newCheckedLists, 0);
                    newCheckedLists[i] = true;
                    foreach(int n in newMaster[i])
                    {
                        List<int> newCycle = cycle;
                        newCycle.Add(n);
                        List<int> resultCycle = CheckCycle(n.ToString().Substring(2), master, newCheckedLists, newCycle);
                        if(checkedLists.Where(x => x == true).ToList().Count != 6)
                        {
                            resultCycle.RemoveAt(resultCycle.Count - 1);
                        }
                    }
                }
            }
            return cycle;
        }
    }
}
