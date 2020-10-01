using Enigma.Models;
using Enigma.Models.Repositories;
using Enigma.ViewModels.Base;
using Enigma.Views;
using Npgsql;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Navigation;

namespace Enigma.ViewModels
{
    class PickPlayerViewModel : BaseViewModel
    {
        #region Properties
        public string PlayerName { get; set; }
        public string CreateNewPlayerLabel { get; set; } = "Create new player:";
        public ObservableCollection<Player> AllPlayers { get; set; }
        public ICommand ChoosePlayerCommand { get; set; }
        public ICommand AddPlayerClick { get; set; }
        public ICommand DeletePlayerClick { get; set; }
        #endregion

        private int maxNumberOfPlayers = 10;

        #region Constructor
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

        #region Navigation
        public void GoToPuzzlePage()
        {
            if (MyPlayer != null)
            {
                var model = new BackStoryViewModel(MyPlayer);
                var page = new BackStoryPage();
                NavigationService.Navigate(page);
            }
            else
            {
                NoPlayerMessage();
            }
        }
        #endregion

        #region Methods
        public void AddPlayer()
        {
            if (ListCanHaveMorePlayers() && PlayerName != null)
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
                    CreateNewPlayerLabel = "Create new player:";
                }
                catch (PostgresException error)
                {
                    CreateNewPlayerLabel = PostgresError.GetErrorMessage(error.SqlState);
                    PlayerName = null;
                }
            }
            else if (!ListCanHaveMorePlayers())
            {
                CreateNewPlayerLabel = "There are to many players. Delete one to add a new.";
            }
            else
            {
                CreateNewPlayerLabel = "You have to write in a name";
            }
        }

        private bool ListCanHaveMorePlayers()
        {
            bool result = false;
            if (AllPlayers.Count < maxNumberOfPlayers)
            {
                result = true;
            }
            return result;
        }

        public void DeletePlayer()
        {
            if (IsMyPlayerNotNull())
            {
                CreateNewPlayerLabel = "Create new player:";
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
            AllPlayers = Repository.GetAllPlayersFromDb();
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
        #endregion
    }
}
