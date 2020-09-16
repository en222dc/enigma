using System;
using System.Collections.Generic;
using System.Text;

namespace Enigma.Models
{
    public class KillerTranslation: SymbolAlphabet, IGameLogicSymbol
    {
        // Klassens syfte är att översätta mördarens namn till symboler. Använder sig av KillerCreation och SymbolAlphabet

        KillerCreation killercreator = new KillerCreation();

        public char[] TranslateKillerName (char [] symbolArray) // Metod som översätter latinska alfabetet till nepaliska och sätter in symbolerna i min array
        {
            string killer = killercreator.KillerName.ToLower();

            foreach (KeyValuePair<char, char> pair in SymbolMap)
            {
                killer = killer.Replace(pair.Value, pair.Key);
            }

            for (int i = 0; i < symbolArray.Length; i++)
            {
                foreach (char c in killer)
                {
                    symbolArray[i] = c;
                    i++;
                }
            }

            return symbolArray;

        }

    }
}
