using System.Collections;
using NUnit.Framework;
using PokerHandsComparer.Models;

namespace PokerHandsComparer.UnitTests
{
    class PairTests
    {
        [Test, TestCaseSource("PairTestsWithResults")]
        public Winner CompareWith_ReturnsTheCorrectWinner(Hand first, Hand second)
        {
            return first.CompareWith(second);
        }

        private static IEnumerable PairTestsWithResults
        {
            get
            {
                yield return new TestCaseData(HandsHelper.PairOfTensKingHigh, HandsHelper.PairOfTensKingHigh).Returns(Winner.Tie);
                yield return new TestCaseData(HandsHelper.PairOfTensKingHigh, HandsHelper.HighCardQueen).Returns(Winner.Hand1);

                yield return new TestCaseData(HandsHelper.PairOfTensKingHigh, HandsHelper.PairOfTensNineHigh).Returns(Winner.Hand1);
                yield return new TestCaseData(HandsHelper.PairOfTensNineHigh, HandsHelper.PairOfTensKingHigh).Returns(Winner.Hand2);
                yield return new TestCaseData(HandsHelper.PairOfTensKingHigh, HandsHelper.PairOfSixesKingHigh).Returns(Winner.Hand1);
                yield return new TestCaseData(HandsHelper.PairOfSixesKingHigh, HandsHelper.PairOfTensKingHigh).Returns(Winner.Hand2);

                yield return new TestCaseData(HandsHelper.PairOfTensKingHigh, HandsHelper.PairsOfJacksAndTensAndKingHigh).Returns(Winner.Hand2);
                yield return new TestCaseData(HandsHelper.PairOfTensKingHigh, HandsHelper.TripleJacks).Returns(Winner.Hand2);
                yield return new TestCaseData(HandsHelper.PairOfTensKingHigh, HandsHelper.StraightToEight).Returns(Winner.Hand2);
                yield return new TestCaseData(HandsHelper.PairOfTensKingHigh, HandsHelper.FlushToTen).Returns(Winner.Hand2);
                yield return new TestCaseData(HandsHelper.PairOfTensKingHigh, HandsHelper.FullFivesOverTens).Returns(Winner.Hand2);
                yield return new TestCaseData(HandsHelper.PairOfTensKingHigh, HandsHelper.FourOfSevens).Returns(Winner.Hand2);
                yield return new TestCaseData(HandsHelper.PairOfTensKingHigh, HandsHelper.StraightFlushToEight).Returns(Winner.Hand2);
            }
        }
    }
}
