using Enigma.ViewModels.Base;
using Enigma.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using System.Windows.Navigation;

namespace Enigma.ViewModels
{
    class PickPlayerViewModel : BaseViewModel
    {

      
        
          public ICommand CreateNewPlayerCommand { get; set; }
           public ICommand ChoosePlayerCommand { get; set; }

        public PickPlayerViewModel()
            {
                ChoosePlayerCommand = new RelayCommand(GoToBackStoryPageAndPickPlayer);
                CreateNewPlayerCommand = new RelayCommand(CreateNewPlayer);
        }


            public void GoToBackStoryPageAndPickPlayer()

            {
              var page = new BackStory();
               NavigationService.Navigate(page);

            }
        public void CreateNewPlayer()
        {
          

        }
        
          
        
        }
    }



