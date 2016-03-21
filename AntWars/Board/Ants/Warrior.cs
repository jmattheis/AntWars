using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntWars.Board.Ants
{
    public class Warrior : Ant
    {
        public int AttackPower { get; internal set; }

        internal Warrior(int attackPower, Board board, Player owner, int viewRange, int inventory, int moveRange, int hp)
            : base(board, owner, viewRange, inventory, moveRange, hp)
        {
            AttackPower = attackPower;
        }

        public bool fight()
        {
            return false;
        }
    }
}
