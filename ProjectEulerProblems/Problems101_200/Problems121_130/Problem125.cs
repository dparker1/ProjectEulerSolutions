using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerProblems
{
    public class Problem125
    {
        public static long Solve()
        {
            long sum = 0;
            int bound = 100000000;
            IEnumerable<int> palindromes = Enumerable.Range(5, bound - 5).Where(x => EulerUtilities.IsPalindrome(x.ToString()));
            List<int> squares = new List<int>();
            for(int i = 1; i < bound; i++)
            {
                int power = (int)Math.Pow(i, 2);
                if(power > bound)
                {
                    break;
                }
                squares.Add(power);
            }
            foreach(int i in palindromes)
            {
                bool keepOn = true;
                for(int begin = 0; begin < squares.Count && keepOn; begin++)
                {
                    if(squares[begin] >= i)
                    {
                        break;
                    }
                    int conseqSum = 0;
                    for(int square = begin; square < squares.Count; square++)
                    {
                        conseqSum += squares[square];
                        if(conseqSum > i)
                        {
                            break;
                        }
                        if(conseqSum == i)
                        {
                            Console.WriteLine(begin + 1 + ", " + (square + 1) + ": " + i);
                            sum += i;
                            keepOn = false;
                            break;
                        }
                    }
                }
            }
            return sum;
        }
    }
}
