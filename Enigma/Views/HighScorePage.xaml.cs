﻿using Enigma.Animation;
using Enigma.Models.Repositories;
using System;
using System.Collections.Generic;
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

namespace Enigma.ViewModels
{
    /// <summary>
    /// Interaction logic for HighScoreEndPage.xaml
    /// </summary>
    public partial class HighScorePage : Page
    {
        public PageAnimation PageLoadAnimation { get; set; } = PageAnimation.FadeIn;

        public float SlideSeconds { get; set; } = 0.5f;
        public HighScorePage()
        {
            InitializeComponent();
            this.Loaded += HighScorePage_Loaded;
            DataContext = new HighscoreViewModel();
        }

        private async void HighScorePage_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            await AnimateIn();
        }

        public async Task AnimateIn()
        {
            if (this.PageLoadAnimation == PageAnimation.None)
            {
                return;
            }

            switch (this.PageLoadAnimation)
            {
                case PageAnimation.FadeIn:

                    await this.FadeIn (this.SlideSeconds * 2);

                    break;
            }
        }
       


    }
}
