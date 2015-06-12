using System;
using System.Collections.Generic;
using System.Linq;

namespace PokerHandsComparer.Models
{
    public class Hand
    {
        private readonly CategoryRank categoryRank;
        private List<Rank> MatchedRanks { get; set; }
        private List<Rank> Kickers { get; set; }
        public List<Card> Cards { get; private set; }

        public Hand(ICollection<Card> cards)
        {
            if (cards.Count != 5)
            {
                throw new ArgumentException("Invalid number of cards in Hand.");
            }

            Cards = cards.OrderByDescending(card => card.Rank).ToList();
            MatchedRanks = new List<Rank>();
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

            winner = GetWinnerByMatchedRanks(otherHand.MatchedRanks);

            return winner == Winner.Tie ? GetWinnerByKickers(otherHand.Kickers) : winner;
        }

        private Winner GetWinnerByMatchedRanks(IList<Rank> otherHandMatches)
        {
            for (int i = 0; i < MatchedRanks.Count; i++)
            {
                if (MatchedRanks[i] == otherHandMatches[i])
                {
                    continue;
                }

                return MatchedRanks[i] > otherHandMatches[i] ? Winner.Hand1 : Winner.Hand2;
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

                return Kickers[i] > otherHandKickers[i] ? Winner.Hand1 : Winner.Hand2;
            }

            return Winner.Tie;
        }

        private Winner GetWinnerByCategoryRanks(CategoryRank otherHandRank)
        {
            if (categoryRank == otherHandRank)
            {
                return Winner.Tie;
            }

            return categoryRank < otherHandRank ? Winner.Hand2 : Winner.Hand1;
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

            MatchedRanks = Cards.Select(card => card.Rank).ToList();
            return CategoryRank.HighCard;
        }

        private bool IsStraightFlush()
        {
            return IsFlush() && IsStraight();
        }

        private bool IsFourOfAKind()
        {
            var fourOfAKindGroups = Cards.GroupBy(card => card.Rank).Where(g => g.Skip(3).Any()).ToList();
            MatchedRanks = GetMatchedRanks(fourOfAKindGroups);
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

            MatchedRanks.Clear();
            MatchedRanks.AddRange(GetMatchedRanks(threeOfAKindGroups));
            MatchedRanks.AddRange(GetMatchedRanks(twoOfAKindGroups));

            return threeOfAKindGroups.Count == 1 && twoOfAKindGroups.Count == 1;
        }

        private bool IsFlush()
        {
            MatchedRanks = Cards.Select(card => card.Rank).ToList();
            return Cards.All(card => card.Suit == Cards.First().Suit);
        }

        private bool IsStraight()
        {
            var fiveHighStraight = new List<Rank> { Rank.Ace, Rank.Two, Rank.Three, Rank.Four, Rank.Five };
            bool isFiveHighStraight = Cards.Select(card => card.Rank).Intersect(fiveHighStraight).Count() == Cards.Count;

            if (isFiveHighStraight)
            {
                MatchedRanks.Clear();
                MatchedRanks.AddRange(fiveHighStraight.Where(rank => rank != Rank.Ace));
                MatchedRanks.Add(Rank.Ace);
            }
            else
            {
                MatchedRanks = Cards.Select(card => card.Rank).ToList();
            }

            return AreCardsRanksConsecutive() || isFiveHighStraight;
        }

        private bool AreCardsRanksConsecutive()
        {
            return !Cards.Select((card, index) => card.Rank + index).Distinct().Skip(1).Any();
        }

        private bool IsThreeOfAKind()
        {
            var threeOfAKindGroups = Cards.GroupBy(card => card.Rank).Where(group => group.Skip(2).Any()).ToList();
            MatchedRanks = GetMatchedRanks(threeOfAKindGroups);
            Kickers = GetKickers();
            return threeOfAKindGroups.Count == 1;
        }

        private bool IsTwoPairs()
        {
            var twoOfAKindGroups = Cards.GroupBy(card => card.Rank).Where(group => group.Skip(1).Any()).ToList();
            MatchedRanks = GetMatchedRanks(twoOfAKindGroups);
            Kickers = GetKickers();
            return twoOfAKindGroups.Count == 2;
        }

        private bool IsPair()
        {
            var twoOfAKindGroups = Cards.GroupBy(card => card.Rank).Where(group => group.Skip(1).Any()).ToList();
            MatchedRanks = GetMatchedRanks(twoOfAKindGroups);
            Kickers = GetKickers();
            return twoOfAKindGroups.Count == 1;
        }

        private static List<Rank> GetMatchedRanks(IEnumerable<IGrouping<Rank, Card>> groups)
        {
            return groups.SelectMany(group => group).Select(card => card.Rank).ToList();
        }

        private List<Rank> GetKickers()
        {
            return Cards.Where(card => !MatchedRanks.Contains(card.Rank)).Select(card => card.Rank).ToList();
        }
    }
}
