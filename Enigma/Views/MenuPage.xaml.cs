using Enigma.ViewModels;
using System.Windows.Controls;

namespace Enigma.Views
{
    /// <summary>
    /// Interaction logic for MenuPage.xaml
    /// </summary>
    public partial class MenuPage : Page
    {
        public MenuPage()
        {
            InitializeComponent();
            DataContext = new MenuViewModel();
        }
    }
}
