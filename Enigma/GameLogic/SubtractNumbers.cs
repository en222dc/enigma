using Enigma.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Enigma.GameLogic
{
    class SubtractNumbers : IGameLogic
    {

        public string Hint { get; set; } = "Subtract the first number from the second number.";

        public void GenerateRandomNr(int[] anyArray)
        {
            Random randomGenerator = new Random();
          

            for (int counter = 0; counter < anyArray.Length; counter++)
            {
                
                anyArray[counter] = randomGenerator.Next(1,30);
               
               
            }
            Array.Sort(anyArray);

        }

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

