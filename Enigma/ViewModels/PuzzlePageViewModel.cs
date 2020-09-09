using Enigma.GameLogic;
using Enigma.Models;
using Enigma.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Channels;
using System.Windows.Input;

namespace Enigma.ViewModels
{
    class PuzzlePageViewModel
    {
        
        public ObservableCollection<int> Fibonacci { get; set; } = new ObservableCollection<int>();




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
           


        }

        public string MyName { get; set; } = "Patric";
       





        public ICommand GetNbrsCommand { get; set; }
       
        //public GetN
    }
}
