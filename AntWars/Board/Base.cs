using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntWars
{
    class Base : BoardObject
    {
        public Base(Player p)
        {
            Player = p;
        }
        public Player Player { get; set; }
    }
}
