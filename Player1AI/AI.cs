using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AntWars.Board;
using AntWars.Board.Ants;
using AntWars.AI;

namespace PlayerAI
{
    public class AI : AIBase
    {
        public override void nextTick()
        {
            buyCarrier(5,5);
        }
    }

    public class AIAnt : AIAntBase
    {
        private Random rand = new Random();
        public override void antTick(BoardObject[] view)
        {
            // Zucker aufheben Test
            Ant.pickUpSugar();
            // RANDOM FTW
            switch (rand.Next(0, 4))
            {
                case 1:
                    Ant.moveDown();
                    break;
                case 2:
                    Ant.moveLeft();
                    break;
                case 3:
                    Ant.moveRight();
                    break;
                case 0:
                    Ant.moveUp();
                    break;

            }
        }
    }
}
