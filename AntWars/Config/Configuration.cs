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
    public class Configuration
    {
        public GameConfig Game { get; set; }
        public PlayerConfig Player1 { get; set; }
        public PlayerConfig Player2 { get; set; }
    }
}
