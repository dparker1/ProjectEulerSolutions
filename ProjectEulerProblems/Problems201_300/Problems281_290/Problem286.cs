using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerProblems
{
    public class Problem286
    {
        static int throwsNeeded = 20;
        static int maxD = 50;
        public static double Solve()
        {
            double targetP = 0.02d;
            double precision = Math.Pow(10, -15);
            double q = 52;
            double p = Probability(q, 0, 1, new Dictionary<Tuple<int, int, double>, double>());
            double diff = p - targetP;
            double delta = 1;
            while(Math.Abs(diff) > precision)
            {
                if(diff > 0)
                {
                    q += delta;
                }
                else
                {
                    q -= delta;
                    delta /= 10;
                    q += delta;
                }
                p = Probability(q, 0, 1, new Dictionary<Tuple<int, int, double>, double>());
                diff = p - targetP;
            }
            return q;
        }

        public static double Probability(double q, int made, int x, Dictionary<Tuple<int, int, double>, double> results)
        {
            if(made > 50)
            {
                return 0;
            }
            if(x > maxD)
            {
                return made == throwsNeeded ? 1 : 0;
            }

            Tuple<int, int, double> tup = new Tuple<int, int, double>(made, x, q);
            if(results.ContainsKey(tup))
            {
                return results[tup];
            }

            double score = 1 - x / q;

            x++;
            double r = score * Probability(q, made + 1, x, results) + (1 - score) * Probability(q, made, x, results);
            results[tup] = r;
            return r;
        }
    }
}
