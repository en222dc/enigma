using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media;

namespace Enigma.Models
{
    class KillerCreation: GetSuspects
    {
        public string KillerName { get; set; }

        public ImageSource KillerPortrait { get; set; }

        Random random = new Random();

        //GetSuspects suspects = new GetSuspects();


        public KillerCreation()
        {
            int index = random.Next(Suspects.Count);

            KillerName = Suspects[index].Name.ToString();
            KillerPortrait = Suspects[index].Portrait;

        }

    }
}
