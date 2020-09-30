using Enigma.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Enigma.ViewModels
{
    class GameOverViewModel: BaseViewModel
    {
        public string GameOverText { get; set; }
        public ICommand GoToBackStoryCommand { get; set; }

        public GameOverViewModel()
        {
            GoToBackStoryCommand = new RelayCommand(GoToBackStory);
            GameOverText = $"You let us down {MyPlayer.Player_name}, apparently you´re not as god as we thought you were...\n The killer has killed more people and left similar clues at the crime scenes. We will hire a new detective and hunt this serial killer down, before he/she kills more people.";
        }

        #region Navigation

        public void GoToBackStory()
        {            
            var page = new BackStory();
            NavigationService.Navigate(page);
        }

        #endregion
    }
}
