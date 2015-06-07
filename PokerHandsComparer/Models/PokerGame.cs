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

            FirstHand = GetHand(deck);
            SecondHand = GetHand(deck);
        }

        public Winner GetWinner()
        {
            return FirstHand.CompareWith(SecondHand);
        }

        private static Hand GetHand(Deck deck)
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
