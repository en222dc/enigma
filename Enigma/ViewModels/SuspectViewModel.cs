using Enigma.ViewModels.Base;
using Enigma.Views;
using System;
using System.Windows.Media.Imaging;

namespace Enigma.ViewModels
{
    class SuspectViewModel : BaseViewModel
    {
        #region Properties
        public BitmapImage KillerPortrait { get; set; }
        public string KillerName { get; set; }
        public string Summary { get; set; } = $"Well done {MyPlayer.Player_name}, you have done an excellent job to find and charge the killer! {MyKiller.Name} is a notorious serial killer and the question was not if, but when, {MyKiller.Name} would strike again! Thanks to you, our citizens can once again feel safe. We knew we did the right thing to put our faith in you, {MyPlayer.Player_name}, thank you!";
        #endregion

        #region Constructor
        public SuspectViewModel(int time)
        {
            ShowKiller();
            TimeLapse = "You used: " + time.ToString() + " seconds to catch the killer";
            TimeStop();
            ExitButtonContent = "Exit to Start Page";
            MyWindow.MenuFrame.Content = new MenuPage();
        }
        #endregion 

        #region Methods
        private void ShowKiller()
        {
            string portraitPath = MyKiller.Portrait.UriSource.ToString();
            BitmapImage glowIcon = new BitmapImage();
            glowIcon.BeginInit();
            glowIcon.UriSource = new Uri(portraitPath, UriKind.Relative);
            glowIcon.EndInit();
            KillerPortrait = glowIcon;
            KillerName = MyKiller.Name;
        }
        #endregion
    }
}
