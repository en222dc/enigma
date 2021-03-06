﻿using Enigma.Interfaces;
using System;

namespace Enigma.GameLogic
{
    class Multiplication : IGameLogic
    {
        public string Hint { get; set; } = "The next number is twice as big as the current number ";



        /// <summary>
        /// This methods fill the first place in an Array with a random number.
        /// </summary>
        /// <param name="anyArray"></param>

        public void GenerateRandomNr(int[] anyArray)
        {
            Random randomGenerator = new Random();
            anyArray[0] = randomGenerator.Next(1, 51);
        }


        /// <summary>
        /// This method transfer an Array so that the first number are twice as big as the first.
        /// </summary>
        /// <param name="anyArray"></param>
        ///  <returns>Array where the last number is twice as big as the first</returns>

        public int[] GetRestOfNrInSequence(int[] anyArray)
        {
            int haveValues = 1;

            for (int i = 0; i < anyArray.Length - haveValues; i++)
            {
                anyArray[haveValues + i] = anyArray[i] * 2;
            }
            return anyArray;
        }
    }
}



