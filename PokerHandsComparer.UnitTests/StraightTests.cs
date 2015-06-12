using System.Collections;
using NUnit.Framework;
using PokerHandsComparer.Models;

namespace PokerHandsComparer.UnitTests
{
    class StraightTests
    {
        [Test, TestCaseSource("StraightTestsWithResults")]
        public Winner CompareWith_ReturnsTheCorrectWinner(Hand first, Hand second)
        {
            return first.CompareWith(second);
        }

        private static IEnumerable StraightTestsWithResults
        {
            get
            {
                yield return new TestCaseData(HandsHelper.StraightToEight, HandsHelper.StraightToEight).Returns(Winner.Tie);
                yield return new TestCaseData(HandsHelper.StraightToEight, HandsHelper.HighCardQueen).Returns(Winner.Hand1);
                yield return new TestCaseData(HandsHelper.StraightToEight, HandsHelper.PairOfTensKingHigh).Returns(Winner.Hand1);
                yield return new TestCaseData(HandsHelper.StraightToEight, HandsHelper.PairsOfAcesAndFoursAndKingHigh).Returns(Winner.Hand1);
                yield return new TestCaseData(HandsHelper.StraightToEight, HandsHelper.TripleKings).Returns(Winner.Hand1);

                yield return new TestCaseData(HandsHelper.StraightToEight, HandsHelper.StraightToFive).Returns(Winner.Hand1);
                yield return new TestCaseData(HandsHelper.StraightToFive, HandsHelper.StraightToEight).Returns(Winner.Hand2);

                yield return new TestCaseData(HandsHelper.StraightToEight, HandsHelper.FlushToTen).Returns(Winner.Hand2);
                yield return new TestCaseData(HandsHelper.StraightToEight, HandsHelper.FullFivesOverTens).Returns(Winner.Hand2);
                yield return new TestCaseData(HandsHelper.StraightToEight, HandsHelper.FourOfSevens).Returns(Winner.Hand2);
                yield return new TestCaseData(HandsHelper.StraightToEight, HandsHelper.StraightFlushToEight).Returns(Winner.Hand2);
            }
        }
    }
}
