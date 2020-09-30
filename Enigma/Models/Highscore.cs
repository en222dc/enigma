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

      
    }
}

