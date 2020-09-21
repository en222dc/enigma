using Enigma.Models.Repositories;
using Enigma.ViewModels;
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

namespace Enigma.Views
{
    /// <summary>
    /// Interaction logic for PickPlayer.xaml
    /// </summary>
    public partial class PickPlayer : Page
    {
        public PickPlayer()
        {
            InitializeComponent();
            DataContext = new PickPlayerViewModel();

            
        }
    }
}
