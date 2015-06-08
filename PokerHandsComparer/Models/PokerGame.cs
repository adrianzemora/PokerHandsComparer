using System.Collections.Generic;

namespace PokerHandsComparer.Models
{
    class PokerGame
    {
        public Hand FirstHand { get; private set; }
        public Hand SecondHand { get; private set; }

        public PokerGame()
        {
            var deck = new Deck();
            deck.Shuffle();

            FirstHand = GetFiveCardsHand(deck);
            SecondHand = GetFiveCardsHand(deck);
        }

        public Winner GetWinner()
        {
            return FirstHand.CompareWith(SecondHand);
        }

        private static Hand GetFiveCardsHand(Deck deck)
        {
            return new Hand(new List<Card>
            {
                deck.GetSingleCard(),
                deck.GetSingleCard(),
                deck.GetSingleCard(),
                deck.GetSingleCard(),
                deck.GetSingleCard()
            });
        }
    }
}
