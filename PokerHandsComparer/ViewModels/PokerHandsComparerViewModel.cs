using System.Collections.Generic;
using System.Linq;
using PokerHandsComparer.Models;

namespace PokerHandsComparer.ViewModels
{
    public class PokerHandsComparerViewModel
    {
        public HandViewModel FirstHandViewModel { get; private set; }
        public HandViewModel SecondHandViewModel { get; private set; }
        public WinnerViewModel WinnerViewModel { get; set; }

        public PokerHandsComparerViewModel()
        {
            var pokerGame = new PokerGame();
            WinnerViewModel = GetWinnerViewModel(pokerGame);
            FirstHandViewModel = GetHandViewModel(pokerGame.FirstHand);
            SecondHandViewModel = GetHandViewModel(pokerGame.SecondHand);
        }

        private static WinnerViewModel GetWinnerViewModel(PokerGame pokerGame)
        {
            return new WinnerViewModel
            {
                Winner = pokerGame.GetWinner(),
                FirstHandRank = pokerGame.FirstHand.GetCategoryRank(),
                SecondHandRank = pokerGame.SecondHand.GetCategoryRank(),
            };
        }

        private static HandViewModel GetHandViewModel(Hand hand)
        {
            var cards = new List<CardViewModel>();

            foreach (var card in hand.Cards)
            {
                cards.Add(new CardViewModel
                {
                    Rank = Ranks.Values.Single(value => value.Key == card.Rank).Value,
                    Suit = new SuitViewModel
                    {
                        Value = Suits.Values.Single(value => value.Item1 == card.Suit).Item2,
                        Color = Suits.Values.Single(value => value.Item1 == card.Suit).Item3
                    }
                });
            }

            return new HandViewModel
            {
                Cards = cards,
                CategoryRank = hand.GetCategoryRank()
            };
        }
    }
}