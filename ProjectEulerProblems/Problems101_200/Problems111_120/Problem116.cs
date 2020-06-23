using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerProblems
{
    public class Problem116
    {
        public static long Solve()
        {
            int length = 50;
            long[] arr2 = new long[length + 1];
            long[] arr3 = new long[length + 1];
            long[] arr4 = new long[length + 1];
            return Count(arr2, 2, length) + Count(arr3, 3, length) + Count(arr4, 4, length);
        }

        public static long Count(long[] arr, int blockSize, int lengthLeft)
        {
            if(lengthLeft < blockSize)
            {
                return 0;
            }
            if(lengthLeft == blockSize)
            {
                return 1;
            }
            if(arr[lengthLeft] > 0)
            {
                return arr[lengthLeft];
            }

            long total = 0;
            for(int j = 0; j <= lengthLeft - blockSize; j++)
            {
                total += Count(arr, blockSize, lengthLeft - blockSize - j) + 1;
            }
            arr[lengthLeft] = total;
            return total;
        }
    }
}
