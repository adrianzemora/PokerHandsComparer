using System.Collections;
using NUnit.Framework;

namespace PokerHandsComparer.UnitTests
{
    class HighCardTests
    {
        [Test, TestCaseSource("HighCardTestsWithResults")]
        public object CompareWith_ReturnsTheCorrectWinner(Hand first, Hand second)
        {
            return first.CompareWith(second);
        }

        private static IEnumerable HighCardTestsWithResults
        {
            get
            {
                yield return new TestCaseData(HandsHelper.HighCardKing, HandsHelper.HighCardKing).Returns(Winner.Tie);

                yield return new TestCaseData(HandsHelper.HighCardKing, HandsHelper.HighCardQueen).Returns(Winner.FirstHand);
                yield return new TestCaseData(HandsHelper.HighCardQueen, HandsHelper.HighCardKing).Returns(Winner.SecondHand);

                yield return new TestCaseData(HandsHelper.HighCardKing, HandsHelper.PairOfTensKingHigh).Returns(Winner.SecondHand);
                yield return new TestCaseData(HandsHelper.HighCardKing, HandsHelper.PairsOfJacksAndTensAndKingHigh).Returns(Winner.SecondHand);
                yield return new TestCaseData(HandsHelper.HighCardKing, HandsHelper.TripleJacks).Returns(Winner.SecondHand);
                yield return new TestCaseData(HandsHelper.HighCardKing, HandsHelper.StraightToEight).Returns(Winner.SecondHand);
                yield return new TestCaseData(HandsHelper.HighCardKing, HandsHelper.FlushToTen).Returns(Winner.SecondHand);
                yield return new TestCaseData(HandsHelper.HighCardKing, HandsHelper.FullFivesOverTens).Returns(Winner.SecondHand);
                yield return new TestCaseData(HandsHelper.HighCardKing, HandsHelper.FourOfSevens).Returns(Winner.SecondHand);
                yield return new TestCaseData(HandsHelper.HighCardKing, HandsHelper.StraightFlushToEight).Returns(Winner.SecondHand);
            }
        }
    }
}
