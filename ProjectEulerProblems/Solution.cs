using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Numerics;
using System.Linq;
using ProjectEulerProblems.Mathematics;

namespace ProjectEulerProblems
{
    public class Solution
    {
        public static void Main(String[] args)
        {
            Stopwatch timer = Stopwatch.StartNew();
            Console.WriteLine(Problem689.Solve());
            timer.Stop();
            Console.WriteLine("Time: " + timer.ElapsedMilliseconds + " ms");
            Console.Read();

        }
    } 
}
