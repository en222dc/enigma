using Enigma.Interfaces;
using Enigma.ViewModels.Base;
using Enigma.Views;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Input;
using System.Xml.Schema;

namespace Enigma.ViewModels
{
    class PuzzleViewModel : BaseViewModel
    {
        #region Properties
        public ObservableCollection<IGameLogic> ListOfPuzzlesAvaible { get; set; } = new ObservableCollection<IGameLogic>();    
        public ObservableCollection<IGameLogic> PuzzlesForGame { get; set; } = new ObservableCollection<IGameLogic>();
        public ObservableCollection<int> NumberSequence { get; set; } = new ObservableCollection<int>();
        public Visibility LblInvisibleHintGetVisible { get; set; } = Visibility.Hidden;
        public Visibility LblInvisibleSymbolsGetVisible { get; set; } = Visibility.Hidden;
        public string ButtonName { get; set; } = "Guess nr";
        public string Guess4thNr { get; set; }
        public string Guess5thNr { get; set; }
        public string Hint { get; set; }
        public string TextBoxBorderColor { get; set; } = "Black";
        public string CluesLeftToFind { get; set; }
        public bool IsButtonClickable { get; set; } = true;
        public char[] EncryptedName { get; set; } = new char[MyKiller.EncryptedName.Length];
        public int CountPuzzles { get; set; }
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
            CountPuzzles = puzzleCounter;
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
            if (CountPuzzles == MyKiller.Name.Length)
            {
                var model = new SolvePuzzleViewModel(totalSeconds);
                var page = new SolvePuzzlePage(model);

                NavigationService.Navigate(page);
            }
            else
            {
                CountNumbeOfSymbols--;
                var model = new PuzzleViewModel(totalSeconds, CountPuzzles, PuzzlesForGame);
                var page = new PuzzlePage(model);
                NavigationService.Navigate(page);
            }
        }
        #endregion

        #region Methods
        private void StartGame()
        {
            GetAllTypeOfPuzzles();
            SetPuzzlesForGame();
            int[] numberSequenceArray = new int[5];
            InstantiatePuzzle(numberSequenceArray);
            GetEntirePuzzleSequence(numberSequenceArray);
            GetHint();
            GetEncryptedName();
            GetSymbolToPuzzle();
            TimeStart();
        }

        private void ContinueGame()
        {
            int[] numberSequenceArray = new int[5];
            InstantiatePuzzle(numberSequenceArray);
            GetEntirePuzzleSequence(numberSequenceArray);
            GetHint();
            GetEncryptedName();
            GetSymbolToPuzzle();
            TimeStart();
        }

        /// <summary>
        /// Gets all type of puzzles who implements the Interface "IGameLogic"
        /// </summary>
        private void GetAllTypeOfPuzzles()
        {
            //Tagit från sida https://stackoverflow.com/questions/699852/how-to-find-all-the-classes-which-implement-a-given-interface
            var instances = from classes in Assembly.GetExecutingAssembly().GetTypes()
                            where classes.GetInterfaces().Contains(typeof(IGameLogic))
                                     && classes.GetConstructor(Type.EmptyTypes) != null
                            select Activator.CreateInstance(classes) as IGameLogic;

            foreach (var item in instances)
            {
                ListOfPuzzlesAvaible.Add(item);
            }
        }

        /// <summary>
        /// Gets the list with all avaible puzzles and it will randomize what type of puzzles that will be presented for the player in the game 
        /// </summary>
        private void SetPuzzlesForGame()
        {
            Random random = new Random();
            for (int i = 0; i < MyKiller.Name.Length; i++)
            {
                PuzzlesForGame.Add(ListOfPuzzlesAvaible[random.Next(ListOfPuzzlesAvaible.Count)]);
            }
        }

        private void InstantiatePuzzle(int[] array)
        {
            PuzzlesForGame[CountPuzzles].GenerateRandomNr(array);
            PuzzlesForGame[CountPuzzles].GetRestOfNrInSequence(array);
        }

        /// <summary>
        /// Transfer an array of integers into a property
        /// </summary>
        /// <param name="array"></param>
        private void GetEntirePuzzleSequence(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                NumberSequence.Add(array[i]);
            }
        }

        /// <summary>
        /// Gets the killers encrypted name and put it into a property
        /// </summary>
        private void GetEncryptedName()
        {        
            for (int i = 0; i < MyKiller.EncryptedName.Length; i++)
            {            
                EncryptedName[i] = MyKiller.EncryptedName[i];
            }
        }

        /// <summary>
        /// Gets the propertys "EncryptedName" and "CountPuzzles" to specify a specific position in the killers encrypted name and put it into a property
        /// </summary>
        private void GetSymbolToPuzzle()
        {
            SpecificSymbol = EncryptedName[CountPuzzles];
        }


        private void GoToNextPuzzle()
        {
            if (IsGuessCorrect())
            {
                ButtonName = "Go To The Next Puzzle!";
                CountPuzzles++;
                CountNumbeOfSymbols -= CountPuzzles;
                if (CountPuzzles < 4)
                {
                    CluesLeftToFind = "Well Done, You found A Clue. Try to collect " + CountNumbeOfSymbols.ToString() + " more symbols";
                    TextBoxBorderColor = "Green";
                }
                else
                {
                    CluesLeftToFind = "Well Done, You found all the Clues. Now go and catch the killer";
                    TextBoxBorderColor = "Green";
                }
                LblInvisibleSymbolsGetVisible = Visibility.Visible;
                GoToNextPuzzleCommand = new RelayCommand(ChangePage);

            }
            else
            {
                ButtonName = "Wrong, guess again!";
                TextBoxBorderColor = "Red";
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

        private void GetHint()
        {
            Hint = PuzzlesForGame[CountPuzzles].Hint;
        }
        private void ShowHint()
        {
            if (LblInvisibleHintGetVisible == Visibility.Hidden)
            {
                LblInvisibleHintGetVisible = Visibility.Visible;
                Hint60();
            }
            IsButtonClickable = false;
        }
        #endregion
    }
}
