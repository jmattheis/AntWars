using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AntWars.Config;
using AntWars.Board.Ants;
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
        public AILoader AILoader { get; set; }
        public IAI AI { get; set; }

        //TODO beim erstellen/laden einer Config müssen Kosten neu berechnet werden
        public int ScoutSpeed { get; set; }
        public int CarrySpeed { get; set; }
        public int CurrentScore { get; set; }
        public int Money { get; set; }
        public int ScoutCount { get; set; }
        public int CarryCount { get; set; }

        public Player(PlayerConfig config, AILoader aiLoader, int money)
        {
            PlayerConfig = config;
            AILoader = aiLoader;
            Money = money;
            ScoutCount = 0;
            CarryCount = 0;
            CurrentScore = 0;
        }

        public void setScoutAndCarryPixelRange(int BoardHeight, int BoardWidth)
        {
            // MoveRange berechnet sich aus der config und der jeweiligen Feldgröße

            this.PlayerConfig.ScoutPixelRange = this.PlayerConfig.ScoutMoveRange * BoardHeight * BoardWidth / 100;
            this.PlayerConfig.CarryPixelRange = this.PlayerConfig.CarryMoveRange * BoardHeight * BoardWidth / 100;
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
