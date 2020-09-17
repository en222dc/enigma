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

        public string ButtonName { get; set; } = "Play Game";



        public ICommand PlayGameCommand { get; set;}
        public ICommand CreatePlayerCommand { get; set; }

        public StartPageViewModel()
        {
            PlayGameCommand = new RelayCommand(GoToPickPlayerPage);
            CreatePlayerCommand = new RelayCommand(GoToCreatePlayerPage); 

        }

       // public event PropertyChangedEventHandler PropertyChanged;

        public void GoToPickPlayerPage()

        {
            var model = new PlayerRegistrationViewModel();
            var page = new PlayerRegistration();
            NavigationService.Navigate(page);
             
        }

        public void GoToCreatePlayerPage()
        {
            var model = new PlayerRegistrationViewModel();
            var page = new PlayerRegistration();
            NavigationService.Navigate(page);
        }


        /*
        protected void OnPropertyChanged ([CallerMemberName] string name = null)
        {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
           
        }
        */
        }
}
