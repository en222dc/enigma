using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Enigma.Views;
using Enigma.Models;
using System.Threading.Channels;
using System.Windows.Input;

    

namespace Enigma.ViewModels
{
    class SolvePuzzlePageViewModel
    {
        

        public SolvePuzzlePageViewModel()
        {
            char[] symbolArray = new char[4];
            IGameLogicSymbol symbol = new SymbolAlphabet();
            symbol.TranslateSuspectNameToArray(symbolArray);
        }
           

    }
}
