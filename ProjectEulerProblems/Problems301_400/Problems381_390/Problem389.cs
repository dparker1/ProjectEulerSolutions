using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerProblems
{
    public class Problem389
    {
        public static double Solve()
        {
            int a = 1;
            int[] bArr = new int[] { 4, 6, 8, 12, 20 };
            double[] Es = new double[bArr.Length];
            double[] Vs = new double[bArr.Length];
            Es[0] = E(a, bArr[0]);
            Vs[0] = Var(a, bArr[0]);
            for(int i = 1; i < bArr.Length; i++)
            {
                double expect = E(a, bArr[i]);
                Es[i] = Es[i - 1] * expect;
                Vs[i] = Es[i - 1] * Var(a, bArr[i]) + expect * expect * Vs[i - 1];
            }
            return Vs.Last();
        }

        private static double E(double a, double b)
        {
            return (b + a) / 2;
        }

        private static double Var(double a, double b)
        {
            return (Math.Pow(b - a + 1, 2) - 1) / 12;
        }
    }
}
