using System;
using System.Collections.Generic;
using System.Linq;

namespace PokerHandsComparer
{
    class Deck
    {
        private List<Card> cards;

        public Deck()
        {
            CreateDeck();
        }

        public void Shuffle()
        {
            cards = cards.OrderBy(card => Guid.NewGuid()).ToList();
        }

        public Card GetCard()
        {
            Card topCard = cards[cards.Count - 1];
            cards.RemoveAt(cards.Count - 1);
            return topCard;
        }

        public List<Card> GetAllCards()
        {
            return cards;
        }

        private void CreateDeck()
        {
            cards = new List<Card>();
            foreach (Value cardValue in Enum.GetValues(typeof(Value)))
            {
                foreach (Suit cardSuit in Enum.GetValues(typeof(Suit)))
                {
                    cards.Add(new Card(cardValue, cardSuit));
                }
            }
        }
    }
}
