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
        public BitmapImage KillerPortrait { get; set; }
        public string KillerName { get; set; }

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

        public SuspectsPageModel(ObservableCollection<Suspect> SuspectList)
        {
            ShowKiller(SuspectList);
        }

        
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
