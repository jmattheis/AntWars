﻿using System;
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
    /// Der Player.
    /// </summary>
    class Player
    {
        /// <summary>
        /// Punkte vom Spieler
        /// </summary>
        public int Points { get; set; }

        /// <summary>
        /// Die Configuration vom Spieler
        /// </summary>
        public PlayerConfig PlayerConfig { get; set; }

        /// <summary>
        /// Der AI loader welcher instancen von der AI erstellt.
        /// </summary>
        public AILoader AILoader { get; set; }

        /// <summary>
        /// Eine AI Instance.
        /// </summary>
        public IAI AI { get; set; }

        /// <summary>
        /// Das momentane Geld vom Spieler.
        /// </summary>
        public int Money { get; set; }

        /// <summary>
        /// Die Anzahl von Scount auf dem Feld.
        /// </summary>
        public int ScoutCount { get; set; }

        /// <summary>
        /// Die Anzahl von carries auf dem Feld.
        /// </summary>
        public int CarryCount { get; set; }

        public Player(PlayerConfig config, AILoader aiLoader, int money)
        {
            PlayerConfig = config;
            AILoader = aiLoader;
            Money = money;
            ScoutCount = 0;
            CarryCount = 0;
        }

        /// <summary>
        /// Erhöht die Anzahl der Carries oder Scouts
        /// </summary>
        /// <param name="ant">Die neue Ameise</param>
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
