using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AntWars.Board;
using AntWars.Board.Ants;
using AntWars.AIs.Converter.Classes;

namespace AntWars.AI
{
    interface IAI
    {
        void nextTick();
        void antTick(Ant ant, List<AIBoardObject> view);
        Game Game {set;}
        Player Player { set;}
    }
}
