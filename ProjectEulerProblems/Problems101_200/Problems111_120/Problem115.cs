using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerProblems
{
    public class Problem115
    {
        public static int Solve()
        {
            int maxBlock = 50;
            for(int length = 51; length < 175; length++)
            {
                int[] arr = new int[length + 1];
                arr[maxBlock] = 2;
                int c = Count(arr, maxBlock, length);
                if(c > 1000000)
                {
                    return length;
                }
            }
            return 0;
        }

        public static int Count(int[] arr, int maxBlock, int lengthLeft)
        {
            if(lengthLeft < maxBlock)
            {
                return 1;
            }
            if(arr[lengthLeft] > 0)
            {
                return arr[lengthLeft];
            }

            int total = 1;
            for(int i = maxBlock; i <= lengthLeft; i++)
            {
                for(int j = 0; j <= lengthLeft - i; j++)
                {
                    total += Count(arr, maxBlock, lengthLeft - i - j - 1);
                }
            }
            arr[lengthLeft] = total;
            return total;
        }
    }
}
