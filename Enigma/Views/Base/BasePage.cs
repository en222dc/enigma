using Enigma.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace Enigma.Views.Base
{
   public class BasePage<VM> : Page where VM : BaseViewModel, new()
    {
        private VM viewModel;

        public VM ViewModel
        {
            get => viewModel;
            set
            {
              
                if (viewModel == value)
                    return;
                viewModel = value;
                DataContext = viewModel;
            }
        }



        public BasePage() : base()
        {
            ViewModel = new VM();
        }

      
        public BasePage(VM specificViewModel = null) : base()
        {
            if (specificViewModel != null)
                ViewModel = specificViewModel;
        }

    }
}
