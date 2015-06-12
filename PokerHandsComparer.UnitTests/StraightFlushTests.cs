using System.Collections;
using NUnit.Framework;
using PokerHandsComparer.Models;

namespace PokerHandsComparer.UnitTests
{
    class StraightFlushTests
    {
        [Test, TestCaseSource("StraightFlushTestsWithResults")]
        public Winner CompareWith_ReturnsTheCorrectWinner(Hand first, Hand second)
        {
            return first.CompareWith(second);
        }

        private static IEnumerable StraightFlushTestsWithResults
        {
            get
            {
                yield return new TestCaseData(HandsHelper.StraightFlushToEight, HandsHelper.StraightFlushToEight).Returns(Winner.Tie);
                yield return new TestCaseData(HandsHelper.StraightFlushToEight, HandsHelper.HighCardQueen).Returns(Winner.Hand1);
                yield return new TestCaseData(HandsHelper.StraightFlushToEight, HandsHelper.PairOfTensKingHigh).Returns(Winner.Hand1);
                yield return new TestCaseData(HandsHelper.StraightFlushToEight, HandsHelper.PairsOfAcesAndFoursAndKingHigh).Returns(Winner.Hand1);
                yield return new TestCaseData(HandsHelper.StraightFlushToEight, HandsHelper.TripleKings).Returns(Winner.Hand1);
                yield return new TestCaseData(HandsHelper.StraightFlushToEight, HandsHelper.StraightToEight).Returns(Winner.Hand1);
                yield return new TestCaseData(HandsHelper.StraightFlushToEight, HandsHelper.FlushToTen).Returns(Winner.Hand1);
                yield return new TestCaseData(HandsHelper.StraightFlushToEight, HandsHelper.FullNinesOverKings).Returns(Winner.Hand1);
                yield return new TestCaseData(HandsHelper.StraightFlushToEight, HandsHelper.FourOfSevens).Returns(Winner.Hand1);

                yield return new TestCaseData(HandsHelper.StraightFlushToEight, HandsHelper.StraightToFive).Returns(Winner.Hand1);
                yield return new TestCaseData(HandsHelper.StraightFlushToFive, HandsHelper.StraightFlushToEight).Returns(Winner.Hand2);
            }
        }
    }
}
