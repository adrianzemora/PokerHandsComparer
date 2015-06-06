using System.Collections.Generic;
using NUnit.Framework;

namespace PokerHandsComparer.UnitTests
{
    class DeckTests
    {
        [Test]
        void Shuffle_MixesTheCards()
        {
            var deck = new Deck();
            List<Card> beforeShuffle = deck.GetCards();

            deck.Shuffle();

            CollectionAssert.AreNotEqual(beforeShuffle, deck.GetCards());
        }

        [Test]
        public void GetSingleCard_ReturnTheCardFromTop()
        {
            var deck = new Deck();
            var allCards = deck.GetCards();
            Card topCard = allCards[allCards.Count - 1];

            Assert.AreEqual(topCard, deck.GetSingleCard());
        }

        [Test]
        public void GetSingleCard_RemovesCardFromDeck()
        {
            var deck = new Deck();

            var card = deck.GetSingleCard();

            CollectionAssert.DoesNotContain(deck.GetCards(), card);
        }
    }
}
