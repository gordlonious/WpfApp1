using AppLogicCommandsAndQueries;
using Domain;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace WpfApp1.Commands
{
    public class WordSearchCommand : ICommand, INotifyPropertyChanged
    {
        public string LastFoundWord { get; set; }
        public string LastFoundDefinition { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter) { return true; }

        public void Execute(object parameter)
        {
            string word = (string)parameter;
            bool found = SearchWordLogic.WordExistsOffline(word);
            if (found)
            {
                Word w = SearchWordLogic.GetWord(word);
                LastFoundWord = word;
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs("LastFoundWord"));
                if (w.DefinitionList.Count > 0)
                {
                    LastFoundDefinition = w.DefinitionList[0]?.Meaning;
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs("LastFoundDefinition"));
                }
            }
            else
            {
                MessageBox.Show("not found.");
            }
        }
    }
}
