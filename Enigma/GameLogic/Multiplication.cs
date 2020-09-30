using System;
using System.Collections.Generic;
using System.Text;

namespace Enigma.GameLogic
{
    class Multiplication : IGameLogic
    {
        public string Hint { get; set; } = "The next number is twice as big as the current number ";

        public void GenerateRandomNr(int[] anyArray)
        {
            Random randomGenerator = new Random();
            anyArray[0] = randomGenerator.Next(1,51);
                
            }

        public int[] GetRestOfNrInSequence(int[] anyArray)
        {
            int haveValues = 1;

            for (int i = 0; i < anyArray.Length - haveValues; i++)
            {

                anyArray[haveValues + i] = anyArray[ i ] * 2;


            }
            return anyArray;
        }
    }

       
    }



