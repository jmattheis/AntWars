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

    }
}
