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
        public ObservableCollection<Highscore> ListOfAllHighScores { get; set; } = new ObservableCollection<Highscore>();
        public ObservableCollection<Highscore> ListOfTopHighScores { get; set; } = new ObservableCollection<Highscore>();
        public ObservableCollection<Player> ListOfMostFrequentPlayers { get; set; } = new ObservableCollection<Player>();        
        public ObservableCollection<int> PlayerFrequence { get; set; } = new ObservableCollection<int>();
        public ICommand GoToPageCommand { get; set; }
        #endregion

        #region Constructor
        public HighscoreViewModel()
        {
            GetAllHighScores();
            GetTopHighscores();
            GetMostFrequentPlayers();
            GetPlayerFrequence();
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
        private void GetAllHighScores()
        {
            foreach (var highscore in Repository.GetHighscoresFromDb())
            {
                ListOfAllHighScores.Add(highscore);
            }
        }

        private void GetTopHighscores(int highscores = 3)
        {
            for (int i = 0; i < ListOfAllHighScores.Count; i++)
            {
                if (i < highscores)
                {
                    ListOfTopHighScores.Add(ListOfAllHighScores[i]);
                }
                else break;
            }
        }

        private void GetMostFrequentPlayers(int players = 3)
        {
            foreach (var player in Repository.GetTopPlayersFromDb())
            {
                ListOfMostFrequentPlayers.Add(player);
                players--;
                if (players == 0)
                {
                    break;
                }
            }
        }

        private void GetPlayerFrequence()
        {
            foreach (var player in ListOfMostFrequentPlayers)
            {
                int numberOfGames = 0;
                foreach (var score in ListOfAllHighScores)
                {
                    if (player.Player_name == score.Player_name)
                    {
                        numberOfGames++;
                    }
                }
                if (numberOfGames > 0)
                {
                    PlayerFrequence.Add(numberOfGames);
                }
            }
        }
        #endregion
    }
}  
