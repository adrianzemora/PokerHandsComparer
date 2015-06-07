using PokerHandsComparer.Models;

namespace PokerHandsComparer.ViewModels
{
    public class WinnerViewModel
    {
        public CategoryRank FirstHandRank { get; set; }
        public CategoryRank SecondHandRank { get; set; }
        public Winner Winner { get; set; }
    }
}