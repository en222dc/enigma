using System.Collections.ObjectModel;
using Enigma.Models;
using System.ComponentModel;
using Enigma.ViewModels.Base;
using System.Windows.Threading;
using System;

namespace Enigma.ViewModels
{
    public class SolvePuzzlePageViewModel : BaseViewModel
    {
        public ObservableCollection<char> SymbolArray { get; set; }
            
            
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

        public void KillerNameToArray ()
        {
            SymbolArray = new ObservableCollection<char>();
            char[] symbolarray = new char[4];
            IGameLogicSymbol symbols = new KillerTranslation();
            symbols.TranslateKillerName(symbolarray);

            foreach (char symbol in symbolarray)
            {
                SymbolArray.Add(symbol);
            }

        }

        public SolvePuzzlePageViewModel(int totalSecondsFromPuzzlePage) // Legg til liste her Christoffer ObservableCollection<char> symbols
        {
            KillerNameToArray();
            totalSeconds = totalSecondsFromPuzzlePage;
            Time();
        }
    }

    }
