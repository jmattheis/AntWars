using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AntWars.Board.Ants;

namespace AntWars.Board {

    public class ControllableBoardObject : BoardObject {

        /// <summary>
        /// Gibt an, ob die Ameise sich in diesem Tick schon bewegt hat. 
        /// </summary>
        public bool TookAction { get; internal set; }

        /// <summary>
        /// Der Faktor für die Berechnung der Bewegungsreichweite.
        /// </summary>
        public int MoveRangeFactor { get; internal set; }

        /// <summary>
        /// Wie weit die Ameise schon gegangen ist.
        /// </summary>
        public int UnitsGone { get; internal set; }

        /// <summary>
        /// Wie weit die Ameise sehen kann.
        /// </summary>
        public int ViewRange { get; protected set; }

        /// <summary>
        /// Lebenspunkte der Ameise.
        /// </summary>
        public int Health { get; protected set; }

        /// <summary>
        /// Angriffstärke der Ameise.
        /// </summary>
        public int AttackPower { get; protected set; }

        /// <summary>
        /// Wie weit die Ameise gehen kann. 
        /// </summary>
        public int MoveRange { get; protected set; }

        internal Board board;

        internal ControllableBoardObject(Board board, int viewRange, int moveRangeFactor, int hp, int attackPower) {
            ViewRange = viewRange;
            this.board = board;
            MoveRangeFactor = moveRangeFactor;
            MoveRange = MoveRangeFactor * board.Diagonal;
            Health = hp;
            TookAction = false;
            this.UnitsGone = 0;
            AttackPower = attackPower;
        }

        /// <summary>
        /// Lässt die Ameise nach links bewegen.
        /// </summary>
        /// <returns>true wenn das Bewegen erfolgreich war, false wenn etwas im Weg ist.</returns>
        public bool moveLeft() {
            Coordinates newCoords = new Coordinates(Coords.X - 1, Coords.Y);
            return move(newCoords);
        }
        /// <summary>
        /// Lässt die Ameise diagonal nach links oben bewegen.
        /// </summary>
        /// <returns>true wenn das Bewegen erfolgreich war, false wenn etwas im Weg ist.</returns>
        public bool moveUpperLeft() {
            Coordinates newCoords = new Coordinates(Coords.X - 1, Coords.Y - 1);
            return move(newCoords);
        }

        /// <summary>
        /// Lässt die Ameise diagonal nach links unten bewegen.
        /// </summary>
        /// <returns>true wenn das Bewegen erfolgreich war, false wenn etwas im Weg ist.</returns>
        public bool moveLowerLeft() {
            Coordinates newCoords = new Coordinates(Coords.X - 1, Coords.Y + 1);
            return move(newCoords);
        }

        /// <summary>
        /// Lässt die Ameise nach rechts bewegen.
        /// </summary>
        /// <returns>true wenn das Bewegen erfolgreich war, false wenn etwas im Weg ist.</returns>
        public bool moveRight() {
            Coordinates newCoords = new Coordinates(Coords.X + 1, Coords.Y);
            return move(newCoords);
        }

        /// <summary>
        /// Lässt die Ameise diagonal nach rechts oben bewegen.
        /// </summary>
        /// <returns>true wenn das Bewegen erfolgreich war, false wenn etwas im Weg ist.</returns>
        public bool moveUpperRight() {
            Coordinates newCoords = new Coordinates(Coords.X + 1, Coords.Y - 1);
            return move(newCoords);
        }

        /// <summary>
        /// Lässt die Ameise diagonal nach rechts unten bewegen.
        /// </summary>
        /// <returns>true wenn das Bewegen erfolgreich war, false wenn etwas im Weg ist.</returns>
        public bool moveLowerRight() {
            Coordinates newCoords = new Coordinates(Coords.X + 1, Coords.Y + 1);
            return move(newCoords);
        }

        /// <summary>
        /// Lässt die Ameise nach oben bewegen
        /// </summary>
        /// <returns>true wenn das Bewegen erfolgreich war, false wenn etwas im Weg ist</returns>
        public bool moveUp() {
            Coordinates newCoords = new Coordinates(Coords.X, Coords.Y - 1);
            return move(newCoords);
        }

        /// <summary>
        /// Lässt die Ameise nach unten bewegen
        /// </summary>
        /// <returns>true wenn das Bewegen erfolgreich war, false wenn etwas im Weg ist</returns>
        public bool moveDown() {
            Coordinates newCoords = new Coordinates(Coords.X, Coords.Y + 1);
            return move(newCoords);
        }

        /// <summary>
        /// Prüfen, ob die Ameise sich noch bewegen kann.
        /// </summary>
        /// <returns>True wenn ja, False wenn nicht</returns>
        public bool canMove() {
            if (UnitsGone >= MoveRange)
                return false;
            return true;
        }

        /// <summary>
        /// Greift das übergebene Objekt an und fügt Schaden in Höhe der Attackpower zu. Das Objekt muss unmittelbar neben der Ameise stehen.
        /// Kann nur von Warrior-Ameisen benutzt werden.
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public virtual bool fight(ControllableBoardObject target) {
            throw new InvalidOperationException("Object isn't allowed to call the fight method.");
        }

        /// <summary>
        /// Lässt die Einheit sterben.
        /// </summary>
        public virtual void die() {
            board.killBoardObject(this);
        }

        internal void takeDamage(int dmg) {
            Health -= dmg;
            if (Health <= 0) {
                die();
            }
        }

        private bool move(Coordinates to) {
            if (!canMove()) {
                die();
            } else if (!TookAction && board.BoardObjects.move(this, to)) {
                TookAction = true;
                UnitsGone++;
                return true;
            }
            return false;
        }
    }
}
