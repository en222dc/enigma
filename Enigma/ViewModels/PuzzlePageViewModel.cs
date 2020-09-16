using Enigma.Converters;
using Enigma.GameLogic;
using Enigma.Models;
using Enigma.ViewModels.Base;
using Enigma.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace Enigma.ViewModels
{
    class PuzzlePageViewModel : BaseViewModel
    {
        #region Properties
        public ObservableCollection<int> Fibonacci { get; set; } = new ObservableCollection<int>();
        public ObservableCollection<IGameLogic> listOfPuzzles { get; set; } = new ObservableCollection<IGameLogic>();    //Används inte till något för tillfället, kan vara bra att ha ifall vi vill ha flera pussel 
        public Visibility LblInvisibleHintGetVisible { get; set; }

        public string ButtonName { get; set; } = "Guess nr";
        public string Guess4thNr { get; set; }
        public string Guess5thNr { get; set; }

        #endregion

        #region Commands

        public ICommand GetNxtNrInSequenceCommand { get; set; }

        public ICommand CheckIfGuessCorrectCommand { get; set; }

        public ICommand ShowHintCommand { get; set; }

        #endregion

        #region Konstruktor
        public PuzzlePageViewModel()
        {
            LblInvisibleHintGetVisible = Visibility.Hidden;
            //this.GoToNextPuzzleCommand = new GoToNextPuzzleCommand(this);
            int[] fibonacciArray = new int[5];
            IGameLogic fibonacci = new Fibonacci();
            fibonacci.GenerateRandomNr(fibonacciArray);
            fibonacci.GetRestOfNrInSequence(fibonacciArray);


            foreach (var position in fibonacciArray)
            {
                Fibonacci.Add(position);
            }

            listOfPuzzles.Add(fibonacci);

            // GetNxtNrInSequenceCommand = new RelayCommand(GetNxtNrInSequence); Används inte för tillfället (Har dock sparat metoden för den ifall vi vill använda oss av den senare.
            CheckIfGuessCorrectCommand = new RelayCommand(CheckIfGuessCorrect);
            ShowHintCommand = new RelayCommand(ShowHint);

            Time();

        }
        #endregion

        #region Metoder

        
        public void CheckIfGuessCorrect()
        {
            if (Guess4thNr == Fibonacci[3].ToString() && Guess5thNr == Fibonacci[4].ToString())
            {
                ButtonName = "Go To The Next Puzzle!";
            }
            else ButtonName = "Wrong, guess again!";

        }

        public void ShowHint()
        {
            if (LblInvisibleHintGetVisible == Visibility.Visible)
            {
                LblInvisibleHintGetVisible = Visibility.Hidden;
                Hint60();
            }
            else LblInvisibleHintGetVisible = Visibility.Visible;

        }


        #endregion

        private int totalSeconds = 0;
        private DispatcherTimer dispatcherTimer = null;
        private string _timeLapse;
        public string TimeLapse
        {
            get { return _timeLapse; }
            set
            {
                _timeLapse = value;
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
            TimeLapse = string.Format("{0:hh\\:mm\\:ss}", TimeSpan.FromSeconds(totalSeconds).Duration());
            OnPropertyChanged();
        }

        public void Hint60()
        {
            totalSeconds += 60;
        }

        public int getTimeElapsed()
        {

            return totalSeconds;
        }
      

        public void ChangePage()
        {
            var model = new SolvePuzzlePageViewModel(totalSeconds);
            var page = new SolvePuzzlePage(model);
            NavigationService.Navigate(page);
        }



        //public void GetNxtNrInSequence()
        //    {            
        //          count++; // Variabel för att veta filket fack koden ska hämta ifrån i "Fibonacci"-arrayen.
        //        if (count==1)
        //        {
        //          FirstHelp =  Fibonacci[count].ToString();
        //        }
        //        if (count==2)
        //        {
        //            SecondHelp= Fibonacci[count].ToString();
        //        }

        //    } // Den här metoden används inte för tillfället


    }
}
