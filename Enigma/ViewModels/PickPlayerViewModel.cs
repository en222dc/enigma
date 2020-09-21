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

        public PickPlayerViewModel()
        {
            CommandClick = new RelayCommand(GoToPuzzlePage);
            AddPlayerClick = new RelayCommand(AddPlayer);
            AllPlayers = Repository.GetAllPlayers();
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
            var newPlayer = new Player
            {
                Player_name = PlayerName
            };
            MyPlayer = Repository.AddNewPlayerToDb(newPlayer);
        }

        //protected void OnPropertyChanged([CallerMemberName] string name = null)
        //    {
        //        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        //    }
    }
}



