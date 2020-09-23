using System;
using System.Collections.Generic;
using System.Text; 
using System.Windows.Input;

namespace Enigma.ViewModels
{
  public class HelpAndRulesViewModel: BackStoryViewModel
    {
      public ICommand GoToStartPageCommand { get; set; }

      public HelpAndRulesViewModel()
        {
            GoToPageCommand = new RelayCommand(GoToStartPage);
        }


        public void GoToStartPage()
        {
            var page = new StartPage();
            NavigationService.Navigate(page);
        }

    }
}
