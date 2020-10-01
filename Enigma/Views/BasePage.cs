using Enigma.Animation;
using System.Windows.Controls;
using System.Windows;
using System.Threading.Tasks;
using Enigma.ViewModels.Base;

namespace Enigma.Views
{
    public class BasePage<VM> : Page
        where VM: BaseViewModel, new()
    {
        #region Private Member
        private VM myViewModel;
        #endregion

        #region Public Properties
        public PageAnimation PageLoadAnimation { get; set; } = PageAnimation.SlideAndFadeInFromRight;

        public float SlideSeconds { get; set; } = 0.8f;

        public VM ViewModel
        {
            get { return myViewModel; }
            set
            {
                if (myViewModel == value)
                    return;

                myViewModel = value;

                this.DataContext = myViewModel;
            }
        }
           


        #endregion

        #region Constructor
        public BasePage()
        {
            this.Loaded += BasePage_Loaded;
            if (this.PageLoadAnimation != PageAnimation.None)
            {
                this.Visibility = Visibility.Collapsed;
            }

            this.ViewModel = new VM();
        }
        #endregion

        #region Animation Load / Unload
        private async void BasePage_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            await AnimateIn();
        }
        #endregion

        #region Animation Tasks
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

        #endregion 
    }
}
