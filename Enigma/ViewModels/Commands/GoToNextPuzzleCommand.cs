using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Enigma.ViewModels.Commands
{
    class GoToNextPuzzleCommand : ICommand
    {

       // public PuzzlePageViewModel PuzzlePageViewModel { get; set; }

        //public GoToNextPuzzleCommand(PuzzlePageViewModel puzzlePageViewModel)
        //{
        //    this.PuzzlePageViewModel = puzzlePageViewModel;
        //}

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            if (parameter!=null)
            {
                var s = parameter as string;
                if (string.IsNullOrEmpty(s))
                {
                    return false;
                }
                return true;
            }
            return false;
        }

        public void Execute(object parameter)
        {
            //this.PuzzlePageViewModel.CheckIfGuessIsCorrect(parameter as string);
        }
    }
}
