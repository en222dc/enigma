using Enigma.ViewModels;
using Enigma.ViewModels.Base;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Enigma.Views
{
    /// <summary>
    /// Interaction logic for SuspectsPage.xaml
    /// </summary>
    public partial class SuspectsPage : Page
    {

        public SuspectsPage(BaseViewModel SuspectPageModel)
        {
            InitializeComponent();
            DataContext = SuspectPageModel;
        }

        private void btnGoToPuzzle_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Views/PuzzlePage.xaml", UriKind.Relative));
        }
    }
}
