using System.Collections;
using NUnit.Framework;

namespace PokerHandsComparer.UnitTests
{
    class ThreeOfAKindTests
    {
        [Test, TestCaseSource("FirstHandWinnerThreeOfAKindTests")]
        public void CompareWith_ReturnsFirstHandAsWinner_WhenFirstHandIsBetterThanSecondOne(Hand first, Hand second)
        {
            Assert.AreEqual(Winner.Hand1, first.CompareWith(second));
        }

        [Test]
        public void CompareWith_ReturnsTie_WhenBothHandsHaveTheSameCardRanks()
        {
            Assert.AreEqual(Winner.Tie, HandsHelper.TripleJacks.CompareWith(HandsHelper.TripleJacks));
        }

        [Test, TestCaseSource("SecondHandWinnerThreeOfAKindTests")]
        public void CompareWith_ReturnsSecondHandAsWinner_WhenFirstHandIsWorseThanSecondOne(Hand first, Hand second)
        {
            Assert.AreEqual(Winner.Hand2, first.CompareWith(second));
        }

        private static IEnumerable FirstHandWinnerThreeOfAKindTests
        {
            get
            {
                yield return new TestCaseData(HandsHelper.TripleJacks, HandsHelper.HighCardQueen);
                yield return new TestCaseData(HandsHelper.TripleJacks, HandsHelper.PairOfTensKingHigh);
                yield return new TestCaseData(HandsHelper.TripleJacks, HandsHelper.PairsOfAcesAndFoursAndKingHigh);
                yield return new TestCaseData(HandsHelper.TripleKings, HandsHelper.TripleJacks);
            }
        }

        private static IEnumerable SecondHandWinnerThreeOfAKindTests
        {
            get
            {
                yield return new TestCaseData(HandsHelper.TripleJacks, HandsHelper.TripleKings);
                yield return new TestCaseData(HandsHelper.TripleJacks, HandsHelper.StraightToEight);
                yield return new TestCaseData(HandsHelper.TripleJacks, HandsHelper.FlushToTen);
                yield return new TestCaseData(HandsHelper.TripleJacks, HandsHelper.FullFivesOverTens);
                yield return new TestCaseData(HandsHelper.TripleJacks, HandsHelper.FourOfSevens);
                yield return new TestCaseData(HandsHelper.TripleJacks, HandsHelper.StraightFlushToEight);
            }
        }
    }
}
