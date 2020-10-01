using Enigma.Animation;
using Enigma.ViewModels;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Enigma.Views
{
    /// <summary>
    /// Interaction logic for StartPage.xaml
    /// </summary>
    public partial class StartPage : Page
    {
        public PageAnimation PageLoadAnimation { get; set; } = PageAnimation.SlideAndFadeInFromRight;
        public float SlideSeconds { get; set; } = 0.8f;

        public StartPage()
        {
            InitializeComponent();
            this.Loaded += StartPage_Loaded;
            DataContext = new StartViewModel();
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
    }
}
