using Enigma.Models;
using Enigma.Models.Repositories;
using Enigma.ViewModels.Base;
using Enigma.Views;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Input;
using System.Windows.Navigation;

namespace Enigma.ViewModels
{
    class PickPlayerViewModel : BaseViewModel
    {
       
        public string PlayerName { get; set; }

        public string CreateNewPlayerLabel { get; set; } = "Create new player:";
        public ObservableCollection<Player> AllPlayers { get; set; }

        public ICommand ChoosePlayerCommand{ get; set; }
        public ICommand AddPlayerClick { get; set; }
        public ICommand DeletePlayerClick { get; set; }

        private int maxNumberOfPlayers = 10;

        public PickPlayerViewModel()
        {
            UpdateAllPlayerList();
            ChoosePlayerCommand = new RelayCommand(GoToPuzzlePage);
            AddPlayerClick = new RelayCommand(AddPlayer);
            DeletePlayerClick = new RelayCommand(DeletePlayer);
        }

       

        public void GoToPuzzlePage()
        {
            

            if (MyPlayer != null)
            {
                //MyPlayerInGame = MyPlayer;
                var model = new BackStoryViewModel(MyPlayer);
                var page = new BackStory();
                NavigationService.Navigate(page);
            }
            else
            {
               NoPlayerMessage();
            }


        }

        public void AddPlayer()
        {
            if (CanListHaveMorePlayers() == true)
            {        
                var newPlayer = new Player
                {
                    Player_name = PlayerName
                };

                try
                {
                    Repository.AddNewPlayerToDb(newPlayer);
                    MyPlayer = newPlayer;
                    PlayerName = null;
                    UpdateAllPlayerList();
                    GoToPuzzlePage();
                    MyPlayer = null; // må se videre på om dette er nyttig
                    CreateNewPlayerLabel = "Create new player:";
                }
                catch (PostgresException error)
                {
                    CreateNewPlayerLabel = PostgresError.GetErrorMessage(error.SqlState);
                    PlayerName = null;
                    // MessageBox.Show(PostgresError.GetErrorMessage(error.SqlState));
                }
                
            }
            else if (CanListHaveMorePlayers()== false )
                {
                CreateNewPlayerLabel = "There is to many players, Delete one to add a new one";
            }

        }


        private bool CanListHaveMorePlayers()
        {
            bool result = false;
            if (AllPlayers.Count < maxNumberOfPlayers)
                result = true;
            return result;
        }

        public void DeletePlayer()
        {
            while (CanListHaveMorePlayers() == true && IsMyPlayerNotNull())
            {
                Repository.DeleteChosenPlayerFromDb(MyPlayer.Player_id);
                UpdateAllPlayerList();
            }
            if (CanListHaveMorePlayers() == false && IsMyPlayerNotNull())
            {
                CreateNewPlayerLabel = "Create new player:";
                Repository.DeleteChosenPlayerFromDb(MyPlayer.Player_id);
                UpdateAllPlayerList();
            }
            else
                NoPlayerMessage();
        }

        private void UpdateAllPlayerList()
        {
            AllPlayers = Repository.GetAllPlayers();
        }

        private bool IsMyPlayerNotNull()
        {
            bool result = false;
            if (MyPlayer != null)
                result = true;
            return result;
        }

        private void NoPlayerMessage()
        {
            MessageBox.Show("You have to choose a player first.");
        }

    }
}



