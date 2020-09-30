using Enigma.Models;
using Enigma.Models.Repositories;
using System.Windows.Input;
using System.Collections.ObjectModel;
using System.Windows.Navigation;
using Enigma.ViewModels.Base;
using Enigma.Views;

namespace Enigma.ViewModels
{
    public class HighscoreViewModel : BaseViewModel
    {
        #region Properties
        public ObservableCollection<Highscore> ListOfHighScores { get; set; } = new ObservableCollection<Highscore>();
        public ObservableCollection<Player> ListOfPlayersInHighScore { get; set; } = new ObservableCollection<Player>();
        public string ListOfHighScoreToString { get; set; } 
        public string MostFrequentPlayersToString { get; set; }
        public ICommand GoToPageCommand { get; set; }
        #endregion

        #region Constructor
        public HighscoreViewModel()
        {
            ShowHighScoreFromDataBase();
            GetHighScoreListToString();
            GetMostFrequentPlayersToString();
            GoToPageCommand = new RelayCommand(GoToStartPage);
            ExitButtonContent = "Exit to Start Page";
            MyWindow.MenuFrame.Content = new MenuPage();
        }
        #endregion

        #region Navigation
        public void GoToStartPage()
        {
            var startpage = new StartPage();
            NavigationService.Navigate(startpage);
        }
        #endregion

        #region Methods
        public void ShowHighScoreFromDataBase()
        {
            foreach (var highscore in Repository.GetHighscores())
            {
                ListOfHighScores.Add(highscore);
            }
            foreach (var player in Repository.GetTopPlayers())
            {
                ListOfPlayersInHighScore.Add(player);
            }
        }

        private void GetHighScoreListToString(int highScoreToDisplay = 10)
        {
            int highScorePlace = 1;
            if (ListOfHighScores.Count == 0)
            {
                ListOfHighScoreToString = "There is no High Score registered";
            }
            else
            {
                foreach (var position in ListOfHighScores)
                {
                    if (highScorePlace <= highScoreToDisplay)
                    {
                        ListOfHighScoreToString += $"    {highScorePlace}.\t{position.Player_name}\t   {position.Time}\n";
                        highScorePlace++;
                    }
                }
            }
        }

        private void GetMostFrequentPlayersToString()
        {
            if (ListOfPlayersInHighScore.Count == 0)
            {
                MostFrequentPlayersToString = "No player has played the game";
            }
            else
            {
                foreach (var player in ListOfPlayersInHighScore)
                {
                    int numberOfGames = 0;
                    foreach (var score in ListOfHighScores)
                    {
                        if (score.Player_name == player.Player_name)
                        {
                            numberOfGames++;
                        }
                    }
                    MostFrequentPlayersToString += $"{player.Player_name}\t{numberOfGames}\n";
                }
            }
        }
        #endregion
    }
}  
