using System.Collections;
using NUnit.Framework;

namespace PokerHandsComparer.UnitTests
{
    class ThreeOfAKindTests
    {
        [Test, TestCaseSource("ThreeOfAKindTestsWithResults")]
        public object CompareWith_ReturnsTheCorrectWinner(Hand first, Hand second)
        {
            return first.CompareWith(second);
        }

        private static IEnumerable ThreeOfAKindTestsWithResults
        {
            get
            {
                yield return new TestCaseData(HandsHelper.TripleJacks, HandsHelper.TripleJacks).Returns(Winner.Tie);
                yield return new TestCaseData(HandsHelper.TripleJacks, HandsHelper.HighCardQueen).Returns(Winner.FirstHand);
                yield return new TestCaseData(HandsHelper.TripleJacks, HandsHelper.PairOfTensKingHigh).Returns(Winner.FirstHand);
                yield return new TestCaseData(HandsHelper.TripleJacks, HandsHelper.PairsOfAcesAndFoursAndKingHigh).Returns(Winner.FirstHand);

                yield return new TestCaseData(HandsHelper.TripleJacks, HandsHelper.TripleKings).Returns(Winner.SecondHand);
                yield return new TestCaseData(HandsHelper.TripleKings, HandsHelper.TripleJacks).Returns(Winner.FirstHand);

                yield return new TestCaseData(HandsHelper.TripleJacks, HandsHelper.StraightToEight).Returns(Winner.SecondHand);
                yield return new TestCaseData(HandsHelper.TripleJacks, HandsHelper.FlushToTen).Returns(Winner.SecondHand);
                yield return new TestCaseData(HandsHelper.TripleJacks, HandsHelper.FullFivesOverTens).Returns(Winner.SecondHand);
                yield return new TestCaseData(HandsHelper.TripleJacks, HandsHelper.FourOfSevens).Returns(Winner.SecondHand);
                yield return new TestCaseData(HandsHelper.TripleJacks, HandsHelper.StraightFlushToEight).Returns(Winner.SecondHand);
            }
        }
    }
}
