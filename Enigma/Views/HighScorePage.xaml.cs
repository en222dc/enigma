﻿using Enigma.Models.Repositories;
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
    /// Interaction logic for HighScoreEndPage.xaml
    /// </summary>
    public partial class HighScorePage : Page
    {
        public HighScorePage()
        {
            InitializeComponent();
            DataContext = new HighscoreViewModel();

           // lstBoHighscoreName.ItemsSource = Repository.GetHighscores();

          //  lstBoTopPlayer.ItemsSource = Repository.GetTopPlayers();


        }
    }
}
