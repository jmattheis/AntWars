using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntWars.Config
{
    /// <summary>
    /// Die Configuration enthält die PlayerConfiguration und die GameConfiguration
    /// </summary>
    class Configuration
    {
        //  TODO Game config
        public int BoardWidth { get; set; }
        public int BoardHeight { get; set; }
        public int StartMoney { get; set; }
        public PlayerConfig Player1 { get; set; }
        public PlayerConfig Player2 { get; set; }
    }
}
