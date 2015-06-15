using System.Collections;
using NUnit.Framework;

namespace PokerHandsComparer.UnitTests
{
    class FullHouseTests
    {
        [Test, TestCaseSource("FirstHandWinnerFullHouseTests")]
        public void CompareWith_ReturnsFirstHandAsWinner_WhenFirstHandIsBetterThanSecondOne(Hand first, Hand second)
        {
            Assert.AreEqual(Winner.Hand1, first.CompareWith(second));
        }

        [Test, TestCaseSource("SecondHandWinnerFullHouseTests")]
        public void CompareWith_ReturnsSecondHandAsWinner_WhenFirstHandIsWorseThanSecondOne(Hand first, Hand second)
        {
            Assert.AreEqual(Winner.Hand2, first.CompareWith(second));
        }

        private static IEnumerable FirstHandWinnerFullHouseTests
        {
            get
            {
                yield return new TestCaseData(HandsHelper.FullFivesOverTens, HandsHelper.HighCardQueen);
                yield return new TestCaseData(HandsHelper.FullFivesOverTens, HandsHelper.PairOfTensKingHigh);
                yield return new TestCaseData(HandsHelper.FullFivesOverTens, HandsHelper.PairsOfAcesAndFoursAndKingHigh);
                yield return new TestCaseData(HandsHelper.FullFivesOverTens, HandsHelper.TripleKings);
                yield return new TestCaseData(HandsHelper.FullFivesOverTens, HandsHelper.StraightToEight);
                yield return new TestCaseData(HandsHelper.FullFivesOverTens, HandsHelper.FlushToTen);
                yield return new TestCaseData(HandsHelper.FullFivesOverAces, HandsHelper.FullFivesOverTens);
                yield return new TestCaseData(HandsHelper.FullNinesOverKings, HandsHelper.FullThreesOverKings);
                yield return new TestCaseData(HandsHelper.FullNinesOverKings, HandsHelper.FullFivesOverAces);
            }
        }

        private static IEnumerable SecondHandWinnerFullHouseTests
        {
            get
            {
                yield return new TestCaseData(HandsHelper.FullFivesOverTens, HandsHelper.FullFivesOverAces);
                yield return new TestCaseData(HandsHelper.FullThreesOverKings, HandsHelper.FullNinesOverKings);
                yield return new TestCaseData(HandsHelper.FullFivesOverAces, HandsHelper.FullNinesOverKings);
                yield return new TestCaseData(HandsHelper.FullFivesOverTens, HandsHelper.FourOfSevens);
                yield return new TestCaseData(HandsHelper.FullFivesOverTens, HandsHelper.StraightFlushToEight);
            }
        }
    }
}
