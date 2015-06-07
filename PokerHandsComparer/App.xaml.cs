using System;
using System.Windows;
using System.Windows.Threading;

namespace PokerHandsComparer
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void HandleException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            MessageBox.Show(string.Format("Error occurred: {0}{1}", Environment.NewLine, e.Exception), "ERROR",
                MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
