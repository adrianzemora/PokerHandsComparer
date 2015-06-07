using System.Collections;
using NUnit.Framework;
using PokerHandsComparer.Models;

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

                yield return new TestCaseData(HandsHelper.HighCardKing, HandsHelper.HighCardQueen).Returns(Winner.Hand1);
                yield return new TestCaseData(HandsHelper.HighCardQueen, HandsHelper.HighCardKing).Returns(Winner.Hand2);

                yield return new TestCaseData(HandsHelper.HighCardKing, HandsHelper.PairOfTensKingHigh).Returns(Winner.Hand2);
                yield return new TestCaseData(HandsHelper.HighCardKing, HandsHelper.PairsOfJacksAndTensAndKingHigh).Returns(Winner.Hand2);
                yield return new TestCaseData(HandsHelper.HighCardKing, HandsHelper.TripleJacks).Returns(Winner.Hand2);
                yield return new TestCaseData(HandsHelper.HighCardKing, HandsHelper.StraightToEight).Returns(Winner.Hand2);
                yield return new TestCaseData(HandsHelper.HighCardKing, HandsHelper.FlushToTen).Returns(Winner.Hand2);
                yield return new TestCaseData(HandsHelper.HighCardKing, HandsHelper.FullFivesOverTens).Returns(Winner.Hand2);
                yield return new TestCaseData(HandsHelper.HighCardKing, HandsHelper.FourOfSevens).Returns(Winner.Hand2);
                yield return new TestCaseData(HandsHelper.HighCardKing, HandsHelper.StraightFlushToEight).Returns(Winner.Hand2);
            }
        }
    }
}
