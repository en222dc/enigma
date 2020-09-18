using System;
using System.Collections.Generic;
using System.Text;

namespace Enigma.Models
{
    public class KillerTranslation: SymbolAlphabet
    {
        // Klassens syfte är att översätta mördarens namn till symboler. Använder sig av KillerCreation och SymbolAlphabet

        KillerCreation killercreator = new KillerCreation();

        public char[] TranslateKillerName(Dictionary<char, char>symbolArray, string killerName, char[]encryptedKillerName) // Metod som översätter latinska alfabetet till nepaliska och sätter in symbolerna i min array
        {
           

            foreach (KeyValuePair<char, char> pair in SymbolMap)
            {
                killerName = killerName.ToLower().Replace(pair.Value, pair.Key);
            }

            for (int i = 0; i < killerName.Length; i++)
            {
                foreach (char c in killerName)
                {
                    encryptedKillerName[i] = c;
                    i++;
                }
            }

            return encryptedKillerName;

        }

    }
}
