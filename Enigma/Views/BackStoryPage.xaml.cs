using Enigma.Animation;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Enigma.ViewModels
{
    /// <summary>
    /// Interaction logic for BackStory.xaml
    /// </summary>
    public partial class BackStoryPage : Page
    {
        public PageAnimation PageLoadAnimation { get; set; } = PageAnimation.SlideAndFadeInFromRight;

        public float SlideSeconds { get; set; } = 0.5f;
        public BackStoryPage()
        {
            InitializeComponent();
            this.Loaded += BackStory_Loaded;
            DataContext = new BackStoryViewModel();
        }

        private async void BackStory_Loaded(object sender, System.Windows.RoutedEventArgs e)
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
