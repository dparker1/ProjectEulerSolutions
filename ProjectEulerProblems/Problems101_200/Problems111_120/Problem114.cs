using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerProblems
{
    public class Problem114
    {
        public static long Solve()
        {
            int length = 50;
            long[] arr = new long[length + 1];
            arr[3] = 2;
            long result = Count(arr, length);
            return result;
        }

        public static long Count(long[] arr, int lengthLeft)
        {
            if(lengthLeft < 3)
            {
                return 1;
            }
            if(arr[lengthLeft] > 0)
            {
                return arr[lengthLeft];
            }

            long total = 1;
            for(int i = 3; i <= lengthLeft; i++)
            {
                for(int j = 0; j <= lengthLeft - i; j++)
                {
                    total += Count(arr, lengthLeft - i - j - 1);
                }
            }
            arr[lengthLeft] = total;
            return total;
        }
    }
}
