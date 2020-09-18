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
        char[] encryptKillerName = new char[4];

        public StartPageViewModel()
        {
            PlayGameCommand = new RelayCommand(ChangePage);
            CreatePlayerCommand = new RelayCommand(GoToCreatePlayerPage);

            GetSuspects getSuspects = new GetSuspects();
            getSuspects.GetAllSuspects(ListOfSuspects);

            KillerCreation killerCreation = new KillerCreation();
            killerCreation.GetKiller(ListOfSuspects, Killer);



            string killerName = Killer[0].Name;
            KillerTranslation killerTranslation = new KillerTranslation();
            killerTranslation.TranslateKillerName(killerName, encryptKillerName);



        }

        public void ChangePage()
        {
            var model = new PuzzlePageViewModel(encryptKillerName);
            var page = new PuzzlePage(model);
            NavigationService.Navigate(page);
        }

       
        public void GoToCreatePlayerPage()
        {
            var model = new PlayerRegistrationViewModel();
            var page = new PlayerRegistration();
            NavigationService.Navigate(page);
        }


    }
}
