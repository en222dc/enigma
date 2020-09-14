using Enigma.ViewModels.Base;
using Enigma.Views;
using Enigma.Views.Base;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;
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
    /// Interaction logic for StartPage.xaml
    /// </summary>
    public partial class StartPage 
    {
        public StartPage()
        {
            InitializeComponent();
            DataContext = new StartPageViewModel();
        }
      

        private void btnNewPlayer_Click(object sender, RoutedEventArgs e)
        {

           // NavigationService.Navigate(new Uri("/Views/PlayerRegistration.xaml", UriKind.Relative)); // kilde https://www.c-sharpcorner.com/UploadFile/e3d1d8/data-passing-from-one-page-to-another-in-xaml/
  
        }

       
    }
    }

