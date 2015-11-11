using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AntWars.Board;
using AntWars.Board.Ants;

namespace AntWars.AI
{
    interface IAI
    {
        void nextTick();
        void antTick(Ant ant, List<BoardObject> view);
    }
}
