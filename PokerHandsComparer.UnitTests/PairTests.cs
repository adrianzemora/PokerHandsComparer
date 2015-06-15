using System.Collections;
using NUnit.Framework;

namespace PokerHandsComparer.UnitTests
{
    class PairTests
    {
        [Test, TestCaseSource("FirstHandWinnerPairTests")]
        public void CompareWith_ReturnsFirstHandAsWinner_WhenFirstHandIsBetterThanSecondOne(Hand first, Hand second)
        {
            Assert.AreEqual(Winner.Hand1, first.CompareWith(second));
        }

        [Test]
        public void CompareWith_ReturnsTie_WhenBothHandsHaveTheSameCardRanks()
        {
            Assert.AreEqual(Winner.Tie, HandsHelper.PairOfSixesKingHigh.CompareWith(HandsHelper.PairOfSixesKingHigh));
        }

        [Test, TestCaseSource("SecondHandWinnerPairTests")]
        public void CompareWith_ReturnsSecondHandAsWinner_WhenFirstHandIsWorseThanSecondOne(Hand first, Hand second)
        {
            Assert.AreEqual(Winner.Hand2, first.CompareWith(second));
        }

        private static IEnumerable FirstHandWinnerPairTests
        {
            get
            {
                yield return new TestCaseData(HandsHelper.PairOfTensKingHigh, HandsHelper.HighCardQueen);
                yield return new TestCaseData(HandsHelper.PairOfTensKingHigh, HandsHelper.PairOfTensNineHigh);
                yield return new TestCaseData(HandsHelper.PairOfTensKingHigh, HandsHelper.PairOfSixesKingHigh);
            }
        }

        private static IEnumerable SecondHandWinnerPairTests
        {
            get
            {
                yield return new TestCaseData(HandsHelper.PairOfTensNineHigh, HandsHelper.PairOfTensKingHigh);
                yield return new TestCaseData(HandsHelper.PairOfSixesKingHigh, HandsHelper.PairOfTensKingHigh);
                yield return new TestCaseData(HandsHelper.PairOfTensKingHigh, HandsHelper.PairsOfJacksAndTensAndKingHigh);
                yield return new TestCaseData(HandsHelper.PairOfTensKingHigh, HandsHelper.TripleJacks);
                yield return new TestCaseData(HandsHelper.PairOfTensKingHigh, HandsHelper.StraightToEight);
                yield return new TestCaseData(HandsHelper.PairOfTensKingHigh, HandsHelper.FlushToTen);
                yield return new TestCaseData(HandsHelper.PairOfTensKingHigh, HandsHelper.FullFivesOverTens);
                yield return new TestCaseData(HandsHelper.PairOfTensKingHigh, HandsHelper.FourOfSevens);
                yield return new TestCaseData(HandsHelper.PairOfTensKingHigh, HandsHelper.StraightFlushToEight);
            }
        }
    }
}
