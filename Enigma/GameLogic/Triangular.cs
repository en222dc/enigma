using Enigma.Interfaces;
using System;

namespace Enigma.GameLogic
{
    class Triangular : IGameLogic
    {
        public string Hint { get; set; } = "This is a Triangular number. The difference between the previous two numbers, adding one.";

        public void GenerateRandomNr(int[] anyArray)
        { 
            Random randomGenerator = new Random();
            int triangleNumber = randomGenerator.Next(6);
            anyArray[0] = GetRandomTriangularNumbers()[triangleNumber]; // her henter den en random plass i arrayen å lagrer det i en ny array
            int nextTriangularNumber = triangleNumber + 1; // her finner man neste posisjon i arrayen
            anyArray[1] = GetRandomTriangularNumbers()[nextTriangularNumber];//setter neste posisjon i arrayen
        }

        public int[] GetRestOfNrInSequence(int[] anyArray)
        {
            int counter = anyArray[1] - anyArray[0]; // henter potensen til de nåværende tallene altså for å finne det tredje tallet i rekken
            int areTaken = 2;

            for (int i = 0; i < anyArray.Length - areTaken; i++)
            {
                counter++;
                anyArray[areTaken + i] = anyArray[areTaken + i - 1] + counter;
            }
            return anyArray;
        }


        public int[] GetRandomTriangularNumbers()
        {
            int[] anyArray = new int[7]; // skaper an ny array
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

