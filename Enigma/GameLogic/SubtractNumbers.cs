using Enigma.Interfaces;
using System;

namespace Enigma.GameLogic
{
    class SubtractNumbers : IGameLogic
    {
        public string Hint { get; set; } = "Subtract the first number from the second number.";



        /// <summary>
        /// This methods fills an Array with random numbers from 1 to 30 and sort it.
        /// </summary>
        /// <param name="anyArray"></param>


        public void GenerateRandomNr(int[] anyArray)
        {
            Random randomGenerator = new Random();

            for (int counter = 0; counter < anyArray.Length; counter++)
            {
                anyArray[counter] = randomGenerator.Next(1, 30);
            }
            Array.Sort(anyArray);
        }


        /// <summary>
        /// This method transfer an Array so that the next number is the subtraction of the two previous numbers.
        /// </summary>
        /// <param name="anyArray"></param>
        ///  <returns>Array</returns>

        public int[] GetRestOfNrInSequence(int[] anyArray)
        {
            int haveValues = 2;

            for (int i = 0; i < anyArray.Length - haveValues; i++)
            {
                anyArray[haveValues + i] = anyArray[haveValues + i - 1] - anyArray[haveValues + i - 2];
            }
            return anyArray;
        }
    }
}

