using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntWars.Board {

    /// <summary>
    /// Die Base hier "spawnen" die Ameisen, wird generell am Rand des Spielfeldes generiert.
    /// </summary>
    public class Base : BoardObject {

        internal Player Player { get; private set; }

        /// <summary>
        /// Die Größe der Base.
        /// </summary>
        public int Range { get; internal set; }

        /// <summary>
        /// Der Factor wie schnell sich eine Ameise erholen kann.
        /// </summary>
        public int Recover { get; internal set; }

        internal Base(Player p) {
            Player = p;
            Range = 0;
            Recover = 0;
        }

    }
}
