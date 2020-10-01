using System.Collections.ObjectModel;
using Enigma.Models;
using Enigma.ViewModels.Base;
using System.Windows.Input;
using Enigma.Views;
using Enigma.Models.Repositories;
using System.Reflection.Metadata;
using System.Windows.Navigation;

namespace Enigma.ViewModels
{
    public class SolvePuzzleViewModel : BaseViewModel
    {
        #region Properties
        public ObservableCollection<char> SymbolArray { get; set; } 
        private string Name { get; set; }
        public string Guess1stSymbol { get; set; }
        public string Guess2ndSymbol { get; set; }
        public string Guess3rdSymbol { get; set; }
        public string Guess4thSymbol { get; set; }
        public string TextBoxBorderColor { get; set; } = "Black";
        public int GuessesLeft { get; set; } = 3;
        public string Error { get; set; }
        public Highscore HighscoreToDB {get; set;}
        public ICommand IsGuessCorrectCommand { get; set; }
        #endregion

        #region Constructor
        public SolvePuzzleViewModel(int total)
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
            var model = new SuspectViewModel(totalSeconds);
            var page = new SuspectPage(model);
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
            string guess = (Guess1stSymbol + Guess2ndSymbol + Guess3rdSymbol + Guess4thSymbol).ToString();

            if (IsAnyGuessNullOrEmpty())
            {
                Error = "Fill in all the boxes.";
                TextBoxBorderColor = "Red";
                GuessesLeft--;

                if (IsGameOver())
                {
                    ChangePage();
                }
            }

            else if (IsAnyGuessNotLetter(guess))
            {
                Error = "Only letters allowed.";
                TextBoxBorderColor = "Red";
                GuessesLeft--;

                if (IsGameOver())
                {
                    ChangePage();
                }
            }

            else if (IsAnyGuessNotLetter(guess) == false && IsAnyGuessNullOrEmpty() == false)
            {
                if (guess.ToLower() == Name.ToLower())
                {
                    TextBoxBorderColor = "Green";
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

        public bool IsAnyGuessNotLetter(string guess)
        {
            foreach (char c in guess)
            {
                if (!char.IsLetter(c))
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsAnyGuessNullOrEmpty()
        {
            if (string.IsNullOrEmpty(Guess1stSymbol) || string.IsNullOrEmpty(Guess2ndSymbol) || string.IsNullOrEmpty(Guess3rdSymbol) || string.IsNullOrEmpty(Guess4thSymbol))
            {
                return true;
            }
            return false;
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

        public void AddHighScore()
        {
            MyHighScore = totalSeconds;
            var newHighScore = new Highscore
            {
                Time = totalSeconds,
                Fk_Player_id = MyPlayer.Player_id,
            };
            HighscoreToDB = Repository.AddHighScoreToDb(newHighScore);
        }
        #endregion
    }
}
