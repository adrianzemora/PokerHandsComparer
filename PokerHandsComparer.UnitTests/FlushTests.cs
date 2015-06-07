using System.Collections;
using NUnit.Framework;
using PokerHandsComparer.Models;

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
                yield return new TestCaseData(HandsHelper.FlushToTen, HandsHelper.HighCardQueen).Returns(Winner.Hand1);
                yield return new TestCaseData(HandsHelper.FlushToTen, HandsHelper.PairOfTensKingHigh).Returns(Winner.Hand1);
                yield return new TestCaseData(HandsHelper.FlushToTen, HandsHelper.PairsOfAcesAndFoursAndKingHigh).Returns(Winner.Hand1);
                yield return new TestCaseData(HandsHelper.FlushToTen, HandsHelper.TripleKings).Returns(Winner.Hand1);
                yield return new TestCaseData(HandsHelper.FlushToTen, HandsHelper.StraightToEight).Returns(Winner.Hand1);

                yield return new TestCaseData(HandsHelper.FlushToTen, HandsHelper.FlushToKing).Returns(Winner.Hand2);
                yield return new TestCaseData(HandsHelper.FlushToKing, HandsHelper.FlushToTen).Returns(Winner.Hand1);

                yield return new TestCaseData(HandsHelper.FlushToTen, HandsHelper.FullFivesOverTens).Returns(Winner.Hand2);
                yield return new TestCaseData(HandsHelper.FlushToTen, HandsHelper.FourOfSevens).Returns(Winner.Hand2);
                yield return new TestCaseData(HandsHelper.FlushToTen, HandsHelper.StraightFlushToEight).Returns(Winner.Hand2);
            }
        }
    }
}
