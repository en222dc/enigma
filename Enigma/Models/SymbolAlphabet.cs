using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using Enigma.ViewModels;
using Enigma.Models;

namespace Enigma.Models
{
    public class SymbolAlphabet : IGameLogicSymbol
    {
        public string Hint { get; set; } = "Use the solve-sheet to translate the symbols to get the name of the killer"; // Potentiell hint för sista puzzlet

        public string SuspectName { get; set; } = "Adam"; // Hårdkodar ett SuspectName för testning

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


        public char[] TranslateSuspectNameToArray (char[] symbolArray) // Metod som översätter latinska alfabetet till nepaliska och sätter in symbolerna i min array
        {
            string suspect = SuspectName.ToLower();

            foreach (KeyValuePair<char, char> pair in SymbolMap)
            {
                suspect = suspect.Replace(pair.Value, pair.Key);
            }

            for (int i = 0; i < symbolArray.Length; i++)
            {
                foreach (char c in suspect)
                {
                    symbolArray[i] = c;
                    i++;
                }
            }

            return symbolArray;

        }

        //public char ReturnFirstSymbol (char [] symbolArray)
        //{
        //    if (IsSolved == true)
        //    {
        //        return symbolArray[0];
        //    }
        //}

        //public char ReturnSecondSymbol (char[] symbolArray)
        //{
        //    if (IsSolved == true)
        //    {
        //        return symbolArray[1];
        //    }
        //}

        //public char ReturnThirdSymbol(char[] symbolArray)
        //{
        //    if (IsSolved == true)
        //    {
        //        return symbolArray[2];
        //    }
        //}

        //public char ReturnFourthSymbol(char[] symbolArray)
        //{
        //    if (IsSolved == true)
        //    {
        //        return symbolArray[3];
        //    }
        //}


    }
}
