using Enigma.ViewModels.Base;
using Enigma.Views;
using System.ComponentModel;
using System.DirectoryServices.ActiveDirectory;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Windows.Navigation;

namespace Enigma.ViewModels
{
    public class StartPageViewModel : INotifyPropertyChanged
    {


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
           
            // PickPlayer pickPlayerPage =  new PickPlayer();
           //  MainWindow.ContentProperty = new PickPlayerPage();
            // startPage.Content = new PickPlayer();


          //  ButtonName = "Play!";
             
        }
        protected void OnPropertyChanged ([CallerMemberName] string name = null)
        {
            
           
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
           
        }

        }
}
