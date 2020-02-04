using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerProblems
{
    public class Problem461
    {
        static double n = 200;
        static double lessPI = 4 + Math.PI;
        static double[] ks;
        static double[] gradient, exps;
        public static double Solve()
        {
            ks = new double[] { 1, 2, 3, 4 };
            exps = new double[4];
            gradient = new double[4];
            double value = 0;
            int i = 0;
            while(i < 10000)
            {
                value = Objective();
                Gradient();
                Step(value);
                i++;
            }

            for(i = 0; i < 4; i++)
            {
                Console.WriteLine(ks[i]);
            }
            return Objective();
        }

        public static void Gradient()
        {
            double sgn = ObjectiveSign();
            for(int i = 0; i < 4; i++)
            {
                gradient[i] = sgn * (exps[i] / n);
            }
        }

        public static double Objective()
        {
            double x = 0;
            for(int i = 0; i < 4; i++)
            {
                exps[i] = Exp(ks[i]);
                x += exps[i];
            }
            return Math.Abs(x - lessPI);
        }

        public static double ObjectiveSign()
        {
            double x = 0;
            for(int i = 0; i < 4; i++)
            {
                exps[i] = Exp(ks[i]);
                x += exps[i];
            }
            return Math.Sign(x - lessPI);
        }

        public static void Step(double oldValue)
        {
            int maxI = 0;
            for(int i = 1; i < 4; i++)
            {
                if(Math.Abs(gradient[i]) > Math.Abs(gradient[maxI]))
                {
                    maxI = i;
                }
            }
            int sgn = Math.Sign(gradient[maxI]);
            double size = 1;
            ks[maxI] -= sgn;
            double newValue = Objective();
            while(size > 0.00001)
            {
                ks[maxI] -= sgn * size;
                oldValue = newValue;
                newValue = Objective();
                if(newValue > oldValue)
                {
                    ks[maxI] += sgn * size;
                    size /= 10;
                }
            }
            ks[maxI] = Math.Round(ks[maxI]);
        }

        public static double Exp(double x)
        {
            return Math.Exp(x / n);
        }
    }
}
