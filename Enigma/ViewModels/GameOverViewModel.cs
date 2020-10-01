using Enigma.ViewModels.Base;
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
            GameOverText = $"You really let us down {MyPlayer.Player_name}, apparently you´re not as good as we thought you were ...\nBecause of your incapability, the killer got away and continues to end peoples lives, leaving similar clues at the crime scenes. \n\nWe do not enjoy this kind of mockery, and we do blame you.";
        }
        #endregion

        #region Navigation
        public void GoToBackStory()
        {            
            var page = new BackStoryPage();
            NavigationService.Navigate(page);
        }
        #endregion
    }
}
