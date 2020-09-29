﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;

namespace Enigma.GameLogic
{
    class Triangular : IGameLogic
    {

        public string Hint { get; set; } = $"  *  1   *  3     * 6          *  10" +
            "                                        * *      * *          * * " +
            "                                                * * *        * * * " +
            "                                                            * * * *  ";

        public void GenerateRandomNr(int[] anyArray)
        { 
            
            Random randomGenerator = new Random();
            int triangleNumber = randomGenerator.Next(7); 
            anyArray[0] = GetTriangularNumbers()[triangleNumber]; // her henter den en random plass i arrayen å lagrer det i en ny array
            int counter = triangleNumber + 1; // her finner man neste posisjon i arrayen
            anyArray[1] = GetTriangularNumbers()[counter];//setter neste posisjon i arrayen
            
        }

        public int[] GetRestOfNrInSequence(int[] anyArray)
        {
             int counter = anyArray[1] - anyArray[0]; // henter potensen til de nåværende tallene altså for å finne det tredje tallet i rekken
             int areTaken = 2;
            
            for (int i = 0; i < 3; i++)
            {
                    counter++;
                    anyArray[areTaken + i] = anyArray[areTaken + i - 1] + counter;
            }
            return anyArray;
        }


        public int[] GetTriangularNumbers()
        {
            int[] anyArray = new int[6]; // skaper an ny array
            anyArray[0] = 1; // setter første posisjonen i arrayen til en fordi det er første nummeret
            int counter = 1;// setter første potensen til en fordi 0 har potens 1 og neste tall har potens 2.
            int areTaken = 1;// for å bevege seg i arrayen

            for (int i = 0; i < anyArray.Length - areTaken; i++)
            {
                counter++;
                anyArray[areTaken + i] = anyArray[areTaken + i - 1] + counter; // Her plusser man potensen med det forrige tallet i arryen for å finne neste

            }
            return anyArray;
        }

    }

}

