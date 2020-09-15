using Enigma.Models;
using Enigma.Models.Repositories;
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

namespace Enigma.ViewModels
{
    /// <summary>
    /// Interaction logic for PlayerRegistration.xaml
    /// </summary>
    public partial class PlayerRegistration : Page
    {
        public PlayerRegistration()
        {
            InitializeComponent();
        }

        private void btnAddPlayer_Click(object sender, RoutedEventArgs e)
        {
            
            var player = new Player
            {
                Player_name = txtPlayerName.Text
            };

            Repository.AddNewPlayerToDb(player);
            

            //PlayerRegistrationViewModel.AddPlayer();

            NavigationService.Navigate(new Uri("/Views/BackStory.xaml", UriKind.Relative));
        }
    }
}
