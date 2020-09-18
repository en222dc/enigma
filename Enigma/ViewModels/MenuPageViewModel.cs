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
        public ICommand ChangeToHighScorePageCommand { get; set; }

        public MenuPageViewModel()
        {
            ExitGameCommand = new RelayCommand(ExitGame);
            ChangeToHighScorePageCommand = new RelayCommand(ChangeToHighScorePage);
        }



        public void ExitGame()
        {
            var startpage = new StartPage();
            NavigationService.Navigate(startpage);
        }

        public void ChangeToHighScorePage()
        {
            var  highScorePage  = new HighScorePage();
            NavigationService.Navigate(highScorePage);
        }
    }
}
