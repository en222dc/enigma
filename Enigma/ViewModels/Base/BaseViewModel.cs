using Enigma.Models;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Navigation;
using System.Windows.Threading;

namespace Enigma.ViewModels.Base
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        #region Properties
        protected static NavigationService NavigationService { get; } = (Application.Current.MainWindow as MainWindow).MainFrame.NavigationService;
        public static ObservableCollection<Suspect> ListOfSuspects { get; set; } = new ObservableCollection<Suspect>();
        public MainWindow MyWindow { get; } = (MainWindow)Application.Current.MainWindow;
        public static string ExitButtonContent { get; set; }
        public static Player MyPlayer { get; set; }
        public static Suspect MyKiller { get; set; }
        public static int MyHighScore { get; set; }
        public string TimeLapse { get; set; }
        #endregion

        public DispatcherTimer dispatcherTimer = new DispatcherTimer();
        public int totalSeconds = 0;
        public int hintPenaltySixtySec = 60;

        #region Methods
        public void TimeStart()
        {
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Tick += new EventHandler(TimerTicks);
            dispatcherTimer.Start();
        }

        public void TimeStop()
        {
            dispatcherTimer.Stop();
        }
        public void PenaltyTimeForUsedHint()
        {
            totalSeconds += hintPenaltySixtySec;
        }

        private void TimerTicks(object state, EventArgs e)
        {
            totalSeconds++;
            TimeLapse = string.Format("{0:mm\\:ss}", TimeSpan.FromSeconds(totalSeconds).Duration());
            OnPropertyChanged();
        }
        #endregion

        #region EventHandler
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        #endregion
    }
}


