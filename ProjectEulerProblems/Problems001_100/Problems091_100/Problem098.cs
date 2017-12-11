using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerProblems
{
    public class Problem098
    {
        public static int Solve()
        {
            string text = File.ReadAllText(@"..\..\txt\Problem098Text.txt");
            string[] words = text.Split(',');
            for(int i = 0; i < words.Length; i++)
            {
                words[i] = words[i].Replace("\"", "");
            }

            string[] sortedWords = words;
            for(int i = 0; i < sortedWords.Length; i++)
            {
                char[] sort = sortedWords[i].ToArray();
                Array.Sort(sort);
                sortedWords[i] = String.Join("", sort);
            }
            Dictionary<string, List<string>> set = new Dictionary<string, List<string>>();
            for(int i = 0; i < words.Length; i++)
            {
                if(!set.ContainsKey(sortedWords[i]))
                {
                    set[sortedWords[i]] = new List<string>();
                }
                set[sortedWords[i]].Add(words[i]);
            }
            List<long> squares = new List<long>();
            for(int i = 1; i < 1000000; i++)
            {
                squares.Add((long) Math.Pow(i, 2));
            }

            int maxSquare = 0;
            foreach(string key in set.Keys.Where(x=>set[x].Count == 2))
            {
                var tempSquares = squares.Where(x => x.ToString().Length == key.Length).Reverse();
                string word1 = set[key][0];
                string word2 = set[key][1];
                foreach(long square in tempSquares)
                {
                    Dictionary<char, int> mapping = new Dictionary<char, int>();
                    for(int i = 0; i < word1.Length; i++)
                    {
                        
                    }
                }
            }
            return 0;
        }
    }
}
