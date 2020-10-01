using Enigma.Animation;
using Enigma.ViewModels;
using Enigma.ViewModels.Base;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;


namespace Enigma.Views
{
    /// <summary>
    /// Interaction logic for SuspectsPage.xaml
    /// </summary>
    public partial class SuspectPage : Page
    {
        public PageAnimation PageLoadAnimation { get; set; } = PageAnimation.SlideAndFadeInFromRight;

        public float SlideSeconds { get; set; } = 0.5f;

        public SuspectPage(BaseViewModel SuspectPageViewModel)
        {
            InitializeComponent();
            this.Loaded += SuspectsPage_Loaded;
            DataContext = SuspectPageViewModel;
        }

        private async void SuspectsPage_Loaded(object sender, System.Windows.RoutedEventArgs e)
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


    }
}
