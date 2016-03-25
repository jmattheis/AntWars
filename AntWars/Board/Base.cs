using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntWars.Board {

    /// <summary>
    /// Die Base hier "spawnen" die Ameisen, wird generell am rand des spielfeldes generiert.
    /// </summary>
    public class Base : BoardObject {

        internal Player Player { get; private set; }

        public int Range { get; internal set; }

        internal Base(Player p) {
            Player = p;
            Range = 0;
        }

    }
}
