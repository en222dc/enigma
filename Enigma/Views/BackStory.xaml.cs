using System;
using System.Collections.Generic;
using System.Text;
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
    /// Interaction logic for BackStory.xaml
    /// </summary>
    public partial class BackStory : Page
    {
        public BackStory()
        {
            InitializeComponent();
            DataContext = new BackStoryViewModel();
         }

   





    }
}
