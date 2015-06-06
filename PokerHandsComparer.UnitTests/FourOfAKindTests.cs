using System.Collections;
using NUnit.Framework;

namespace PokerHandsComparer.UnitTests
{
    class FourOfAKindTests
    {
        [Test, TestCaseSource("FourOfAKindTestsWithResults")]
        public object CompareWith_ReturnsTheCorrectWinner(Hand first, Hand second)
        {
            return first.CompareWith(second);
        }

        private static IEnumerable FourOfAKindTestsWithResults
        {
            get
            {
                yield return new TestCaseData(HandsHelper.FourOfSevens, HandsHelper.FourOfSevens).Returns(Winner.Tie);
                yield return new TestCaseData(HandsHelper.FourOfSevens, HandsHelper.HighCardQueen).Returns(Winner.FirstHand);
                yield return new TestCaseData(HandsHelper.FourOfSevens, HandsHelper.PairOfTensKingHigh).Returns(Winner.FirstHand);
                yield return new TestCaseData(HandsHelper.FourOfSevens, HandsHelper.PairsOfAcesAndFoursAndKingHigh).Returns(Winner.FirstHand);
                yield return new TestCaseData(HandsHelper.FourOfSevens, HandsHelper.TripleKings).Returns(Winner.FirstHand);
                yield return new TestCaseData(HandsHelper.FourOfSevens, HandsHelper.StraightToEight).Returns(Winner.FirstHand);
                yield return new TestCaseData(HandsHelper.FourOfSevens, HandsHelper.FlushToTen).Returns(Winner.FirstHand);
                yield return new TestCaseData(HandsHelper.FourOfSevens, HandsHelper.FullFivesOverTens).Returns(Winner.FirstHand);

                yield return new TestCaseData(HandsHelper.FourOfSevens, HandsHelper.FourOfTwos).Returns(Winner.FirstHand);
                yield return new TestCaseData(HandsHelper.FourOfTwos, HandsHelper.FourOfSevens).Returns(Winner.SecondHand);

                yield return new TestCaseData(HandsHelper.FourOfSevens, HandsHelper.StraightFlushToEight).Returns(Winner.SecondHand);
            }
        }
    }
}
