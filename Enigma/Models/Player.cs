using Enigma.Interfaces;

namespace Enigma.Models
{
   public class Player : IPlayer
    {
        #region Properties
        public int Player_id { get; set; }
        public string Player_name { get; set; }
        #endregion

        #region Constructor
        public Player()
        {
        }
        #endregion
    }
}
