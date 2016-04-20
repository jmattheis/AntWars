using AntWars.Board;
using System.Collections.Generic;

namespace AntWars.AI {

    /// <summary>
    /// Das interface für die AIAnt.
    /// </summary>
    public interface IAIAnt {

        /// <summary>
        /// Wird in jedem Tick für jede Ameise einmal aufgerufen.
        /// </summary>
        /// <param name="view">Alle BoardObject's die die Ameise sieht</param>
        void antTick(BoardObject[] view);

        void notify(HashSet<Coordinates> coords);
    }
}
