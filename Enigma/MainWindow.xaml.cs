using Enigma.Models;
using Enigma.Models.Repositories;
using Enigma.ViewModels;
using Enigma.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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

            //var startPage = new StartPage();
            //var menuPage = new MenuPage();

            ////Ta bort sen
            //var pickPlayerPage = new PickPlayer();


            //MainFrame.Content = pickPlayerPage;
            //MenuFrame.Content = menuPage;


            //DataContext = new MainViewModel();

            var startPage = new StartPage();
            var menuPage = new MenuPage();

            MainFrame.Content = startPage;
            MenuFrame.Content = menuPage;

            DataContext = new MainViewModel();
        }
    }
}
