using Enigma.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;

namespace Enigma.ViewModels
{
    class SuspectsPageModel : BaseViewModel
    {

        public ICommand PlayGameCommand { get; set; }

        public SuspectsPageModel()
        {
            PlayGameCommand = new RelayCommand(GoToPageCommand);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void GoToPageCommand()

        {
             var model = new BackStoryViewModel();
            var page = new BackStory();
        NavigationService.Navigate(page);



        }
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {


            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        }

    }
}
