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
    class SolvePuzzelPageViewModel : BaseViewModel
    {

        private int totalSeconds = 0;
        private DispatcherTimer dispatcherTimer = null;

        // private string TimeLapse2 { set; get; }


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

        public SolvePuzzelPageViewModel( int total)
        {
            totalSeconds = total;
            Time();
           

        }

       


    }
    }

