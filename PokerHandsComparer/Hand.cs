using System;
using System.Collections.Generic;
using System.Linq;

namespace PokerHandsComparer
{
    public class Hand
    {
        private readonly CategoryRank categoryRank;
        private List<Card> Cards { get; set; }
        private List<Rank> Matches { get; set; }
        private List<Rank> Kickers { get; set; }

        public Hand(ICollection<Card> cards)
        {
            if (cards.Count != 5)
            {
                throw new ArgumentException("Invalid number of cards in Hand.");
            }

            Cards = cards.OrderByDescending(card => card.Rank).ToList();
            Matches = new List<Rank>();
            Kickers = new List<Rank>();
            categoryRank = GetRank();
        }

        public CategoryRank GetCategoryRank()
        {
            return categoryRank;
        }

        public Winner CompareWith(Hand otherHand)
        {
            Winner winner = GetWinnerByCategoryRanks(otherHand.GetCategoryRank());

            if (winner != Winner.Tie)
            {
                return winner;
            }

            winner = GetWinnerByMatches(otherHand.Matches);

            return winner == Winner.Tie ? GetWinnerByKickers(otherHand.Kickers) : winner;
        }

        private Winner GetWinnerByMatches(IList<Rank> otherHandMatches)
        {
            for (int i = 0; i < Matches.Count; i++)
            {
                if (Matches[i] == otherHandMatches[i])
                {
                    continue;
                }

                return Matches[i] > otherHandMatches[i] ? Winner.FirstHand : Winner.SecondHand;
            }

            return Winner.Tie;
        }

        private Winner GetWinnerByKickers(IList<Rank> otherHandKickers)
        {
            for (int i = 0; i < Kickers.Count; i++)
            {
                if (Kickers[i] == otherHandKickers[i])
                {
                    continue;
                }

                return Kickers[i] > otherHandKickers[i] ? Winner.FirstHand : Winner.SecondHand;
            }

            return Winner.Tie;
        }

        private Winner GetWinnerByCategoryRanks(CategoryRank otherHandRank)
        {
            if (categoryRank == otherHandRank)
            {
                return Winner.Tie;
            }

            return categoryRank < otherHandRank ? Winner.SecondHand : Winner.FirstHand;
        }

        private CategoryRank GetRank()
        {
            if (IsStraightFlush())
                return CategoryRank.StraightFlush;

            if (IsFourOfAKind())
                return CategoryRank.FourOfAKind;

            if (IsFullHouse())
                return CategoryRank.FullHouse;

            if (IsFlush())
                return CategoryRank.Flush;

            if (IsStraight())
                return CategoryRank.Straight;

            if (IsThreeOfAKind())
                return CategoryRank.ThreeOfAKind;

            if (IsTwoPairs())
                return CategoryRank.TwoPairs;

            if (IsPair())
                return CategoryRank.Pair;

            Matches = Cards.Select(card => card.Rank).ToList();
            return CategoryRank.HighCard;
        }

        private bool IsStraightFlush()
        {
            return IsFlush() && IsStraight();
        }

        private bool IsFourOfAKind()
        {
            var fourOfAKindGroups = Cards.GroupBy(card => card.Rank).Where(g => g.Skip(3).Any()).ToList();
            Matches = GetMatches(fourOfAKindGroups);
            Kickers = GetKickers();
            return fourOfAKindGroups.Count == 1;
        }

        private bool IsFullHouse()
        {
            var threeOfAKindGroups = Cards.GroupBy(card => card.Rank).Where(group => group.Skip(2).Any()).ToList();

            if (threeOfAKindGroups.Count == 0)
            {
                return false;
            }

            var twoOfAKindGroups =
                Cards.GroupBy(card => card.Rank)
                    .Where(group => group.Skip(1).Any() && group.Key != threeOfAKindGroups.First().Key)
                    .ToList();

            Matches.Clear();
            Matches.AddRange(GetMatches(threeOfAKindGroups));
            Matches.AddRange(GetMatches(twoOfAKindGroups));

            return threeOfAKindGroups.Count == 1 && twoOfAKindGroups.Count == 1;
        }

        private bool IsFlush()
        {
            Matches = Cards.Select(card => card.Rank).ToList();
            return Cards.All(card => card.Suit == Cards.First().Suit);
        }

        private bool IsStraight()
        {
            bool isStraightToFive =
                Cards.Exists(card => card.Rank == Rank.Ace) && Cards.Exists(card => card.Rank == Rank.Two) &&
                Cards.Exists(card => card.Rank == Rank.Three) && Cards.Exists(card => card.Rank == Rank.Four) &&
                Cards.Exists(card => card.Rank == Rank.Five);

            if (isStraightToFive)
            {
                Matches.Clear();
                Matches.AddRange(Cards.Where(card => card.Rank != Rank.Ace).Select(card => card.Rank));
                Matches.Add(Rank.Ace);
            }
            else
            {
                Matches = Cards.Select(card => card.Rank).ToList();
            }

            return !Cards.Select((card, index) => card.Rank + index).Distinct().Skip(1).Any() || isStraightToFive;
        }

        private bool IsThreeOfAKind()
        {
            var threeOfAKindGroups = Cards.GroupBy(card => card.Rank).Where(group => group.Skip(2).Any()).ToList();
            Matches = GetMatches(threeOfAKindGroups);
            Kickers = GetKickers();
            return threeOfAKindGroups.Count == 1;
        }

        private bool IsTwoPairs()
        {
            var twoOfAKindGroups = Cards.GroupBy(card => card.Rank).Where(group => group.Skip(1).Any()).ToList();
            Matches = GetMatches(twoOfAKindGroups);
            Kickers = GetKickers();
            return twoOfAKindGroups.Count == 2;
        }

        private bool IsPair()
        {
            var twoOfAKindGroups = Cards.GroupBy(card => card.Rank).Where(group => group.Skip(1).Any()).ToList();
            Matches = GetMatches(twoOfAKindGroups);
            Kickers = GetKickers();
            return twoOfAKindGroups.Count == 1;
        }

        private static List<Rank> GetMatches(IEnumerable<IGrouping<Rank, Card>> groups)
        {
            return groups.Select(group => group.Key).ToList();
        }

        private List<Rank> GetKickers()
        {
            return Cards.Where(card => !Matches.Contains(card.Rank)).Select(card => card.Rank).ToList();
        }
    }
}
