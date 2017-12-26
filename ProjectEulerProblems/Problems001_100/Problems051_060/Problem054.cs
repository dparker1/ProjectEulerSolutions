using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerProblems
{
    public class Problem054
    {
        public static int Solve()
        {
            string[] lines = System.IO.File.ReadAllLines(@"..\..\txt\Problem054Text.txt");
            List<List<Card>> playerOne = new List<List<Card>>();
            List<List<Card>> playerTwo = new List<List<Card>>();
            for(int i = 0; i < lines.Length; i++)
            {
                string[] split = lines[i].Split(' ');
                playerOne.Add(new List<Card>());
                playerTwo.Add(new List<Card>());
                for(int z = 0; z < 5; z++)
                {
                    playerOne[i].Add(new Card(split[z]));
                    playerTwo[i].Add(new Card(split[z + 5]));
                }
            }
            int count = 0;
            for(int i = 0; i < lines.Length; i++)
            {
                if(Card.DidPlayer1Win(playerOne[i], playerTwo[i]))
                {
                    count++;
                }
            }

            return count;
        }
    }
}
