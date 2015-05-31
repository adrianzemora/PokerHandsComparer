using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PokerHandsComparer.UnitTests
{
    [TestClass]
    public class HandTests
    {
        [TestMethod]
        public void GetRank_ReturnsRoyalFlush_WhenCardsAreConsecutiveWithSameSuitAndAllAreHigherThanNine()
        {
            var hand = new Hand
            {
                Cards = new List<Card>
                {
                    new Card(Value.Ten, Suit.Hearts),
                    new Card(Value.Jack, Suit.Hearts),
                    new Card(Value.Queen, Suit.Hearts),
                    new Card(Value.King, Suit.Hearts),
                    new Card(Value.Ace, Suit.Hearts),
                }
            };

            Assert.AreEqual(Rank.RoyalFlush, hand.GetRank());
        }

        [TestMethod]
        public void GetRank_ReturnsStraightFlush_WhenCardsAreConsecutiveWithSameSuitAndAtLeastOneIsLowerThanTen()
        {
            var hand = new Hand
            {
                Cards = new List<Card>
                {
                    new Card(Value.Nine, Suit.Hearts),
                    new Card(Value.Ten, Suit.Hearts),
                    new Card(Value.Jack, Suit.Hearts),
                    new Card(Value.Queen, Suit.Hearts),
                    new Card(Value.King, Suit.Hearts),
                }
            };

            Assert.AreEqual(Rank.StraightFlush, hand.GetRank());
        }

        [TestMethod]
        public void GetRank_ReturnsFourOfAKind_WhenThereAreFourCardsWithTheSameValue()
        {
            var hand = new Hand
            {
                Cards = new List<Card>
                {
                    new Card(Value.Four, Suit.Clubs),
                    new Card(Value.Four, Suit.Hearts),
                    new Card(Value.Four, Suit.Diamonds),
                    new Card(Value.Four, Suit.Spades),
                    new Card(Value.Ten, Suit.Diamonds),
                }
            };

            Assert.AreEqual(Rank.FourOfAKind, hand.GetRank());
        }

        [TestMethod]
        public void GetRank_ReturnsFullHouse_WhenThereAreThreeCardsOfAKindAndTwoOfAnotherKind()
        {
            var hand = new Hand
            {
                Cards = new List<Card>
                {
                    new Card(Value.Four, Suit.Clubs),
                    new Card(Value.Four, Suit.Hearts),
                    new Card(Value.Four, Suit.Diamonds),
                    new Card(Value.Ten, Suit.Spades),
                    new Card(Value.Ten, Suit.Diamonds),
                }
            };

            Assert.AreEqual(Rank.FullHouse, hand.GetRank());
        }

        [TestMethod]
        public void GetRank_ReturnsFlush_WhenAllCardsHaveTheSameSuit()
        {
            var hand = new Hand
            {
                Cards = new List<Card>
                {
                    new Card(Value.Two, Suit.Clubs),
                    new Card(Value.Six, Suit.Clubs),
                    new Card(Value.Eight, Suit.Clubs),
                    new Card(Value.Jack, Suit.Clubs),
                    new Card(Value.Queen, Suit.Clubs),
                }
            };

            Assert.AreEqual(Rank.Flush, hand.GetRank());
        }

        [TestMethod]
        public void GetRank_ReturnsStraight_WhenCardsAreFromTwoToFiveAndThereIsAlsoAnAce()
        {
            var hand = new Hand
            {
                Cards = new List<Card>
                {
                    new Card(Value.Ace, Suit.Clubs),
                    new Card(Value.Two, Suit.Clubs),
                    new Card(Value.Three, Suit.Clubs),
                    new Card(Value.Four, Suit.Diamonds),
                    new Card(Value.Five, Suit.Hearts),
                }
            };

            Assert.AreEqual(Rank.Straight, hand.GetRank());
        }

        [TestMethod]
        public void GetRank_ReturnsStraight_WhenCardsAreConsecutive()
        {
            var hand = new Hand
            {
                Cards = new List<Card>
                {
                    new Card(Value.Eight, Suit.Clubs),
                    new Card(Value.Nine, Suit.Clubs),
                    new Card(Value.Ten, Suit.Diamonds),
                    new Card(Value.Jack, Suit.Hearts),
                    new Card(Value.Queen, Suit.Clubs),
                }
            };

            Assert.AreEqual(Rank.Straight, hand.GetRank());
        }

        [TestMethod]
        public void GetRank_ReturnsThreeOfAKind_WhenThereAreThreeCardsWithTheSameValue()
        {
            var hand = new Hand
            {
                Cards = new List<Card>
                {
                    new Card(Value.Seven, Suit.Clubs),
                    new Card(Value.Seven, Suit.Hearts),
                    new Card(Value.Seven, Suit.Diamonds),
                    new Card(Value.Jack, Suit.Hearts),
                    new Card(Value.Queen, Suit.Clubs),
                }
            };

            Assert.AreEqual(Rank.ThreeOfAKind, hand.GetRank());
        }

        [TestMethod]
        public void GetRank_ReturnsTwoPairs_WhenThereAreTwoCardsWithSameValueAndAnotherTwoCardsWithAnotherValue()
        {
            var hand = new Hand
            {
                Cards = new List<Card>
                {
                    new Card(Value.Seven, Suit.Clubs),
                    new Card(Value.Seven, Suit.Hearts),
                    new Card(Value.Jack, Suit.Hearts),
                    new Card(Value.Queen, Suit.Diamonds),
                    new Card(Value.Queen, Suit.Clubs),
                }
            };

            Assert.AreEqual(Rank.TwoPairs, hand.GetRank());
        }

        [TestMethod]
        public void GetRank_ReturnsPair_WhenThereAreTwoCardsWithTheSameValue()
        {
            var hand = new Hand
            {
                Cards = new List<Card>
                {
                    new Card(Value.Seven, Suit.Clubs),
                    new Card(Value.Seven, Suit.Hearts),
                    new Card(Value.Three, Suit.Hearts),
                    new Card(Value.Queen, Suit.Diamonds),
                    new Card(Value.Ace, Suit.Clubs),
                }
            };

            Assert.AreEqual(Rank.Pair, hand.GetRank());
        }

        [TestMethod]
        public void GetRank_ReturnsHighCard_IfTheCardsDoNotFormAHigherRank()
        {
            var hand = new Hand
            {
                Cards = new List<Card>
                {
                    new Card(Value.Two, Suit.Clubs),
                    new Card(Value.Seven, Suit.Hearts),
                    new Card(Value.Three, Suit.Hearts),
                    new Card(Value.Queen, Suit.Diamonds),
                    new Card(Value.Ace, Suit.Clubs),
                }
            };

            Assert.AreEqual(Rank.HighCard, hand.GetRank());
        }
    }
}
