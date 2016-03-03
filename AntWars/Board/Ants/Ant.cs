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
        public int UnitsGone { get; set; }
        public int Speed { get; set; }
        public int CarryMaxInventory { get { return Owner.PlayerConfig.CarryInventory; } }
        public int ScoutMaxInventory { get { return Owner.PlayerConfig.ScoutInventory; } }
        internal Player Owner { get; private set; }
        internal IAIAnt AI { get; set; }
        internal Board board;

        internal Ant(Board board, Player owner)
        {
            this.board = board;
            this.UnitsGone = 0;
            Owner = owner;
        }

        public bool moveLeft()
        {
            Coordinates newCoords = new Coordinates(Coords.X - 1, Coords.Y);
            if (board.BoardObjects.outOfRange(this))
            {
                die();
            }
            else if(board.BoardObjects.move(this, newCoords))
            {
                UnitsGone++;
                return true;
            }
            return false;
        }

        public bool moveRight()
        {
            Coordinates newCoords = new Coordinates(Coords.X + 1, Coords.Y);
            if (board.BoardObjects.outOfRange(this))
            {
                die();
            }
            if(board.BoardObjects.move(this, newCoords))
            {
                UnitsGone++;
                return true;
            }
            return false;
        }

        public bool moveUp()
        {
            Coordinates newCoords = new Coordinates(Coords.X, Coords.Y - 1);
            if (board.BoardObjects.outOfRange(this))
            {
                die();
            }
            if(board.BoardObjects.move(this, newCoords))
            {
                UnitsGone++;
                return true;
            }
            return false;
        }

        public bool moveDown()
        {
            Coordinates newCoords = new Coordinates(Coords.X, Coords.Y + 1);
            if (board.BoardObjects.outOfRange(this))
            {
                die();
            }
            if(board.BoardObjects.move(this, newCoords))
            {
                UnitsGone++;
                return true;
            }
            return false;
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

        /// <summary>
        /// Die Ameise am Ende des Zuges sterben lassen.
        /// </summary>
        public void die()
        {
            board.DyingAnts.Add(this);
        }

        /// <summary>
        /// Prüfen, ob die Ameise sich noch bewegen kann.
        /// </summary>
        /// <returns>True wenn ja, False wenn nicht</returns>
        public bool canMove()
        {
            return !board.BoardObjects.outOfRange(this);
        }

        public Coordinates getBaseCoords()
        {
            return board.BoardObjects.getBase(Owner).Coords;
        }
    }

}
