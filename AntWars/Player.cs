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
    /// Der Player, wird an einer GUID identifiziert enthält die AU, sein momentanes geld, den momentanen score und die PlayerConfig.
    /// </summary>
    class Player
    {
        private Guid guid = Guid.NewGuid();

        public int Points { get; set; }
        public PlayerConfig PlayerConfig { get; set; }
        public IAI AI { get; set; }
        public int currentScore = 0;
        public int money = 0;

        public override bool Equals(System.Object obj)
        {
            if (obj == null)
            {
                return false;
            }

            Player p = obj as Player;
            if ((System.Object)p == null)
            {
                return false;
            }

            // Return true if the fields match:
            return guid == p.guid;
        }

        public bool Equals(Player p)
        {
            // If parameter is null return false:
            if ((object)p == null)
            {
                return false;
            }

            // Return true if the fields match:
            return guid == p.guid;
        }

        public override int GetHashCode()
        {
            return guid.GetHashCode();
        }
    }
}
