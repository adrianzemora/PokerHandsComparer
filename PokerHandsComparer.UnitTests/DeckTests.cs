using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PokerHandsComparer.UnitTests
{
    [TestClass]
    public class DeckTests
    {
        [TestMethod]
        public void Shuffle_MixesTheCards()
        {
            var deck = new Deck();
            List<Card> beforeShuffle = deck.GetCards();

            deck.Shuffle();

            CollectionAssert.AreNotEqual(beforeShuffle, deck.GetCards());
        }

        [TestMethod]
        public void GetSingleCard_ReturnTheCardFromTop()
        {
            var deck = new Deck();
            var allCards = deck.GetCards();
            Card topCard = allCards[allCards.Count - 1];

            Assert.AreEqual(topCard, deck.GetSingleCard());
        }

        [TestMethod]
        public void GetSingleCard_RemovesCardFromDeck()
        {
            var deck = new Deck();

            var card = deck.GetSingleCard();

            CollectionAssert.DoesNotContain(deck.GetCards(), card);
        }
    }
}
