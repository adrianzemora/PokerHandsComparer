using System.Collections;
using NUnit.Framework;

namespace PokerHandsComparer.UnitTests
{
    class PairTests
    {
        [Test, TestCaseSource("PairTestsWithResults")]
        public object CompareWith_ReturnsTheCorrectWinner(Hand first, Hand second)
        {
            return first.CompareWith(second);
        }

        private static IEnumerable PairTestsWithResults
        {
            get
            {
                yield return new TestCaseData(HandsHelper.PairOfTensKingHigh, HandsHelper.PairOfTensKingHigh).Returns(Winner.Tie);
                yield return new TestCaseData(HandsHelper.PairOfTensKingHigh, HandsHelper.HighCardQueen).Returns(Winner.FirstHand);

                yield return new TestCaseData(HandsHelper.PairOfTensKingHigh, HandsHelper.PairOfTensNineHigh).Returns(Winner.FirstHand);
                yield return new TestCaseData(HandsHelper.PairOfTensNineHigh, HandsHelper.PairOfTensKingHigh).Returns(Winner.SecondHand);
                yield return new TestCaseData(HandsHelper.PairOfTensKingHigh, HandsHelper.PairOfSixesKingHigh).Returns(Winner.FirstHand);
                yield return new TestCaseData(HandsHelper.PairOfSixesKingHigh, HandsHelper.PairOfTensKingHigh).Returns(Winner.SecondHand);

                yield return new TestCaseData(HandsHelper.PairOfTensKingHigh, HandsHelper.PairsOfJacksAndTensAndKingHigh).Returns(Winner.SecondHand);
                yield return new TestCaseData(HandsHelper.PairOfTensKingHigh, HandsHelper.TripleJacks).Returns(Winner.SecondHand);
                yield return new TestCaseData(HandsHelper.PairOfTensKingHigh, HandsHelper.StraightToEight).Returns(Winner.SecondHand);
                yield return new TestCaseData(HandsHelper.PairOfTensKingHigh, HandsHelper.FlushToTen).Returns(Winner.SecondHand);
                yield return new TestCaseData(HandsHelper.PairOfTensKingHigh, HandsHelper.FullFivesOverTens).Returns(Winner.SecondHand);
                yield return new TestCaseData(HandsHelper.PairOfTensKingHigh, HandsHelper.FourOfSevens).Returns(Winner.SecondHand);
                yield return new TestCaseData(HandsHelper.PairOfTensKingHigh, HandsHelper.StraightFlushToEight).Returns(Winner.SecondHand);
            }
        }
    }
}
