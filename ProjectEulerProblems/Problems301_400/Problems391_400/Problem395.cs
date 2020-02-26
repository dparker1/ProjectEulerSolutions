using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerProblems
{
    public class Problem395
    {
        public static double Solve()
        {
            List<Tuple<double, double, double, double>> allSquares = new List<Tuple<double, double, double, double>>();
            List<Tuple<double, double, double, double>> recentSquares = new List<Tuple<double, double, double, double>>();
            List<Tuple<double, double, double, double>> updatedSquares = new List<Tuple<double, double, double, double>>();
            HashSet<Tuple<double, double, double, double>> keptSquares = new HashSet<Tuple<double, double, double, double>>();
            recentSquares.Add(new Tuple<double, double, double, double>(0, 0, 1, 90));
            allSquares.Add(recentSquares[0]);

            double alpha = 90 - (Math.Asin(0.6) * 180 / Math.PI);
            double alphaRad = alpha * Math.PI / 180;
            int i = 0;
            int maxIter = 200;
            while(i < maxIter)
            {
                foreach(var x in recentSquares)
                {
                    double sizeLeft = Math.Cos(alphaRad) * x.Item3;
                    double sizeRight = Math.Sin(alphaRad) * x.Item3;
                    double angleLeft = x.Item4 + alpha;
                    double angleRight = x.Item4 - (90 - alpha);

                    double xLeft = x.Item1 + x.Item3 * Math.Cos(x.Item4 * Math.PI / 180);
                    double yLeft = x.Item2 + x.Item3 * Math.Sin(x.Item4 * Math.PI / 180);

                    double xRight = x.Item1 + x.Item3 * Math.Cos(x.Item4 * Math.PI / 180) + sizeLeft * Math.Cos(angleRight * Math.PI / 180);
                    double yRight = x.Item2 + x.Item3 * Math.Sin(x.Item4 * Math.PI / 180) + sizeLeft * Math.Sin(angleRight * Math.PI / 180);
                    updatedSquares.Add(new Tuple<double, double, double, double>(xLeft, yLeft, sizeLeft, angleLeft));
                    updatedSquares.Add(new Tuple<double, double, double, double>(xRight, yRight, sizeRight, angleRight));
                }

                updatedSquares = updatedSquares.OrderBy(x => x.Item1).ToList();
                int m = Math.Min(8, updatedSquares.Count);
                for(int j = 0; j < m; j++)
                {
                    keptSquares.Add(updatedSquares[j]);
                }
                updatedSquares = updatedSquares.OrderBy(x => -x.Item1).ToList();
                for(int j = 0; j < m; j++)
                {
                    keptSquares.Add(updatedSquares[j]);
                }
                updatedSquares = updatedSquares.OrderBy(x => x.Item2).ToList();
                for(int j = 0; j < m; j++)
                {
                    keptSquares.Add(updatedSquares[j]);
                }
                updatedSquares = updatedSquares.OrderBy(x => -x.Item2).ToList();
                for(int j = 0; j < m; j++)
                {
                    keptSquares.Add(updatedSquares[j]);
                }
                recentSquares.Clear();
                foreach(var x in keptSquares)
                {
                    recentSquares.Add(x);
                    allSquares.Add(x);
                }
                keptSquares.Clear();
                updatedSquares.Clear();
                i++;
            }
            List<double> xs = new List<double>();
            List<double> ys = new List<double>();

            foreach(var x in allSquares)
            {
                xs.Add(x.Item1);
                xs.Add(x.Item1 + x.Item3 * Math.Cos(x.Item4 * Math.PI / 180));
                xs.Add(x.Item1 + x.Item3 * Math.Cos((90 - x.Item4) * Math.PI / 180));
                xs.Add(x.Item1 + x.Item3 * (Math.Cos(x.Item4 * Math.PI / 180) + Math.Cos((90 - x.Item4) * Math.PI / 180)));

                ys.Add(x.Item2);
                ys.Add(x.Item2 + x.Item3 * Math.Sin(x.Item4 * Math.PI / 180));
                ys.Add(x.Item2 + x.Item3 * Math.Sin((x.Item4 - 90) * Math.PI / 180));
                ys.Add(x.Item2 + x.Item3 * (Math.Sin(x.Item4 * Math.PI / 180) + Math.Sin((x.Item4 - 90) * Math.PI / 180)));
            }

            double xMax = xs.Max();
            double xMin = xs.Min();
            double yMax = ys.Max();
            double yMin = ys.Min();

            return (xMax - xMin) * (yMax - yMin);
        }
    }
}
