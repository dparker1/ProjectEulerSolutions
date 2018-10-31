using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerProblems
{
    public class Problem093
    {
        static List<Func<double, double, double>> allOps;
        public static string Solve()
        {
            allOps = new List<Func<double, double, double>>();
            allOps.Add(Add);
            allOps.Add(Sub);
            allOps.Add(Mul);
            allOps.Add(Div);

            List<List<Func<double, double, double>>> operators = PermuteOperations(3);
            List<List<int>> positions = EulerUtilities.Permute(new List<int>(new int[] { 0, 1, 2, 3 }));
            int largestRun = 0;
            string runString = "";
            for(double a = 1; a <= 6; a++)
            {
                for(double b = a + 1; b <= 7; b++)
                {
                    for(double c = b + 1; c <= 8; c++)
                    {
                        for(double d = c + 1; d <= 9; d++)
                        {
                            SortedSet<int> generateds = new SortedSet<int>();
                            double[] arr = new double[4] { a, b, c, d };
                            foreach(var pos in positions)
                            {
                                List<double> l = new List<double>(4);
                                for(int i = 0; i < 4; i++)
                                {
                                    l.Add(arr[pos[i]]);
                                }
                                foreach(var ops in operators)
                                {
                                    for(int firstOp = 0; firstOp < 3; firstOp++)
                                    {
                                        List<double> l1 = new List<double>(l);
                                        var o1 = new List<Func<double, double, double>>(ops);
                                        double temp = o1[firstOp](l1[firstOp], l1[firstOp + 1]);
                                        o1.RemoveAt(firstOp);
                                        l1.RemoveAt(firstOp);
                                        l1.RemoveAt(firstOp);
                                        l1.Insert(firstOp, temp);
                                        for(int secOp = 0; secOp < 2; secOp++)
                                        {
                                            List<double> l2 = new List<double>(l1);
                                            var o2 = new List<Func<double, double, double>>(o1);
                                            temp = o2[secOp](l2[secOp], l2[secOp + 1]);
                                            o2.RemoveAt(secOp);
                                            l2.RemoveAt(secOp);
                                            l2.RemoveAt(secOp);
                                            l2.Insert(secOp, temp);
                                            temp = o2[0](l2[0], l2[1]);
                                            if(EulerUtilities.IsInteger(temp))
                                            {
                                                generateds.Add((int)temp);
                                            }
                                        }
                                        
                                    }
                                }
                            }
                            int prev = 0;
                            int run = 0;
                            var cut = new SortedSet<int>(generateds.Where(x => x > 0));
                            foreach(int i in cut)
                            {
                                if(i - 1 != prev)
                                {
                                    break;
                                }
                                run++;
                                prev = i;
                                if(run > largestRun)
                                {
                                    largestRun = run;
                                    runString = "" + a + b + c + d;
                                }
                            }
                        }
                    }
                }
            }
            return runString;
        }

        public static List<List<Func<double, double, double>>> PermuteOperations(int size)
        {
            var result = new List<List<Func<double, double, double>>>();
            PermuteOperations(size, result, new List<Func<double, double, double>>());
            return result;
        }

        private static void PermuteOperations(int size, List<List<Func<double, double, double>>> result, List<Func<double, double, double>> soFar)
        {
            if(soFar.Count == size)
            {
                result.Add(soFar);
                return;
            }

            foreach(var f in allOps)
            {
                var temp = new List<Func<double, double, double>>(soFar);
                temp.Add(f);
                PermuteOperations(size, result, temp);
            }
        }

        private static double Add(double a, double b)
        {
            return a + b;
        }

        private static double Sub(double a, double b)
        {
            return a - b;
        }

        private static double Mul(double a, double b)
        {
            return a * b;
        }

        private static double Div(double a, double b)
        {
            return a / b;
        }
    }
}
