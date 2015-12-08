using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AntWars.Board.Ants;

namespace AntWars.AIs.Converter.Classes
{
    class AIAnt : AIBoardObject
    {
        public AIAnt(Ant ant) : base(ant)
        {
            Owner = ant.Owner;
        }
        public Player Owner { get; private set; }

    }
}
