using Enigma.Animation;
using Enigma.ViewModels;
using Enigma.ViewModels.Base;
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

namespace Enigma.Views
{
    /// <summary>
    /// Interaction logic for StartPage.xaml
    /// </summary>
    public partial class StartPage : Page
    {

        public PageAnimation PageLoadAnimation { get; set; } = PageAnimation.SlideAndFadeInFromRight;

        public PageAnimation PageUnloadAnimation { get; set; } = PageAnimation.SlideAndFadeOutToLeft;

        public float SlideSeconds { get; set; } = 0.8f;

        public StartPage()
        {
            InitializeComponent();
            this.Loaded += StartPage_Loaded;
            DataContext = new StartPageViewModel();
        }

        private async void StartPage_Loaded(object sender, RoutedEventArgs e)
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
                case PageAnimation.SlideAndFadeInFromRight:

                    await this.SlideAndFadeInFromRight(this.SlideSeconds * 4);

                    break;
            }
        }

        public async Task AnimateOut()
        {
            if (this.PageUnloadAnimation == PageAnimation.None)
            {
                return;
            }

            switch (this.PageUnloadAnimation)
            {
                case PageAnimation.SlideAndFadeOutToLeft:

                    await this.SlideAndFadeOutToLeft(this.SlideSeconds * 4);

                    break;
            }
        }




    }
}
