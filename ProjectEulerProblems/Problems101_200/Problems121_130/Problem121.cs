using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerProblems
{
    public class Problem121
    {
        static Random rand;
        public static int Solve()
        {
            rand = new Random();
            int numRounds = 15;
            int iterations = 100000000;

            int wins = 0;
            for(int iter = 0; iter < iterations; iter++)
            {
                wins += Win(numRounds);
            }

            double prize = (double)iterations / wins;
            return (int)Math.Floor(prize);
        }

        public static int Win(int numRounds)
        {
            int red = 1, blueDrawn = 0, totalDisks = 2, round = 0;
            while(round < numRounds)
            {
                int val = rand.Next(0, totalDisks);
                if(val == 0)
                {
                    blueDrawn++;
                }
                red++;
                totalDisks++;
                round++;
            }

            return (blueDrawn > 7) ? 1 : 0;
        }
    }
}
