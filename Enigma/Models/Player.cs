﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Enigma.Models
{
   public class Player
    {
        public int Player_id { get; set; }
        public string Player_name { get; set; }
        //public int NumberOfGames { get; set; }


        public Player(string playerName)
        {
            Player_name = playerName;
        }

        public Player()
        {

        }

        public override string ToString()
        {
            return $"{Player_name}";
        }
    }
}
