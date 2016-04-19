using AntWars.Board.Ants;

namespace AntWars.Board {

    /// <summary>
    /// Das BoardObject der startpunkt für alles was auf dem Board ist.
    /// </summary>
    public class BoardObject {

        /// <summary>
        /// Die Koordinate vom Object.
        /// </summary>
        public Coordinates Coords { get; internal set; }

        /// <summary>
        /// Überprüft ob das BoardObject eine Ameise ist.
        /// </summary>
        /// <returns>true wenn es eine Ameise ist</returns>
        public bool isAnt() {
            return GetType() == typeof(Ant) || isScout() || isCarry() || isWarrior();
        }

        /// <summary>
        /// Überprüft ob das BoardObject Zucker ist.
        /// </summary>
        /// <returns>true wenn es eine Zucker ist</returns>
        public bool isSugar() {
            return GetType() == typeof(Sugar);
        }

        /// <summary>
        /// Überprüft ob das BoardObject eine Basis ist.
        /// </summary>
        /// <returns>true wenn es eine Basis ist</returns>
        public bool isBase() {
            return GetType() == typeof(Base);
        }

        /// <summary>
        /// Überprüft ob das BoardObject ein Carry ist.
        /// </summary>
        /// <returns>true wenn es ein Carry ist</returns>
        public bool isCarry() {
            return GetType() == typeof(Carry);
        }

        /// <summary>
        /// Überprüft ob das BoardObject ein Scout ist.
        /// </summary>
        /// <returns>true wenn es ein Scout ist</returns>
        public bool isScout() {
            return GetType() == typeof(Scout);
        }

        /// <summary>
        /// Überprüft ob das BoardObject ein Warrior ist.
        /// </summary>
        /// <returns>true wenn es ein Warrior ist</returns>
        public bool isWarrior() {
            return GetType() == typeof(Warrior);
        }
    }
}
