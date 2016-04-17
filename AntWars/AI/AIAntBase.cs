using AntWars.Board;
using AntWars.Board.Ants;
using System.Collections.Generic;

namespace AntWars.AI {

    /// <summary>
    /// Die Basis für die KI der Ameise.
    /// </summary>
    public abstract class AIAntBase : IAIAnt {

        private static readonly Random RANDOM_INSTANCE = new Random();

        /// <summary>
        /// Die Ameise für die momentane AI instance.
        /// </summary>
        public Ant Ant { get; internal set; }

        internal Config Conf { get; set; }

        /// <summary>
        /// Die BoardWidth
        /// </summary>
        public int BoardWidth { get { return Conf.BoardWidth; } }

        /// <summary>
        /// Die BoardHeight
        /// </summary>
        public int BoardHeight { get { return Conf.BoardHeight; } }

        public abstract void antTick(BoardObject[] view);

        public abstract void notify(HashSet<Coordinates> coords);

        /// <summary>
        /// Gibt eine Instanz der Klasse Random zurück.
        /// </summary>
        /// <returns>Instanz der Random-Klasse</returns>
        public Random getRandom() {
            return RANDOM_INSTANCE;
        }
    }
}
