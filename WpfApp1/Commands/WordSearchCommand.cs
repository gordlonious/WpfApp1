using System;
using System.Windows;
using System.Windows.Input;

namespace WpfApp1.Commands
{
    public class WordSearchCommand : ICommand
    {

        private string previousSearch;

        public event EventHandler CanExecuteChanged = delegate (object s, EventArgs e)
        {
            MessageBox.Show("word search can execute changed");
        };

        public bool CanExecute(object parameter)
        {
            return previousSearch != (string)parameter;
        }

        public void Execute(object parameter)
        {
            // if online check online db else check offline db

            MessageBox.Show("word search command");

            previousSearch = (string)parameter;
        }
    }
}
