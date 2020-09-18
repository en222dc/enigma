using Enigma.Models;
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
        List<Suspect> ListOfSuspects = new List<Suspect>();
        List<Suspect> Killer = new List<Suspect>();

        public ICommand PlayGameCommand { get; set; }

        public SuspectsPageModel()
        {
            GetSuspects getSuspects = new GetSuspects();
            getSuspects.GetAllSuspects(ListOfSuspects);
            KillerCreation killerCreation = new KillerCreation();
            killerCreation.GetKiller(ListOfSuspects, Killer);
            PlayGameCommand = new RelayCommand(GoToPageCommand);
        }

        
        public void ChangePage()
        {
           // var model = new PuzzlePageViewModel(Killer);
            //var page = new PuzzlePageViewModel(model);
           // NavigationService.Navigate(model);
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
