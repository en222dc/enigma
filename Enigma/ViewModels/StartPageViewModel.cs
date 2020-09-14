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
    public class StartPageViewModel : BaseViewModel
    {

        /*
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
        */
        
        public ICommand PlayGameCommand { get; set;} 

        public StartPageViewModel()
        {
            PlayGameCommand = new RelayCommand(GoToPage);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void GoToPage()

        {
              
            var model = new BackStoryViewModel();
            var page = new BackStory(model);
            NavigationService.Navigate(page);

         
             
        }
        protected void OnPropertyChanged ([CallerMemberName] string name = null)
        {
            
           
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
           
        }

        }
}
