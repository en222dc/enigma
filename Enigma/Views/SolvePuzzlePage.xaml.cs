using Enigma.Animation;
using Enigma.ViewModels.Base;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Enigma.Views
{
    /// <summary>
    /// Interaction logic for SolvePuzzlePage.xaml
    /// </summary>
    public partial class SolvePuzzlePage : Page
    {

        public PageAnimation PageLoadAnimation { get; set; } = PageAnimation.SlideAndFadeInFromRight;

        public float SlideSeconds { get; set; } = 0.8f;
        public SolvePuzzlePage(BaseViewModel SolvePuzzlePageViewModel)
        {
            InitializeComponent();
            this.Loaded += SolvePuzzlePage_Loaded;
            DataContext = SolvePuzzlePageViewModel;
        }

        private async void SolvePuzzlePage_Loaded(object sender, RoutedEventArgs e)
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
