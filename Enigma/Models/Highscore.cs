using System;
using System.Collections.Generic;
using System.Text;

namespace Enigma.Models
{
   public class Highscore
    {
        public int Highscore_id { get; set; }
        public int Fk_Player_id { get; set; }
        public int Time { get; set; }
        public string Player_name { get; set; }

        public Highscore()
        {

        }

        /*
        public Highscore(int highscore_id, int fk_player_id, int time)
        {
            Highscore_id = highscore_id;
            Fk_Player_id = fk_player_id;
            Time = time;
        }
        */

        public override string ToString()
        {
            return $"{Player_name}      {Time}";
        }

    }
}

