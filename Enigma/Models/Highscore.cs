namespace Enigma.Models
{
   public class Highscore
    {
        #region Properties
        public int Highscore_id { get; set; }
        public int Fk_Player_id { get; set; }
        public int Time { get; set; }
        public string Player_name { get; set; }
        #endregion

        #region Constructor
        public Highscore()
        {
        }
        #endregion
    }
}

