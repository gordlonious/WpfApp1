using System.ComponentModel;
using WpfApp1.Commands;
namespace WpfApp1.ViewModels
{
    public class WordSaveViewModel : INotifyPropertyChanged
    {
        public WordSaveViewModel()
        {
            WordSaveCommand = new WordSaveCommand();
        }
        public WordSaveCommand WordSaveCommand { get; set; }
        private string _saveWord;
        public string SaveWord 
        { 
            get
            {
                return _saveWord;
            }
            set
            {
                _saveWord = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SaveWord"));
            }
        }
        private string _saveDefinition;
        public string SaveDefinition 
        {
            get
            {
                return _saveDefinition;
            }
            set
            {
                _saveDefinition = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SaveDefinition"));
            } 
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
