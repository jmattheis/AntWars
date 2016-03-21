using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AntWars;
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
        public double Money { get; private set; }

        /// <summary>
        /// Die Anzahl von Scount auf dem Feld.
        /// </summary>
        public int ScoutCount { get; set; }

        /// <summary>
        /// Die Anzahl der Warriors auf dem Feld.
        /// </summary>
        public int WarriorCount { get; set; }

        /// <summary>
        /// Die Anzahl von Carries auf dem Feld.
        /// </summary>
        public int CarryCount { get; set; }

        public Player(AILoader aiLoader, double money)
        {
            AILoader = aiLoader;
            Money = money;
            ScoutCount = 0;
            CarryCount = 0;
        }

        /// <summary>
        /// Erhöht die Anzahl der Ameisen eines Ameisentyps um eins.
        /// </summary>
        /// <param name="ant">Die neue Ameise.</param>
        public void incrementAnts(Ant ant)
        {
            if (ant.isCarry())
            {
                CarryCount++;
            }
            else if (ant.isScout())
            {
                ScoutCount++;
            }
            else if (ant.isWarrior())
            {
                WarriorCount++;
            }
            else
            {
                throw new RuntimeException("Unknown ant type.");
            }
        }

        /// <summary>
        /// Verringert die Anzahl der Ameisen eines Ameisentyps um eins.
        /// </summary>
        /// <param name="ant">Die zu verringernde Ameise.</param>
        public void decreaseAnts(Ant ant)
        {
            if (ant.isCarry())
            {
                CarryCount--;
            }
            else if (ant.isScout())
            {
                ScoutCount--;
            }
            else
            {
                throw new RuntimeException("Unknown ant type.");
            }
        }

        /// <summary>
        /// Zieht dem Spieler Geld ab.
        /// </summary>
        /// <param name="amount">Die Anzahl an Geld</param>
        /// <returns>true wenn der Spieler genügend Geld hat andernfalls false</returns>
        public bool pay(double amount)
        {
            if(Money >= amount)
            {
                Money -= amount;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Gibt dem Spieler Geld.
        /// </summary>
        /// <param name="amount">Die Anzahl an Geld</param>
        public void addMoney(double amount)
        {
            if(amount < 0) { throw new ArgumentException("Money may not be less than 0"); }
            Money += amount;
        }
    }
}
