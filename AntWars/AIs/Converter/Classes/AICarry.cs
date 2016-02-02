using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AntWars.Board.Ants;

namespace AntWars.AIs.Converter.Classes
{
    public class AICarry : AIAnt
    {
        internal AICarry(Carry carry, Board.Board board)
            : base(carry, board)
        {

        }
    }
}
