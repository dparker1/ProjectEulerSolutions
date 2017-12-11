using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerProblems
{
    public class Problem032
    {
        public static int Solve()
        {
            SortedSet<int> pandigitals = new SortedSet<int>();
            int product = 0;
            string pan = "123456789";
            string productString = "";
            for(int i = 1; i <= 4000; i++)
            {
                for(int b = 1; b <= 4000; b++)
                {
                    product = i * b;
                    productString = product + "" + i + "" + b;
                    bool isPan = true;
                    if(productString.Length == 9 && !productString.Contains("0"))
                    {
                        for(int place = 0; place < pan.Length; place++)
                        {
                            if(!productString.Contains(pan[place]))
                            {
                                isPan = false;
                                break;
                            }
                        }
                    }
                    else
                    {
                        isPan = false;
                    }
                    if(isPan)
                    {
                        pandigitals.Add(product);
                        Console.WriteLine(productString);
                    }
                }
            }

            return pandigitals.Sum();
        }
    }
}
