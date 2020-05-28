using WpfApp1.Commands;
namespace WpfApp1.ViewModels
{
    public class WordSaveViewModel
    {
        public WordSaveViewModel()
        {
            WordSaveCommand = new WordSaveCommand();
        }
        public WordSaveCommand WordSaveCommand { get; set; }

        public string SaveWord { get; set; }
    }
}
