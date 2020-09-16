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

      
        
            public ICommand CommandClick { get; set; }

            public PickPlayerViewModel()
            {
                CommandClick = new RelayCommand(GoToPuzzlePage);
            }



            public event PropertyChangedEventHandler PropertyChanged;

            public void GoToPuzzlePage()

            {
                var model = new PuzzlePageViewModel();
                var page = new PuzzlePage();

                NavigationService.Navigate(page);



            }
            protected void OnPropertyChanged([CallerMemberName] string name = null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

            }

        }
    }



