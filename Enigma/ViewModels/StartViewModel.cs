using Enigma.ViewModels.Base;
using Enigma.Views;
using System.Windows.Input;

namespace Enigma.ViewModels
{
    public class StartViewModel : BaseViewModel
    {
        #region Properties
        public ICommand PlayGameCommand { get; set;}
        #endregion

        #region Constructor
        public StartViewModel()
        {            
            PlayGameCommand = new RelayCommand(ChangePage);
            MyPlayer = null;
            ExitButtonContent = "Quit Game";
            MyWindow.MenuFrame.Content = new MenuPage();
        }
        #endregion

        #region Navigation
        public void ChangePage()
        {
            MyWindow.MainFrame.Content = new PickPlayerPage();
        }
        #endregion
    }
}
