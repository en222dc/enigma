using Enigma.Interfaces;
using System.Windows.Media.Imaging;

namespace Enigma.Models
{
    public class Suspect : ISuspect
    {
        public string Name { get; set; }
        public BitmapImage Portrait { get; set; }
        public bool IsKiller { get; set; }
        public char[] EncryptedName { get; set; }
    }
}
