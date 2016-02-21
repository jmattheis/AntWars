﻿using System;
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
    public class BoardObject
    {
        public Coordinates Coords { get; protected set; }

        public BoardObject(Coordinates coords)
        {
            Coords = coords;
        }

        public bool isAnt()
        {
            return GetType() == typeof(Ant) || isScout() || isCarry();
        }

        public bool isSugar()
        {
            return GetType() == typeof(Sugar);
        }

        public bool isBase()
        {
            return GetType() == typeof(Base);
        }

        public bool isCarry()
        {
            return GetType() == typeof(Carry);
        }

        public bool isScout()
        {
            return GetType() == typeof(Scout);
        }

        public bool isSignal()
        {
            return GetType() == typeof(Signal);
        }
    }
}
