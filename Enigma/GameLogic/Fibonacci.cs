using Enigma.Interfaces;
using System;

namespace Enigma.Models
{
    class Fibonacci : IGameLogic
    {
        public string Hint { get; set; } = "A Fibonacci puzzle is solved by taking the previous two numbers and adding them together. ";



        /// <summary>
        /// This methods fills the two first places in an Array with random numbers and sorts the array.
        /// </summary>
        /// <param name="anyArray"></param>


        public void GenerateRandomNr(int[] anyArray)
        {
            Random randomGenerator = new Random();
            int needValues = 2;

            for (int counter = 0; counter < anyArray.Length; counter++)
            {
                if ((counter) == needValues)
                {
                    if (anyArray[1] < anyArray[0])
                    {
                        int[] temp = new int[1];
                        temp[0] = anyArray[1];
                        anyArray[1] = anyArray[0];
                        anyArray[0] = temp[0];
                    }
                    break;
                }
                anyArray[counter] = randomGenerator.Next(20);
                anyArray[counter]++;
            }
        }

        /// <summary>
        /// This method transfer an Array baased on the logic of the fobonacci numbers.
        /// </summary>
        /// <param name="anyArray"></param>
        ///  <returns>Array  similar to the fibonacci numbers numbers</returns>

        public int[] GetRestOfNrInSequence(int[]anyArray)
        {
            int haveValues = 2;

            for (int i = 0; i < anyArray.Length - haveValues; i++)
            {
                anyArray[haveValues + i] = anyArray[haveValues + i - 1] + anyArray[haveValues + i - 2];
            }
            return anyArray;
        }
    }
}
