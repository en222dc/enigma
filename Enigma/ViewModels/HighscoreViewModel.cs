using Enigma.Models;
using Enigma.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using System.Data;
using System.Data.SqlClient; //For å connecte til databasen
using System.Configuration; // For å conneste til database 
using System.Collections.ObjectModel;
using System.Linq;
using System.Collections;
using System.Windows.Navigation;
using Enigma.ViewModels.Base;

//De kan være du må se om system.configuration ligger i Enigma prosjektet også
// Nedenfor kommer kode som kanskje skal være i App.Xaml filen.
// Må også lage en metode som legger til Highscore i databasen, savehighscore > kan legges i en knapp når spillet avsluttes.
/* <connectionStrings>
            < add x: Name = "ConnectionDatabase" connectionString="" providerName= "System.Data.SqlClient" >
  
          </ connectionStrings >

OBS Lag gjerne teksten bli igjen fordi jeg kanskje trenger det til å lagre highscore
*/

namespace Enigma.ViewModels
{
    public class HighscoreViewModel : BaseViewModel
    {
        public ObservableCollection<Highscore> ListOfHighScores { get; set; } = new ObservableCollection<Highscore>();
        public ObservableCollection<Player> ListOfPlayersInHighScore { get; set; } = new ObservableCollection<Player>();

        public string ListOfHighScoreToString { get; set; } 
        public string MostFrequentPlayersToString { get; set; }

        public ICommand GoToPageCommand { get; set; }

        public HighscoreViewModel()
        {

            ShowHighScoreFromDataBase();
            GetHighScoreListToString();
            GetMostFrequentPlayersToString();
            GoToPageCommand = new RelayCommand(GoToStartPage);

        }

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

            if (ListOfPlayersInHighScore.Count==0)
            {
                MostFrequentPlayersToString = "No player has played the game";
            }
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
                MostFrequentPlayersToString += $"{player}\t{numberOfGames}\n";

            }

        }


        public void GoToStartPage()
        {
            var startpage = new StartPage();
            NavigationService.Navigate(startpage);
        }


    }

}  


        
     


    

    

