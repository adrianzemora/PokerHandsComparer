using System.Collections.Generic;
using System.Linq;

namespace PokerHandsComparer
{
    class Hand
    {
        private const int NumberOfCardsInHand = 5;

        public List<Card> Cards { get; set; }

        public Hand()
        {
            Cards = new List<Card>(NumberOfCardsInHand);
        }

        public Rank GetRank()
        {
            Cards = Cards.OrderBy(card => card.Value).ToList();

            if (IsRoyalFlush())
                return Rank.RoyalFlush;

            if (IsStraightFlush())
                return Rank.StraightFlush;

            if (IsFourOfAKind())
                return Rank.FourOfAKind;

            if (IsFullHouse())
                return Rank.FullHouse;

            if (IsFlush())
                return Rank.Flush;

            if (IsStraight())
                return Rank.Straight;

            if (IsThreeOfAKind())
                return Rank.ThreeOfAKind;

            if (IsTwoPairs())
                return Rank.TwoPairs;

            return IsPair() ? Rank.Pair : Rank.HighCard;
        }

        private bool IsRoyalFlush()
        {
            return IsStraight() && IsFlush() && Cards.All(card => card.Value >= Value.Ten);
        }

        private bool IsStraightFlush()
        {
            return IsStraight() && IsFlush() && Cards.Any(card => card.Value < Value.Ten);
        }

        private bool IsFourOfAKind()
        {
            var fourOfAKindGroups = Cards.GroupBy(card => card.Value).Where(g => g.Skip(3).Any()).ToList();
            return fourOfAKindGroups.Count == 1;
        }

        private bool IsFullHouse()
        {
            var threeOfAKindGroups = Cards.GroupBy(card => card.Value).Where(group => group.Skip(2).Any()).ToList();

            if (threeOfAKindGroups.Count == 0)
            {
                return false;
            }

            var twoOfAKindGroups =
                Cards.GroupBy(card => card.Value)
                    .Where(group => group.Skip(1).Any() && group.Key != threeOfAKindGroups.First().Key)
                    .ToList();

            return threeOfAKindGroups.Count == 1 && twoOfAKindGroups.Count == 1;
        }

        private bool IsFlush()
        {
            return Cards.All(card => card.Suit == Cards.First().Suit);
        }

        private bool IsStraight()
        {
            bool isStraightFromAce =
                Cards.Exists(card => card.Value == Value.Ace) && Cards.Exists(card => card.Value == Value.Two) &&
                Cards.Exists(card => card.Value == Value.Three) && Cards.Exists(card => card.Value == Value.Four) &&
                Cards.Exists(card => card.Value == Value.Five);

            return !Cards.Select((card, index) => card.Value - index).Distinct().Skip(1).Any() || isStraightFromAce;
        }

        private bool IsThreeOfAKind()
        {
            var threeOfAKindGroups = Cards.GroupBy(card => card.Value).Where(group => group.Skip(2).Any()).ToList();
            return threeOfAKindGroups.Count == 1;
        }

        private bool IsTwoPairs()
        {
            var twoOfAKindGroups = Cards.GroupBy(card => card.Value).Where(group => group.Skip(1).Any()).ToList();
            return twoOfAKindGroups.Count == 2;
        }

        private bool IsPair()
        {
            var towOfAKindGroups = Cards.GroupBy(card => card.Value).Where(group => group.Skip(1).Any()).ToList();
            return towOfAKindGroups.Count == 1;
        }
    }
}
