using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AntWars.Board;
using AntWars.Board.Ants;
using System.Security.Permissions;

namespace AntWars.AI {
    /// <summary>
    /// Die Basis der AI welcher Ameisen kaufen kann.
    /// </summary>
    public abstract class AIBase : IAI {
        internal Player Player { get; set; }
        internal Game Game { get; set; }
        internal Base Base = null;
        public abstract String Playername { get; }
        public abstract void nextTick();

        /// <summary>
        /// Deine derzeitigen Punkte.
        /// </summary>
        protected int CurrentScore {
            get { return Player.Points; }
        }

        /// <summary>
        /// Die bisher vergangenen Ticks.
        /// </summary>
        protected int CurrentTick {
            get { return Game.getCurrentTick(); }
        }

        /// <summary>
        /// Dein aktuelles Geld.
        /// </summary>
        protected double CurrentMoney {
            get { return Player.Money; }
        }

        /// <summary>
        /// Anzahl deiner Carries.
        /// </summary>
        protected int CurrentCarryCount {
            get { return Player.CarryCount; }
        }

        /// <summary>
        /// Anzahl deiner Scouts.
        /// </summary>
        protected int CurrentScoutScount {
            get { return Player.ScoutCount; }
        }

        /// <summary>
        /// Kauft einen Scout.
        /// Zur Berechnung der Bewegungsreichweite einer Ameise wird die Diagonale des Spielfeldes mit dem gewählten moveRangeFactor multipliziert.
        /// (Eine Umrundung des Spielfeldes benötigt mindestens einen moveRangeFactor von Drei.)
        /// </summary>
        /// <param name="viewRange">Die Sichtweite der Ameise.</param>
        /// <param name="inventory">Die Maximale Anzahl an Zucker, die die Ameise tragen kann.</param>
        /// <param name="moveRangeFactor">Der Faktor für die Bewegungsreichweite der Ameise.</param>
        /// <param name="hp">Lebenspunkte der Ameise.</param>
        /// <returns>>true wenn der Scout erfolgreich gekauft wird andernfalls wenn man nicht genug Geld hat false.</returns>
        protected bool buyScout(int viewRange, int inventory, int moveRangeFactor, int hp) {
            Scout s = new Scout(Game.Board, Player, viewRange, inventory, moveRangeFactor, hp);
            return buyAnt(s);
        }

        /// <summary>
        /// Kauft einen Carry.
        /// Zur Berechnung der Bewegungsreichweite einer Ameise wird die Diagonale des Spielfeldes mit dem gewählten moveRangeFactor multipliziert.
        /// (Eine Umrundung des Spielfeldes benötigt mindestens einen moveRangeFactor von Drei.)
        /// </summary>
        /// <param name="viewRange">Die Sichtweite der Ameise.</param>
        /// <param name="inventory">Die Maximale Anzahl an Zucker, die die Ameise tragen kann.</param>
        /// <param name="moveRangeFactor">Wie weit die Ameise gehen kann.</param>
        /// <param name="hp">Lebenspunkte der Ameise.</param>
        /// <returns>true wenn der Carry erfolgreich gekauft wird andernfalls wenn man nicht genug Geld hat false.</returns>
        protected bool buyCarrier(int viewRange, int inventory, int moveRangeFactor, int hp) {
            Carry c = new Carry(Game.Board, Player, viewRange, inventory, moveRangeFactor, hp);
            return buyAnt(c);
        }

        /// <summary>
        /// Kauft einen Warrior.
        /// Zur Berechnung der Bewegungsreichweite einer Ameise wird die Diagonale des Spielfeldes mit dem gewählten moveRangeFactor multipliziert.
        /// (Eine Umrundung des Spielfeldes benötigt mindestens einen moveRangeFactor von Drei.)
        /// </summary>
        /// <param name="attackPower">Die Angriffsstärke der Ameise.</param>
        /// <param name="viewRange">Die Sichtweite der Ameise.</param>
        /// <param name="inventory">Die Maximale Anzahl an Zucker, die die Ameise tragen kann.</param>
        /// <param name="moveRangeFactor">Wie weit die Ameise gehen kann.</param>
        /// <param name="hp">Lebenspunkte der Ameise.</param>
        /// <returns>true wenn der Warrior erfolgreich gekauft wird andernfalls wenn man nicht genug Geld hat false.</returns>
        protected bool buyWarrior(int attackPower, int viewRange, int inventory, int moveRangeFactor, int hp) {
            Warrior w = new Warrior(attackPower, Game.Board, Player, viewRange, inventory, moveRangeFactor, hp);
            return buyAnt(w);
        }

        /// Verbessert die Reichweite der Basis.
        /// </summary>
        /// <returns>false wenn man zuwenig Geld hat</returns>
        public bool upgradeRange() {
            try {
                double cost = Helper.CostCalculator.calculateUpgradeCost(getBase().Range);
                if (Player.pay(cost)) {
                    Base.Range++;
                    return true;
                }
            } catch (ArgumentException) { } // tritt auf wenn das level zu hoch ist
            return false;
        }

        private bool buyAnt(Ant ant) {
            double cost = Helper.CostCalculator.calculateCost(ant);
            Base b = getBase();
            if (!resolveAntCoords(ant, b) || !Player.pay(cost)) {
                return false;
            }
            ant.AI = Player.AILoader.createAIAntInstance(ant, Game.Conf);
            return Game.Board.BoardObjects.add(ant);
        }

        private bool resolveAntCoords(Ant ant, Base b) {
            if (!Game.Board.BoardObjects.hasAntOnCoords(b.Coords)) {
                ant.Coords = b.Coords;
                return true;
            } else {
                List<Coordinates> adjCoords = b.Coords.getAdjacentCoordinates(3);
                foreach (Coordinates coords in adjCoords) {
                    if (!Game.Board.BoardObjects.isValidCoords(coords)) {
                        continue;
                    }
                    if (!Game.Board.BoardObjects.hasAntOnCoords(coords)) {
                        ant.Coords = coords;
                        return true;
                    }
                }
                return false;
            }
        }

        private Base getBase() {
            if (Base == null)
                Base = Game.Board.BoardObjects.getBase(Player);

            return Base;
        }
    }
}
