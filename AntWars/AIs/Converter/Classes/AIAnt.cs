using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AntWars.Board.Ants;
using AntWars.Board;

namespace AntWars.AIs.Converter.Classes
{
    public class AIAnt : AIBoardObject
    {
        Player Owner { get; set; }

        private Board.Board board;
        Ant ant; 


        internal AIAnt(Ant ant, Board.Board board) : base(ant)
        {
            this.board = board;
            this.ant = ant;
            Owner = ant.Owner;
        }

        public bool moveLeft()
        {
            Coordinates newCoords = Coords.clone();
            newCoords.X--;
            return board.BoardObjects.move(ant, newCoords);
        }

        public bool moveRight()
        {
            Coordinates newCoords = Coords.clone();
            newCoords.X++;
            return board.BoardObjects.move(ant, newCoords);
        }
        public bool moveUp()
        {
            Coordinates newCoords = Coords.clone();
            newCoords.Y++;
            return board.BoardObjects.move(ant, newCoords);
        }

        public bool moveDown()
        {
            Coordinates newCoords = Coords.clone();
            newCoords.Y--;
            return board.BoardObjects.move(ant, newCoords);
        }

        /// <summary>
        /// Zucker aufnehmen. Die Ameise muss auf dem Zucker stehen.
        /// </summary>
        /// <returns>True bei Erfolg, false wenn kein Zucker gefunden wurde.</returns>
        public bool pickUpSugar()
        {
            int maxInventory = ant.isCarry() ? ant.Owner.PlayerConfig.CarryInventory : ant.Owner.PlayerConfig.ScoutInventory;
            Sugar sugar;

            if (board.BoardObjects.getSugar(Coords, out sugar) && ant.Inventory < maxInventory)
            {
                int tempSugarAmount = sugar.Amount;
                int maxPickUpSugar = maxInventory - ant.Inventory;

                if (sugar.Amount - maxPickUpSugar <= 0)
                {
                    sugar.Amount = 0;
                    board.BoardObjects.remove(sugar);
                }
                else
                {
                    sugar.Amount = sugar.Amount - maxPickUpSugar;
                }
                ant.Inventory += (tempSugarAmount - sugar.Amount);
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
            if (Coords == board.BoardObjects.getBase(Owner).Coords)
            {
                Owner.Money += ant.Inventory;
                Owner.Points += ant.Inventory;
                ant.Inventory = 0;
                return true;
            }
            return false;
        }
    }
}
