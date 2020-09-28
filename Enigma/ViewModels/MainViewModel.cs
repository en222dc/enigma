using Enigma.ViewModels.Base;
using Enigma.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Enigma.ViewModels
{
    class MainViewModel : BaseViewModel 
    {
        public ICommand NavigationCommand { get; set; }

        public MainViewModel()
        {
            NavigationCommand = new RelayCommand(GotoPage);
        }

        public void GotoPage()
        {
            var page = new StartPage();
            NavigationService.Navigate(page);
        }
    }
}
