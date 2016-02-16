using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AntWars.Config;
using AntWars.AI;
using AntWars.Board.Ants;

namespace AntWars
{
    /// <summary>
    /// Der Player, enthält die AU, sein momentanes geld, den momentanen score und die PlayerConfig.
    /// </summary>
    class Player
    {
        public Player()
        {
            scoutCount = 0;
            carryCount = 0;
        }
        public int Points { get; set; }
        public PlayerConfig PlayerConfig { get; set; }
        public IAI AI { get; set; }
        public int currentScore = 0;
        public int money = 0;
<<<<<<< HEAD
        //TODO beim erstellen/laden einer Config müssen Kosten neu berechnet werden
        public int scoutCost { get; set; }
        public int carryCost { get; set; }
        public int scoutSpeed { get; set; }
        public int carrySpeed { get; set; }
=======
        public int scoutCount { get; set; }
        public int carryCount { get; set; }
>>>>>>> 21dee2ac99c6b57c2f6e5fbe91b1fca10c5c804c


        public void incrementAnts(Ant ant)
        {
            if (ant.isCarry())
                carryCount++;
            else if (ant.isScout())
                scoutCount++;
        }
    }
}
