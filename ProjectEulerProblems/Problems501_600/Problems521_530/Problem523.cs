using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace ProjectEulerProblems
{
    public class Problem523
    {
        public static double Solve()
        {
            int n = 30;
            int length = (int)Math.Pow(2, n - 1);
            double[] arr = new double[length];
            double[] arrTemp = new double[length];
            arr[0] = 1;
            arr[1] = 1;
            for(int i = 2; i < n; i++)
            {
                int prevLength = (int)Math.Pow(2, i - 1);
                int currLength = (int)Math.Pow(2, i);

                for(int k = 0; k < prevLength; k++)
                {
                    arrTemp[k] = arr[k];
                }

                for(int j = 1; j <= prevLength; j *= 2)
                {
                    for(int k = 0; k < prevLength; k++)
                    {
                        arrTemp[k + j] += arr[k];
                    }
                }
                for(int k = 0; k < currLength; k++)
                {
                    arr[k] = arrTemp[k];
                }
                Console.WriteLine(i);
            }

            double sum = 0;
            double adjustment = n * (n - 1) * (n - 2) * (n - 3) * (n - 4) * (n - 5);
            for(int i = 0; i < length; i++)
            {
                sum += ((double)arr[i] / adjustment) * i;
            }
            for(double i = 1; i <= n - 6; i++)
            {
                sum /= i;
            }
            return sum;
        }

        public static int FirstSort(List<int> x)
        {
            LinkedList<int> z = new LinkedList<int>(x);
            int count = 0;
            bool done = false;
            while(!done)
            {
                bool first = true;
                int last = 0;
                done = true;
                foreach(int e in z)
                {
                    if(first)
                    {
                        last = e;
                        first = false;
                    }
                    else
                    {
                        if(last > e)
                        {
                            z.Remove(e);
                            z.AddFirst(e);
                            count++;
                            done = false;
                            first = true;
                            break;
                        }
                        last = e;
                    }
                }
            }
            return count;

        }
    }
}
