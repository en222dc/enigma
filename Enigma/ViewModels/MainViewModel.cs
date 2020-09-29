using Enigma.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Enigma.ViewModels
{
    class MainViewModel : BaseViewModel 
    {
        #region Properties
        public ICommand NavigationCommand { get; set; }
        #endregion

        #region Constructor
        public MainViewModel()
        {
            NavigationCommand = new RelayCommand(GotoPage);
        }
        #endregion

        #region Navigate
        public void GotoPage()
        {
            var page = new StartPage();
            NavigationService.Navigate(page);
        }
        #endregion
    }
}
