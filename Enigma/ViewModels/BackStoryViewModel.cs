using Enigma.Models;
using Enigma.ViewModels.Base;
using Enigma.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;

namespace Enigma.ViewModels
{
   public class BackStoryViewModel : BaseViewModel
    {
        public ICommand GoToPageCommand { get; set; }
       
        public BackStoryViewModel()
        {
           
            GoToPageCommand = new RelayCommand(GoToPuzzlePage);
        }

       

        public void GoToPuzzlePage()
        {
         var model = new PuzzlePageViewModel();
         var page = new PuzzlePage();
          NavigationService.Navigate(page);



        }
       

    }
}
