using System;
using System.Collections.Generic;
using System.Text;

namespace Enigma
{
    interface IGameLogicSymbol
    {
        public char[] TranslateKillerName(char[] symbolArray);
    }
}
