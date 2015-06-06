using System.Collections;
using NUnit.Framework;

namespace PokerHandsComparer.UnitTests
{
    class StraightTests
    {
        [Test, TestCaseSource("StraightTestsWithResults")]
        public object CompareWith_ReturnsTheCorrectWinner(Hand first, Hand second)
        {
            return first.CompareWith(second);
        }

        private static IEnumerable StraightTestsWithResults
        {
            get
            {
                yield return new TestCaseData(HandsHelper.StraightToEight, HandsHelper.StraightToEight).Returns(Winner.Tie);
                yield return new TestCaseData(HandsHelper.StraightToEight, HandsHelper.HighCardQueen).Returns(Winner.FirstHand);
                yield return new TestCaseData(HandsHelper.StraightToEight, HandsHelper.PairOfTensKingHigh).Returns(Winner.FirstHand);
                yield return new TestCaseData(HandsHelper.StraightToEight, HandsHelper.PairsOfAcesAndFoursAndKingHigh).Returns(Winner.FirstHand);
                yield return new TestCaseData(HandsHelper.StraightToEight, HandsHelper.TripleKings).Returns(Winner.FirstHand);

                yield return new TestCaseData(HandsHelper.StraightToEight, HandsHelper.StraightToFive).Returns(Winner.FirstHand);
                yield return new TestCaseData(HandsHelper.StraightToFive, HandsHelper.StraightToEight).Returns(Winner.SecondHand);

                yield return new TestCaseData(HandsHelper.StraightToEight, HandsHelper.FlushToTen).Returns(Winner.SecondHand);
                yield return new TestCaseData(HandsHelper.StraightToEight, HandsHelper.FullFivesOverTens).Returns(Winner.SecondHand);
                yield return new TestCaseData(HandsHelper.StraightToEight, HandsHelper.FourOfSevens).Returns(Winner.SecondHand);
                yield return new TestCaseData(HandsHelper.StraightToEight, HandsHelper.StraightFlushToEight).Returns(Winner.SecondHand);
            }
        }
    }
}
