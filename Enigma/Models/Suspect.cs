using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Enigma.Models
{
    public class Suspect
    {
        // Klassens syfte är att lägga till egenskaper för objektet Suspect

        public string Name { get; set; }
        public BitmapImage Portrait { get; set; }

        public bool IsKiller { get; set; }


        public char[] EncryptedName { get; set; }




    }
}
