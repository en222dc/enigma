using System;
using System.Collections.Generic;
using System.Text;

namespace Enigma.Models
{
    class KillerCreation
    {
        public List<string> SuspectNames { get; set; }

        Random random = new Random(); 

        public string CreateKiller()
        {
            var killerselection = new List<string> { "Olga", "Odam", "Adam", "Dani" };

            int index = random.Next(killerselection.Count);

            return killerselection[index];
        }
        
    }
}
