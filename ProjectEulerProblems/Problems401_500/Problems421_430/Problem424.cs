using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerProblems
{
    public class Problem424
    {
        public static long Solve()
        {
            KakuroBoard k = new KakuroBoard("6,X,X,(vCC),(vI),X,X,X,(hH),B,O,(vCA),(vJE),X,(hFE,vD),O,O,O,O,(hA),O,I,(hJC,vB),O,O,(hJC),H,O,O,O,X,X,X,(hJE),O,O,X");
            k.Solve();
            return 0;
        }
    }

    public class KakuroBoard
    {
        private int Size;
        private char[,] SpacesMasked;
        private int[,] Spaces;
        private List<KakuroClue> Clues;
        private Dictionary<Tuple<int, int>, List<KakuroClue>> SpaceToClue;
        private Dictionary<char, List<int>> Possibilities;
        private Dictionary<char, bool> PossibilitiesSet;

        public KakuroBoard(string s)
        {
            SpaceToClue = new Dictionary<Tuple<int, int>, List<KakuroClue>>();
            Clues = new List<KakuroClue>();
            string[] splits = s.Split(',');
            Size = int.Parse(splits[0]);
            List<string> splitsList = new List<string>();
            for(int i = 1; i < splits.Length; i++)
            {
                if(splits[i].Contains("(") && !splits[i].Contains(")") | (!splits[i].Contains("(") && splits[i].Contains(")")))
                {
                    splitsList.Add(splits[i] + "," + splits[i + 1]);
                    i++;
                }
                else
                {
                    splitsList.Add(splits[i]);
                }
            }
            
            Spaces = new int[Size, Size];
            SpacesMasked = new char[Size, Size];
            for(int i = 0; i < splitsList.Count; i++)
            {
                int r = i / Size;
                int c = i % Size;
                if(splitsList[i] == "X")
                {
                    Spaces[r, c] = -1;
                    SpacesMasked[r, c] = 'X';
                }
                else if(splitsList[i].Contains("(") && splitsList[i].Contains(")"))
                {
                    Spaces[r, c] = -1;
                    SpacesMasked[r, c] = 'X';
                    string[] clues = splitsList[i].Split(',');
                    for(int j = 0; j < clues.Length; j++)
                    {
                        clues[j] = clues[j].Trim(')', '(');
                        bool vertical = clues[j][0] == 'v';
                        string valMasked = clues[j].Trim('v', 'h');
                        Clues.Add(new KakuroClue(valMasked, 0, vertical, new Tuple<int, int>(r, c)));
                    }
                }
                else
                {
                    Spaces[r, c] = 0;
                    SpacesMasked[r, c] = splitsList[i][0];
                }
            }
            foreach(KakuroClue v in Clues)
            {
                if(v.Vertical)
                {
                    int c = v.Position.Item2;
                    for (int r = v.Position.Item1 + 1; r < Size; r++)
                    {
                        if(Spaces[r, c] == -1)
                        {
                            break;
                        }
                        v.AddSpace(r, c);
                        Tuple<int, int> coord = new Tuple<int, int>(r, c);
                        if(SpaceToClue.ContainsKey(coord))
                        {
                            SpaceToClue[coord].Add(v);
                        }
                        else
                        {
                            List<KakuroClue> temp = new List<KakuroClue>();
                            temp.Add(v);
                            SpaceToClue.Add(coord, temp);
                        }
                    }
                }
                else
                {
                    int r = v.Position.Item1;
                    for (int c = v.Position.Item2 + 1; c < Size; c++)
                    {
                        if (Spaces[r, c] == -1)
                        {
                            break;
                        }
                        v.AddSpace(r, c);
                        Tuple<int, int> coord = new Tuple<int, int>(r, c);
                        if (SpaceToClue.ContainsKey(coord))
                        {
                            SpaceToClue[coord].Add(v);
                        }
                        else
                        {
                            List<KakuroClue> temp = new List<KakuroClue>();
                            temp.Add(v);
                            SpaceToClue.Add(coord, temp);
                        }
                    }
                }
            }
            PossibilitiesSet = new Dictionary<char, bool>();
            Possibilities = new Dictionary<char, List<int>>();
            for(int i = 0; i < 10; i++)
            {
                char c = (char)(i + 65);
                PossibilitiesSet.Add(c, false);
                Possibilities.Add(c, new List<int>(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }));
            }
        }

        private void UpdatePossibilities()
        {
            for(int i = 0; i <= 9; i++)
            {
                char c = (char)(i + 65);
                List<int> temp = new List<int>(Possibilities[c]);
                for(int j = 0; j <= 9; j++)
                {
                    char c1 = (char)(j + 65);
                    if(c == c1)
                    {
                        continue;
                    }
                    temp.RemoveAll(x => Possibilities[c1].Contains(x));
                }
                if(temp.Count == 1)
                {
                    Possibilities[c] = temp;
                }
            }
            for (int i = 0; i <= 9; i++)
            {
                char c = (char)(i + 65);
                if (Possibilities[c].Count == 1 & !PossibilitiesSet[c])
                {
                    PossibilitiesSet[c] = true;
                    i = 0;
                    foreach (char c1 in Possibilities.Keys)
                    {
                        if(c1 == c)
                        {
                            continue;
                        }
                        Possibilities[c1].Remove(Possibilities[c][0]);
                    }
                }
            }

            for (int i = 0; i <= 9; i++)
            {
                char c = (char)(i + 65);
                if(Possibilities[c].Count == 2)
                {
                    for (int j = 1; j <= 9; j++)
                    {
                        char c1 = (char)(j + 65);
                        if(c1 == c)
                        {
                            continue;
                        }
                        if (Possibilities[c].SequenceEqual(Possibilities[c1]))
                        {
                            for (int k = 0; k <= 9; k++)
                            {
                                char c2 = (char)(k + 65);
                                if (c2 == c || c2 == c1)
                                {
                                    continue;
                                }
                                Possibilities[c2].RemoveAll(x => Possibilities[c].Contains(x));
                            }
                        }
                    }
                }
            }
        }

        private void UpdateCluesSpaces()
        {
            foreach(char c in PossibilitiesSet.Keys)
            {
                if(PossibilitiesSet[c])
                {
                    foreach(KakuroClue clue in Clues)
                    {
                        int place = clue.ValueMasked.IndexOf(c);
                        if(place > -1)
                        {
                            clue.ValueInter[place] = Possibilities[c][0];
                        }
                    }
                }
                for (int row = 0; row < Size; row++)
                {
                    for (int col = 0; col < Size; col++)
                    {
                        if (SpacesMasked[row, col] == c)
                        {
                            Spaces[row, col] = Possibilities[c][0];
                        }
                    }
                }
            }
            
        }

        public void Solve()
        {
            HashSet<char> chars = new HashSet<char>();
            // Remove zero from as many possibilities as possible
            for (int r = 0; r < Size; r++)
            {
                for(int c = 0; c < Size; c++)
                {
                    if(SpacesMasked[r, c] != 'X' & SpacesMasked[r, c] != 'O')
                    {
                        chars.Add(SpacesMasked[r, c]);
                        Possibilities[SpacesMasked[r, c]].Remove(0);
                    }
                }
            }
            // Remove based on clues (first letter of two letters cannot be > 3)
            foreach(KakuroClue clue in Clues)
            {
                foreach(char c in clue.ValueMasked)
                {
                    chars.Add(c);
                }
                Possibilities[clue.ValueMasked[0]].Remove(0);
                if(clue.ValueMasked.Length == 2)
                {
                    for(int i = 4; i <= 9; i++)
                    {
                        Possibilities[clue.ValueMasked[0]].Remove(i);
                    }
                    if(clue.Spaces.Count == 2)
                    {
                        for (int i = 2; i <= 9; i++)
                        {
                            Possibilities[clue.ValueMasked[0]].Remove(i);
                        }
                        Possibilities[clue.ValueMasked[1]].Remove(9);
                        Possibilities[clue.ValueMasked[1]].Remove(8);
                    }
                }
                if(clue.ValueMasked.Length == 1 && clue.Spaces.Count < 3)
                {
                    Possibilities[clue.ValueMasked[0]].Remove(1);
                    Possibilities[clue.ValueMasked[0]].Remove(2);
                }
            }

            // If a character does not appear, it must appear on the board, so cannot be zero
            for(int i = 0; i <= 9; i++)
            {
                char c = (char)(i + 65);
                if(!chars.Contains(c))
                {
                    Possibilities[c].Remove(0);
                }
            }

            // If a letter is on the board and associated with a one character clue with two spaces, it can't be a 9
            for (int r = 0; r < Size; r++)
            {
                for (int c = 0; c < Size; c++)
                {
                    if (SpacesMasked[r, c] != 'X' && SpacesMasked[r, c] != 'O')
                    {
                        Tuple<int, int> space = new Tuple<int, int>(r, c);
                        foreach (KakuroClue clue in SpaceToClue[space])
                        {
                            if (clue.Spaces.Count == 2)
                            {
                                Possibilities[SpacesMasked[r, c]].Remove(9);
                            }
                        }
                    }

                }
            }

            UpdatePossibilities();
            UpdateCluesSpaces();

            for (int i = 0; i < 10; i++)
            {
                char c = (char)(i + 65);
                Console.Write(c + ": ");
                foreach(int v in Possibilities[c])
                {
                    Console.Write(v + " ");
                }
                Console.WriteLine();
            }

            foreach (KakuroClue clue in Clues)
            {
                Console.WriteLine(clue);
            }
        }
    }

    public class KakuroClue
    {
        public bool Vertical;
        public string ValueMasked;
        public List<int> ValueInter;
        public int Value;
        public Tuple<int, int> Position;
        public List<Tuple<int, int>> Spaces;
        
        public KakuroClue(string vm, int v, bool vertical, Tuple<int, int> pos)
        {
            ValueMasked = vm;
            ValueInter = new List<int>();
            for(int i = 0; i < vm.Length; i++)
            {
                ValueInter.Add(-1);
            }
            Value = v;
            Vertical = vertical;
            Spaces = new List<Tuple<int, int>>();
            Position = pos;
        }

        public void AddSpace(int r, int c)
        {
            Spaces.Add(new Tuple<int, int>(r, c));
        }

        public override string ToString()
        {
            string s = "";
            for(int i = 0; i < ValueInter.Count; i++)
            {
                s = s + ValueInter[i];
            }
            return Position + " | " + ValueMasked + ": " + s + ", Length = " + Spaces.Count;
        }
    }
}
