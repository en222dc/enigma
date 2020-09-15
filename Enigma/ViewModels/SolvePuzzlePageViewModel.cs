using System.Collections.ObjectModel;
using Enigma.Models;
using System.ComponentModel;

namespace Enigma.ViewModels
{
    public class SolvePuzzlePageViewModel: INotifyPropertyChanged
    {
        private ObservableCollection<char> _symbolArray;
        public ObservableCollection<char> SymbolArray
        {
            get { return _symbolArray; }
            set
            {
                if (value != _symbolArray)
                {
                    _symbolArray = value;
                    OnPropertyChanged("SymbolArray");
                }
            }
        }
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public SolvePuzzlePageViewModel()
        {
            SymbolArray = new ObservableCollection<char>();
            char[] symbolarray = new char[4];
            IGameLogicSymbol symbols = new SymbolAlphabet();
            symbols.TranslateSuspectNameToArray(symbolarray);

            foreach (char symbol in symbolarray)
            {
                SymbolArray.Add(symbol);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
