using Enigma.GameLogic;
using Enigma.Models;
using Enigma.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Channels;
using System.Windows.Input;

namespace Enigma.ViewModels
{
    class PuzzlePageViewModel: INotifyPropertyChanged
    {
        
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

        }

      


        public ICommand GetNbrsCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public void GetNbr()
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

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {


            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        }

        //public GetN
    }
}
