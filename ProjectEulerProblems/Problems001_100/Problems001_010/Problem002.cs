using System;

namespace ProjectEulerProblems
{
    public class Problem002
    {
        public static int Solve()
        {
            int termOne = 0;
            int termTwo = 1;
            int currentTerm = 2;
            int sum = 0;
            while(currentTerm < 4000000)
            {
                if(currentTerm % 2 == 0)
                {
                    sum += currentTerm;
                }
                termOne = termTwo;
                termTwo = currentTerm;
                currentTerm = termOne + termTwo;
            }

            return sum;
        }
    }
}
