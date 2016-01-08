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
    class Player1 : AIBase
    {
        private Random rand = new Random();
        public override void antTick(AIAnt ant, List<AIBoardObject> view)
        {
            // Zucker aufheben Test
            ant.pickUpSugar();

            // RANDOM FTW
            if (ant.canMove()) // TODO: Ameisen bleiben stehen wenn sie die MoveRange gelaufen sind
            {
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
        }

        public override void nextTick(int currentMoney, int currentScore, int carryCount, int scoutCount, int time)
        {
            buyCarrier();
        }

    }
}
