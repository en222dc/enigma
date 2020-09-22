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
       public string Error { get; set; }
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
        public void ShowEncryptedName (ObservableCollection<Suspect> suspects)
        {
            SymbolArray = new ObservableCollection<string>();

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

        private void GetLetterArray(ObservableCollection<Suspect> suspects)
        {
            string killer = "";
            foreach (var suspect in suspects)
            {
                if (suspect.IsKiller == true)
                {
                    killer = suspect.Name.ToLower();

                }
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
            if (string.IsNullOrEmpty(Guess1stSymbol) || string.IsNullOrEmpty(Guess2ndSymbol) || string.IsNullOrEmpty(Guess3rdSymbol) || string.IsNullOrEmpty (Guess4thSymbol))
            {
                Error = "Please type a letter into every box";
            }
            else
            {
                if (Guess1stSymbol.ToLower() == LetterArray[0] && Guess2ndSymbol.ToLower() == LetterArray[1] && Guess3rdSymbol.ToLower() == LetterArray[2] && Guess4thSymbol.ToLower() == LetterArray[3])
                {
                    IsGuessCorrectCommand = new RelayCommand(GoToSuspectPage);
                }

                else
                {
                    Error = "Your guess was wrong";
                }
            }
            
        }

        private void GoToSuspectPage ()
        {
            var model = new SuspectsPageModel(ListOfSuspects);
            var page = new SuspectsPage(model);
            NavigationService.Navigate(page);
        }

        public ObservableCollection<Suspect> ReturnList (ObservableCollection<Suspect> test)
        {
            return test;
        }
        #endregion

        #region Constructor
        public SolvePuzzlePageViewModel(int total, ObservableCollection<Suspect> SuspectList)
        {
            ShowEncryptedName(SuspectList);
            GetLetterArray(SuspectList);
            totalSeconds = total;
            IsGuessCorrectCommand = new RelayCommand(IsGuessCorrect);
            Time();
        }

        #endregion

    }

}
