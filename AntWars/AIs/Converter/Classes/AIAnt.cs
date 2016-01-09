using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AntWars.Board.Ants;
using AntWars.Board;

namespace AntWars.AIs.Converter.Classes
{
    class AIAnt : AIBoardObject
    {
        private Board.Board board;
        private Ant ant; 
        public AIAnt(Ant ant, Board.Board board) : base(ant)
        {
            this.board = board;
            this.ant = ant;
            Owner = ant.Owner;
        }
        public Player Owner { get; private set; }

        public bool moveLeft()
        {
            Coordinates newCoords = Coords.clone();
            newCoords.X--;
            ant.UnitsGone++;
            return board.BoardObjects.move(ant, newCoords);
        }

        public bool moveRight()
        {
            Coordinates newCoords = Coords.clone();
            newCoords.X++;
            ant.UnitsGone++;
            return board.BoardObjects.move(ant, newCoords);
        }
        public bool moveUp()
        {
            Coordinates newCoords = Coords.clone();
            newCoords.Y++;
            ant.UnitsGone++;
            return board.BoardObjects.move(ant, newCoords);
        }

        public bool moveDown()
        {
            Coordinates newCoords = Coords.clone();
            newCoords.Y--;
            ant.UnitsGone++;
            return board.BoardObjects.move(ant, newCoords);
        }

        /// <summary>
        /// Zucker aufnehmen. Die Ameise muss auf dem Zucker stehen.
        /// </summary>
        /// <returns>True bei Erfolg, false wenn kein Zucker gefunden wurde.</returns>
        public bool pickUpSugar()
        {
            int maxInventory = ant.isCarry() ? ant.Owner.PlayerConfig.carryInventory : ant.Owner.PlayerConfig.scoutInventory;
            Sugar sugar;

            if (board.BoardObjects.getSugar(Coords, out sugar) && ant.Inventory < maxInventory)
            {
                int tempSugarAmount = sugar.amount;
                int maxPickUpSugar = maxInventory - ant.Inventory;

                if (sugar.amount - maxPickUpSugar <= 0)
                {
                    // Zucker bei 0 entfernen
                    sugar.amount = 0;
                    board.BoardObjects.remove(sugar);
                }
                else
                {
                    sugar.amount = sugar.amount - maxPickUpSugar;
                }
                ant.Inventory += (tempSugarAmount - sugar.amount);
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Zucker bei der Base abgeben. Die Ameise muss auf der Base stehen.
        /// </summary>
        /// <returns>True bei Erfolg, false wenn die Ameise nicht auf der Base steht.</returns>
        public bool dropSugarOnBase()
        {
            if (Coords == board.BoardObjects.getBase(Owner).Coords)
            {
                Owner.money += ant.Inventory;
                Owner.Points += ant.Inventory;
                ant.Inventory = 0;
                return true;
            }
            else
                return false;
        }
    }
}
