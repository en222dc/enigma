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
    class HighscoreViewModel
    {

        public ObservableCollection<Highscore> HighScoreDatabase { get; set; } = new ObservableCollection<Highscore>();
        public ObservableCollection<Player> PlayerNameDataBase { get; set; } = new ObservableCollection<Player>();
       

        public HighscoreViewModel()
        {


            ShowHighScoreFromDataBase();
            
        }

        public void ShowHighScoreFromDataBase()
        {
            foreach (var highscore in Repository.GetHighscores())
            {
                HighScoreDatabase.Add(highscore);
            }
            foreach (var player in Repository.GetTopPlayers())
            {
                PlayerNameDataBase.Add(player);
            }
        }

    }

      

}
        
     


    

    

