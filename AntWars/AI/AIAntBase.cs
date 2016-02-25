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
        public MovableAnt Ant { get; internal set; }
        internal Config.GameConfig Conf { get; set; }
        public int BoardWidth { get { return Conf.BoardWidth; } }
        public int BoardHeight { get { return Conf.BoardHeight; } }
        public abstract void antTick(BoardObject[] view);
    }
}
