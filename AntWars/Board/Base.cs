using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntWars.Board
{
    /// <summary>
    /// Die Base hier "spawnen" die Ameisen, wird generell am rand des spielfeldes generiert.
    /// </summary>
    class Base : BoardObject
    {
        public Base(Player p)
        {
            Player = p;
        }
        public Player Player { get; set; }
    }
}
