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
*/

namespace Enigma.ViewModels
{
    class HighscoreViewModel
    {

       // public ObservableCollection<Highscore> HighScoreDatabase { get; set; } //= new ObservableCollection<int>();
        public ObservableCollection<Player> PlayerNameDataBase { get; set; }// = new ObservableCollection<string>();
        ICommand HighScoreDataBase { get; set; }
        ICommand ShowTopPlayerName { get; set; }

        List<Highscore> highscores { get; set; } 



        public HighscoreViewModel()
        {

            HighScoreDataBase = new RelayCommand(ShowHighScoreFromDataBase);
            FillList();
            
        }

        public void ShowHighScoreFromDataBase()
        {

            //HighScoreSelectionChanged er i xaml filen.
            //  "TopPlayerSelcetionChanged" er i xamlfilen


            //  ItemsSource = Repository.GetHighscores();
            // ItemsSource = Repository.GetTopPlayers();
            // ListBox.DisplayMemberPath;


            //SelectionChanged="TopPlayerSelcetionChanged"
            //SelectionChanged="HighScoreSelcetionChanged"
        }

        public void FillList()
            {
               /// HighScoreDatabase = new ObservableCollection<Highscore>();
            //Repository.GetHighscores;

            highscores =new List<Highscore>();

            foreach (var highscore in Repository.GetHighscores())
            {
                highscores.Add(highscore);
            }
            
          

        }
        
     


    }

    }

