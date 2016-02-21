using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntWars.Board
{
    /// <summary>
    /// Die Base hier "spawnen" die Ameisen, wird generell am rand des spielfeldes generiert.
    /// </summary>
    public class Base : BoardObject
    {
        internal Player Player { get; private set; }

        internal Base(Player p, Coordinates coords) : base(coords)
        {
            Player = p;
        }

    }
}
