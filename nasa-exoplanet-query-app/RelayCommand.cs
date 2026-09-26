using System;
using System.Windows.Input;

namespace nasa_exoplanet_query_app {
    /// <summary>
    /// Simple RelayCommand implementation for command binding
    /// </summary>
    public class RelayCommand : ICommand {
        private readonly Action mExecute;
        private readonly Func<bool>? mCanExecute;

        public RelayCommand(Action execute, Func<bool>? canExecute = null) {
            mExecute = execute;
            mCanExecute = canExecute;
        }

        public event EventHandler? CanExecuteChanged {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object? parameter) => mCanExecute?.Invoke() ?? true;

        public void Execute(object? parameter) => mExecute();
    }
}
