using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerProblems
{
    public class Problem684
    {
        public static int Solve()
        {
            ulong mod = 1000000007;
            for(ulong i = 99999999; i < 1099999999; i += 100000000)
            {
                Console.WriteLine(i + ": " + i % mod);
            }
            Console.WriteLine();
            for(ulong i = 999999999; i < 10999999999; i += 1000000000)
            {
                Console.WriteLine(i + ": " + i % mod);
            }
            Console.WriteLine();
            for(ulong i = 9999999999; i < 109999999999; i += 10000000000)
            {
                Console.WriteLine(i + ": " + i % mod);
            }
            Console.WriteLine();
            for(ulong i = 99999999999; i < 1099999999999; i += 100000000000)
            {
                Console.WriteLine(i + ": " + i % mod);
            }
            Console.WriteLine();
            for(ulong i = 999999999999; i < 10999999999999; i += 1000000000000)
            {
                Console.WriteLine(i + ": " + i % mod);
            }
            Console.WriteLine();
            for(ulong i = 9999999999999; i < 100999999999999; i+= 10000000000000)
            {
                Console.WriteLine(i + ": " + i % mod);
            }
            Console.WriteLine();
            for(ulong i = 99999999999999; i < 1000999999999999; i += 100000000000000)
            {
                Console.WriteLine(i + ": " + i % mod);
            }
            Console.WriteLine();
            for(ulong i = 999999999999999; i < 10000999999999999; i += 1000000000000000)
            {
                Console.WriteLine(i + ": " + i % mod);
            }
            Console.WriteLine();
            for(ulong i = 9999999999999999; i < 100000999999999999; i += 10000000000000000)
            {
                Console.WriteLine(i + ": " + i % mod);
            }
            Console.WriteLine();
            for(ulong i = 99999999999999999; i < 1000000999999999999; i += 100000000000000000)
            {
                Console.WriteLine(i + ": " + i % mod);
            }
            Console.WriteLine();
            for(ulong i = 999999999999999999; i < 10000000999999999999; i += 1000000000000000000)
            {
                Console.WriteLine(i + ": " + i % mod);
            }
            Console.WriteLine();
            for(ulong i = 9999999999999999999L; i < 10000000999999999999L; i += 10000000000000000000L)
            {
                Console.WriteLine(i + ": " + i % mod);
            }
            return 0;
        }
    }
}
