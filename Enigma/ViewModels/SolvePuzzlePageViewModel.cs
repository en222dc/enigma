using System.Collections.ObjectModel;
using Enigma.Models;
using System.ComponentModel;
using Enigma.ViewModels.Base;
using System.Windows.Threading;
using System;
using System.Windows.Input;
using Enigma.Views;

namespace Enigma.ViewModels
{
    public class SolvePuzzlePageViewModel : BaseViewModel, INotifyPropertyChanged
    {
       public ObservableCollection<char> SymbolArray { get; set; }
        private string Killer { get; set; }
       private char[] LetterArray { get; set; }
       public char Guess1stSymbol { get; set; }
       public char Guess2ndSymbol { get; set; }
       public char Guess3rdSymbol { get; set; }
       public char Guess4thSymbol { get; set; }
       public string Guess { get; set; } 

       public ICommand IsGuessCorrectCommand { get; set; }
       


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

        public void SymbolsToArray (string killer)
        {
            SymbolArray = new ObservableCollection<char>();

            foreach (char symbol in killer)
            {
                SymbolArray.Add(symbol);
            }

        }

        public void GetLetterArray(string killer)
        {
            KillerTranslation killerTranslation = new KillerTranslation();
            killer = killerTranslation.SymbolsToLetters(killer);
            LetterArray = new char[4];

            for (int i = 0; i < killer.Length; i++)
            {
                foreach (char c in killer)
                {
                    LetterArray[i] = c;
                    i++;
                }
            }
        }

        private void IsGuessCorrect()
        {

            if (Guess1stSymbol == LetterArray[0] && Guess2ndSymbol == LetterArray[1] && Guess3rdSymbol == LetterArray[2] && Guess4thSymbol == LetterArray[3])
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
            var model = new SuspectsPageModel();
            var page = new SuspectsPage();
            NavigationService.Navigate(page);

        }

        public SolvePuzzlePageViewModel()
        {
            SymbolsToArray(Killer);
            GetLetterArray(Killer);
            IsGuessCorrectCommand = new RelayCommand(IsGuessCorrect);
            Time();
        }


        public SolvePuzzlePageViewModel(int total, string killer)
        {
            
            SymbolsToArray(killer);
            GetLetterArray(killer);
            totalSeconds = total;
            killer = Killer;
            Time();
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }

    }
