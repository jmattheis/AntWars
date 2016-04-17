using AntWars.AI;
using AntWars.Board;
using AntWars.Board.Ants;
using System;
using System.Collections.Generic;

namespace PlayerAI {
    public class AI : AIBase {
        public override string Playername {
            get { return "Random"; }
        }
        public override void nextTick() {
            buyWarrior(1, 10, 1, 3, 10);
        }
    }

    public class AIAnt : AIAntBase {
        private Random rand = new Random();
        public override void antTick(BoardObject[] view) {

            if (Ant.isScout()) {
                // its a Scout
                HashSet<Coordinates> set = new HashSet<Coordinates>();
                set.Add(new Coordinates(2, 4));
                Ant.notifyOtherAnts(set);
            }

            if (Ant.isWarrior()) {
                for (int i = 0; i < view.Length; i++) {
                    BoardObject bObject = view[i];
                    if (bObject != Ant && bObject.isAnt() && bObject.Coords.isInRange(1, Ant.Coords)) {
                        Ant.fight(bObject as Ant);
                        break;
                    }
                }
            }

            // Zucker aufheben Test
            Ant.pickUpSugar();
            // RANDOM FTW
            switch (rand.Next(0, 7)) {
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

        public override void notify(HashSet<Coordinates> coords) {
            // nothing todo hier.
        }
    }
}
