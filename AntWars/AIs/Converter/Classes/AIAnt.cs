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

        protected bool checkCollision(Coordinates coords)
        {
            List<BoardObject> coordObjects = board.getBoardObjectsForCoordinates(coords);
            foreach (BoardObject coordObject in coordObjects)
            {
                if (coordObject.isAnt())
                    return false;               
            }
            return true;
        }
        public void moveLeft()
        {
            Coordinates newCoords = Coords.clone();
            newCoords.X--;
            if (!checkCollision(newCoords))
                Coords.X--;
        }

        public void moveRight()
        {
            Coordinates newCoords = Coords.clone();
            newCoords.X++;
            if (!checkCollision(newCoords))
                Coords.X++;
        }
        public void moveUp()
        {
            Coordinates newCoords = Coords.clone();
            newCoords.Y++;
            if (!checkCollision(newCoords))
                Coords.Y++;
        }

        public void moveDown()
        {
            Coordinates newCoords = Coords.clone();
            newCoords.Y--;
            if (!checkCollision(newCoords))
                Coords.Y--;
        }

    }
}
