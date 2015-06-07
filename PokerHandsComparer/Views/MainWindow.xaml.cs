using System.Windows;
using PokerHandsComparer.ViewModels;

namespace PokerHandsComparer.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new PokerHandsComparerViewModel();
        }
    }
}
