using System.Collections;
using NUnit.Framework;

namespace PokerHandsComparer.UnitTests
{
    class FlushTests
    {
        [Test, TestCaseSource("FirstHandWinnerFlushTests")]
        public void CompareWith_ReturnsFirstHandAsWinner_WhenFirstHandIsBetterThanSecondOne(Hand first, Hand second)
        {
            Assert.AreEqual(Winner.Hand1, first.CompareWith(second));
        }

        [Test]
        public void CompareWith_ReturnsTie_WhenBothHandsHaveTheSameCardRanks()
        {
            Assert.AreEqual(Winner.Tie, HandsHelper.FlushToTen.CompareWith(HandsHelper.FlushToTen));
        }

        [Test, TestCaseSource("SecondHandWinnerFlushTests")]
        public void CompareWith_ReturnsSecondHandAsWinner_WhenFirstHandIsWorseThanSecondOne(Hand first, Hand second)
        {
            Assert.AreEqual(Winner.Hand2, first.CompareWith(second));
        }

        private static IEnumerable FirstHandWinnerFlushTests
        {
            get
            {
                yield return new TestCaseData(HandsHelper.FlushToTen, HandsHelper.HighCardQueen);
                yield return new TestCaseData(HandsHelper.FlushToTen, HandsHelper.PairOfTensKingHigh);
                yield return new TestCaseData(HandsHelper.FlushToTen, HandsHelper.PairsOfAcesAndFoursAndKingHigh);
                yield return new TestCaseData(HandsHelper.FlushToTen, HandsHelper.TripleKings);
                yield return new TestCaseData(HandsHelper.FlushToTen, HandsHelper.StraightToEight);
                yield return new TestCaseData(HandsHelper.FlushToKing, HandsHelper.FlushToTen);
            }
        }

        private static IEnumerable SecondHandWinnerFlushTests
        {
            get
            {
                yield return new TestCaseData(HandsHelper.FlushToTen, HandsHelper.FlushToKing);
                yield return new TestCaseData(HandsHelper.FlushToTen, HandsHelper.FullFivesOverTens);
                yield return new TestCaseData(HandsHelper.FlushToTen, HandsHelper.FourOfSevens);
                yield return new TestCaseData(HandsHelper.FlushToTen, HandsHelper.StraightFlushToEight);
            }
        }
    }
}
