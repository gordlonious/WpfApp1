using AppLogicCommandsAndQueries;
using System;
using System.Windows.Input;
using WpfApp1.ViewModels;

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
            if (parameter == null)
                return false;

            WordSaveViewModel vm = (WordSaveViewModel)parameter;
            if (vm.SaveWord == "" && vm.SaveDefinition == "")
            {
                return false;
            }

            return true;
        }

        public void Execute(object parameter)
        {
            WordSaveViewModel vm = (WordSaveViewModel)parameter;
            SaveWordLogic.SaveWordOffline(vm.SaveWord, vm.SaveDefinition);
            vm.SaveWord = "";
            vm.SaveDefinition = "";
        }
    }
}
