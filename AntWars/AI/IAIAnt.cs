using AntWars.Board;
using AntWars.Board.Ants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntWars.AI {

    /// <summary>
    /// Das interface für die AIAnt.
    /// </summary>
    public interface IAIAnt {

        /// <summary>
        /// Wird in jedem Tick für jede Ameise einmal aufgerufen.
        /// </summary>
        /// <param name="view">Alle BoardObject's die die Ameise sieht</param>
        void antTick();

        void notify(HashSet<Coordinates> coords);
    }
}
