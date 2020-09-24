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

        public MenuPageViewModel()
        {
            ExitGameCommand = new RelayCommand(ExitGame);
            ChangeToHighScorePageCommand = new RelayCommand(GoToHighscore);
            ChangeToHelpAndRulesCommand = new RelayCommand(GoToHelpAndRules);
        }

        public void ExitGame()
        {
            if (IsMainFrameSetToStartPage())
            {
                MessageBoxResult result = MessageBox.Show("Do you want to exit the game?", "Exit", MessageBoxButton.YesNo);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        MyWindow.Close();
                        break;
                    case MessageBoxResult.No:
                        break;
                }
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("Do you want to quit to Title?", "Exit", MessageBoxButton.YesNo);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        MyWindow.MainFrame.Content = new StartPage();
                        break;
                    case MessageBoxResult.No:
                        break;
                }
            }
        }

        public void GoToHelpAndRules()
        {
            if (IsMainFrameSetToStartPage())
            {
                ChangeToHelpAndRules();
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("If you leave this page, all your none saved progress will be lost. Are you sure?", "Leave page", MessageBoxButton.YesNo);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        ChangeToHelpAndRules();
                        break;
                    case MessageBoxResult.No:
                        break;
                }
            }
        }

        public void GoToHighscore()
        {
            if (IsMainFrameSetToStartPage())
            {
                ChangeToHighScorePage();
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("If you leave this page, all your none saved progress will be lost. Are you sure?", "Leave page", MessageBoxButton.YesNo);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        ChangeToHighScorePage();
                        break;
                    case MessageBoxResult.No:
                        break;
                }
            }
        }


        public bool IsMainFrameSetToStartPage()
        {
            bool result = false;

            Object CurrentPage = MyWindow.MainFrame.Content.GetType().Name;
            if ((string)CurrentPage == "StartPage")
            {
                result = true;
            }
            return result;
        }

        public void ChangeToHighScorePage()
        {
            var highScorePage = new HighScorePage();
            NavigationService.Navigate(highScorePage);
        }

        public void ChangeToHelpAndRules()
        {
            var helpAndRulesPage = new HelpAndRules();
            NavigationService.Navigate(helpAndRulesPage);
        }
    }
}
