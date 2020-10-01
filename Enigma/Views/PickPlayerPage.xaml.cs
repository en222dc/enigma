using Enigma.Animation;
using Enigma.ViewModels;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Enigma.Views
{
    /// <summary>
    /// Interaction logic for PickPlayer.xaml
    /// </summary>
    /// 
    public partial class PickPlayerPage : Page
    {
     public PageAnimation PageLoadAnimation { get; set; } = PageAnimation.SlideAndFadeInFromRight;

     public float SlideSeconds { get; set; } = 0.5f;
        public PickPlayerPage()
        {
            InitializeComponent();
            this.Loaded += PickPlayerPage_Loaded;
            if (this.PageLoadAnimation != PageAnimation.None)
            {
                this.Visibility = Visibility.Collapsed;
            }
            DataContext = new PickPlayerViewModel();
        }

        private async void PickPlayerPage_Loaded(object sender, System.Windows.RoutedEventArgs e)
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
