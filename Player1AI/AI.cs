﻿using System;
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
        public override string Playername
        {
            get { return "Random"; }
        }
        public override void nextTick()
        {
            buyCarrier(1, 1, 1);
            buyScout(1, 1, 1);
        }
    }

    public class AIAnt : AIAntBase
    {
        private Random rand = new Random();
        public override void antTick(BoardObject[] view)
        {
            Scout scout = Ant as Scout;
            if(scout != null)
            {
                // its a Scout
                scout.notifyOtherAnts(new Coordinates(2, 4));
            }

            // Zucker aufheben Test
            Ant.pickUpSugar();
            // RANDOM FTW
            switch (rand.Next(0, 7))
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
                case 4:
                    Ant.moveLowerLeft();
                    break;
                case 5:
                    Ant.moveLowerRight();
                    break;
                case 6:
                    Ant.moveUpperLeft();
                    break;
                case 7:
                    Ant.moveUpperRight();
                    break;


            }
        }

        public override void notify(Coordinates coords)
        {
            // nothing todo hier.
        }
    }
}
