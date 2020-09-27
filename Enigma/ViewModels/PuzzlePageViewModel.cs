using Enigma.Converters;
using Enigma.GameLogic;
using Enigma.Models;
using Enigma.ViewModels.Base;
using Enigma.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Reflection;
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
        public Visibility LblInvisibleHintGetVisible { get; set; } = Visibility.Hidden;
        public Visibility LblInvisibleSymbolsGetVisible { get; set; } = Visibility.Hidden;

        // public Player MyPlayer { get; set; }


        public string ButtonName { get; set; } = "Guess nr";
        public string Guess4thNr { get; set; }
        public string Guess5thNr { get; set; }

        public string Hint { get; set; }
        public char[] EncryptedName { get; set; } = new char[4];
        public int CountPuzzles { get; set; }
        public char SpecificSymbol { get; set; }




        #endregion

        #region Commands

        public ICommand GetNxtNrInSequenceCommand { get; set; }

        public ICommand CheckIfGuessCorrectCommand { get; set; }

        public ICommand ShowHintCommand { get; set; }

        #endregion



        #region Konstruktor

        public PuzzlePageViewModel()
        {

            //this.GoToNextPuzzleCommand = new GoToNextPuzzleCommand(this);
            int[] fibonacciArray = new int[5];
            IGameLogic fibonacci = new Fibonacci();
            fibonacci.GenerateRandomNr(fibonacciArray);
            fibonacci.GetRestOfNrInSequence(fibonacciArray);
            GetHint(fibonacci);
            GetEncryptedName(ListOfSuspects);
            GetSymbolToPuzzle();


            foreach (var position in fibonacciArray)
            {
                Fibonacci.Add(position);
            }

            listOfPuzzles.Add(fibonacci);
            CheckIfGuessCorrectCommand = new RelayCommand(CheckIfGuessCorrect);
            ShowHintCommand = new RelayCommand(ShowHint);
            TimeStart();



        }



        //public PuzzlePageViewModel(ObservableCollection<Suspect>ListOfSuspects)
        //{           

        //    int[] fibonacciArray = new int[5];
        //    IGameLogic fibonacci = new Fibonacci(); //Detta borde möjliggöra att vi kan lägga flera olika typer av pussel i samma lista (Alla som har IGameLogic)
        //    fibonacci.GenerateRandomNr(fibonacciArray);
        //    fibonacci.GetRestOfNrInSequence(fibonacciArray);
        //    GetPuzzleSequenceToProperty(fibonacciArray);

        //    GetEncryptedName(ListOfSuspects);
        //    Time();        

        //    CheckIfGuessCorrectCommand = new RelayCommand(CheckIfGuessCorrect);
        //    ShowHintCommand = new RelayCommand(ShowHint);

        //}

        public PuzzlePageViewModel(Player player, ObservableCollection<Suspect> ListOfSuspects)
        {

            int[] fibonacciArray = new int[5];
            IGameLogic fibonacci = new Fibonacci(); //Detta borde möjliggöra att vi kan lägga flera olika typer av pussel i samma lista (Alla som har IGameLogic)
            fibonacci.GenerateRandomNr(fibonacciArray);
            fibonacci.GetRestOfNrInSequence(fibonacciArray);
            GetEntirePuzzleSequence(fibonacciArray);
            GetHint(fibonacci);
            MyPlayer = player;
            GetEncryptedName(ListOfSuspects);
            GetSymbolToPuzzle();
            TimeStart();

            CheckIfGuessCorrectCommand = new RelayCommand(CheckIfGuessCorrect);
            ShowHintCommand = new RelayCommand(ShowHint);

        }

        public PuzzlePageViewModel(int total, int puzzleCounter, ObservableCollection<Suspect> ImportedListOfSuspects)
        {

            int[] fibonacciArray = new int[5];
            IGameLogic fibonacci = new Fibonacci(); //Detta borde möjliggöra att vi kan lägga flera olika typer av pussel i samma lista (Alla som har IGameLogic)
            fibonacci.GenerateRandomNr(fibonacciArray);
            fibonacci.GetRestOfNrInSequence(fibonacciArray);
            GetEntirePuzzleSequence(fibonacciArray);
            GetHint(fibonacci);
            ListOfSuspects = ImportedListOfSuspects;
            CountPuzzles = puzzleCounter;
            totalSeconds = total;

            GetEncryptedName(ListOfSuspects);
            GetSymbolToPuzzle();
            TimeStart();

            CheckIfGuessCorrectCommand = new RelayCommand(CheckIfGuessCorrect);
            ShowHintCommand = new RelayCommand(ShowHint);

        }



        #endregion

        #region Metoder

        private void GetEntirePuzzleSequence(int[] array)
        {
            foreach (var item in array)
            {
                Fibonacci.Add(item);
            }
        }

        private void GetEncryptedName(ObservableCollection<Suspect> List)
        {
            foreach (var item in List)
            {
                if (item.IsKiller)
                {

                    for (int i = 0; i < item.EncryptedName.Length; i++)
                    {
                        EncryptedName[i] = item.EncryptedName[i];
                    }

                }
            }

        }

        private void GetSymbolToPuzzle()
        {
            SpecificSymbol = EncryptedName[CountPuzzles];
        }


        private void CheckIfGuessCorrect()
        {
            if (Guess4thNr == Fibonacci[3].ToString() && Guess5thNr == Fibonacci[4].ToString())
            {
                ButtonName = "Go To The Next Puzzle!";
                LblInvisibleSymbolsGetVisible = Visibility.Visible;
                CountPuzzles++;
                CheckIfGuessCorrectCommand = new RelayCommand(ChangePage);
            }
            else ButtonName = "Wrong, guess again!";

        }

        private void GetHint(IGameLogic puzzle)
        {
            Hint = puzzle.Hint;
        }
        private void ShowHint()
        {
            if (LblInvisibleHintGetVisible == Visibility.Hidden)
            {
                LblInvisibleHintGetVisible = Visibility.Visible;
                Hint60();

            }
        }

        private void ChangePage()
        {
            if (CountPuzzles == 4)
            {
                var model = new SolvePuzzlePageViewModel(totalSeconds, ListOfSuspects);
                var page = new SolvePuzzlePage(model);
                NavigationService.Navigate(page);
            }
            else
            {
                var model = new PuzzlePageViewModel(totalSeconds, CountPuzzles, ListOfSuspects);
                var page = new PuzzlePage(model);
                NavigationService.Navigate(page);
            }
        }


        #endregion

 

      




       

    
        




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
