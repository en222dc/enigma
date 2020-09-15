using System.Collections.ObjectModel;
using Enigma.Models;
using System.ComponentModel;

namespace Enigma.ViewModels
{
    public class SolvePuzzlePageViewModel: INotifyPropertyChanged
    {
        public ObservableCollection<char> SymbolArray { get; set; }

        public SolvePuzzlePageViewModel()
        {
            SymbolArray = new ObservableCollection<char>();
            char[] symbolarray = new char[4];
            IGameLogicSymbol symbols = new KillerTranslation();
            symbols.TranslateKillerName(symbolarray);

            foreach (char symbol in symbolarray)
            {
                SymbolArray.Add(symbol);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
