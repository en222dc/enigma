using Enigma.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Navigation;
using System.Windows.Threading;

namespace Enigma.ViewModels.Base
{
  public class BaseViewModel : INotifyPropertyChanged
    {
        #region Properties
        public static string ExitButtonContent { get; set; }
        public static ObservableCollection<Suspect> ListOfSuspects { get; set; } =new ObservableCollection<Suspect>();
        public static Player MyPlayer { get; set; }
        public MainWindow MyWindow { get; } = (MainWindow)Application.Current.MainWindow;
        public static Suspect MyKiller { get; set; }
        public static int MyHighScore { get; set; }
        public static string GetPicture { get; set; }
        public string TimeLapse { get; set; }
        protected static NavigationService NavigationService { get; } = (Application.Current.MainWindow as MainWindow).MainFrame.NavigationService;

        
        public int totalSeconds = 0;
        public DispatcherTimer dispatcherTimer = new DispatcherTimer();


        #endregion

        #region Constructor
        public BaseViewModel()
        {
            WhoIsTheKiller();
            GetPicture = @"\Assets\Images\image3.jpg";
           
        }

        #endregion

        #region Methods

        private Suspect WhoIsTheKiller()
        {
            foreach (var suspect in ListOfSuspects)
            {
                if (suspect.IsKiller)
                {
                    MyKiller = suspect;
                }
            }
            return MyKiller;
        }

        #endregion

        #region Timer
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
        public void Hint60()
        {
            totalSeconds += 60;
        }

        private void TimerTicks(object state, EventArgs e)
        {
            totalSeconds++;
            TimeLapse = string.Format("{0:mm\\:ss}", TimeSpan.FromSeconds(totalSeconds).Duration());
            OnPropertyChanged();
        }

        #endregion


        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
    

