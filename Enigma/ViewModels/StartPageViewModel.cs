using Enigma.Models;
using Enigma.Models.Repositories;
using Enigma.ViewModels.Base;
using Enigma.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        #region Properties

        public ICommand PlayGameCommand { get; set;}

        #endregion

        #region Construct
        public StartPageViewModel()
        {            
            PlayGameCommand = new RelayCommand(ChangePage);
            ExitButtonContent = "Quit Game";
            MyWindow.MenuFrame.Content = new MenuPage();
        }

        #endregion

        #region Methods
        public void ChangePage()
        {
            MyWindow.MainFrame.Content = new PickPlayer();
        }

        #endregion
    }
}
