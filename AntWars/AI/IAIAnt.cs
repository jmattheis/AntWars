using AntWars.Board;
using AntWars.Board.Ants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntWars.AI
{
    public interface IAIAnt
    {
        void antTick(BoardObject[] view);
    }
}
