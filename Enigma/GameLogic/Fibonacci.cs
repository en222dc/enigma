using Enigma.GameLogic;
using Enigma.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Enigma.Models
{
    class Fibonacci : IGameLogic
    {
        public string Hint { get; set; } = "A Fibonacci puzzle is solved by taking the previous two numbers and adding them together. ";

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
