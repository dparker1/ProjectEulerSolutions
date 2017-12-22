using System;
using System.Collections.Generic;
using System.Numerics;
using System.Linq;

namespace ProjectEulerProblems
{
    public class Solution
    {
        public static void Main(String[] args)
        {
            DateTime startTime = DateTime.Now;
            Console.WriteLine(Problem125.Solve());
            TimeSpan timeElapsed = DateTime.Now - startTime;
            Console.WriteLine("Time: " + timeElapsed.Milliseconds + " ms");
            Console.Read();
        }
    } 
}
