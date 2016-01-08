using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntWars.Board.Ants
{
    enum Direction
    {
        LEFT, RIGHT, UP, DOWN
    }
    /// <summary>
    /// Die Ameise.
    /// </summary>
    class Ant : BoardObject
    {
        
        public Player Owner { get; set; }
        public int Inventory { get; set; }
        public int ViewRange { get; set; }
        public int UnitsGone { get; set; }
        
        public void move(Direction d)
        {
            // TODO move
        }

        public void recall()
        {
            // TODO goto base
        }

        public void pickup()
        {
            // pick something from the current coordinates 
        }
    }

}
