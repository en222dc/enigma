using Enigma.ViewModels.Base;
using Enigma.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using System.Windows;


namespace Enigma.ViewModels
{
    class MenuPageViewModel : BaseViewModel
    {
        public ICommand ExitGameCommand { get; set; }
        public ICommand ChangeToHighScorePageCommand { get; set; }
       
        public ICommand ChangeToHelpAndRulesCommand { get; set; }


        public MainWindow myWindow = (MainWindow)Application.Current.MainWindow;
        

        public MenuPageViewModel()
        {
            ExitGameCommand = new RelayCommand(ExitGame);
            ChangeToHighScorePageCommand = new RelayCommand(ChangeToHighScorePage);
            ChangeToHelpAndRulesCommand = new RelayCommand(ChangeToHelpAndRules);
        }

        public bool IsMainFrameSetToStartPage()
        {
            bool result = false;
            //if (myWindow.MainFrame.Content == StartPage)
            //    result = true;
            return result;
        }

        public void ExitGame()
        {
            if (IsMainFrameSetToStartPage())
            {
                myWindow.Close();
            }
            else
            {
                var startpage = new StartPage();
                NavigationService.Navigate(startpage);
            }
        }

        public void ChangeToHighScorePage()
        {
            var  highScorePage  = new HighScorePage();
            NavigationService.Navigate(highScorePage);
        }

        public void ChangeToHelpAndRules()
        {
            var helpAndRulesPage = new HelpAndRules();
            NavigationService.Navigate(helpAndRulesPage);
        }
    }
}
