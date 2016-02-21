using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntWars.Board
{
    /// <summary>
    /// ZUCKEERRRR
    /// </summary>
    public class Sugar : BoardObject
    {
        public int Amount { get; internal set; }

        public Sugar(Coordinates coords) : base(coords) { }
    }
}