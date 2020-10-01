using Enigma.Interfaces;
using System.Windows.Media.Imaging;

namespace Enigma.Models
{
    public class Suspect : ISuspect
    {
        public string KillerName { get; set; }
        public BitmapImage KillerPortrait { get; set; }
        public bool IsKiller { get; set; }
        public char[] EncryptedNameOfKiller { get; set; }
    }
}
