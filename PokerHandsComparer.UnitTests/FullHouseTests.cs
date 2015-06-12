using System.Collections;
using NUnit.Framework;
using PokerHandsComparer.Models;

namespace PokerHandsComparer.UnitTests
{
    class FullHouseTests
    {
        [Test, TestCaseSource("FullHouseTestsWithResults")]
        public Winner CompareWith_ReturnsTheCorrectWinner(Hand first, Hand second)
        {
            return first.CompareWith(second);
        }

        private static IEnumerable FullHouseTestsWithResults
        {
            get
            {
                yield return new TestCaseData(HandsHelper.FullFivesOverTens, HandsHelper.FullFivesOverTens).Returns(Winner.Tie);
                yield return new TestCaseData(HandsHelper.FullFivesOverTens, HandsHelper.HighCardQueen).Returns(Winner.Hand1);
                yield return new TestCaseData(HandsHelper.FullFivesOverTens, HandsHelper.PairOfTensKingHigh).Returns(Winner.Hand1);
                yield return new TestCaseData(HandsHelper.FullFivesOverTens, HandsHelper.PairsOfAcesAndFoursAndKingHigh).Returns(Winner.Hand1);
                yield return new TestCaseData(HandsHelper.FullFivesOverTens, HandsHelper.TripleKings).Returns(Winner.Hand1);
                yield return new TestCaseData(HandsHelper.FullFivesOverTens, HandsHelper.StraightToEight).Returns(Winner.Hand1);
                yield return new TestCaseData(HandsHelper.FullFivesOverTens, HandsHelper.FlushToTen).Returns(Winner.Hand1);

                yield return new TestCaseData(HandsHelper.FullFivesOverTens, HandsHelper.FullFivesOverAces).Returns(Winner.Hand2);
                yield return new TestCaseData(HandsHelper.FullFivesOverAces, HandsHelper.FullFivesOverTens).Returns(Winner.Hand1);
                yield return new TestCaseData(HandsHelper.FullNinesOverKings, HandsHelper.FullThreesOverKings).Returns(Winner.Hand1);
                yield return new TestCaseData(HandsHelper.FullThreesOverKings, HandsHelper.FullNinesOverKings).Returns(Winner.Hand2);
                yield return new TestCaseData(HandsHelper.FullFivesOverAces, HandsHelper.FullNinesOverKings).Returns(Winner.Hand2);
                yield return new TestCaseData(HandsHelper.FullNinesOverKings, HandsHelper.FullFivesOverAces).Returns(Winner.Hand1);

                yield return new TestCaseData(HandsHelper.FullFivesOverTens, HandsHelper.FourOfSevens).Returns(Winner.Hand2);
                yield return new TestCaseData(HandsHelper.FullFivesOverTens, HandsHelper.StraightFlushToEight).Returns(Winner.Hand2);
            }
        }
    }
}
