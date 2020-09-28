using Enigma.ViewModels.Base;
using System.Windows.Controls;

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
