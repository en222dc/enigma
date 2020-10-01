using System.Collections.Generic;

namespace Enigma.Models
{
    public class SymbolAlphabet
    {
        /// <summary>
        /// A dictionary that uses letters from the nepali alphabet and gives them the value of a letter from the latin alphabet.
        /// </summary>
        public static Dictionary<string, string> TranslateMySymbolsToLetters { get; set; } = new Dictionary<string, string> 
        {
                { "क", "a" },
                { "ख", "b" },
                { "ग", "c" },
                { "घ", "d" },
                { "ङ", "e" },
                { "च", "f" },
                { "छ", "g" },
                { "ज", "h" },
                { "झ", "i" },
                { "ञ", "j" },
                { "ट", "k" },
                { "ठ", "l" },
                { "ड", "m" },
                { "ढ", "n" },
                { "ण", "o"},
                { "त", "p" },
                { "थ", "q" },
                { "द", "r" },
                { "ध", "s" },
                { "न", "t" },
                { "प", "u" },
                { "फ", "v" },
                { "ब", "w" },
                { "भ", "x" },
                { "म", "y" },
                { "य", "z" },
        };
    }
}
