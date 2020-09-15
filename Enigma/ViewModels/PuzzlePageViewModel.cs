using Enigma.GameLogic;
using Enigma.Models;
using Enigma.ViewModels.Base;
using Enigma.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Dynamic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Channels;
using System.Windows.Input;
using System.Windows.Threading;

namespace Enigma.ViewModels
{
    class PuzzlePageViewModel: INotifyPropertyChanged // Shows no timer if it inherent from BaseViewModel??
    {
        private int totalSeconds = 0;
     

        private DispatcherTimer dispatcherTimer = null;

             
        string _timeLapse;
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
        }

        public void Hint15()
        {
          
                totalSeconds = +totalSeconds + 15;
             
        
        }

        public int getTimeElapsed()
        {

            return 1;
        }



        public ICommand SolvedPuzzel { get; set; }

        public void ChangePage()
        {
            var model = new SolvePuzzelPageViewModel();
            var page = new SolvePuzzlePage();
          //  NavigationService.Navigate(page);
        }

   


        public ObservableCollection<int> Fibonacci { get; set; } = new ObservableCollection<int>();


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


        public PuzzlePageViewModel()
        {
            
            int[] fibonacciArray = new int[5];
            IGameLogic fibonacci = new Fibonacci();
            fibonacci.GenerateRandomNr(fibonacciArray);
            fibonacci.GetRestOfNr(fibonacciArray);
            
            foreach (var position in fibonacciArray)
            {
            Fibonacci.Add(position);
            }

            GetNbrsCommand = new RelayCommand(GetNbr);
            SolvedPuzzel = new RelayCommand(ChangePage);
            Time();


          
         
        }


      


        public ICommand GetNbrsCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public void GetNbr()
        {
            
            
            count++; // Variabel för att veta filket fack koden ska hämta ifrån i "Fibonacci"-arrayen.
            if (count==1)
            {
              FirstHelp =  Fibonacci[count].ToString();
                Hint15(); //Adds 15 seconds if you ask for a hint
            }
            if (count==2)
            {
                SecondHelp= Fibonacci[count].ToString();
                Hint15();
            }

           
           
        }

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {


            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        }

        //public GetN
    }
}
