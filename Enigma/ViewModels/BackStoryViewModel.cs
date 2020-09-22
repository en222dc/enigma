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

        public string BackStoryText { get; set; } 
        public ICommand GoToPageCommand { get; set; }
       
        public BackStoryViewModel()
        {
           
            GoToPageCommand = new RelayCommand(GoToPuzzlePage);
            BackStoryText = "The president of Russia has assigned you to solve the mysterious murder of his wife Katja.The police has apprehended 4 suspects.The only clue at your disposal" +
                " is a puzzle left by the killer with the note Solve me for a clue.Will You be the player who finds the killer the fastest ? ";
        }

       

        public void GoToPuzzlePage()
        {
         var model = new PuzzlePageViewModel();
         var page = new PuzzlePage();
          NavigationService.Navigate(page);



        }
       

    }
}
