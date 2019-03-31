using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerProblems
{
    public class Problem392
    {
        static double delta = 0.0001;
        public static double Solve()
        {
            int xDim = 5;
            double[] x = new double[xDim];
            init(x, xDim);
            for(int i = 0; i < 100000; i++)
            {
                Tuple<int, int> gradient = grad(x);
                x[gradient.Item1] += gradient.Item2 * delta;
            }
            return func(x);
        }

        private static double func(double[] x)
        {
            double area = Math.Sin(x[0]) + (1 - Math.Sin(x.Last())) * Math.Cos(x.Last());
            for(int i = 1; i < x.Length; i++)
            {
                area += (Math.Sin(x[i]) - Math.Sin(x[i - 1])) * Math.Cos(x[i]);
            }
            return area;
        }

        private static void init(double[] x, int xDim)
        {
            double c = (2 * Math.PI * xDim);
            for(int i = 0; i < x.Length; i++)
            {
                x[i] = i /c;
            }
        }

        private static Tuple<int, int> grad(double[] x)
        {
            double ev = func(x);
            double maxDescent = 0;
            double diff = 0;
            Tuple<int, int> res = new Tuple<int, int>(0, 0);
            for(int i = 0; i < x.Length; i++)
            {
                x[i] += delta;
                diff = func(x) - ev;
                if(diff < maxDescent)
                {
                    res = new Tuple<int, int>(i, 1);
                }
                x[i] -= 2 * delta;
                diff = func(x) - ev;
                if(diff < maxDescent)
                {
                    res = new Tuple<int, int>(i, -1);
                }
                x[i] += delta;
            }
            return res;
        }

        private static double ToRad(double x)
        {
            return Math.PI * x / 180.0d;
        }
    }
}
