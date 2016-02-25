using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntWars.Board.Ants
{
    public class MovableAnt : Ant
    {
        Ant ant;
        internal MovableAnt(Ant ant) : base(ant.board, ant.Owner)
        {
            this.ant = ant;
            Coords = ant.Coords;
        }
        public bool moveLeft()
        {
            Coordinates newCoords = new Coordinates(Coords.X - 1, Coords.Y);
            return board.BoardObjects.move(ant, newCoords);
        }

        public bool moveRight()
        {
            Coordinates newCoords = new Coordinates(Coords.X + 1, Coords.Y);
            return board.BoardObjects.move(ant, newCoords);
        }

        public bool moveUp()
        {
            Coordinates newCoords = new Coordinates(Coords.X, Coords.Y - 1);
            return board.BoardObjects.move(ant, newCoords);
        }

        public bool moveDown()
        {
            Coordinates newCoords = new Coordinates(Coords.X, Coords.Y + 1);
            return board.BoardObjects.move(ant, newCoords);
        }

    }
}
