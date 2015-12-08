using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AntWars.Board;

namespace AntWars.AIs.Converter.Classes
{
    class AIBoardObject
    {
        public AIBoardObject(BoardObject boardObject)
        {
            Coords = boardObject.Coords;
        }
        public Coordinates Coords { get; private set; }
    }
}
