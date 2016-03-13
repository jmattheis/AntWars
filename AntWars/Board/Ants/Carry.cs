using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntWars.Board.Ants
{
    public class Carry : Ant
    {
        internal Carry(Board board, Player owner, int viewRange, int inventory)
            : base(board, owner, viewRange, inventory)
        { }
    }
}
