﻿using Enigma.Models;
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
    /// Interaction logic for PuzzlePage.xaml
    /// </summary>
    public partial class PuzzlePage : Page
    {
        public PuzzlePage()
        {
            InitializeComponent();
            DataContext = new PuzzlePageViewModel();
            //var puzzle = new Fibonacci();
            //var showFibonacci = new PuzzlePage();
            //int[] fibonacciArray = new int[5];
            //puzzle.GenerateRandomNr(fibonacciArray);
            // puzzle.GetRestOfNr(fibonacciArray);

        }
    }
}
