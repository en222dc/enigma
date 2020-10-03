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
            ListOfAllHighScores=GetAllHighScores();
            ListOfTopHighScores=GetTopHighscores();
            ListOfMostFrequentPlayers=GetMostFrequentPlayers();
            PlayerFrequence=GetPlayerFrequence(ListOfAllHighScores, ListOfMostFrequentPlayers);
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
        private ObservableCollection<Highscore> GetAllHighScores()
        {
            ObservableCollection<Highscore> listOfAllHighScores = new ObservableCollection<Highscore>();
            foreach (var highscore in Repository.GetHighscoresFromDb())
            {
                listOfAllHighScores.Add(highscore);
            }
            return listOfAllHighScores;

        }

        private ObservableCollection<Highscore> GetTopHighscores(int highscores = 3)
        {
            ObservableCollection<Highscore> listOfTopHighScores = new ObservableCollection<Highscore>();
            for (int i = 0; i < ListOfAllHighScores.Count; i++)
            {
                if (i < highscores)
                {
                    listOfTopHighScores.Add(ListOfAllHighScores[i]);
                }
                else break;
            }
            return listOfTopHighScores;
        }

        private ObservableCollection<Player> GetMostFrequentPlayers(int players = 3)
        {
            ObservableCollection<Player> listOfMostFrequentPlayers = new ObservableCollection<Player>();
            foreach (var player in Repository.GetTopPlayersFromDb())
            {
                listOfMostFrequentPlayers.Add(player);
                players--;
                if (players == 0)
                {
                    break;
                }
            }
            return listOfMostFrequentPlayers;

        }

        private ObservableCollection<int> GetPlayerFrequence(ObservableCollection<Highscore>listOfAllHighScores,ObservableCollection<Player> listOfMostFrequentPlayers)
        {
            ObservableCollection<int> playerFrequence = new ObservableCollection<int>();
            foreach (var player in listOfMostFrequentPlayers)
            {
                int numberOfGames = 0;
                foreach (var score in listOfAllHighScores)
                {
                    if (player.Player_name == score.Player_name)
                    {
                        numberOfGames++;
                    }
                }
                if (numberOfGames > 0)
                {
                    playerFrequence.Add(numberOfGames);
                }
            }
            return playerFrequence;
        }
        #endregion
    }
}  
