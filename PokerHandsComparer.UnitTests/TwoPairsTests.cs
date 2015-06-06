using System.Collections;
using NUnit.Framework;

namespace PokerHandsComparer.UnitTests
{
    class TwoPairsTests
    {
        [Test, TestCaseSource("TwoPairsTestsWithResults")]
        public object CompareWith_ReturnsTheCorrectWinner(Hand first, Hand second)
        {
            return first.CompareWith(second);
        }

        private static IEnumerable TwoPairsTestsWithResults
        {
            get
            {
                yield return new TestCaseData(HandsHelper.PairsOfJacksAndTensAndKingHigh, HandsHelper.PairsOfJacksAndTensAndKingHigh).Returns(Winner.Tie);
                yield return new TestCaseData(HandsHelper.PairsOfJacksAndTensAndKingHigh, HandsHelper.HighCardQueen).Returns(Winner.FirstHand);
                yield return new TestCaseData(HandsHelper.PairsOfJacksAndTensAndKingHigh, HandsHelper.PairOfTensKingHigh).Returns(Winner.FirstHand);

                yield return new TestCaseData(HandsHelper.PairsOfJacksAndTensAndKingHigh, HandsHelper.PairsOfAcesAndFoursAndKingHigh).Returns(Winner.SecondHand);
                yield return new TestCaseData(HandsHelper.PairsOfAcesAndFoursAndKingHigh, HandsHelper.PairsOfJacksAndTensAndKingHigh).Returns(Winner.FirstHand);
                yield return new TestCaseData(HandsHelper.PairsOfJacksAndTensAndKingHigh, HandsHelper.PairsOfJacksAndSixesAndKingHigh).Returns(Winner.FirstHand);
                yield return new TestCaseData(HandsHelper.PairsOfJacksAndSixesAndKingHigh, HandsHelper.PairsOfJacksAndTensAndKingHigh).Returns(Winner.SecondHand);
                yield return new TestCaseData(HandsHelper.PairsOfAcesAndFoursAndKingHigh, HandsHelper.PairsOfAcesAndFoursAndTenHigh).Returns(Winner.FirstHand);
                yield return new TestCaseData(HandsHelper.PairsOfAcesAndFoursAndTenHigh, HandsHelper.PairsOfAcesAndFoursAndKingHigh).Returns(Winner.SecondHand);

                yield return new TestCaseData(HandsHelper.PairsOfJacksAndTensAndKingHigh, HandsHelper.TripleJacks).Returns(Winner.SecondHand);
                yield return new TestCaseData(HandsHelper.PairsOfJacksAndTensAndKingHigh, HandsHelper.StraightToEight).Returns(Winner.SecondHand);
                yield return new TestCaseData(HandsHelper.PairsOfJacksAndTensAndKingHigh, HandsHelper.FlushToTen).Returns(Winner.SecondHand);
                yield return new TestCaseData(HandsHelper.PairsOfJacksAndTensAndKingHigh, HandsHelper.FullFivesOverTens).Returns(Winner.SecondHand);
                yield return new TestCaseData(HandsHelper.PairsOfJacksAndTensAndKingHigh, HandsHelper.FourOfSevens).Returns(Winner.SecondHand);
                yield return new TestCaseData(HandsHelper.PairsOfJacksAndTensAndKingHigh, HandsHelper.StraightFlushToEight).Returns(Winner.SecondHand);
            }
        }
    }
}
