using System.Collections.Generic;

namespace PokerHandsComparer.UnitTests
{
    static class HandsHelper
    {

        public static readonly Hand HighCardKing =
            new Hand(new List<Card>
            {
                new Card(Rank.King, Suit.Hearts),
                new Card(Rank.Eight, Suit.Clubs),
                new Card(Rank.Five, Suit.Diamonds),
                new Card(Rank.Three, Suit.Hearts),
                new Card(Rank.Two, Suit.Clubs)
            });

        public static readonly Hand HighCardQueen =
            new Hand(new List<Card>
            {
                new Card(Rank.Queen, Suit.Hearts),
                new Card(Rank.Jack, Suit.Clubs),
                new Card(Rank.Ten, Suit.Diamonds),
                new Card(Rank.Three, Suit.Diamonds),
                new Card(Rank.Two, Suit.Diamonds)
            });

        public static readonly Hand PairOfTensKingHigh =
            new Hand(new List<Card>
            {
                new Card(Rank.Ten, Suit.Hearts),
                new Card(Rank.Ten, Suit.Clubs),
                new Card(Rank.Queen, Suit.Diamonds),
                new Card(Rank.Three, Suit.Diamonds),
                new Card(Rank.Two, Suit.Diamonds)
            });

        public static readonly Hand PairOfTensNineHigh =
            new Hand(new List<Card>
            {
                new Card(Rank.Ten, Suit.Hearts),
                new Card(Rank.Ten, Suit.Clubs),
                new Card(Rank.Nine, Suit.Diamonds),
                new Card(Rank.Three, Suit.Diamonds),
                new Card(Rank.Two, Suit.Diamonds)
            });

        public static readonly Hand PairOfSixesKingHigh =
            new Hand(new List<Card>
            {
                new Card(Rank.Six, Suit.Hearts),
                new Card(Rank.Six, Suit.Clubs),
                new Card(Rank.King, Suit.Diamonds),
                new Card(Rank.Three, Suit.Diamonds),
                new Card(Rank.Two, Suit.Diamonds)
            });

        public static readonly Hand PairsOfJacksAndTensAndKingHigh =
                   new Hand(new List<Card>
            {
                new Card(Rank.Jack, Suit.Hearts),
                new Card(Rank.Jack, Suit.Clubs),
                new Card(Rank.Ten, Suit.Diamonds),
                new Card(Rank.Ten, Suit.Clubs),
                new Card(Rank.King, Suit.Diamonds)
            });

        public static readonly Hand PairsOfAcesAndFoursAndTenHigh =
                   new Hand(new List<Card>
            {
                new Card(Rank.Ace, Suit.Hearts),
                new Card(Rank.Ace, Suit.Clubs),
                new Card(Rank.Four, Suit.Diamonds),
                new Card(Rank.Four, Suit.Clubs),
                new Card(Rank.Ten, Suit.Diamonds)
            });

        public static readonly Hand PairsOfAcesAndFoursAndKingHigh =
                   new Hand(new List<Card>
            {
                new Card(Rank.Ace, Suit.Hearts),
                new Card(Rank.Ace, Suit.Clubs),
                new Card(Rank.Four, Suit.Diamonds),
                new Card(Rank.Four, Suit.Clubs),
                new Card(Rank.King, Suit.Diamonds)
            });

        public static readonly Hand PairsOfJacksAndSixesAndKingHigh =
                   new Hand(new List<Card>
            {
                new Card(Rank.Jack, Suit.Hearts),
                new Card(Rank.Jack, Suit.Clubs),
                new Card(Rank.Six, Suit.Diamonds),
                new Card(Rank.Six, Suit.Clubs),
                new Card(Rank.King, Suit.Diamonds)
            });

        public static readonly Hand TripleJacks =
                   new Hand(new List<Card>
            {
                new Card(Rank.Jack, Suit.Hearts),
                new Card(Rank.Jack, Suit.Clubs),
                new Card(Rank.Jack, Suit.Diamonds),
                new Card(Rank.Queen, Suit.Diamonds),
                new Card(Rank.Ten, Suit.Diamonds)
            });

        public static readonly Hand TripleKings =
                   new Hand(new List<Card>
            {
                new Card(Rank.King, Suit.Hearts),
                new Card(Rank.King, Suit.Clubs),
                new Card(Rank.King, Suit.Diamonds),
                new Card(Rank.Five, Suit.Diamonds),
                new Card(Rank.Two, Suit.Diamonds)
            });

        public static readonly Hand StraightToEight =
                   new Hand(new List<Card>
            {
                new Card(Rank.Four, Suit.Hearts),
                new Card(Rank.Five, Suit.Clubs),
                new Card(Rank.Six, Suit.Diamonds),
                new Card(Rank.Seven, Suit.Diamonds),
                new Card(Rank.Eight, Suit.Diamonds)
            });

        public static readonly Hand StraightToFive =
                   new Hand(new List<Card>
            {
                new Card(Rank.Ace, Suit.Hearts),
                new Card(Rank.Two, Suit.Clubs),
                new Card(Rank.Three, Suit.Diamonds),
                new Card(Rank.Four, Suit.Diamonds),
                new Card(Rank.Five, Suit.Diamonds)
            });

        public static readonly Hand FlushToTen =
                   new Hand(new List<Card>
            {
                new Card(Rank.Two, Suit.Hearts),
                new Card(Rank.Five, Suit.Hearts),
                new Card(Rank.Six, Suit.Hearts),
                new Card(Rank.Nine, Suit.Hearts),
                new Card(Rank.Ten, Suit.Hearts)
            });

        public static readonly Hand FlushToKing =
                   new Hand(new List<Card>
            {
                new Card(Rank.Two, Suit.Diamonds),
                new Card(Rank.Five, Suit.Diamonds),
                new Card(Rank.Six, Suit.Diamonds),
                new Card(Rank.Nine, Suit.Diamonds),
                new Card(Rank.King, Suit.Diamonds)
            });

        public static readonly Hand FullFivesOverTens =
                   new Hand(new List<Card>
            {
                new Card(Rank.Five, Suit.Hearts),
                new Card(Rank.Five, Suit.Clubs),
                new Card(Rank.Five, Suit.Diamonds),
                new Card(Rank.Ten, Suit.Hearts),
                new Card(Rank.Ten, Suit.Spades)
            });

        public static readonly Hand FullFivesOverAces =
                  new Hand(new List<Card>
            {
                new Card(Rank.Five, Suit.Hearts),
                new Card(Rank.Five, Suit.Clubs),
                new Card(Rank.Five, Suit.Diamonds),
                new Card(Rank.Ace, Suit.Hearts),
                new Card(Rank.Ace, Suit.Spades)
            });

        public static readonly Hand FullNinesOverKings =
                  new Hand(new List<Card>
            {
                new Card(Rank.Nine, Suit.Hearts),
                new Card(Rank.Nine, Suit.Clubs),
                new Card(Rank.Nine, Suit.Diamonds),
                new Card(Rank.King, Suit.Hearts),
                new Card(Rank.King, Suit.Spades)
            });

        public static readonly Hand FullThreesOverKings =
                  new Hand(new List<Card>
            {
                new Card(Rank.Three, Suit.Hearts),
                new Card(Rank.Three, Suit.Clubs),
                new Card(Rank.Three, Suit.Diamonds),
                new Card(Rank.King, Suit.Hearts),
                new Card(Rank.King, Suit.Spades)
            });

        public static readonly Hand FourOfSevens =
                           new Hand(new List<Card>
            {
                new Card(Rank.Seven, Suit.Hearts),
                new Card(Rank.Seven, Suit.Clubs),
                new Card(Rank.Seven, Suit.Spades),
                new Card(Rank.Seven, Suit.Diamonds),
                new Card(Rank.Ten, Suit.Hearts)
            });

        public static readonly Hand FourOfTwos =
                           new Hand(new List<Card>
            {
                new Card(Rank.Two, Suit.Hearts),
                new Card(Rank.Two, Suit.Clubs),
                new Card(Rank.Two, Suit.Spades),
                new Card(Rank.Two, Suit.Diamonds),
                new Card(Rank.Ten, Suit.Hearts)
            });

        public static readonly Hand StraightFlushToEight =
                           new Hand(new List<Card>
            {
                new Card(Rank.Four, Suit.Hearts),
                new Card(Rank.Five, Suit.Hearts),
                new Card(Rank.Six, Suit.Hearts),
                new Card(Rank.Seven, Suit.Hearts),
                new Card(Rank.Eight, Suit.Hearts)
            });

        public static readonly Hand StraightFlushToFive =
                           new Hand(new List<Card>
            {
                new Card(Rank.Ace, Suit.Clubs),
                new Card(Rank.Two, Suit.Clubs),
                new Card(Rank.Three, Suit.Clubs),
                new Card(Rank.Four, Suit.Clubs),
                new Card(Rank.Five, Suit.Clubs)
            });
    }
}
