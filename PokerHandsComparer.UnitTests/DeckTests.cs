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
            List<Card> beforeShuffle = deck.GetAllCards();

            deck.Shuffle();

            CollectionAssert.AreNotEqual(beforeShuffle, deck.GetAllCards());
        }

        [TestMethod]
        public void GetCard_ReturnTheCardFromTop()
        {
            var deck = new Deck();
            var allCards = deck.GetAllCards();
            Card topCard = allCards[allCards.Count - 1];

            Assert.AreEqual(topCard, deck.GetCard());
        }

        [TestMethod]
        public void GetCard_RemovesCardFromDeck()
        {
            var deck = new Deck();

            var card = deck.GetCard();

            CollectionAssert.DoesNotContain(deck.GetAllCards(), card);
        }
    }
}
