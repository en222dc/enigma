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

        #region Properties

        public string ButtonName { get; set; } = "Play Game";

        #endregion


        #region

        public ICommand PlayGameCommand { get; set;}
        public ICommand CreatePlayerCommand { get; set; }

        #endregion


        #region Konstruktor

        public StartPageViewModel()
        {            
            PlayGameCommand = new RelayCommand(ChangePage);
            CreatePlayerCommand = new RelayCommand(GoToCreatePlayerPage);           
            ListOfSuspects = SetSuspectsForGame();
            SetKiller(ListOfSuspects);
            EncryptKillerName(ListOfSuspects);
        }

        #endregion

        #region Metoder

        private ObservableCollection<Suspect> GetAllSuspects()
        {
            ObservableCollection<Suspect> Templist = new ObservableCollection<Suspect>();
            foreach (var suspect in Repository.GetAllSuspects())
            {
                Templist.Add(suspect);
            }

            return Templist;
        }

        private ObservableCollection<Suspect> SetSuspectsForGame(int number = 4)
        {
            ObservableCollection<Suspect> ListOfAllSuspects = new ObservableCollection<Suspect>();
            ListOfAllSuspects = GetAllSuspects();
            ObservableCollection<Suspect> SuspectsInGame = new ObservableCollection<Suspect>();
           
            int position;
            Random random = new Random();
            for (int i = 0; i < number; i++)
            {               
                    position = random.Next(ListOfAllSuspects.Count);
                    if (SuspectsInGame.Contains(ListOfAllSuspects[position]))
                    {
                        i = i - 1;
                    }
                    else
                    { 
                    SuspectsInGame.Add(ListOfAllSuspects[position]);                    
                    }                
            }
            return SuspectsInGame;
        }

        private void SetKiller(ObservableCollection<Suspect> suspects)
        {

            Random random = new Random();
            int index;
            index = random.Next(suspects.Count);
            suspects[index].IsKiller = true;

        }

        public void EncryptKillerName(ObservableCollection<Suspect> listOfSuspects)
        {
            string killerName = "";
            for (int suspect = 0; suspect < listOfSuspects.Count; suspect++)
            {
                if (listOfSuspects[suspect].IsKiller)
                {
                    killerName = listOfSuspects[suspect].Name;
                    listOfSuspects[suspect].EncryptedName = new char[listOfSuspects[suspect].Name.Length];
                    foreach (KeyValuePair<string, string> pair in SymbolAlphabet.SymbolMap)
                    {
                        killerName = killerName.ToLower().Replace(pair.Value, pair.Key);
                    }


                    for (int i = 0; i < killerName.Length; i++)
                    {
                        foreach (char c in killerName)
                        {
                            listOfSuspects[suspect].EncryptedName[i] = c;
                            i++;
                        }
                    }
                }
            }      



        }

        public void ChangePage()
        {
            var model = new PuzzlePageViewModel(ListOfSuspects);
            var page = new PuzzlePage(model);
            NavigationService.Navigate(page);
        }


        public void GoToCreatePlayerPage()
        {
            //var model = new PlayerRegistrationViewModel();
            var page = new PlayerRegistration();
            NavigationService.Navigate(page);
        }

        #endregion





    }
}
