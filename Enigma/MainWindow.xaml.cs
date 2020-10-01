using Enigma.Views;
using System.Windows;

namespace Enigma
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var startPage = new StartPage();
            var menuPage = new MenuPage();

            MainFrame.Content = startPage;
            MenuFrame.Content = menuPage;
        }
    }
}
