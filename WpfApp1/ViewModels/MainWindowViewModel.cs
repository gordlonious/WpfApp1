namespace WpfApp1.ViewModels
{
    public class MainWindowViewModel
    {
        public MainWindowViewModel()
        {
            WordSearchViewModel = new WordSearchViewModel();
            WordSaveViewModel = new WordSaveViewModel();
        }
        public WordSearchViewModel WordSearchViewModel { get; set; }
        public WordSaveViewModel WordSaveViewModel { get; set; }
    }
}
