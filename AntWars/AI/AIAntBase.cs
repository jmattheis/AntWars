using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AntWars.Board;
using AntWars.Board.Ants;

namespace AntWars.AI
{
    /// <summary>
    /// Die Basis für die KI der Ameise.
    /// </summary>
    public abstract class AIAntBase : IAIAnt
    {
        /// <summary>
        /// Die Ameise für die momentane AI instance.
        /// </summary>
        public Ant Ant { get; internal set; }
        internal Config.GameConfig Conf { get; set; }
        /// <summary>
        /// Die BoardWidth
        /// </summary>
        public int BoardWidth { get { return Conf.BoardWidth; } }
        /// <summary>
        /// Die BoardHeight
        /// </summary>
        public int BoardHeight { get { return Conf.BoardHeight; } }
        /// <summary>
        /// Führt den ant tick aus welcher 1 mal für jede Ameise pro Gametick ausgeführt wird.
        /// </summary>
        /// <param name="view"></param>
        public abstract void antTick(BoardObject[] view);
    }
}
