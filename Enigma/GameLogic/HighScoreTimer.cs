using Enigma.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Threading;

namespace Enigma.Models
{
    class HighScoreTimer: BaseViewModel
    {
        public string TimeLapse { get; set; }

        private int totalSeconds = 0;

        private DispatcherTimer dispatcherTimer = null;



        public void Time()
        {
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Tick += new EventHandler(Timer_Ticks);
            dispatcherTimer.Start();

        }


        private void Timer_Ticks(object state, EventArgs e)
        {
            totalSeconds++;
            TimeLapse = string.Format("{0:hh\\:mm\\:ss}", TimeSpan.FromSeconds(totalSeconds).Duration());
             OnPropertyChanged();
        }

        public void Hint60()
        {
            totalSeconds += 60;
        }

        public void getTime(int seconds, String timeLapse)
        {

           totalSeconds = seconds;
           TimeLapse = timeLapse;
            Time();


        }

    }

    }

