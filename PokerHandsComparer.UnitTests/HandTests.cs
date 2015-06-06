using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace PokerHandsComparer.UnitTests
{
    class HandTests
    {
        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void New_ThrowsException_WhenTheHandIsNotReceivingFiveCards()
        {
            new Hand(new List<Card>
            {
                new Card(Rank.Jack, Suit.Hearts),
                new Card(Rank.Queen, Suit.Hearts),
                new Card(Rank.King, Suit.Hearts)});
        }

        [Test]
        public void GetCategoryRank_ReturnsStraightFlush_WhenCardsAreConsecutiveWithSameSuitAndAtLeastOneIsLowerThanTen()
        {
            var hand = new Hand(new List<Card>
                {
                    new Card(Rank.Nine, Suit.Hearts),
                    new Card(Rank.Ten, Suit.Hearts),
                    new Card(Rank.Jack, Suit.Hearts),
                    new Card(Rank.Queen, Suit.Hearts),
                    new Card(Rank.King, Suit.Hearts)});

            Assert.AreEqual(CategoryRank.StraightFlush, hand.GetCategoryRank());
        }

        [Test]
        public void GetCategoryRank_ReturnsFourOfAKind_WhenThereAreFourCardsWithTheSameValue()
        {
            var hand = new Hand(new List<Card>
                {
                    new Card(Rank.Four, Suit.Clubs),
                    new Card(Rank.Four, Suit.Hearts),
                    new Card(Rank.Four, Suit.Diamonds),
                    new Card(Rank.Four, Suit.Spades),
                    new Card(Rank.Ten, Suit.Diamonds)});

            Assert.AreEqual(CategoryRank.FourOfAKind, hand.GetCategoryRank());
        }

        [Test]
        public void GetCategoryRank_ReturnsFullHouse_WhenThereAreThreeCardsOfAKindAndTwoOfAnotherKind()
        {
            var hand = new Hand(new List<Card>
                {
                    new Card(Rank.Four, Suit.Clubs),
                    new Card(Rank.Four, Suit.Hearts),
                    new Card(Rank.Four, Suit.Diamonds),
                    new Card(Rank.Ten, Suit.Spades),
                    new Card(Rank.Ten, Suit.Diamonds)});

            Assert.AreEqual(CategoryRank.FullHouse, hand.GetCategoryRank());
        }

        [Test]
        public void GetCategoryRank_ReturnsFlush_WhenAllCardsHaveTheSameSuit()
        {
            var hand = new Hand(new List<Card>
                {
                    new Card(Rank.Two, Suit.Clubs),
                    new Card(Rank.Six, Suit.Clubs),
                    new Card(Rank.Eight, Suit.Clubs),
                    new Card(Rank.Jack, Suit.Clubs),
                    new Card(Rank.Queen, Suit.Clubs)});

            Assert.AreEqual(CategoryRank.Flush, hand.GetCategoryRank());
        }

        [Test]
        public void GetCategoryRank_ReturnsStraight_WhenCardsAreFromTwoToFiveAndThereIsAlsoAnAce()
        {
            var hand = new Hand(new List<Card>
                {
                    new Card(Rank.Ace, Suit.Clubs),
                    new Card(Rank.Two, Suit.Clubs),
                    new Card(Rank.Three, Suit.Clubs),
                    new Card(Rank.Four, Suit.Diamonds),
                    new Card(Rank.Five, Suit.Hearts)});

            Assert.AreEqual(CategoryRank.Straight, hand.GetCategoryRank());
        }

        [Test]
        public void GetCategoryRank_ReturnsStraight_WhenCardsAreConsecutive()
        {
            var hand = new Hand(new List<Card>
                {
                    new Card(Rank.Eight, Suit.Clubs),
                    new Card(Rank.Nine, Suit.Clubs),
                    new Card(Rank.Ten, Suit.Diamonds),
                    new Card(Rank.Jack, Suit.Hearts),
                    new Card(Rank.Queen, Suit.Clubs)});

            Assert.AreEqual(CategoryRank.Straight, hand.GetCategoryRank());
        }

        [Test]
        public void GetCategoryRank_ReturnsThreeOfAKind_WhenThereAreThreeCardsWithTheSameValue()
        {
            var hand = new Hand(new List<Card>
                {
                    new Card(Rank.Seven, Suit.Clubs),
                    new Card(Rank.Seven, Suit.Hearts),
                    new Card(Rank.Seven, Suit.Diamonds),
                    new Card(Rank.Jack, Suit.Hearts),
                    new Card(Rank.Queen, Suit.Clubs)});

            Assert.AreEqual(CategoryRank.ThreeOfAKind, hand.GetCategoryRank());
        }

        [Test]
        public void GetCategoryRank_ReturnsTwoPairs_WhenThereAreTwoCardsWithSameValueAndAnotherTwoCardsWithAnotherValue()
        {
            var hand = new Hand(new List<Card>
                {
                    new Card(Rank.Seven, Suit.Clubs),
                    new Card(Rank.Seven, Suit.Hearts),
                    new Card(Rank.Jack, Suit.Hearts),
                    new Card(Rank.Queen, Suit.Diamonds),
                    new Card(Rank.Queen, Suit.Clubs)});

            Assert.AreEqual(CategoryRank.TwoPairs, hand.GetCategoryRank());
        }

        [Test]
        public void GetCategoryRank_ReturnsPair_WhenThereAreTwoCardsWithTheSameValue()
        {
            var hand = new Hand(new List<Card>
                {
                    new Card(Rank.Seven, Suit.Clubs),
                    new Card(Rank.Seven, Suit.Hearts),
                    new Card(Rank.Three, Suit.Hearts),
                    new Card(Rank.Queen, Suit.Diamonds),
                    new Card(Rank.Ace, Suit.Clubs)});

            Assert.AreEqual(CategoryRank.Pair, hand.GetCategoryRank());
        }

        [Test]
        public void GetCategoryRank_ReturnsHighCard_IfTheCardsDoNotFormAHigherRank()
        {
            var hand = new Hand(new List<Card>
                {
                    new Card(Rank.Two, Suit.Clubs),
                    new Card(Rank.Seven, Suit.Hearts),
                    new Card(Rank.Three, Suit.Hearts),
                    new Card(Rank.Queen, Suit.Diamonds),
                    new Card(Rank.Ace, Suit.Clubs)});

            Assert.AreEqual(CategoryRank.HighCard, hand.GetCategoryRank());
        }
    }
}
