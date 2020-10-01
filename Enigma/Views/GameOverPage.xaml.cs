using Enigma.Animation;
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
    /// Interaction logic for GameOverPage.xaml
    /// </summary>
    public partial class GameOverPage : Page
    {
        public PageAnimation PageLoadAnimation { get; set; } = PageAnimation.SlideAndFadeInFromRight;

        public float SlideSeconds { get; set; } = 0.5f;
        public GameOverPage(BaseViewModel GameOverViewModel)
        {
            InitializeComponent();
            this.Loaded += GameOverPage_Loaded;
            DataContext = GameOverViewModel;
        }

        private async void GameOverPage_Loaded(object sender, System.Windows.RoutedEventArgs e)
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
