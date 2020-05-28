using System;
using System.Windows;
using System.Windows.Input;

namespace WpfApp1.Commands
{
    public class WordSaveCommand : ICommand
    {
        public WordSaveCommand() { }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            if ((string)parameter == "")
            {
                return false;
            }

            return true;
        }

        public void Execute(object parameter)
        {
            MessageBox.Show("Saved");
        }
    }
}
