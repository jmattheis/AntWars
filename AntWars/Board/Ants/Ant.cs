using AntWars.AI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntWars.Board.Ants
{
    /// <summary>
    /// Die Ameise.
    /// </summary>
    public abstract class Ant : BoardObject
    {

        /// <summary>
        /// Das Maximale Inventory der Ant.
        /// </summary>
        public int MaxInventory { get; protected set; }
        /// <summary>
        /// Die Kosten der Ameise.
        /// </summary>
        public int Cost { get; protected set; }
        /// <summary>
        /// Das Inventory von der Ameise, welches aussagt wieviel Zucker die Ameise momentan Trägt
        /// </summary>
        public int Inventory { get; protected set; }
        /// <summary>
        /// Wie weit die Ameise sehen kann.
        /// </summary>
        public int ViewRange { get; protected set; }

        internal Player Owner { get; private set; }
        internal IAIAnt AI { get; set; }
        internal Board board;

        internal Ant(Board board, Player owner)
        {
            this.board = board;
            Owner = owner;
        }

        /// <summary>
        /// Lässt die Ameise nach links bewegen
        /// </summary>
        /// <returns>true wenn das Bewegen erfolgreich war, false wenn etwas im Weg ist</returns>
        public bool moveLeft()
        {
            Coordinates newCoords = new Coordinates(Coords.X - 1, Coords.Y);
            return board.BoardObjects.move(this, newCoords);
        }

        /// <summary>
        /// Lässt die Ameise nach rechts bewegen
        /// </summary>
        /// <returns>true wenn das Bewegen erfolgreich war, false wenn etwas im Weg ist</returns>
        public bool moveRight()
        {
            Coordinates newCoords = new Coordinates(Coords.X + 1, Coords.Y);
            return board.BoardObjects.move(this, newCoords);
        }

        /// <summary>
        /// Lässt die Ameise nach oben bewegen
        /// </summary>
        /// <returns>true wenn das Bewegen erfolgreich war, false wenn etwas im Weg ist</returns>
        public bool moveUp()
        {
            Coordinates newCoords = new Coordinates(Coords.X, Coords.Y - 1);
            return board.BoardObjects.move(this, newCoords);
        }

        /// <summary>
        /// Lässt die Ameise nach unten bewegen
        /// </summary>
        /// <returns>true wenn das Bewegen erfolgreich war, false wenn etwas im Weg ist</returns>
        public bool moveDown()
        {
            Coordinates newCoords = new Coordinates(Coords.X, Coords.Y + 1);
            return board.BoardObjects.move(this, newCoords);
        }

        /// <summary>
        /// Zucker aufnehmen. Die Ameise muss auf dem Zucker stehen.
        /// </summary>
        /// <returns>True bei Erfolg, false wenn kein Zucker gefunden wurde.</returns>
        public bool pickUpSugar()
        {
            Sugar sugar;

            if (board.BoardObjects.getSugar(Coords, out sugar) && Inventory < MaxInventory)
            {
                int tempSugarAmount = sugar.Amount;
                int maxPickUpSugar = MaxInventory - Inventory;

                if (sugar.Amount - maxPickUpSugar <= 0)
                {
                    // Zucker bei 0 entfernen
                    sugar.Amount = 0;
                    board.BoardObjects.remove(sugar);
                }
                else
                {
                    sugar.Amount = sugar.Amount - maxPickUpSugar;
                }
                Inventory += (tempSugarAmount - sugar.Amount);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Zucker bei der Base abgeben. Die Ameise muss auf der Base stehen.
        /// </summary>
        /// <returns>True bei Erfolg, false wenn die Ameise nicht auf der Base steht.</returns>
        public bool dropSugarOnBase()
        {
            int range = (int)((Owner.CarryCount + Owner.ScoutCount) / 50);
            if (range > 3) { range = 3; }
            if (Coords.isInRange(range, getBaseCoords()))
            {
                Owner.Money += Inventory;
                Owner.Points += Inventory;
                Inventory = 0;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Gibt die Koordinaten von der zugehörigen Base zurück.
        /// </summary>
        /// <returns>Die Koordinaten von der Base</returns>
        public Coordinates getBaseCoords()
        {
            return board.BoardObjects.getBase(Owner).Coords;
        }
    }

}
