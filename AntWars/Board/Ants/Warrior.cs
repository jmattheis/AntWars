using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntWars.Board.Ants {

    public class Warrior : Ant {

        internal Warrior(int attackPower, Board board, Player owner, int viewRange, int inventory, int moveRange, int hp)
            : base(board, owner, viewRange, inventory, moveRange, hp, attackPower) { }

        public override bool fight(ControllableBoardObject target) {

            if (!TookAction && target.Coords.isInRange(1, Coords)) {
                target.takeDamage(AttackPower);
                TookAction = true;
                return true;
            }

            return false;
        }

    }
}
