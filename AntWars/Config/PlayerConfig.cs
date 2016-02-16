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
        public string playername { get; set; }
        public int scoutViewRange { get; set;}
        public int carryViewRange { get; set;}
        public int scoutMoveRange { get; set;}
        public int carryMoveRange { get; set;}
        public int scoutInventory { get; set;}
        public int carryInventory { get; set;}
        public int scoutSpeed { get; set;}
        public int carrySpeed { get; set;}
        [XmlIgnore]
        public int scoutCost { get; set;}
        [XmlIgnore]
        public int carryCost { get; set; }

        public PlayerConfig()
        {
            playername = "Player";
            scoutViewRange = 1;
            carryViewRange = 1;
            scoutMoveRange = 1;
            carryMoveRange = 1;
            scoutInventory = 1;
            carryInventory = 1;
            scoutSpeed = 1;
            carrySpeed = 1;
        }
    }
}
