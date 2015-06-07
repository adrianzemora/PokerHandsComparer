using System.Collections.Generic;
using PokerHandsComparer.Models;
using PokerHandsComparer.Properties;

namespace PokerHandsComparer.ViewModels
{
    static class Ranks
    {
        public static readonly List<KeyValuePair<Rank, string>> Values = new List<KeyValuePair<Rank, string>>()
        {
            new KeyValuePair<Rank, string>(Rank.Two, Resources.Two),
            new KeyValuePair<Rank, string>(Rank.Three, Resources.Three),
            new KeyValuePair<Rank, string>(Rank.Four, Resources.Four),
            new KeyValuePair<Rank, string>(Rank.Five, Resources.Five),
            new KeyValuePair<Rank, string>(Rank.Six, Resources.Six),
            new KeyValuePair<Rank, string>(Rank.Seven, Resources.Seven),
            new KeyValuePair<Rank, string>(Rank.Eight, Resources.Eight),
            new KeyValuePair<Rank, string>(Rank.Nine, Resources.Nine),
            new KeyValuePair<Rank, string>(Rank.Ten, Resources.Ten),
            new KeyValuePair<Rank, string>(Rank.Jack, Resources.Jack),
            new KeyValuePair<Rank, string>(Rank.Queen, Resources.Queen),
            new KeyValuePair<Rank, string>(Rank.King, Resources.King),
            new KeyValuePair<Rank, string>(Rank.Ace, Resources.Ace)
        };
    }
}