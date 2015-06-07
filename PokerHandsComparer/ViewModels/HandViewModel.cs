using System.Collections.Generic;
using PokerHandsComparer.Models;

namespace PokerHandsComparer.ViewModels
{
    public class HandViewModel
    {
        public List<CardViewModel> Cards { get; set; }
        public CategoryRank CategoryRank { get; set; }
    }
}