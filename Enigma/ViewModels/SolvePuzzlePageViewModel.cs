using System.Collections.ObjectModel;
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
        public int GuessesLeft { get; set; } = 3;
        public string Error { get; set; }
        public Highscore HighscoreToDB {get; set;}
        public ICommand IsGuessCorrectCommand { get; set; }
        #endregion

        #region Constructor
        public SolvePuzzlePageViewModel(int total, ObservableCollection<Suspect> SuspectList)
        {
            GetNameOnKiller();
            GetEncryptedName();
            totalSeconds = total;
            IsGuessCorrectCommand = new RelayCommand(IsGuessCorrect);
            TimeStart();
            ExitButtonContent = "Exit to Start Page";
            MyWindow.MenuFrame.Content = new MenuPage(); 
        }
        #endregion

        #region Navigation
        private void GoToSuspectPage()
        {
            var model = new SuspectsPageModel(totalSeconds);
            var page = new SuspectsPage(model);
            AddHighScore();
            NavigationService.Navigate(page);
        }

        private void GoToGameOverPage()
        {
            var model = new GameOverViewModel();
            var page = new GameOverPage(model);            
            NavigationService.Navigate(page);
        }
        #endregion

        #region Methods
        
        /// <summary>
        /// Get the Killers Encrypted name and set it in a property array of chars
        /// </summary>
        public void GetEncryptedName()
        {
            SymbolArray = new ObservableCollection<char>();
            for (int i = 0; i < MyKiller.EncryptedName.Length; i++)
            {
                SymbolArray.Add(MyKiller.EncryptedName[i]);
            }
        }

        /// <summary>
        /// Get the killers name and put it in a property of string
        /// </summary>
        private void GetNameOnKiller()
        {
            Name = MyKiller.Name;
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
                    ChangePage();
                }
                else
                {
                    GuessesLeft--;
                    if (IsGameOver())
                    {
                        ChangePage();
                    }
                    else Error = "Your guess was wrong";
                }
            }
        }




        private bool IsGameOver()
        {
            if (GuessesLeft==0)
            {
                return true;
            }
            return false;
        }

        private void ChangePage()
        {
            if (IsGameOver())
            {
                GoToGameOverPage();
            }
            else GoToSuspectPage();
        }

       // private void 
        public void AddHighScore()
        {
            MyHighScore = totalSeconds;
            var newHighScore = new Highscore
            {
                Time = totalSeconds,
                Fk_Player_id = MyPlayer.Player_id,
            };
            HighscoreToDB = Repository.AddHighScore(newHighScore);
        }
        #endregion
    }
}
