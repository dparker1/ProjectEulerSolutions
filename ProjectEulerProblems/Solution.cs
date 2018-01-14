using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Numerics;
using System.Linq;

namespace ProjectEulerProblems
{
    public class Solution
    {
        public static void Main(String[] args)
        {
            Stopwatch timer = Stopwatch.StartNew();
            Console.WriteLine(Problem084.Solve());
            timer.Stop();
            Console.WriteLine("Time: " + timer.ElapsedMilliseconds + " ms");
            Console.Read();
        }
    } 
}
