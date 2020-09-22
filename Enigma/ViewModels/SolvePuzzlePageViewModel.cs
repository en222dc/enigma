using System.Collections.ObjectModel;
using Enigma.Models;
using System.ComponentModel;
using Enigma.ViewModels.Base;
using System.Windows.Threading;
using System;
using System.Windows.Input;
using Enigma.Views;
using System.Collections.Generic;

namespace Enigma.ViewModels
{
    public class SolvePuzzlePageViewModel : BaseViewModel
    {
        #region Properties
       public ObservableCollection<string> SymbolArray { get; set; }
       private string[] LetterArray { get; set; }
       public string Guess1stSymbol { get; set; }
       public string Guess2ndSymbol { get; set; }
       public string Guess3rdSymbol { get; set; }
       public string Guess4thSymbol { get; set; }
       public string Guess { get; set; }
        #endregion

        #region Commands
        public ICommand IsGuessCorrectCommand { get; set; }
        #endregion

        #region Timer
        private int totalSeconds = 0;
        private DispatcherTimer dispatcherTimer = null;
 
        private string _timeLapse2;
        public string TimeLapse2
        {
            get { return _timeLapse2; }
            set
            {
                _timeLapse2 = value;
                OnPropertyChanged();
            }
        }


        public void Time()
        {
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Tick += new EventHandler(Timer_Tick2);
            dispatcherTimer.Start();
        }


   
     private void Timer_Tick2(object state, EventArgs e)
        {
            totalSeconds++;
            TimeLapse2 = string.Format("{0:hh\\:mm\\:ss}", TimeSpan.FromSeconds(totalSeconds).Duration());
        }

        #endregion

        #region Methods
        public void SymbolsToArray (string killer)
        {
            SymbolArray = new ObservableCollection<string>();

            foreach (char symbol in killer)
            {
                SymbolArray.Add(symbol.ToString());
            }
        }

        private void GetLetterArray(string killer)
        {
            foreach (KeyValuePair<string, string> pair in SymbolAlphabet.SymbolMap)
            {
                killer = killer.ToLower().Replace(pair.Key, pair.Value);
            }

            LetterArray = new string[4];

            for (int i = 0; i < killer.Length; i++)
            {
                foreach (char c in killer)
                {
                    LetterArray[i] = c.ToString();
                    i++;
                }
            }
        }

        private void IsGuessCorrect()
        {
            if (Guess1stSymbol.ToLower() == LetterArray[0] && Guess2ndSymbol.ToLower() == LetterArray[1] && Guess3rdSymbol.ToLower() == LetterArray[2] && Guess4thSymbol.ToLower() == LetterArray[3])
            {
                IsGuessCorrectCommand = new RelayCommand(GoToSuspectPage);
            }
            else
            {
                Guess = "Your guess was wrong!";
            }
        }

        private void GoToSuspectPage ()
        {
            var model = new SuspectsPageModel(ListOfSuspectsInGame);
            var page = new SuspectsPage(model);
            NavigationService.Navigate(page);
        }
        #endregion

        ObservableCollection<Suspect> ListOfSuspectsInGame = new ObservableCollection<Suspect>();

        #region Constructor
        public SolvePuzzlePageViewModel(int total, ObservableCollection<Suspect>ListOfSuspects)
        {
            ListOfSuspectsInGame = ListOfSuspects;
            //SymbolsToArray(encryptedname);
            //GetLetterArray(encryptedname);
            totalSeconds = total;
            IsGuessCorrectCommand = new RelayCommand(IsGuessCorrect);
            Time();
        }

        #endregion

    }

}
