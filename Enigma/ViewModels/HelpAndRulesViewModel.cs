using Enigma.ViewModels.Base;
using Enigma.Views;
using System.Windows.Input;

namespace Enigma.ViewModels
{
    class HelpAndRulesViewModel : BaseViewModel
    {
        #region Properties
        public ICommand GoToPageCommand { get; set; }
        #endregion

        #region Constructor
        public HelpAndRulesViewModel()
        {
            GoToPageCommand = new RelayCommand(GoToStartPage);
            ExitButtonContent = "Exit to Start Page";
            MyWindow.MenuFrame.Content = new MenuPage();
        }
        #endregion

        #region Navigation
        public void GoToStartPage()
        {
            MyWindow.MainFrame.Content = new StartPage();
        }
        #endregion
    }
}
