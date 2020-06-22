using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerProblems
{
    public class Problem151
    {
        public static double Solve()
        {
            Dictionary<int, Dictionary<int, double>> resultDict = new Dictionary<int, Dictionary<int, double>>();
            Dictionary<int, Tuple<int, int, int, int, int>> ids = new Dictionary<int, Tuple<int, int, int, int, int>>();
            Build(resultDict, ids);
            List<int> onePaperIds = new List<int>();
            foreach(int i in ids.Keys)
            {
                if((ids[i].Item2 == 1 && ids[i].Item3 == 0 && ids[i].Item4 == 0 && ids[i].Item5 == 0) ||
                   (ids[i].Item2 == 0 && ids[i].Item3 == 1 && ids[i].Item4 == 0 && ids[i].Item5 == 0) ||
                   (ids[i].Item2 == 0 && ids[i].Item3 == 0 && ids[i].Item4 == 1 && ids[i].Item5 == 0))
                {
                    onePaperIds.Add(i);
                }
            }
            int n = ids.Count;
            double[,] matrix = new double[n, n];
            double[,] matrixPrime = new double[n, n];
            Dictionary<int, double> tmp;
            foreach(int i in ids.Keys)
            {
                tmp = resultDict[i];
                foreach(int j in tmp.Keys)
                {
                    matrix[i, j] = tmp[j];
                    matrixPrime[i, j] = tmp[j];
                }
            }
            double sum = 0;
            for(int i = 0; i < 16; i++)
            {
                matrix = MMult(matrix, matrixPrime, n);
                foreach(int j in onePaperIds)
                {
                    sum += matrix[0, j];
                }
            }
            return sum;
        }

        public static void Build(Dictionary<int, Dictionary<int, double>> result, Dictionary<int, Tuple<int, int, int, int, int>> ids)
        {
            var reverseIds = new Dictionary<Tuple<int, int, int, int, int>, int>();
            Queue<int> q = new Queue<int>();
            var tmp = new Tuple<int, int, int, int, int>(1, 0, 0, 0, 0);
            
            var tmpArr = new int[5];
            var modArr = new int[5];
            int maxId = 0;
            int tmpId = 0;

            ids.Add(0, tmp);
            reverseIds.Add(tmp, 0);
            q.Enqueue(0);
            while(q.Count != 0)
            {
                int currentId = q.Dequeue();
                var currentTuple = ids[currentId];
                currentTuple.Deconstruct(out tmpArr[0], out tmpArr[1], out tmpArr[2], out tmpArr[3], out tmpArr[4]);
                double sum = 0;
                for(int i = 0; i < 5; i++)
                {
                    sum += tmpArr[i];
                }
                
                for(int i = 0; i < 5; i++)
                {
                    if(tmpArr[i] > 0)
                    {
                        double prob = tmpArr[i] / sum;
                        tmpArr.CopyTo(modArr, 0);
                        modArr[i]--;
                        for(int j = i + 1; j < 5; j++)
                        {
                            modArr[j]++;
                        }
                        tmp = new Tuple<int, int, int, int, int>(modArr[0], modArr[1], modArr[2], modArr[3], modArr[4]);
                        if(!reverseIds.ContainsKey(tmp))
                        {
                            maxId++;
                            tmpId = maxId;
                            ids.Add(maxId, tmp);
                            reverseIds.Add(tmp, maxId);
                            q.Enqueue(maxId);
                        }
                        else
                        {
                            tmpId = reverseIds[tmp];
                        }
                        if(!result.ContainsKey(currentId))
                        {
                            result.Add(currentId, new Dictionary<int, double>());
                        }
                        result[currentId].Add(tmpId, prob);
                    }
                }
            }
            Dictionary<int, double> t = new Dictionary<int, double>();
            t.Add(maxId, 1);
            result.Add(maxId, t);
        }

        public static double[,] MMult(double[,] x, double[,] y, int n)
        {
            double[,] result = new double[n, n];
            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < n; j++)
                {
                    for(int k = 0; k < n; k++)
                    {
                        result[i, j] += x[i, k] * y[k, j];
                    }
                }
            }
            return result;
        }
    }
}
