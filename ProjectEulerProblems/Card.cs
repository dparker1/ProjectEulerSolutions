using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerProblems
{
    public class Card : IComparable<Card>
    {
        private int Value;
        private int Suit;

        public Card(string s)
        {
            switch(s[0])
            {
                case 'T':
                    Value = 10;
                    break;
                case 'J':
                    Value = 11;
                    break;
                case 'Q':
                    Value = 12;
                    break;
                case 'K':
                    Value = 13;
                    break;
                case 'A':
                    Value = 14;
                    break;
                default:
                    Value = s[0] - 48;
                    break;
            }
            switch(s[1])
            {
                case 'D':
                    Suit = 1;
                    break;
                case 'S':
                    Suit = 2;
                    break;
                case 'C':
                    Suit = 3;
                    break;
                case 'H':
                    Suit = 4;
                    break;
            }
        }

        public static bool DidPlayer1Win(List<Card> hand1, List<Card> hand2)
        {
            hand1.Sort();
            hand2.Sort();
            if(IsRoyalFlush(hand1) != IsRoyalFlush(hand2)) return IsRoyalFlush(hand1) > IsRoyalFlush(hand2);
            if(IsStraightFlush(hand1) != IsStraightFlush(hand2)) return IsStraightFlush(hand1) > IsStraightFlush(hand2);
            if(IsFourOfAKind(hand1) != IsFourOfAKind(hand2)) return IsFourOfAKind(hand1) > IsFourOfAKind(hand2);
            if(IsFullHouse(hand1, 1) != IsFullHouse(hand2, 1)) return IsFullHouse(hand1, 1) > IsFullHouse(hand2, 1);
            if(IsFullHouse(hand1, 2) != IsFullHouse(hand2, 2)) return IsFullHouse(hand1, 2) < IsFullHouse(hand2, 2);
            if(IsFlush(hand1) != IsFlush(hand2)) return IsFlush(hand1) > IsFlush(hand2);
            if(IsStraight(hand1) != IsStraight(hand2)) return IsStraight(hand1) > IsStraight(hand2);
            if(IsThreeOfAKind(hand1) != IsThreeOfAKind(hand2)) return IsThreeOfAKind(hand1) > IsThreeOfAKind(hand2);
            if(IsTwoPairs(hand1, 1) != IsTwoPairs(hand2, 1)) return IsTwoPairs(hand1, 1) > IsTwoPairs(hand2, 1);
            if(IsTwoPairs(hand1, 2) != IsTwoPairs(hand2, 2)) return IsTwoPairs(hand1, 2) > IsTwoPairs(hand2, 2);
            if(IsOnePair(hand1) != IsOnePair(hand2)) return IsOnePair(hand1) > IsOnePair(hand2);
            if(IsHighCard(hand1, 0) != IsHighCard(hand2, 0)) return IsHighCard(hand1, 0) > IsHighCard(hand2, 0);
            if(IsHighCard(hand1, 1) != IsHighCard(hand2, 1)) return IsHighCard(hand1, 1) > IsHighCard(hand2, 1);
            if(IsHighCard(hand1, 2) != IsHighCard(hand2, 2)) return IsHighCard(hand1, 2) > IsHighCard(hand2, 2);
            if(IsHighCard(hand1, 3) != IsHighCard(hand2, 3)) return IsHighCard(hand1, 3) > IsHighCard(hand2, 3);

            return false;
        }

        private static int IsStraight(List<Card> h)
        {
            for(int i = 0; i < 4; i++)
            {
                if(h[i].Value != h[i + 1].Value - 1)
                {
                    return -1;
                }
            }
            return h[4].Value;
        }

        private static int IsFlush(List<Card> h)
        {
            for(int i = 0; i < 4; i++)
            {
                if(h[i].Suit != h[i + 1].Suit)
                {
                    return -1;
                }
            }
            return h[4].Value;
        }

        private static int IsStraightFlush(List<Card> h)
        {
            if(IsFlush(h) > 0 && IsStraight(h) > 0)
            {
                return h[4].Value;
            }
            return -1;
        }

        private static int IsRoyalFlush(List<Card> h)
        {
            if(IsFlush(h) == 14) return 14;
            return -1;
        }

        private static int IsFourOfAKind(List<Card> h)
        {
            if(h[0].Value == h[1].Value &&
                h[1].Value == h[2].Value &&
                h[2].Value == h[3].Value)
                return h[0].Value;
            if(h[1].Value == h[2].Value &&
                h[2].Value == h[3].Value &&
                h[3].Value == h[4].Value)
                return h[1].Value;

            return -1;

        }

        private static int IsFullHouse(List<Card> h, int set)
        {
            if(set == 1 &&
               h[0].Value == h[1].Value &&
               h[1].Value == h[2].Value &&
               h[3].Value == h[4].Value)
                return h[0].Value;
            if(set == 2 &&
                h[0].Value == h[1].Value &&
               h[1].Value == h[2].Value &&
               h[3].Value == h[4].Value)
                return h[4].Value;
            if(set == 1 &&
               h[0].Value == h[1].Value &&
               h[2].Value == h[3].Value &&
               h[3].Value == h[4].Value)
                return h[4].Value;
            if(set == 2 &&
                h[0].Value == h[1].Value &&
               h[2].Value == h[3].Value &&
               h[3].Value == h[4].Value)
                return h[0].Value;
            return -1;
        }

        private static int IsThreeOfAKind(List<Card> h)
        {
            if(h[0].Value == h[1].Value &&
               h[1].Value == h[2].Value)
                return h[0].Value;

            if(h[1].Value == h[2].Value &&
               h[2].Value == h[3].Value)
                return h[1].Value;

            if(h[2].Value == h[3].Value &&
               h[3].Value == h[4].Value)
                return h[2].Value;

            return -1;
        }

        private static int IsTwoPairs(List<Card> h, int set)
        {
            if(set == 1 &&
                h[0].Value == h[1].Value &&
                h[2].Value == h[3].Value)
                return h[0].Value;
            if(set == 2 &&
                h[0].Value == h[1].Value &&
                h[2].Value == h[3].Value)
                return h[2].Value;
            if(set == 1 &&
                h[0].Value == h[1].Value &&
                h[3].Value == h[4].Value)
                return h[0].Value;
            if(set == 2 &&
                h[0].Value == h[1].Value &&
                h[3].Value == h[4].Value)
                return h[3].Value;

            if(set == 1 &&
                h[1].Value == h[2].Value &&
                h[3].Value == h[4].Value)
                return h[1].Value;
            if(set == 2 &&
                h[1].Value == h[2].Value &&
                h[3].Value == h[4].Value)
                return h[3].Value;
            return -1;
        }

        private static int IsOnePair(List<Card> h)
        {
            if(h[0].Value == h[1].Value) return h[0].Value;
            if(h[1].Value == h[2].Value) return h[1].Value;
            if(h[2].Value == h[3].Value) return h[2].Value;
            if(h[3].Value == h[4].Value) return h[3].Value;

            return -1;
        }

        private static int IsHighCard(List<Card> h, int card)
        {
            return h[4 - card].Value;
        }

        public int CompareTo(Card c)
        {
            if(c == null)
            {
                return 1;
            }
            if(this.Value > c.Value)
            {
                return 1;
            }
            else if(this.Value < c.Value)
            {
                return -1;
            }
            return 0;
        }

        public override string ToString()
        {
            return "DSCH"[Suit - 1] + "" + Value;
        }
    }
}
