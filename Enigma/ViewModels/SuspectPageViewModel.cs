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
        public Image KillerPortrait { get; set; }
        public string KillerName { get; set; }
        #endregion

        #region Methods
        private void ShowKiller(ObservableCollection<Suspect> SuspectList)
        {
            foreach (var suspect in SuspectList)
            {
                if (suspect.IsKiller == true)
                {
                    KillerPortrait = suspect.Portrait;
                    KillerName = suspect.Name;
                }
            }
        }
        #endregion

        #region Constructor
        public SuspectsPageModel(ObservableCollection<Suspect> SuspectList)
        {
            ShowKiller(SuspectList);
        }
        #endregion 


        public void ChangePage()
        {

        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        }

    }
}
