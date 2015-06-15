using System.Collections;
using NUnit.Framework;

namespace PokerHandsComparer.UnitTests
{
    class HighCardTests
    {
        [Test]
        public void CompareWith_ReturnsFirstHandAsWinner_WhenFirstHandIsBetterThanSecondOne()
        {
            Assert.AreEqual(Winner.Hand1, HandsHelper.HighCardKing.CompareWith(HandsHelper.HighCardQueen));
        }

        [Test]
        public void CompareWith_ReturnsTie_WhenBothHandsHaveTheSameCardRanks()
        {
            Assert.AreEqual(Winner.Tie, HandsHelper.HighCardKing.CompareWith(HandsHelper.HighCardKing));
        }

        [Test, TestCaseSource("SecondHandWinnerHighCardTests")]
        public void CompareWith_ReturnsSecondHandAsWinner_WhenFirstHandIsWorseThanSecondOne(Hand first, Hand second)
        {
            Assert.AreEqual(Winner.Hand2, first.CompareWith(second));
        }
        
        private static IEnumerable SecondHandWinnerHighCardTests
        {
            get
            {
                yield return new TestCaseData(HandsHelper.HighCardQueen, HandsHelper.HighCardKing);
                yield return new TestCaseData(HandsHelper.HighCardKing, HandsHelper.PairOfTensKingHigh);
                yield return new TestCaseData(HandsHelper.HighCardKing, HandsHelper.PairsOfJacksAndTensAndKingHigh);
                yield return new TestCaseData(HandsHelper.HighCardKing, HandsHelper.TripleJacks);
                yield return new TestCaseData(HandsHelper.HighCardKing, HandsHelper.StraightToEight);
                yield return new TestCaseData(HandsHelper.HighCardKing, HandsHelper.FlushToTen);
                yield return new TestCaseData(HandsHelper.HighCardKing, HandsHelper.FullFivesOverTens);
                yield return new TestCaseData(HandsHelper.HighCardKing, HandsHelper.FourOfSevens);
                yield return new TestCaseData(HandsHelper.HighCardKing, HandsHelper.StraightFlushToEight);
            }
        }
    }
}
