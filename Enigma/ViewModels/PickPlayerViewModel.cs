using Enigma.Models;
using Enigma.Models.Repositories;
using Enigma.ViewModels.Base;
using Enigma.Views;
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
        public Player MyPlayer { get; set; }
        public string PlayerName { get; set; }
        public ObservableCollection<Player> AllPlayers { get; set; }

        public ICommand CommandClick { get; set; }
        public ICommand AddPlayerClick { get; set; }
        public ICommand DeletePlayerClick { get; set; }

        private int maxNumberOfPlayers = 10;

        public PickPlayerViewModel()
        {
            UpdateAllPlayerList();
            CommandClick = new RelayCommand(GoToPuzzlePage);
            AddPlayerClick = new RelayCommand(AddPlayer);
            DeletePlayerClick = new RelayCommand(DeletePlayer);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void GoToPuzzlePage()
        {
            var model = new PuzzlePageViewModel();
            var page = new PuzzlePage();

            NavigationService.Navigate(page);
        }

        public void AddPlayer()
        {
            if (CanListHaveMorePlayers())
            {
                var newPlayer = new Player
                {
                    Player_name = PlayerName
                };
                MyPlayer = Repository.AddNewPlayerToDb(newPlayer);
                UpdateAllPlayerList();
                PlayerName = null;
            }
            else
                MessageBox.Show($"You have to delete a player first, maximum allowed players is {maxNumberOfPlayers}");
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
            if (IsMyPlayerNotNull())
            {
                //Repository.
                //Repository.DeleteChosenPlayerFromDb(MyPlayer.Player_id);
                //UpdateAllPlayerList();
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

        //protected void OnPropertyChanged([CallerMemberName] string name = null)
        //    {
        //        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        //    }
    }
}



