using System;
using System.Collections.Generic;
using System.Windows.Media;
using PokerHandsComparer.UI.Properties;

namespace PokerHandsComparer.UI.ViewModels
{
    static class Suits
    {
        public static readonly List<Tuple<Suit, string, Brush>> Values = new List<Tuple<Suit, string, Brush>>()
        {
            new Tuple<Suit, string, Brush>(Suit.Clubs, Resources.Clubs, Brushes.Black),
            new Tuple<Suit, string, Brush>(Suit.Diamonds, Resources.Diamonds, Brushes.Red),
            new Tuple<Suit, string, Brush>(Suit.Hearts, Resources.Hearts, Brushes.Red),
            new Tuple<Suit, string, Brush>(Suit.Spades, Resources.Spades, Brushes.Black),
        };
    }
}