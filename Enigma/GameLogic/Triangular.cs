using Enigma.Interfaces;
using System;

namespace Enigma.GameLogic
{
    class Triangular : IGameLogic
    {
        public string Hint { get; set; } = "This is a Triangular number. The difference between the previous two numbers, adding one.";




        /// <summary>
        /// This methods fill the two first place in an Array with random triangularnumber
        /// </summary>
        /// <param name="anyArray"></param>
        public void GenerateRandomNr(int[] anyArray)
        { 
            Random randomGenerator = new Random();
            int triangleNumber = randomGenerator.Next(6);
            anyArray[0] = GetRandomTriangularNumbers()[triangleNumber]; 
            int nextTriangularNumber = triangleNumber + 1; 
            anyArray[1] = GetRandomTriangularNumbers()[nextTriangularNumber];
        }


        /// <summary>
        /// This method transfer an Array baased on the logic of the triangular numbers.
        /// </summary>
        /// <param name="anyArray"></param>
        ///  <returns>Array  similar or equal to the triangular numbers</returns>

        public int[] GetRestOfNrInSequence(int[] anyArray)
        {
            int counter = anyArray[1] - anyArray[0]; 
            int areTaken = 2;

            for (int i = 0; i < anyArray.Length - areTaken; i++)
            {
                counter++;
                anyArray[areTaken + i] = anyArray[areTaken + i - 1] + counter;
            }
            return anyArray;
        }


        /// <summary>
        /// This method creates an Array of triangular numbers. 
        /// </summary>
        /// <returns>An Array with triangular numbers</returns>

        public int[] GetRandomTriangularNumbers()
        {
            int[] anyArray = new int[7]; 
            anyArray[0] = 1; 
            int counter = 1;
            int areTaken = 1;

            for (int i = 0; i < anyArray.Length - areTaken; i++)
            {
                counter++;
                anyArray[areTaken + i] = anyArray[areTaken + i - 1] + counter; 
            }
            return anyArray;
        }
    }
}

