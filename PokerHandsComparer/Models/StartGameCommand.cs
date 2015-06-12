using System;
using System.Windows.Input;

namespace PokerHandsComparer.Models
{
    class StartGameCommand : ICommand
    {
        private readonly Action action;
        public event EventHandler CanExecuteChanged;

        public StartGameCommand(Action action)
        {
            this.action = action;
        }

        public void Execute(object parameter)
        {
            action();
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }
    }
}
