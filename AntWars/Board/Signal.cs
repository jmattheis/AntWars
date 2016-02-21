using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntWars.Board
{
    public class Signal : BoardObject
    {
        internal Player From { get; set; }

        public Signal(Coordinates coords) : base(coords) { }
    }
}
