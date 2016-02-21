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
    public class Ant : BoardObject
    {
        public int Inventory { get; internal set; }
        public int ViewRange { get; internal set; }
        
        internal Player Owner { get; private set; }
        internal IAIAnt AI { get; set; }
        internal Board board;

        internal Ant(Board board, Player owner, Coordinates coords) : base(coords)
        {
            this.board = board;
            Owner = owner;
        }

        public bool moveLeft()
        {
            Coordinates newCoords = Coords.clone();
            newCoords.X--;
            return board.BoardObjects.move(this, newCoords);
        }

        public bool moveRight()
        {
            Coordinates newCoords = Coords.clone();
            newCoords.X++;
            return board.BoardObjects.move(this, newCoords);
        }

        public bool moveUp()
        {
            Coordinates newCoords = Coords.clone();
            newCoords.Y--;
            return board.BoardObjects.move(this, newCoords);
        }

        public bool moveDown()
        {
            Coordinates newCoords = Coords.clone();
            newCoords.Y++;
            return board.BoardObjects.move(this, newCoords);
        }

        /// <summary>
        /// Zucker aufnehmen. Die Ameise muss auf dem Zucker stehen.
        /// </summary>
        /// <returns>True bei Erfolg, false wenn kein Zucker gefunden wurde.</returns>
        public bool pickUpSugar()
        {
            int maxInventory = isCarry() ? Owner.PlayerConfig.CarryInventory : Owner.PlayerConfig.ScoutInventory;
            Sugar sugar;

            if (board.BoardObjects.getSugar(Coords, out sugar) && Inventory < maxInventory)
            {
                int tempSugarAmount = sugar.Amount;
                int maxPickUpSugar = maxInventory - Inventory;

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
            if (Coords.Equals(board.BoardObjects.getBase(Owner).Coords))
            {
                Owner.Money += Inventory;
                Owner.Points += Inventory;
                Inventory = 0;
                return true;
            }
            return false;
        }

        public Coordinates getBaseCoords()
        {
            return board.BoardObjects.getBase(Owner).Coords;
        }
    }

}
