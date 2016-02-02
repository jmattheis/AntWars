using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntWars.Board.Ants
{
    /// <summary>
    /// Die Ameise.
    /// </summary>
    internal class Ant : BoardObject
    {
        
        public Player Owner { get; set; }
        public int Inventory { get; set; }
        public int ViewRange { get; set; }
    }

}
