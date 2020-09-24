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

        public static ObservableCollection<Suspect> ListOfSuspects { get; set; } =new ObservableCollection<Suspect>();
        public static Player MyPlayerInGame { get; set; }
        public static Player MyPlayer { get; set; }
        public MainWindow MyWindow { get; } = (MainWindow)Application.Current.MainWindow;
        public static Suspect MyMurderer { get; set; }
        public static int MyHighScoreInGame { get; set; }
        public static string GetPicture { get; set; }
        protected static NavigationService NavigationService { get; } = (Application.Current.MainWindow as MainWindow).MainFrame.NavigationService;


        #endregion

        #region Constructor
        public BaseViewModel()
        {
            GetMurderer();
            GetPicture = @"\Assets\Images\image3.jpg";
           
        }

        #endregion

        #region Methods

        private Suspect GetMurderer()
        {
            foreach (var suspect in ListOfSuspects)
            {
                if (suspect.IsKiller)
                {
                    MyMurderer = suspect;
                    return MyMurderer;
                }
            }
            return MyMurderer;
        }

        #endregion




        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {


            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        }
    }
}
    

