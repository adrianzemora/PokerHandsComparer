using System.Collections;
using NUnit.Framework;

namespace PokerHandsComparer.UnitTests
{
    class StraightFlushTests
    {
        [Test, TestCaseSource("StraightFlushTestsWithResults")]
        public object CompareWith_ReturnsTheCorrectWinner(Hand first, Hand second)
        {
            return first.CompareWith(second);
        }

        private static IEnumerable StraightFlushTestsWithResults
        {
            get
            {
                yield return new TestCaseData(HandsHelper.StraightFlushToEight, HandsHelper.StraightFlushToEight).Returns(Winner.Tie);
                yield return new TestCaseData(HandsHelper.StraightFlushToEight, HandsHelper.HighCardQueen).Returns(Winner.FirstHand);
                yield return new TestCaseData(HandsHelper.StraightFlushToEight, HandsHelper.PairOfTensKingHigh).Returns(Winner.FirstHand);
                yield return new TestCaseData(HandsHelper.StraightFlushToEight, HandsHelper.PairsOfAcesAndFoursAndKingHigh).Returns(Winner.FirstHand);
                yield return new TestCaseData(HandsHelper.StraightFlushToEight, HandsHelper.TripleKings).Returns(Winner.FirstHand);
                yield return new TestCaseData(HandsHelper.StraightFlushToEight, HandsHelper.StraightToEight).Returns(Winner.FirstHand);
                yield return new TestCaseData(HandsHelper.StraightFlushToEight, HandsHelper.FlushToTen).Returns(Winner.FirstHand);
                yield return new TestCaseData(HandsHelper.StraightFlushToEight, HandsHelper.FullNinesOverKings).Returns(Winner.FirstHand);
                yield return new TestCaseData(HandsHelper.StraightFlushToEight, HandsHelper.FourOfSevens).Returns(Winner.FirstHand);

                yield return new TestCaseData(HandsHelper.StraightFlushToEight, HandsHelper.StraightToFive).Returns(Winner.FirstHand);
                yield return new TestCaseData(HandsHelper.StraightFlushToFive, HandsHelper.StraightFlushToEight).Returns(Winner.SecondHand);
            }
        }
    }
}
