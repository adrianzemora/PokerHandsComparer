using System.Collections.Generic;

namespace PokerHandsComparer.UI.ViewModels
{
    public class HandViewModel
    {
        public List<CardViewModel> Cards { get; set; }
        public CategoryRank CategoryRank { get; set; }
    }
}