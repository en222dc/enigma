using Enigma.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Enigma.ViewModels
{
    class GameOverViewModel: BaseViewModel
    {
        #region Properties
        public string GameOverText { get; set; }
        public ICommand GoToBackStoryCommand { get; set; }
        #endregion

        #region Constructor
        public GameOverViewModel()
        {
            GoToBackStoryCommand = new RelayCommand(GoToBackStory);
            GameOverText = $"You really let us down {MyPlayer.Player_name}, apparently you´re not as good as we thought you were ...\nBecause of your incapability, the killer got away and continues to end peoples lives, leaving similar clues at the crime scenes. We do not enjoy this kind of mockery, and we do blame you. \nWe will hire a new detective and hunt this serial killer down, before he or she kills more people.";
        }
        #endregion

        #region Navigation
        public void GoToBackStory()
        {            
            var page = new BackStory();
            NavigationService.Navigate(page);
        }
        #endregion
    }
}
