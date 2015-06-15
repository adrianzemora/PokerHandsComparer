using System.Collections;
using NUnit.Framework;

namespace PokerHandsComparer.UnitTests
{
    class FourOfAKindTests
    {
        [Test, TestCaseSource("FirstHandWinnerFourOfAKindTests")]
        public void CompareWith_ReturnsFirstHandAsWinner_WhenFirstHandIsBetterThanSecondOne(Hand first, Hand second)
        {
            Assert.AreEqual(Winner.Hand1, first.CompareWith(second));
        }

        [Test]
        public void CompareWith_ReturnsTie_WhenBothHandsHaveTheSameCardRanks()
        {
            Assert.AreEqual(Winner.Tie, HandsHelper.FourOfSevens.CompareWith(HandsHelper.FourOfSevens));
        }

        [Test, TestCaseSource("SecondHandWinnerFourOfAKindTests")]
        public void CompareWith_ReturnsSecondHandAsWinner_WhenFirstHandIsWorseThanSecondOne(Hand first, Hand second)
        {
            Assert.AreEqual(Winner.Hand2, first.CompareWith(second));
        }

        private static IEnumerable FirstHandWinnerFourOfAKindTests
        {
            get
            {
                yield return new TestCaseData(HandsHelper.FourOfSevens, HandsHelper.HighCardQueen);
                yield return new TestCaseData(HandsHelper.FourOfSevens, HandsHelper.PairOfTensKingHigh);
                yield return new TestCaseData(HandsHelper.FourOfSevens, HandsHelper.PairsOfAcesAndFoursAndKingHigh);
                yield return new TestCaseData(HandsHelper.FourOfSevens, HandsHelper.TripleKings);
                yield return new TestCaseData(HandsHelper.FourOfSevens, HandsHelper.StraightToEight);
                yield return new TestCaseData(HandsHelper.FourOfSevens, HandsHelper.FlushToTen);
                yield return new TestCaseData(HandsHelper.FourOfSevens, HandsHelper.FullFivesOverTens);
                yield return new TestCaseData(HandsHelper.FourOfSevens, HandsHelper.FourOfTwos);
            }
        }

        private static IEnumerable SecondHandWinnerFourOfAKindTests
        {
            get
            {
                yield return new TestCaseData(HandsHelper.FourOfTwos, HandsHelper.FourOfSevens);
                yield return new TestCaseData(HandsHelper.FourOfSevens, HandsHelper.StraightFlushToEight);
            }
        }
    }
}
