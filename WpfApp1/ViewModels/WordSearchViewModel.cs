using System.ComponentModel;
using System.Windows.Input;
using WpfApp1.Commands;

namespace WpfApp1.ViewModels
{
    public class WordSearchViewModel : INotifyPropertyChanged
    {
        ICommand _wordSearchCommand;
        public ICommand WordSearchCommand
        {
            get
            {
                if (_wordSearchCommand == null)
                {
                    _wordSearchCommand = new WordSearchCommand();
                }
                return _wordSearchCommand;
            }
            set
            {
                _wordSearchCommand = value;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        string searchWord;
        public string SearchWord
        {
            get
            {
                return searchWord;
            }
            set
            {
                searchWord = value;
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs("SearchWord"));
                
            }

        }
    }
}
