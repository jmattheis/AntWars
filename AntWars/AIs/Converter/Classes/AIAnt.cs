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
        public AIAnt(Ant ant, Board.Board board) : base(ant)
        {
            this.board = board;
            Owner = ant.Owner;
        }
        public Player Owner { get; private set; }

        protected bool checkCollision()
        {
            List<BoardObject> coordObjects = board.getBoardObjectsForCoordinates(Coords);
            foreach (BoardObject coordObject in coordObjects)
            {
                if (coordObject.isAnt())
                    return false;               
            }
            return true;
        }
        public void moveLeft()
        {
            if (!checkCollision())
                Coords.X--;
        }

        public void moveRight()
        {
            if (!checkCollision())
                Coords.X++;
        }
        public void moveUp()
        {
            if (!checkCollision())
                Coords.Y++;
        }

        public void moveDown()
        {
            if (!checkCollision())
                Coords.Y--;
        }

    }
}
