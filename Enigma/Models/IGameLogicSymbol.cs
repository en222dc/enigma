using System;
using System.Collections.Generic;
using System.Text;

namespace Enigma
{
    interface IGameLogicSymbol
    {
        public string Hint { get; set; }

        public string SuspectName { get; set; }

        public static Dictionary<char, char> SymbolMap { get; set; }

        public char[] TranslateSuspectNameToArray(char[] symbolArray);
    }
}
