using System.Collections;
using NUnit.Framework;
using PokerHandsComparer.Models;

namespace PokerHandsComparer.UnitTests
{
    class FourOfAKindTests
    {
        [Test, TestCaseSource("FourOfAKindTestsWithResults")]
        public Winner CompareWith_ReturnsTheCorrectWinner(Hand first, Hand second)
        {
            return first.CompareWith(second);
        }

        private static IEnumerable FourOfAKindTestsWithResults
        {
            get
            {
                yield return new TestCaseData(HandsHelper.FourOfSevens, HandsHelper.FourOfSevens).Returns(Winner.Tie);
                yield return new TestCaseData(HandsHelper.FourOfSevens, HandsHelper.HighCardQueen).Returns(Winner.Hand1);
                yield return new TestCaseData(HandsHelper.FourOfSevens, HandsHelper.PairOfTensKingHigh).Returns(Winner.Hand1);
                yield return new TestCaseData(HandsHelper.FourOfSevens, HandsHelper.PairsOfAcesAndFoursAndKingHigh).Returns(Winner.Hand1);
                yield return new TestCaseData(HandsHelper.FourOfSevens, HandsHelper.TripleKings).Returns(Winner.Hand1);
                yield return new TestCaseData(HandsHelper.FourOfSevens, HandsHelper.StraightToEight).Returns(Winner.Hand1);
                yield return new TestCaseData(HandsHelper.FourOfSevens, HandsHelper.FlushToTen).Returns(Winner.Hand1);
                yield return new TestCaseData(HandsHelper.FourOfSevens, HandsHelper.FullFivesOverTens).Returns(Winner.Hand1);

                yield return new TestCaseData(HandsHelper.FourOfSevens, HandsHelper.FourOfTwos).Returns(Winner.Hand1);
                yield return new TestCaseData(HandsHelper.FourOfTwos, HandsHelper.FourOfSevens).Returns(Winner.Hand2);

                yield return new TestCaseData(HandsHelper.FourOfSevens, HandsHelper.StraightFlushToEight).Returns(Winner.Hand2);
            }
        }
    }
}
