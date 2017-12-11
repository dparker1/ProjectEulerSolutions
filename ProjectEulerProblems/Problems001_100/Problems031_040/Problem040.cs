using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerProblems
{
    public class Problem040
    {
        public static int Solve()
        {
            string champernowne = "0";
            int current = 1;
            StringBuilder builder = new StringBuilder();
            while(builder.Length <= 1000000)
            {
                builder.Append(current);
                current++;
            }
            champernowne += builder.ToString();
            int product = 1;
            for(int i = 1; i <= 1000000; i *= 10)
            {
                product *= (int) Char.GetNumericValue(champernowne[i]);
            }

            return product;
        }
    }
}
