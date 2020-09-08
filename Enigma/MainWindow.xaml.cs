using Enigma.Models;
using Enigma.Models.Repositories;
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
            var suspectPage = new SuspectsPage();

            MainFrame.Content = suspectPage;
        }

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    string playerName = txtPlayerName.Text;
        //    Player newPlayer = new Player(playerName);

        //    newPlayer = PlayerRepository.AddNewPlayerToDb(newPlayer);
        //}
    }
}
