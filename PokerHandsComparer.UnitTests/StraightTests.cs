using System.Collections;
using NUnit.Framework;

namespace PokerHandsComparer.UnitTests
{
    class StraightTests
    {
        [Test, TestCaseSource("FirstHandWinnerStraightTests")]
        public void CompareWith_ReturnsFirstHandAsWinner_WhenFirstHandIsBetterThanSecondOne(Hand first, Hand second)
        {
            Assert.AreEqual(Winner.Hand1, first.CompareWith(second));
        }

        [Test]
        public void CompareWith_ReturnsTie_WhenBothHandsHaveTheSameCardRanks()
        {
            Assert.AreEqual(Winner.Tie, HandsHelper.StraightToEight.CompareWith(HandsHelper.StraightToEight));
        }

        [Test, TestCaseSource("SecondHandWinnerStraightTests")]
        public void CompareWith_ReturnsSecondHandAsWinner_WhenFirstHandIsWorseThanSecondOne(Hand first, Hand second)
        {
            Assert.AreEqual(Winner.Hand2, first.CompareWith(second));
        }

        private static IEnumerable FirstHandWinnerStraightTests
        {
            get
            {
                yield return new TestCaseData(HandsHelper.StraightToEight, HandsHelper.HighCardQueen);
                yield return new TestCaseData(HandsHelper.StraightToEight, HandsHelper.PairOfTensKingHigh);
                yield return new TestCaseData(HandsHelper.StraightToEight, HandsHelper.PairsOfAcesAndFoursAndKingHigh);
                yield return new TestCaseData(HandsHelper.StraightToEight, HandsHelper.TripleKings);
                yield return new TestCaseData(HandsHelper.StraightToEight, HandsHelper.StraightToFive);
            }
        }

        private static IEnumerable SecondHandWinnerStraightTests
        {
            get
            {
                yield return new TestCaseData(HandsHelper.StraightToFive, HandsHelper.StraightToEight);
                yield return new TestCaseData(HandsHelper.StraightToEight, HandsHelper.FlushToTen);
                yield return new TestCaseData(HandsHelper.StraightToEight, HandsHelper.FullFivesOverTens);
                yield return new TestCaseData(HandsHelper.StraightToEight, HandsHelper.FourOfSevens);
                yield return new TestCaseData(HandsHelper.StraightToEight, HandsHelper.StraightFlushToEight);
            }
        }
    }
}
