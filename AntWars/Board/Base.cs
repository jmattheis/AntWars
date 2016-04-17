namespace AntWars.Board {

    /// <summary>
    /// Die Base hier "spawnen" die Ameisen, wird generell am Rand des Spielfeldes generiert.
    /// </summary>
    public class Base : BoardObject {

        internal Player Player { get; private set; }

        /// <summary>
        /// Das Level der Reichweite, gibt an mit wieviel Feldern abstand die Ameise Zucker ablegen/sich erholen kann.
        /// </summary>
        public int RangeLevel { get; internal set; }

        /// <summary>
        /// Das Level der Erholungrate gibt an um wieviel % sich die Ameise erholen kann. Rechnung: (level/10)%
        /// </summary>
        public int RecoverLevel { get; internal set; }

        internal Base(Player p) {
            Player = p;
            RangeLevel = 0;
            RecoverLevel = 1;
        }
    }
}
