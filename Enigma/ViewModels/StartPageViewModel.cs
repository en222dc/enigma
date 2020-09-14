using Enigma.ViewModels.Base;
using Enigma.Views;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.DirectoryServices.ActiveDirectory;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Input;
using System.Windows.Navigation;
using System.Windows.Threading;

namespace Enigma.ViewModels
{
    public class StartPageViewModel : BaseViewModel
    {

        private int totalSeconds = 0;
        public string TimeLapse { get; set; }

        private DispatcherTimer dispatcherTimer = null;


        private string buttonName;

        public string ButtonName
        {
            get { return buttonName; }
            set
            {
                buttonName = value;
                OnPropertyChanged();
            }
        }


        public void Time()
        {
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Tick += new EventHandler(Timer_Tick2);
        }


        private void Timer_Tick2(object state, EventArgs e)
        {
            totalSeconds++;
            TimeLapse = string.Format("{0:hh\\:mm\\:ss}", TimeSpan.FromSeconds(totalSeconds).Duration());
        }


        
        
        public ICommand PlayGameCommand { get; set;} 

        public StartPageViewModel()
        {
            PlayGameCommand = new RelayCommand(GoToPage);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void GoToPage()

        {
            string hei = "Hei";
            ButtonName = hei;  
          //  var model = new BackStoryViewModel();
          //  var page = new BackStory(model);
           // NavigationService.Navigate(page);

         
             
        }
        protected void OnPropertyChanged ([CallerMemberName] string name = null)
        {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
           
        }

        }
}
