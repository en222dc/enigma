using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace Enigma.Models
{
    class SymbolAlphabet
    {
        public string Hint { get; set; } = "Use the solve-sheet to translate the symbols to get the name of the killer"; // Potentiell hint för sista puzzlet

        public string SuspectName { get; set; } = "Adam"; // Hårdkodar ett SuspectName för testning

        public char[] SuspectArray { get; set; } = new char[4]; // Skapar en array så att spelet kan skjuta ut en karaktär för varje klarat puzzel, mest för testning mot ViewModel och View. 

        public static Dictionary<char, char> SymbolMap { get; set; } = new Dictionary<char, char> // Skapar en mappning av vilka symboler som är kopplade till respektive bokstav
        {

                { 'क', 'a' },
                { 'ख', 'b' },
                { 'ग', 'c' },
                { 'घ', 'd' },
                { 'ङ', 'e' },
                { 'च', 'f' },
                { 'छ', 'g' },
                { 'ज', 'h' },
                { 'झ', 'i' },
                { 'ञ', 'j' },
                { 'ट', 'k' },
                { 'ठ', 'l' },
                { 'ड', 'm' },
                { 'ढ', 'n' },
                { 'ण', 'o'},
                { 'त', 'p' },
                { 'थ', 'q' },
                { 'द', 'r' },
                { 'ध', 's' },
                { 'न', 't' },
                { 'प', 'u' },
                { 'फ', 'v' },
                { 'ब', 'w' },
                { 'भ', 'x' },
                { 'म', 'y' },
                { 'य', 'z' },

        };

        //public string TranslateSuspectName(string suspect)
        //{
        //    suspect = SuspectName.ToLower();

        //    foreach (KeyValuePair<char, char> pair in SymbolMap)
        //    {
        //        suspect = suspect.Replace(pair.Value, pair.Key);
        //    }

        //    return suspect;
        //}

        public char[] TranslateSuspectNameToArray (string suspect) // Metod som översätter latinska alfabetet till nepaliska och sätter in symbolerna i min array
        {
            suspect = SuspectName.ToLower();

            foreach (KeyValuePair<char, char> pair in SymbolMap)
            {
                suspect = suspect.Replace(pair.Value, pair.Key);
            }

            for (int i = 0; i < SuspectArray.Length; i++)
            {
                foreach (char c in suspect)
                {
                    SuspectArray[i] = c;
                    i++;
                }
            }

            return SuspectArray;

        }


        //public char[] GetSuspectArray ()
        //{
        //    for (int i = 0; i < SuspectArray.Length; i++)
        //    {
        //        foreach (char c in SuspectName.ToLower())
        //        {
        //            SuspectArray[i] = c;
        //            i++;
        //        }
        //    }

        //    return SuspectArray;
        //}
    }
}
