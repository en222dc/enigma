using Enigma.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;

namespace Enigma.Converters
{
    class GuessedNrConverter : IValueConverter
    {

        PuzzlePageViewModel PuzzlePageViewModel = new PuzzlePageViewModel();
       



        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            value = PuzzlePageViewModel.Guess;
            
            string v = (string)value;
            
            if (v==null)
            {
                return true;
            }
            else if (v!=null/*PuzzlePageViewModel.CheckIfGuessCorrect(v)*/)
            {
                return false;
            }
            return true;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int returnedValue;

            if (int.TryParse((string)value, out returnedValue))
            {
                return true;
            }

            throw new Exception("The text is not a number");
        }
    }
}
