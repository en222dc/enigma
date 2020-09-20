using Enigma.Models;
using Enigma.Models.Repositories;
using Enigma.ViewModels.Base;
using Enigma.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.DirectoryServices.ActiveDirectory;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Input;
using System.Windows.Navigation;
using System.Windows.Threading;

namespace Enigma.ViewModels
{

    public class StartPageViewModel : BaseViewModel
    {

        public string ButtonName { get; set; } = "Play Game";



        public ICommand PlayGameCommand { get; set;}
        public ICommand CreatePlayerCommand { get; set; }


        ObservableCollection<Suspect> ListOfSuspects = new ObservableCollection<Suspect>();


        public StartPageViewModel()
        {
            PlayGameCommand = new RelayCommand(ChangePage);
            CreatePlayerCommand = new RelayCommand(GoToCreatePlayerPage);
            ListOfSuspects = GetAllSuspects();
           


        }

        private ObservableCollection<Suspect> GetAllSuspects()
        {
            ObservableCollection<Suspect> Templist = new ObservableCollection<Suspect>();
            foreach (var suspect in Repository.GetAllSuspects())
            {
                Templist.Add(suspect);
            }

            return Templist;
        }


        public void ChangePage()
        {
            //var model = new PuzzlePageViewModel(encryptKillerName);
            //var page = new PuzzlePage(model);
            //NavigationService.Navigate(page);
        }

       
        public void GoToCreatePlayerPage()
        {
            var model = new PlayerRegistrationViewModel();
            var page = new PlayerRegistration();
            NavigationService.Navigate(page);
        }


    }
}
