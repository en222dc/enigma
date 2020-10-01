using Enigma.ViewModels.Base;
using Enigma.Views;
using System;
using System.Windows.Input;
using System.Windows;

namespace Enigma.ViewModels
{
    class MenuViewModel : BaseViewModel
    {
        #region Properties
        public ICommand ExitGameCommand { get; set; }
        public ICommand ChangeToHighScorePageCommand { get; set; }
        public ICommand ChangeToHelpAndRulesCommand { get; set; }
        #endregion

        #region Constructor
        public MenuViewModel()
        {
            ExitGameCommand = new RelayCommand(ExitGame);
            ChangeToHighScorePageCommand = new RelayCommand(GoToHighscoreOption);
            ChangeToHelpAndRulesCommand = new RelayCommand(GoToHelpAndRulesOption);
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
            var helpAndRulesPage = new HelpAndRulesPage();
            NavigationService.Navigate(helpAndRulesPage);
        }
        #endregion

        #region Methods
        /// <summary>
        /// Exits the current game to the start page if the user is in a game, but closes the application completely if the user is on the start page.
        /// </summary>
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

        /// <summary>
        /// Provides the user with a warning that they will loose their current progress from the puzzles if they go to Help and Rules, and lets them decide what to do.
        /// </summary>
        private void GoToHelpAndRulesOption()
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

        /// <summary>
        /// Provides the user with a warning that they will loose their current progress from the puzzles if they go to Highscore, and lets them decide what to do.
        /// </summary>
        private void GoToHighscoreOption()
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

        /// <summary>
        /// Checks to see if the current page is StartPage.
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Checks to see if the current page is set to PuzzlePage.
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Checks to see if the current page is set to SolvePuzzlePage.
        /// </summary>
        /// <returns></returns>
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
