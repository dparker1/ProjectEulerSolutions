using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerProblems
{
    public class Problem117
    {
        public static long Solve()
        {
            int length = 50;
            long[] arr = new long[length + 1];
            return Count(arr, 2, 4, length);
        }

        public static long Count(long[] arr, int minBlockSize, int maxBlockSize, int lengthLeft)
        {
            if(lengthLeft < minBlockSize)
            {
                return 1;
            }
            if(arr[lengthLeft] > 0)
            {
                return arr[lengthLeft];
            }

            long total = 1;
            for(int blockSize = minBlockSize; blockSize <= maxBlockSize; blockSize++)
            {
                for(int j = 0; j <= lengthLeft - blockSize; j++)
                {
                    total += Count(arr, minBlockSize, maxBlockSize, lengthLeft - blockSize - j);
                }
            }
            arr[lengthLeft] = total;
            return total;
        }
    }
}
