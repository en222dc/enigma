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
        //public ObservableCollection<Suspect> ListOfSuspects { get; set; }
        protected static NavigationService NavigationService { get; } = (Application.Current.MainWindow as MainWindow).MainFrame.NavigationService; 
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {


            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        }
    }
}
    

