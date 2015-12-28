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
        /// <returns></returns>
        public bool pickUpSugar()
        {
            Sugar sugar;
            if (this.board.BoardObjects.getSugar(this.Coords, out sugar) && ant.Inventory > 0)
            {
                int temp = sugar.amount;
                if (sugar.amount - ant.Inventory <= 0)
                {
                    // Zucker bei 0 entfernen
                    sugar.amount = 0;
                    this.board.BoardObjects.remove(sugar);
                }
                else
                    sugar.amount = sugar.amount - ant.Inventory;

                ant.Inventory -= (temp - sugar.amount);
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// Zucker bei der Base abgeben. Die Ameise muss auf der Base stehen.
        /// </summary>
        /// <returns></returns>
        public bool dropSugarOnBase()
        {
            if (this.Coords == this.board.BoardObjects.getBase(this.Owner).Coords)
            {
                this.Owner.money += ant.Inventory;
                this.Owner.Points += ant.Inventory;
                ant.Inventory = 0;
                return true;
            }
            else
                return false;
        }
    }
}
