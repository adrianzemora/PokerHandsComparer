using System.Collections;
using NUnit.Framework;

namespace PokerHandsComparer.UnitTests
{
    class FullHouseTests
    {
        [Test, TestCaseSource("FullHouseTestsWithResults")]
        public object CompareWith_ReturnsTheCorrectWinner(Hand first, Hand second)
        {
            return first.CompareWith(second);
        }

        private static IEnumerable FullHouseTestsWithResults
        {
            get
            {
                yield return new TestCaseData(HandsHelper.FullFivesOverTens, HandsHelper.FullFivesOverTens).Returns(Winner.Tie);
                yield return new TestCaseData(HandsHelper.FullFivesOverTens, HandsHelper.HighCardQueen).Returns(Winner.FirstHand);
                yield return new TestCaseData(HandsHelper.FullFivesOverTens, HandsHelper.PairOfTensKingHigh).Returns(Winner.FirstHand);
                yield return new TestCaseData(HandsHelper.FullFivesOverTens, HandsHelper.PairsOfAcesAndFoursAndKingHigh).Returns(Winner.FirstHand);
                yield return new TestCaseData(HandsHelper.FullFivesOverTens, HandsHelper.TripleKings).Returns(Winner.FirstHand);
                yield return new TestCaseData(HandsHelper.FullFivesOverTens, HandsHelper.StraightToEight).Returns(Winner.FirstHand);
                yield return new TestCaseData(HandsHelper.FullFivesOverTens, HandsHelper.FlushToTen).Returns(Winner.FirstHand);

                yield return new TestCaseData(HandsHelper.FullFivesOverTens, HandsHelper.FullFivesOverAces).Returns(Winner.SecondHand);
                yield return new TestCaseData(HandsHelper.FullFivesOverAces, HandsHelper.FullFivesOverTens).Returns(Winner.FirstHand);
                yield return new TestCaseData(HandsHelper.FullNinesOverKings, HandsHelper.FullThreesOverKings).Returns(Winner.FirstHand);
                yield return new TestCaseData(HandsHelper.FullThreesOverKings, HandsHelper.FullNinesOverKings).Returns(Winner.SecondHand);
                yield return new TestCaseData(HandsHelper.FullFivesOverAces, HandsHelper.FullNinesOverKings).Returns(Winner.SecondHand);
                yield return new TestCaseData(HandsHelper.FullNinesOverKings, HandsHelper.FullFivesOverAces).Returns(Winner.FirstHand);

                yield return new TestCaseData(HandsHelper.FullFivesOverTens, HandsHelper.FourOfSevens).Returns(Winner.SecondHand);
                yield return new TestCaseData(HandsHelper.FullFivesOverTens, HandsHelper.StraightFlushToEight).Returns(Winner.SecondHand);
            }
        }
    }
}
