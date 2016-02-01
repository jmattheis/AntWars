using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AntWars.Config
{
    public class PlayerConfig
    {
        public string PlayerName { get; set; }
        public int ScoutViewRange { get; set; }
        public int CarryViewRange { get; set; }
        public int ScoutMoveRange { get; set; }
        public int CarryMoveRange { get; set; }
        public int ScoutInventory { get; set; }
        public int CarryInventory { get; set; }
        public int ScoutSpeed { get; set; }
        public int CarrySpeed { get; set; }
        public String AIPath { get; set; }
        [XmlIgnore]
        public int ScoutCost { get; set; }
        [XmlIgnore]
        public int CarryCost { get; set; }

        public PlayerConfig()
        {
            PlayerName = "Player";
            ScoutViewRange = 1;
            CarryViewRange = 1;
            ScoutMoveRange = 1;
            CarryMoveRange = 1;
            ScoutInventory = 1;
            CarryInventory = 1;
            ScoutSpeed = 1;
            CarrySpeed = 1;
        }
    }
}
