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

namespace Enigma.ViewModels
{
    public class StartPageViewModel : INotifyPropertyChanged
    {

        int counter = 0;
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

        
        public ICommand PlayGameCommand { get; set;} 

        public StartPageViewModel()
        {
            PlayGameCommand = new RelayCommand(PlayGame);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void PlayGame()

        {
            DateTime time = new DateTime();
            counter = time.Second;


            
            //Stopwatch stopWatch = new Stopwatch();
           // ButtonName = stopWatch.ToString();
          // ButtonName  = Timer.ActiveCount.ToString();
          //  counter++;  
         ButtonName = counter.ToString();

             
        }
        protected void OnPropertyChanged ([CallerMemberName] string name = null)
        {
            
           
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
           
        }

        }
}
