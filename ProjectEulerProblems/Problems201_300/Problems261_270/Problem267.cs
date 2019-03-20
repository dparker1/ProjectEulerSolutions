using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerProblems
{
    public class Problem267
    {
        static int billion = (int)Math.Pow(10, 9);
        static int flips = 1000;
        static double[] binomialProbabilities;
        public static double Solve()
        {
            binomialProbabilities = new double[flips + 1];
            double prob = Math.Pow(0.5, flips);
            for(int k = 0; k <= flips; k++)
            {
                binomialProbabilities[k] = prob;
                prob *= (flips - k) / ((double)k + 1);
            }

            double gr = (Math.Sqrt(5) + 1) / 2;
            double lower = 0.05;
            double upper = 0.3;
            double tolerance = Math.Pow(10, -13);
            double c = upper - (upper - lower) / gr;
            double d = lower + (upper - lower) / gr;
            while(Math.Abs(c - d) > tolerance)
            {
                if(Prob(c) > Prob(d))
                {
                    upper = d;
                } 
                else
                {
                    lower = c;
                }
                c = upper- (upper - lower) / gr;
                d = lower + (upper - lower) / gr;
            }

            return Prob((upper + lower)/2);
        }

        private static double Prob(double f)
        {
            double ratio = (2 * f + 1) / (1 - f);
            int start = 0;
            double outcome = Math.Pow(1 - f, flips);
            while(outcome == 0)
            {
                start++;
                outcome = Math.Pow(1 - f, flips - start);
            }

            bool aboveBillion = false;
            double totalProb = 0;
            for(int k = 1 + start; k <= flips; k++)
            {
                if(!aboveBillion)
                {
                    outcome *= ratio;
                    if(outcome > billion)
                    {
                        aboveBillion = true;
                    }
                }
                if(aboveBillion)
                {
                    totalProb += binomialProbabilities[k];
                }
            }
            return totalProb;
        }
    }
}
