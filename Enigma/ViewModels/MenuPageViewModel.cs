using Enigma.ViewModels.Base;
using Enigma.Views;
using System;
using System.Windows.Input;
using System.Windows;

namespace Enigma.ViewModels
{
    class MenuPageViewModel : BaseViewModel
    {
        #region Properties
        public ICommand ExitGameCommand { get; set; }
        public ICommand ChangeToHighScorePageCommand { get; set; }
        public ICommand ChangeToHelpAndRulesCommand { get; set; }
        #endregion

        #region Constructor
        public MenuPageViewModel()
        {
            ExitGameCommand = new RelayCommand(ExitGame);
            ChangeToHighScorePageCommand = new RelayCommand(GoToHighscore);
            ChangeToHelpAndRulesCommand = new RelayCommand(GoToHelpAndRules);
        }
        #endregion

        #region Navigation
        private void ChangeToHighScorePage()
        {
            var highScorePage = new HighScorePage();
            NavigationService.Navigate(highScorePage);
        }

        private void ChangeToHelpAndRules()
        {
            var helpAndRulesPage = new HelpAndRules();
            NavigationService.Navigate(helpAndRulesPage);
        }
        #endregion

        #region Methods
        private void ExitGame()
        {
            if (IsMainFrameSetToStartPage())
            {
                MessageBoxResult result = MessageBox.Show("Do you want to quit the game?", "Quit", MessageBoxButton.YesNo);
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
                MessageBoxResult result = MessageBox.Show("Do you want to exit to start page?", "Exit", MessageBoxButton.YesNo);
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

        private void GoToHelpAndRules()
        {
            if (IsMainFrameSetToPuzzlePage() || IsMainFrameSetToSolvePuzzlePage())
            {
                MessageBoxResult result = MessageBox.Show("If you leave this page, all your progress will be lost. Are you sure?", "Leave page", MessageBoxButton.YesNo);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        ChangeToHelpAndRules();
                        break;
                    case MessageBoxResult.No:
                        break;
                }
            }
            else
            {
                ChangeToHelpAndRules();
            }
        }

        private void GoToHighscore()
        {
            if (IsMainFrameSetToPuzzlePage() || IsMainFrameSetToSolvePuzzlePage())
            {
                MessageBoxResult result = MessageBox.Show("If you leave this page, all your progress will be lost. Are you sure?", "Leave page", MessageBoxButton.YesNo);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        ChangeToHighScorePage();
                        break;
                    case MessageBoxResult.No:
                        break;
                }
            }
            else
            {
                ChangeToHighScorePage();
            }
        }

        private bool IsMainFrameSetToStartPage()
        {
            bool result = false;

            Object CurrentPage = MyWindow.MainFrame.Content.GetType().Name;
            if ((string)CurrentPage == "StartPage")
            {
                result = true;
            }
            return result;
        }

        private bool IsMainFrameSetToPuzzlePage()
        {
            bool result = false;

            Object CurrentPage = MyWindow.MainFrame.Content.GetType().Name;
            if ((string)CurrentPage == "PuzzlePage")
            {
                result = true;
            }
            return result;
        }

        private bool IsMainFrameSetToSolvePuzzlePage()
        {
            bool result = false;

            Object CurrentPage = MyWindow.MainFrame.Content.GetType().Name;
            if ((string)CurrentPage == "SolvePuzzlePage")
            {
                result = true;
            }
            return result;
        }
        #endregion
    }
}
