using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AntWars.Board.Ants;

namespace AntWars.Board
{
    /// <summary>
    /// Das BoardObject der startpunkt für alles was auf dem board ist.
    /// </summary>
    class BoardObject
    {
        public Coordinates Coords { get; set; }
        public bool signalPlayer1 { get; set; }
        public bool signalPlayer2 { get; set; }

        public bool isAnt()
        {
            return GetType() == typeof(Ant);
        }

        public bool isSugar()
        {
            return GetType() == typeof(Sugar);
        }

        public bool isBase()
        {
            return GetType() == typeof(Base);
        }
    }
}
