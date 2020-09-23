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
using Enigma.ViewModels.Base;

namespace Enigma.ViewModels
{
    class HighscoreViewModel : BaseViewModel
    {
        public ICommand GoToPageCommand { get; set; }

        public ObservableCollection<Highscore> HighScoreDatabase { get; set; } = new ObservableCollection<Highscore>();
        public ObservableCollection<Player> PlayerNameDataBase { get; set; } = new ObservableCollection<Player>();


        public HighscoreViewModel()
        {
            ShowHighScoreFromDataBase();
            GoToPageCommand = new RelayCommand(GoToStartPage);
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
        public void GoToStartPage()
        {
            MyWindow.MainFrame.Content = new StartPage();
        }
    }
}








