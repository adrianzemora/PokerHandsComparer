using System.Collections;
using NUnit.Framework;
using PokerHandsComparer.Models;

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
                yield return new TestCaseData(HandsHelper.TripleJacks, HandsHelper.HighCardQueen).Returns(Winner.Hand1);
                yield return new TestCaseData(HandsHelper.TripleJacks, HandsHelper.PairOfTensKingHigh).Returns(Winner.Hand1);
                yield return new TestCaseData(HandsHelper.TripleJacks, HandsHelper.PairsOfAcesAndFoursAndKingHigh).Returns(Winner.Hand1);

                yield return new TestCaseData(HandsHelper.TripleJacks, HandsHelper.TripleKings).Returns(Winner.Hand2);
                yield return new TestCaseData(HandsHelper.TripleKings, HandsHelper.TripleJacks).Returns(Winner.Hand1);

                yield return new TestCaseData(HandsHelper.TripleJacks, HandsHelper.StraightToEight).Returns(Winner.Hand2);
                yield return new TestCaseData(HandsHelper.TripleJacks, HandsHelper.FlushToTen).Returns(Winner.Hand2);
                yield return new TestCaseData(HandsHelper.TripleJacks, HandsHelper.FullFivesOverTens).Returns(Winner.Hand2);
                yield return new TestCaseData(HandsHelper.TripleJacks, HandsHelper.FourOfSevens).Returns(Winner.Hand2);
                yield return new TestCaseData(HandsHelper.TripleJacks, HandsHelper.StraightFlushToEight).Returns(Winner.Hand2);
            }
        }
    }
}
