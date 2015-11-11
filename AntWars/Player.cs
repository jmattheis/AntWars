using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AntWars.Config;
using AntWars.AI;

namespace AntWars
{
    /// <summary>
    /// Der Player, enthält die AU, sein momentanes geld, den momentanen score und die PlayerConfig.
    /// </summary>
    class Player
    {
        public int Points { get; set; }
        public PlayerConfig PlayerConfig { get; set; }
        public IAI AI { get; set; }
        public int currentScore = 0;
        public int money = 0;

    }
}
