using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AntWars.Board;
using AntWars.Board.Ants;
using AntWars.AIs.Converter.Classes;


namespace AntWars.AI
{
    class Player2 : AIBase
    {
        private Random rand = new Random();
        public override void antTick(AIAnt ant, List<AIBoardObject> view)
        {
            // RANDOM FTW
            switch (rand.Next(0, 4))
            {
                case 1:
                    ant.moveDown();
                    break;
                case 2:
                    ant.moveLeft();
                    break;
                case 3:
                    ant.moveRight();
                    break;
                case 0:
                    ant.moveUp();
                    break;
            }
        }

        public override void nextTick(int currentMoney)
        {
            buyScout();
        }
    }
}
