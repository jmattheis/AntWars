using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AntWars.Config;
using AntWars.Board.Ants;

namespace AntWars
{
    /// <summary>
    /// Der Player, enthält die AU, sein momentanes geld, den momentanen score und die PlayerConfig.
    /// </summary>
    public class Player
    {
        public int Points { get; set; }
        public PlayerConfig PlayerConfig { get; set; }
        public AIs.AI AI { get; set; }
        public int CurrentScore { get; set; }
        public int Money { get; set; }
        public int ScoutCount { get; set; }
        public int CarryCount { get; set; }

        public Player()
        {
            ScoutCount = 0;
            CarryCount = 0;
            Money = 0;
            CurrentScore = 0;
        }
        
        public void incrementAnts(Ant ant)
        {
            if (ant.isCarry())
            {
                CarryCount++;
            } else if(ant.isScout())
            {
                ScoutCount++;
            } else
            {
                throw new RuntimeException("Unknown ant type.");
            }    
        }
    }
}
