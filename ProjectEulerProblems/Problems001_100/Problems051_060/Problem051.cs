using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerProblems
{
    public class Problem051
    {
        static List<string> primes;
        public static string Solve()
        {
            primes = EulerUtilities.GeneratePrimes(1000000).ConvertAll(x => x.ToString());
            primes.RemoveAll(x => x.Length != 6);
            string com = "tttfff";
            HashSet<string> combos = new HashSet<string>(EulerUtilities.Permute(com));
            combos.RemoveWhere(x => x.Last() == 't');
            foreach(string prime in primes)
            {
                foreach(string combo in combos)
                {
                    if(HasReplaceableDigits(prime, combo))
                    {
                        char replaceDigit = prime[combo.IndexOf('t')];
                        if((replaceDigit == '0' || replaceDigit == '1' || replaceDigit == '2') && (CountPrimeFamily(prime, replaceDigit) == 8))
                        {
                            return prime;
                        }
                    }
                }
            }
            return "0";
        }

        public static bool HasReplaceableDigits(string n, string combo)
        {
            int[] digits = new int[3];
            for(int c = 0, d = 0; c < n.Length; c++)
            {
                if(combo[c] == 't')
                {
                    digits[d] = (int) Char.GetNumericValue(n[c]);
                    d++;
                }
            }
            if(digits[0] == digits[1] && digits[1] == digits[2] && CountOccurences(n, (char)(digits[0] + 48)) == 3)
            {
                return true;
            }
            return false;
        }

        public static int CountPrimeFamily(string n, char replaceDigit)
        {
            int count = 0;
            string temp = "";
            for(int i = replaceDigit; i <= 57; i++)
            {
                temp = n.Replace(replaceDigit, (char)i);
                if(primes.Contains(temp))
                {
                    count++;
                }
            }
            return count;
        }

        public static int CountOccurences(string s, char c)
        {
            int count = 0;
            foreach(char i in s)
            {
                if(i == c)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
