using System.Windows;
using PokerHandsComparer.UI.ViewModels;

namespace PokerHandsComparer.UI.Views
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
