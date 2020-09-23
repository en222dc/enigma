using Enigma.Models;
using Enigma.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace Enigma.ViewModels
{
    class SuspectsPageModel : BaseViewModel
    {
        #region Properties
        public BitmapImage KillerPortrait { get; set; }
        public static string KillerName { get; set; }

        

        public string Summary { get; set; } =$"Well done {MyPlayer}, you have done an excellent job to find and charge the killer! {MyMurderer.Name} is a notorious serial killer and the question was not if, but when, {MyMurderer.Name} would strike again! Thanks to you, our citizens can once again feel safe. We knew we did the right thing to put our faith in you {MyPlayer}, thank you!";
        #endregion


        #region Methods
        private void ShowKiller()
        {
            KillerPortrait = MyMurderer.Portrait;
            KillerName = MyMurderer.Name;
        }
        #endregion

        #region Constructor
        public SuspectsPageModel()
        {
            ShowKiller();
        }
        #endregion 

       
        public void ChangePage()
        {

        }


       

    }
}
