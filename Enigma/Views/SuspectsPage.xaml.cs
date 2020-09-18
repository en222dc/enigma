﻿using Enigma.ViewModels.Base;
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
    /// Interaction logic for SuspectsPage.xaml
    /// </summary>
    public partial class SuspectsPage : Page
    {
        public SuspectsPage(BaseViewModel SuspectPageModel)
        {
            InitializeComponent();
        }

        private void btnGoToPuzzle_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Views/PuzzlePage.xaml", UriKind.Relative));
        }
    }
}
