﻿using System;
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
    /// Interaction logic for PuzzlePage.xaml
    /// </summary>
    public partial class PuzzlePage : Page
    {
        public PuzzlePage()
        {
            InitializeComponent();
        }

        private void btnSolvePuzzle_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Views/SolvePuzzlePage.xaml", UriKind.Relative));
        }
    }
}
