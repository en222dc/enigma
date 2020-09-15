using Enigma.Converters;
using Enigma.GameLogic;
using Enigma.Models;
using Enigma.ViewModels.Commands;
using Enigma.Views;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Enigma.ViewModels
{
    class PuzzlePageViewModel: INotifyPropertyChanged
    {
        
        public ObservableCollection<int> Fibonacci { get; set; } = new ObservableCollection<int>();
        public ObservableCollection<IGameLogic> listOfPuzzles { get; set; } = new ObservableCollection<IGameLogic>();

        public GoToNextPuzzleCommand GoToNextPuzzleCommand { get; set; }

       


        #region Konstruktor
        public PuzzlePageViewModel()
        {
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

            GetNxtNrInSequenceCommand = new RelayCommand(GetNxtNrInSequence);
            CheckIfGuessCorrectCommand = new RelayCommand(CheckIfGuessCorrect);
           

        }
        #endregion
        
        #region Gränssnitt för att visa Fibonacci-sekvensen
       
        #region Variabler och propertys
       
        int count = 0; // Variabel för att hålla räkningen på vilket fack i Fibonacci-sekvensen som värdet ska hämtas ifrån
       
        private string _firstHelp; //Variabel för att kunna föra in värdet från en array i propertyn "FirstHelp"
        public string FirstHelp
        {
            get { return _firstHelp; }
            set
            {                
                _firstHelp = value;
                OnPropertyChanged();               
            }
        } //Hämtar den 2:a siffran i NummerSekvensen.
                
        private string _secondHelp; //Variabel för att kunna föra in värdet från en array i propertyn "SecondHelp"
        public string SecondHelp
        {
            get { return _secondHelp; }
            set
            {
                _secondHelp = value;
                OnPropertyChanged();
            }
        } //Hämtar den 3:e siffran i NummerSekvensen.

        private bool _isCorrect;

        public bool IsCorrect //Har binding i vyn till bakgrundsfärg för tillfället
        {
            get 
            { 
                return _isCorrect;               
            }
            set
            {
                _isCorrect = value;
            }           
        
        } 

        #endregion

        

        public ICommand GetNxtNrInSequenceCommand { get; set; }

        public ICommand CheckIfGuessCorrectCommand { get; set; }
        
        public void GetNxtNrInSequence()
        {            
              count++; // Variabel för att veta filket fack koden ska hämta ifrån i "Fibonacci"-arrayen.
            if (count==1)
            {
              FirstHelp =  Fibonacci[count].ToString();
            }
            if (count==2)
            {
                SecondHelp= Fibonacci[count].ToString();
            }
           
        }



        #endregion

        #region  Kollar ifall det gissade svaret av användaren är rätt eller fel och presenterar deti gränssnittet

        private string _buttonName = "Solve Puzzle";
        public string ButtonName
        {
            get { return _buttonName; }
            set
            {
                _buttonName = value;
                OnPropertyChanged();
            }
        }              


        private string _guess;
        public string Guess 
        {
            get { return _guess; }
            set
            {
                _guess = value;
                OnPropertyChanged();
            }
        }

      

        public void CheckIfGuessCorrect()
        {
            if (Guess == Fibonacci[3].ToString())
            {
                ButtonName = "Go To The Next Puzzle!";
            }
            else ButtonName = "Wrong, guess again!";

        }

       

        #endregion



        public event PropertyChangedEventHandler PropertyChanged;       

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

       
    }
}
