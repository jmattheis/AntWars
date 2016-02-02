using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AntWars.Board.Ants;

namespace AntWars.AIs.Converter.Classes
{
    public class AIScout : AIAnt
    {
        internal AIScout(Scout scout, Board.Board board)
            : base(scout, board)
        {

        }
    }
}
