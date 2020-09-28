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
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Navigation;
using System.Windows.Threading;

namespace Enigma.Views
{

    public class StartPageViewModel : BaseViewModel
    {

        #region Properties

        public string ButtonName { get; set; } = "Play Game";

        #endregion


        #region

        public ICommand PlayGameCommand { get; set;}
     

        #endregion


        #region Konstruktor

        public StartPageViewModel()
        {            
            PlayGameCommand = new RelayCommand(ChangePage);                         
        }

        #endregion

        #region Metoder

      

        public void ChangePage()
        {
            
            MyWindow.MainFrame.Content = new PickPlayer();
        }





        #endregion





    }
}
