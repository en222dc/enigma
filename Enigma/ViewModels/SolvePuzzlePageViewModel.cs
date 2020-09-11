using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Enigma.Views;
using Enigma.Models;
using System.Threading.Channels;
using System.Windows.Input;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Enigma.ViewModels
{
    public class SolvePuzzlePageViewModel
    {


        public char[] SymbolArray { get; set; }

        public SolvePuzzlePageViewModel()
        {
            IGameLogicSymbol symbol = new SymbolAlphabet();
            SymbolArray = new char[4];
            symbol.TranslateSuspectNameToArray(SymbolArray);
        }

    }
}
