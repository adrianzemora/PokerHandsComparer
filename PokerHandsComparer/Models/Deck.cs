using System;
using System.Collections.Generic;
using System.Linq;

namespace PokerHandsComparer.Models
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

        public Card GetSingleCard()
        {
            Card topCard = cards[cards.Count - 1];
            cards.RemoveAt(cards.Count - 1);
            return topCard;
        }

        public List<Card> GetCards()
        {
            return cards;
        }

        private void CreateDeck()
        {
            cards = new List<Card>();
            foreach (Rank rank in Enum.GetValues(typeof(Rank)))
            {
                foreach (Suit suit in Enum.GetValues(typeof(Suit)))
                {
                    cards.Add(new Card(rank, suit));
                }
            }
        }
    }
}
