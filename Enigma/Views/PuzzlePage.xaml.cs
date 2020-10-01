using Enigma.ViewModels.Base;
using System.Windows.Controls;

namespace Enigma.Views
{
    /// <summary>
    /// Interaction logic for PuzzlePage.xaml
    /// </summary>
    public partial class PuzzlePage : Page
    {
        public PuzzlePage(BaseViewModel PuzzelPageViewModel)
        {
            InitializeComponent();
            DataContext = PuzzelPageViewModel;
        }
    }
}
