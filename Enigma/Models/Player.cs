using System;
using System.Collections.Generic;
using System.Text;

namespace Enigma.Models
{
    class Player
    {
        public int Player_id { get; set; }
        public string Player_name { get; set; }

        public Player(string playerName)
        {
            Player_name = playerName;
        }
    }
}
