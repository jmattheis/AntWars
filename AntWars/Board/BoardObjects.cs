using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AntWars.Board.Ants;

namespace AntWars.Board
{
    class BoardObjects
    {
        private List<BoardObject> boardObjects = new List<BoardObject>();
        private List<Ant> ants = new List<Ant>();
        private List<Signal> signals = new List<Signal>();
        private List<Base> bases = new List<Base>();
        private List<Sugar> sugars = new List<Sugar>();
        public void add(BoardObject boardObject)
        {
            boardObjects.Add(boardObject);
            if (boardObject.isAnt())
            {
                ants.Add((Ant) boardObject);
            }
            else if (boardObject.isSignal())
            {
                signals.Add((Signal)boardObject);
            }
            else if (boardObject.isBase())
            {
                bases.Add((Base)boardObject);
            }
            else if (boardObject.isSugar())
            {
                sugars.Add((Sugar)boardObject);
            }
        }

    }
}
