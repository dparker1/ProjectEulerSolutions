using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace ProjectEulerProblems
{
    public class Problem206
    {
        public static string Solve()
        {
            char[] target = new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            long n = 138902663;
            long sq;
            bool swit = true;
            while(true)
            {
                sq = n * n;
                if(Check(target, sq))
                {
                    break;
                }
                if(swit)
                {
                    n -= 6;
                }
                else
                {
                    n -= 4;
                }
                swit = !swit;
            }
            return (n * 10).ToString();
        }

        private static bool Check(char[] target, long n)
        {
            string ns = n.ToString();
            for(int i = 0; i < ns.Length; i+=2)
            {
                if(ns[i] != target[i / 2])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
