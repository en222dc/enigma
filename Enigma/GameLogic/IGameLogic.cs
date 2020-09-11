using System;
using System.Collections.Generic;
using System.Text;

namespace Enigma.GameLogic
{
    interface IGameLogic
    {
        public string Hint { get; set; }

        public void GenerateRandomNr(int[]anyArray);

        public int[] GetRestOfNr(int[]anyArray);
    }
}
