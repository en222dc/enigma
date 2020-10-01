using Enigma.Animation;
using Enigma.ViewModels;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Enigma.Views
{
    public partial class HelpAndRulesPage : Page
    {
        public PageAnimation PageLoadAnimation { get; set; } = PageAnimation.FadeIn;

        public float SlideSeconds { get; set; } = 0.5f;
        public HelpAndRulesPage()
        {
            InitializeComponent();
            this.Loaded += HighScorePage_Loaded;
            DataContext = new HelpAndRulesViewModel();
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

                    await this.FadeIn(this.SlideSeconds * 2);

                    break;
            }
        }
    }
}
