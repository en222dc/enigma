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

        #region Properties
        public string PlayerName { get; set; }
        public ObservableCollection<Player> AllPlayers { get; set; }
        public ICommand ChoosePlayerCommand{ get; set; }
        public ICommand AddPlayerClick { get; set; }
        public ICommand DeletePlayerClick { get; set; }
        #endregion

        private int maxNumberOfPlayers = 10;

        #region Construct
        public PickPlayerViewModel()
        {
            UpdateAllPlayerList();
            ChoosePlayerCommand = new RelayCommand(GoToPuzzlePage);
            AddPlayerClick = new RelayCommand(AddPlayer);
            DeletePlayerClick = new RelayCommand(DeletePlayer);
            ExitButtonContent = "Exit to Start Page";
            MyWindow.MenuFrame.Content = new MenuPage();
        }
        #endregion

        #region Methods
        public void GoToPuzzlePage()
        {
            if (MyPlayer != null)
            {
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
            if (PlayerName != null)
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
                    GoToPuzzlePage();
                }
                else
                {
                    MessageBox.Show($"You have to delete a player first, maximum allowed players is {maxNumberOfPlayers}");
                }
            }
            else
            {
                MessageBox.Show("You have to enter a name first.");
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
            if (IsMyPlayerNotNull())
            {
                Repository.DeleteChosenPlayerFromDb(MyPlayer.Player_id);
                UpdateAllPlayerList();
            }
            else
            {
                NoPlayerMessage();
            }
        }

        private void UpdateAllPlayerList()
        {
            AllPlayers = Repository.GetAllPlayers();
        }

        private bool IsMyPlayerNotNull()
        {
            bool result = false;
            if (MyPlayer != null)
            {
                result = true;
            }
            return result;
        }

        private void NoPlayerMessage()
        {
            MessageBox.Show("You have to choose a player first.");
        }
    }
    #endregion
}



