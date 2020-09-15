using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Navigation;
using System.Windows.Threading;

namespace Enigma.ViewModels.Base
{
  public  class BaseViewModel : INotifyPropertyChanged
    {

        protected static NavigationService NavigationService { get; } = (Application.Current.MainWindow as MainWindow).MainFrame.NavigationService; // har endret mainframe til mainframe
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
    

