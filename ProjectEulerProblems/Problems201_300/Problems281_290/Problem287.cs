using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerProblems
{
    public class Problem287
    {
        /*
            (x1, y1) ... (x2, y1)
            |                   |
            |                   |
            (x1, y2) ... (x2, y2)
        */
        public static int limit;
        public static long limitSq;
        public static int Solve()
        {
            int n = 24;
            int dim = (int)Math.Pow(2, n) - 1;
            limit = (int)Math.Pow(2, n - 1);
            limitSq = (long)Math.Pow(limit, 2);

            int result = 0;
            Encode(ref result, 0, dim, dim, 0, true);
            return result;
        }

        public static void Encode(ref int enc, int x1, int y1, int x2, int y2, bool first)
        {
            if(x1 == x2)
            {
                enc += 2;
                return;
            }
            bool topLeft = IsWhite(x1, y1);
            bool topRight = IsWhite(x2, y1);
            bool botLeft = IsWhite(x1, y2);
            bool botRight = IsWhite(x2, y2);
            if(topLeft == topRight && topRight == botLeft && botLeft == botRight && !first)
            {
                enc += 2;
                return;
            }
            if(x1 == (x2 + 1))
            {
                enc += 9;
                return;
            }
            enc++;
            int half = (x2 - x1 + 1) / 2;
            Encode(ref enc, x1, y1, x2 - half, y2 + half, false);
            Encode(ref enc, x1 + half, y1, x2, y2 + half, false);
            Encode(ref enc, x1, y1 - half, x2 - half, y2, false);
            Encode(ref enc, x1 + half, y1 - half, x2, y2, false);
        }

        public static bool IsWhite(int x, int y)
        {
            long x1 = x - limit;
            long y1 = y - limit;
            return (x1) * (x1) + (y1) * (y1) > limitSq;
        }
    }
}
