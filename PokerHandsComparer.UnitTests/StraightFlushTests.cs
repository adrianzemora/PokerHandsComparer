using System.Collections;
using NUnit.Framework;

namespace PokerHandsComparer.UnitTests
{
    class StraightFlushTests
    {
        [Test, TestCaseSource("FirstHandWinnerStraightFlushTests")]
        public void CompareWith_ReturnsFirstHandAsWinner_WhenFirstHandIsBetterThanSecondOne(Hand first, Hand second)
        {
            Assert.AreEqual(Winner.Hand1, first.CompareWith(second));
        }

        [Test]
        public void CompareWith_ReturnsTie_WhenBothHandsHaveTheSameCardRanks()
        {
            Assert.AreEqual(Winner.Tie, HandsHelper.StraightFlushToEight.CompareWith(HandsHelper.StraightFlushToEight));
        }

        [Test]
        public void CompareWith_ReturnsSecondHandAsWinner_WhenFirstHandIsWorseThanSecondOne()
        {
            Assert.AreEqual(Winner.Hand2, HandsHelper.StraightFlushToFive.CompareWith(HandsHelper.StraightFlushToEight));
        }

        private static IEnumerable FirstHandWinnerStraightFlushTests
        {
            get
            {
                yield return new TestCaseData(HandsHelper.StraightFlushToEight, HandsHelper.HighCardQueen);
                yield return new TestCaseData(HandsHelper.StraightFlushToEight, HandsHelper.PairOfTensKingHigh);
                yield return new TestCaseData(HandsHelper.StraightFlushToEight, HandsHelper.PairsOfAcesAndFoursAndKingHigh);
                yield return new TestCaseData(HandsHelper.StraightFlushToEight, HandsHelper.TripleKings);
                yield return new TestCaseData(HandsHelper.StraightFlushToEight, HandsHelper.StraightToEight);
                yield return new TestCaseData(HandsHelper.StraightFlushToEight, HandsHelper.FlushToTen);
                yield return new TestCaseData(HandsHelper.StraightFlushToEight, HandsHelper.FullNinesOverKings);
                yield return new TestCaseData(HandsHelper.StraightFlushToEight, HandsHelper.FourOfSevens);
                yield return new TestCaseData(HandsHelper.StraightFlushToEight, HandsHelper.StraightToFive);
            }
        }
    }
}
