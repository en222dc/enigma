using Enigma.Interfaces;
using Enigma.ViewModels.Base;
using Enigma.Views;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Input;

namespace Enigma.ViewModels
{
    class PuzzleViewModel : BaseViewModel
    {
        #region Properties
        public ObservableCollection<IGameLogic> ListOfPuzzlesAvaible { get; set; } = new ObservableCollection<IGameLogic>();    
        public ObservableCollection<IGameLogic> PuzzlesForGame { get; set; } = new ObservableCollection<IGameLogic>();
        public Visibility LblInvisibleHintGetVisible { get; set; } = Visibility.Hidden;
        public Visibility LblInvisibleSymbolsGetVisible { get; set; } = Visibility.Hidden;
        public int[] NumberSequence { get; set; } = new int[5];
        public string ButtonName { get; set; } = "Solve Puzzle";
        public string Guess4thNr { get; set; }
        public string Guess5thNr { get; set; }
        public string[] Guesses { get; set; }
        public string Error { get; set; }
        public string Hint { get; set; }
        public string TextBoxBorderColor { get; set; } = "Black";
        public string CluesLeftToFind { get; set; }
        public bool IsButtonClickable { get; set; } = true;
        public char[] EncryptedName { get; set; } = new char[MyKiller.EncryptedNameOfKiller.Length];
        public int PuzzleCounter { get; set; }
        public int CountNumbeOfSymbols { get; set; } = 4;
        public char SpecificSymbol { get; set; }       
        public ICommand GoToNextPuzzleCommand { get; set; }
        public ICommand ShowHintCommand { get; set; }


        #endregion

        #region Constructors
        public PuzzleViewModel()
        {
            StartGame();      
          
            GoToNextPuzzleCommand = new RelayCommand(GoToNextPuzzle);
            ShowHintCommand = new RelayCommand(ShowHint);
            ExitButtonContent = "Exit to Start Page";
            MyWindow.MenuFrame.Content = new MenuPage();
        }
      
        public PuzzleViewModel(int total, int puzzleCounter, ObservableCollection<IGameLogic> puzzlesForGame)
        {
            totalSeconds = total;
            PuzzleCounter = puzzleCounter;
            PuzzlesForGame = puzzlesForGame;
            ContinueGame();

            GoToNextPuzzleCommand = new RelayCommand(GoToNextPuzzle);
            ShowHintCommand = new RelayCommand(ShowHint);
            ExitButtonContent = "Exit to Start Page";
            MyWindow.MenuFrame.Content = new MenuPage();
        }
        #endregion

        #region Navigation
        /// <summary>
        /// Generate new puzzles until the player has collected as many symbols as chars in Encrypted name.
        /// When player has collected all symbols-> Navigate to new ViewModel
        /// </summary>
        private void ChangePage()
        {
            if (PuzzleCounter == MyKiller.KillerName.Length)
            {
                var model = new SolvePuzzleViewModel(totalSeconds);
                var page = new SolvePuzzlePage(model);

                NavigationService.Navigate(page);
            }
            else
            {
                CountNumbeOfSymbols--;
                var model = new PuzzleViewModel(totalSeconds, PuzzleCounter, PuzzlesForGame);
                var page = new PuzzlePage(model);
                NavigationService.Navigate(page);
            }
        }
        #endregion

        #region Methods
        private void StartGame()
        {
            EncryptedName = MyKiller.EncryptedNameOfKiller;
            ListOfPuzzlesAvaible=GetAllTypeOfPuzzles();
            PuzzlesForGame=SetPuzzlesForGame(ListOfPuzzlesAvaible, EncryptedName);           
            NumberSequence=SetNumberSequenceInPuzzle(PuzzlesForGame, PuzzleCounter);
            Hint = GetHint(PuzzlesForGame, PuzzleCounter);
            SpecificSymbol = GetSymbolToPuzzle(EncryptedName, PuzzleCounter);
            TimeStart();
        }

        private void ContinueGame()
        {           
            EncryptedName = MyKiller.EncryptedNameOfKiller;
            NumberSequence=SetNumberSequenceInPuzzle(PuzzlesForGame, PuzzleCounter);
            Hint=GetHint(PuzzlesForGame, PuzzleCounter);
            SpecificSymbol=GetSymbolToPuzzle(EncryptedName, PuzzleCounter);
            TimeStart();
        }

        /// <summary>
        /// Gets all type of puzzles who implements the Interface "IGameLogic"
        /// </summary>
        ///<returns>
        ///A list with all puzzles who implements the interface
        ///</returns> 
        private ObservableCollection<IGameLogic> GetAllTypeOfPuzzles()
        {
            //Tagit från sida https://stackoverflow.com/questions/699852/how-to-find-all-the-classes-which-implement-a-given-interface

            ObservableCollection<IGameLogic> templist = new ObservableCollection<IGameLogic>();
            var instances = from classes in Assembly.GetExecutingAssembly().GetTypes()
                            where classes.GetInterfaces().Contains(typeof(IGameLogic))
                                     && classes.GetConstructor(Type.EmptyTypes) != null
                            select Activator.CreateInstance(classes) as IGameLogic;

            foreach (var item in instances)
            {
                templist.Add(item);
            }
            return templist;
        }

        /// <summary>
        /// Gets the list with all avaible puzzles and it will randomize what type of puzzles that will be presented for the player in the game 
        /// </summary>
        /// <returns>
        /// An ObservableCollection with puzzles for the game
        /// </returns>
        private ObservableCollection<IGameLogic> SetPuzzlesForGame(ObservableCollection<IGameLogic> listOfPuzzlesAvaible, char[] encryptedName)
        {
            ObservableCollection<IGameLogic> puzzlesForGame = new ObservableCollection<IGameLogic>();
            Random random = new Random();
            for (int i = 0; i < encryptedName.Length; i++)
            {
                puzzlesForGame.Add(listOfPuzzlesAvaible[random.Next(listOfPuzzlesAvaible.Count)]);
            }
            return puzzlesForGame;
        }

        /// <summary>
        /// Sets the number sequence for the current puzzle
        /// </summary>
        /// <param name="puzzlesForGame"></param>
        /// <param name="array"></param>
        /// <returns>
        /// An array of integers 
        /// </returns>
        private int[] SetNumberSequenceInPuzzle(ObservableCollection<IGameLogic> puzzlesForGame, int puzzleCounter)
        {
            int[] numberSequence = new int[5];
            puzzlesForGame[puzzleCounter].GenerateRandomNr(numberSequence);
            puzzlesForGame[puzzleCounter].GetRestOfNrInSequence(numberSequence);

            return numberSequence;
        }

       
        /// <summary>
        /// Takes an array with chars and a counter that decides wich char to display 
        /// </summary>
        /// <returns>
        /// The specific symbol for the current puzzle
        /// </returns>
        private char GetSymbolToPuzzle(char[] encryptedName, int puzzleCounter)
        {
            char specificSymbol;
            specificSymbol = encryptedName[puzzleCounter];
            return specificSymbol;
        }


        private void GoToNextPuzzle()
        {
            if (IsAnyGuessNullOrEmpty())
            {
                TextBoxBorderColor = "Red";
                Error = "You need to type a number into each of the boxes";
            }
            else
            {
                if (IsGuessCorrect())
                {
                    ButtonName = "Go To The Next Puzzle!";
                    PuzzleCounter++;
                    CountNumbeOfSymbols -= PuzzleCounter;
                    if (PuzzleCounter < 4)
                    {
                        CluesLeftToFind = "Well Done, You found A Clue. Try to collect " + CountNumbeOfSymbols.ToString() + " more symbols";
                        TextBoxBorderColor = "Green";
                        Error = null;
                    }
                    else
                    {
                        CluesLeftToFind = "Well Done, You found all the Clues. Now go and catch the killer";
                        TextBoxBorderColor = "Green";
                        Error = null;
                    }
                    LblInvisibleSymbolsGetVisible = Visibility.Visible;
                    GoToNextPuzzleCommand = new RelayCommand(ChangePage);

                }
                else
                {
                    TextBoxBorderColor = "Red";
                    Error = "Your guess was wrong.";
                }
            }
        }

       
        private bool IsGuessCorrect()
        {
                        
            if (Guess4thNr == NumberSequence[3].ToString() && Guess5thNr == NumberSequence[4].ToString())
            {
                return true;
            }
            return false;
        }

        public bool IsAnyGuessNullOrEmpty()
        {
            if (string.IsNullOrEmpty(Guess4thNr) || string.IsNullOrEmpty(Guess5thNr))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Gets the hint for the current puzzle
        /// </summary>
        /// <param name="puzzlesForGame"></param>
        /// <param name="puzzleCounter"></param>
        /// <returns>
        /// The hint for the current puzzle
        /// </returns>
        private string GetHint(ObservableCollection<IGameLogic>puzzlesForGame, int puzzleCounter)
        {
            string hint = puzzlesForGame[puzzleCounter].Hint;
            return hint;
        }
        private void ShowHint()
        {
            if (LblInvisibleHintGetVisible == Visibility.Hidden)
            {
                LblInvisibleHintGetVisible = Visibility.Visible;
                PenaltyTimeForUsedHint();
            }
            IsButtonClickable = false;
        }
        #endregion
    }
}
