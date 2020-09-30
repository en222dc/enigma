using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media.Imaging;

namespace Enigma.Interfaces
{
    interface ISuspect
    {
        public string Name { get; set; }
        public BitmapImage Portrait { get; set; }
        public bool IsKiller { get; set; }
        public char[] EncryptedName { get; set; }
    }
}
