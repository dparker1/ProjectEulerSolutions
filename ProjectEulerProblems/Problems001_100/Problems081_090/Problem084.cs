using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerProblems
{
    public class Problem084
    {
        public static string Solve()
        {
            int dieSides = 4;
            Random die = new Random();
            double[] spaceCount = new double[40];
            int[] commCards = new int[] { -1, -1, -1, 0, 10, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1 };
            int[] chanCards = new int[] { 11, 24, 39, 0, 10, 5, -2, -2, -3, -4, -1, -1, -1, -1, -1, -1 };
            EulerUtilities.Shuffle(commCards);
            EulerUtilities.Shuffle(chanCards);
            int turn = 0;
            int space = 0;
            int drawCardVal = -1;
            while(turn < 1000000)
            {
                space = (space + die.Next(dieSides) + die.Next(dieSides) + 2) % 40;
                //Go to Jail
                if(space == 30)
                {
                    space = 10;
                }
                //Chance
                else if(space == 7 || space == 22 || space == 36)
                {
                    DrawCard(chanCards, out drawCardVal);
                    if(drawCardVal >= 0)
                    {
                        space = drawCardVal;
                    }
                    else if(drawCardVal == -2)
                    {
                        if(space == 7)
                        {
                            space = 15;
                        }
                        if(space == 22)
                        {
                            space = 25;
                        }
                        if(space == 36)
                        {
                            space = 5;
                        }
                    }
                    else if(drawCardVal == -4)
                    {
                        if(space == 7  || space == 36)
                        {
                            space = 12;
                        }
                        else
                        {
                            space = 28;
                        }
                    }
                    else if(drawCardVal == -3)
                    {
                        space += drawCardVal;
                    }
                }
                //Community Chest
                else if(space == 2 || space == 17 || space == 33)
                {
                    DrawCard(commCards, out drawCardVal);
                    if(drawCardVal != -1)
                    {
                        space = drawCardVal;
                    }
                }
                spaceCount[space]++;
                turn++;
            }
            int[] mostSpace = new int[3];
            double[] mostProb = new double[3];
            for(int i = 0; i < spaceCount.Length; i++)
            {
                if(spaceCount[i] > mostProb[0])
                {
                    mostProb[2] = mostProb[1];
                    mostProb[1] = mostProb[0];
                    mostProb[0] = spaceCount[i];
                    mostSpace[2] = mostSpace[1];
                    mostSpace[1] = mostSpace[0];
                    mostSpace[0] = i;
                }
                else if(spaceCount[i] > mostProb[1])
                {
                    mostProb[2] = mostProb[1];
                    mostProb[1] = spaceCount[i];
                    mostSpace[2] = mostSpace[1];
                    mostSpace[1] = i;
                }
                else if(spaceCount[i] > mostProb[2])
                {
                    mostProb[2] = spaceCount[i];
                    mostSpace[2] = i;
                }
            }
            for(int i = 0; i < 3; i++)
            {
                Console.WriteLine(mostSpace[i] + ": " + (mostProb[i] / turn));
            }
            return null;
        }

        private static void DrawCard(int[] deck, out int value)
        {
            value = deck[0];
            for(int i = 0; i < deck.Length - 1; i++)
            {
                EulerUtilities.Swap(deck, i, i + 1);
            }   
        }

    }
}
