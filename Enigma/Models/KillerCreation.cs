using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media;

namespace Enigma.Models
{
    class KillerCreation: GetSuspects
    {
        Random random = new Random();

        public string KillerName { get; set; }
        public ImageSource KillerPortrait { get; set; }

        public KillerCreation()
        {
            int index = random.Next(Suspects.Count);

            KillerName = Suspects[index].Name.ToString();
            KillerPortrait = Suspects[index].Portrait;

        }

    }
}
