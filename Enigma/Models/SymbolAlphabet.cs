using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using Enigma.ViewModels;
using Enigma.Models;

namespace Enigma.Models
{
    public class SymbolAlphabet
    {
        public string Hint { get; set; } = "Use the solve-sheet to translate the symbols to get the name of the killer"; // Potentiell hint för sista puzzlet

        public static Dictionary<string, string> TranslateMySymbolsToLetters { get; set; } = new Dictionary<string, string> // Skapar en mappning av vilka symboler som är kopplade till respektive bokstav
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
