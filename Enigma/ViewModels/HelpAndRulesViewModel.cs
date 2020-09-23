using Enigma.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Enigma.ViewModels
{
    class HelpAndRulesViewModel : BaseViewModel
    {
        public ICommand GoToPageCommand { get; set; }

        public HelpAndRulesViewModel()
        {
            GoToPageCommand = new RelayCommand(GoToStartPage);
        }

        public void GoToStartPage()
        {
            MyWindow.MainFrame.Content = new StartPage();
        }
    }
}
