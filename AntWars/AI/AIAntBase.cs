using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AntWars.Board;
using AntWars.Board.Ants;

namespace AntWars.AI
{
    public abstract class AIAntBase : IAIAnt
    {
        public Ant Ant { get; internal set; }

        public abstract void antTick(BoardObject[] view);
    }
}
