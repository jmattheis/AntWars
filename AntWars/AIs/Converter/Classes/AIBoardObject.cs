using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AntWars.Board;
using AntWars.AIs.Converter.Classes;
using AntWars.Board.Ants;

namespace AntWars.AIs.Converter.Classes
{
    public class AIBoardObject
    {

        internal AIBoardObject(BoardObject boardObject)
        {
            Coords = boardObject.Coords;
        }

        public Coordinates Coords { get; private set; }

        public bool isAnt()
        {
            return GetType() == typeof(AIAnt) || isScout() || isCarry();
        }

        public bool isSugar()
        {
            return GetType() == typeof(AISugar);
        }

        public bool isBase()
        {
            return GetType() == typeof(AIBase);
        }

        public bool isCarry()
        {
            return GetType() == typeof(AICarry);
        }

        public bool isScout()
        {
            return GetType() == typeof(AIScout);
        }

        public bool isSignal()
        {
            return GetType() == typeof(AISignal);
        }
    }
}
