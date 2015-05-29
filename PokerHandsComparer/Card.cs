
namespace PokerHandsComparer
{
    class Card
    {
        public Value Value { get; set; }
        public Suit Suit { get; set; }

        public Card(Value value, Suit suit)
        {
            Value = value;
            Suit = suit;
        }
    }
}
