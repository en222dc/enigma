using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Enigma
{
    public interface IMultipleCommands
    {
        CompositeCommand MultipleCommands { get; }
    }
}
