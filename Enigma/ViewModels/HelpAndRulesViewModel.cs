using Enigma.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Enigma.ViewModels
{
    class HelpAndRulesViewModel : BaseViewModel
    {
        #region Properties
        public ICommand GoToPageCommand { get; set; }
        #endregion

        #region Constructor
        public HelpAndRulesViewModel()
        {
            GoToPageCommand = new RelayCommand(GoToStartPage);
        }
        #endregion

        #region Navigation
        public void GoToStartPage()
        {
            MyWindow.MainFrame.Content = new StartPage();
        }
        #endregion
    }
}
