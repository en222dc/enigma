using Enigma.Models;
using Enigma.ViewModels.Base;
using Enigma.Views;
using System;
using System.Collections.Generic;
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


        List<Suspect> ListOfSuspects = new List<Suspect>();
        List<Suspect> Killer = new List<Suspect>();

        public StartPageViewModel()
        {
            PlayGameCommand = new RelayCommand(ChangePage);
            CreatePlayerCommand = new RelayCommand(GoToCreatePlayerPage);
            GetSuspects getSuspects = new GetSuspects();
            getSuspects.GetAllSuspects(ListOfSuspects);
            KillerCreation killerCreation = new KillerCreation();
            killerCreation.GetKiller(ListOfSuspects, Killer);
            

        }

        public void ChangePage()
        {
            var model = new PuzzlePageViewModel(Killer);
            var page = new PuzzlePage(model);
            NavigationService.Navigate(page);
        }

        // public event PropertyChangedEventHandler PropertyChanged;

        public void GoToPickPlayerPage()

        {
            var model = new PuzzlePageViewModel();
            var page = new PuzzlePage();
            NavigationService.Navigate(page);
             
        }

        public void GoToCreatePlayerPage()
        {
            var model = new PlayerRegistrationViewModel();
            var page = new PlayerRegistration();
            NavigationService.Navigate(page);
        }


        /*
        protected void OnPropertyChanged ([CallerMemberName] string name = null)
        {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
           
        }
        */
        }
}
