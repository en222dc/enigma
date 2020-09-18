using Enigma.ViewModels;
using Enigma.ViewModels.Base;
using Enigma.Views.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Enigma.Views
{
    /// <summary>
    /// Interaction logic for SolvePuzzlePage.xaml
    /// </summary>
    public partial class SolvePuzzlePage : Page
    {
        public SolvePuzzlePage(BaseViewModel SolvePuzzlePageViewModel)
        {
            InitializeComponent();
            DataContext = SolvePuzzlePageViewModel;
        }


    }
}
