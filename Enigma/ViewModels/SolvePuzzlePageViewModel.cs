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
    public class SolvePuzzlePageViewModel
    {

        public SolvePuzzlePageViewModel()
        {
            IGameLogicSymbol symbol = new SymbolAlphabet();
            char[] symbolArray = new char[4];
            symbol.TranslateSuspectNameToArray(symbolArray);
        }
           

    }
}
