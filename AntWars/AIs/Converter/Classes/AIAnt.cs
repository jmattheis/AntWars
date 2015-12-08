using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AntWars.Board.Ants;

namespace AntWars.AIs.Converter.Classes
{
    class AIAnt : AIBoardObject
    {
        enum Direction
        {
            LEFT, RIGHT, UP, DOWN
        }

        public AIAnt(Ant ant) : base(ant)
        {
            Owner = ant.Owner;
        }
        public Player Owner { get; private set; }

        public void move(Direction d)
        {
            switch (d)
            {
                case Direction.DOWN:
                    Coords.Y--;
                    break;
                case Direction.UP:
                    Coords.Y++;
                    break;
                case Direction.LEFT:
                    Coords.X--;
                    break;
                case Direction.RIGHT:
                    Coords.X++;
                    break;
            }
        }

    }
}
