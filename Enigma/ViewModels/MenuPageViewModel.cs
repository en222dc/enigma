using Enigma.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Enigma.ViewModels
{
    class MenuPageViewModel : BaseViewModel
    {
        public ICommand ExitGameCommand { get; set; }

        public MenuPageViewModel()
        {
            ExitGameCommand = new RelayCommand(ExitGame);
        }



        public void ExitGame()
        {
            var startpage = new StartPage();
            NavigationService.Navigate(startpage);
        }
    }
}
