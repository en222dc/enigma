﻿using System.Collections.ObjectModel;
using Enigma.Models;
using System.ComponentModel;
using Enigma.ViewModels.Base;
using System.Windows.Threading;
using System;
using System.Windows.Input;
using Enigma.Views;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Enigma.Models.Repositories;
using System.Linq;

namespace Enigma.ViewModels
{
    public class SolvePuzzlePageViewModel : BaseViewModel
    {
        #region Properties
        public ObservableCollection<char> SymbolArray { get; set; }
        private string Name { get; set; }
        public string Guess1stSymbol { get; set; }
        public string Guess2ndSymbol { get; set; }
        public string Guess3rdSymbol { get; set; }
        public string Guess4thSymbol { get; set; }
        public string Error { get; set; }
        public Highscore HighscoreToDB {get; set;}

      
        #endregion

        #region Commands
        public ICommand IsGuessCorrectCommand { get; set; }
        #endregion

       

        #region Methods
        public void ShowEncryptedName(ObservableCollection<Suspect> suspects)
        {
            SymbolArray = new ObservableCollection<char>();

            foreach (var suspect in suspects)
            {
                if (suspect.IsKiller == true)
                {
                    for (int i = 0; i < suspect.EncryptedName.Length; i++)
                    {
                        SymbolArray.Add(suspect.EncryptedName[i]);
                    }
                }
            }
        }

        private void GetNameOnMurderer(ObservableCollection<Suspect> suspects)
        {
            foreach (var suspect in suspects)
            {
                if (suspect.IsKiller)
                {
                    Name = suspect.Name;
                }
            }
        }




        private void IsGuessCorrect()
        {

            if (string.IsNullOrEmpty(Guess1stSymbol) || string.IsNullOrEmpty(Guess2ndSymbol) || string.IsNullOrEmpty(Guess3rdSymbol) || string.IsNullOrEmpty(Guess4thSymbol))
            {
                Error = "Please type a letter into every box";
            }
            else
            {
                string guess = (Guess1stSymbol + Guess2ndSymbol + Guess3rdSymbol + Guess4thSymbol).ToString();

                if (guess.ToLower() == Name.ToLower())
                {
                    GoToSuspectPage();
                }

                else
                {
                    Error = "Your guess was wrong";
                }
            }

        }

        private void GoToSuspectPage()
        {
            var model = new SuspectsPageModel(ListOfSuspects, totalSeconds);
            var page = new SuspectsPage(model);
            AddHighScore();
            NavigationService.Navigate(page);
        }

        
        #endregion

        #region Constructor
        public SolvePuzzlePageViewModel(int total, ObservableCollection<Suspect> SuspectList)
        {
            ShowEncryptedName(SuspectList);
            GetNameOnMurderer(SuspectList);                 
            totalSeconds = total;
            IsGuessCorrectCommand = new RelayCommand(IsGuessCorrect);
            TimeStart();
           
        }

        #endregion

        #region HighscoreToDB
        public void AddHighScore()
        {
          
            MyHighScore = totalSeconds;
            var newHighScore = new Highscore
            {
                Time = totalSeconds,
                Fk_Player_id= MyPlayer.Player_id,
                };
              HighscoreToDB = Repository.AddHighScore(newHighScore);
               
              
            }

       
         

    }
        #endregion

    }
