using System.Collections;
using NUnit.Framework;

namespace PokerHandsComparer.UnitTests
{
    class FlushTests
    {
        [Test, TestCaseSource("FlushTestsWithResults")]
        public object CompareWith_ReturnsTheCorrectWinner(Hand first, Hand second)
        {
            return first.CompareWith(second);
        }

        private static IEnumerable FlushTestsWithResults
        {
            get
            {
                yield return new TestCaseData(HandsHelper.FlushToTen, HandsHelper.FlushToTen).Returns(Winner.Tie);
                yield return new TestCaseData(HandsHelper.FlushToTen, HandsHelper.HighCardQueen).Returns(Winner.FirstHand);
                yield return new TestCaseData(HandsHelper.FlushToTen, HandsHelper.PairOfTensKingHigh).Returns(Winner.FirstHand);
                yield return new TestCaseData(HandsHelper.FlushToTen, HandsHelper.PairsOfAcesAndFoursAndKingHigh).Returns(Winner.FirstHand);
                yield return new TestCaseData(HandsHelper.FlushToTen, HandsHelper.TripleKings).Returns(Winner.FirstHand);
                yield return new TestCaseData(HandsHelper.FlushToTen, HandsHelper.StraightToEight).Returns(Winner.FirstHand);

                yield return new TestCaseData(HandsHelper.FlushToTen, HandsHelper.FlushToKing).Returns(Winner.SecondHand);
                yield return new TestCaseData(HandsHelper.FlushToKing, HandsHelper.FlushToTen).Returns(Winner.FirstHand);

                yield return new TestCaseData(HandsHelper.FlushToTen, HandsHelper.FullFivesOverTens).Returns(Winner.SecondHand);
                yield return new TestCaseData(HandsHelper.FlushToTen, HandsHelper.FourOfSevens).Returns(Winner.SecondHand);
                yield return new TestCaseData(HandsHelper.FlushToTen, HandsHelper.StraightFlushToEight).Returns(Winner.SecondHand);
            }
        }
    }
}
