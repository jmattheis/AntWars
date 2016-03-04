using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntWars.Config
{
    public class GameConfig
    {
        /// <summary>
        /// Der minimale Zucker der auf dem Feld sein darf.
        /// </summary>
        public int SugarMin { get; set; }

        /// <summary>
        /// Der maximale Zucker der auf dem Feld sein darf.
        /// </summary>
        public int SugarMax { get; set; }

        /// <summary>
        /// Die minimale Anzahl an Zucker der auf dem Feld sein darf.
        /// </summary>
        public int SugarAmountMin { get; set; }

        /// <summary>
        /// Die maximale Anzahl an Zucker der auf dem Feld sein darf.
        /// </summary>
        public int SugarAmountMax { get; set; }

        /// <summary>
        /// Die Breite des Boards
        /// </summary>
        public int BoardWidth { get; set; }

        /// <summary>
        /// Die Höhe des Boards
        /// </summary>
        public int BoardHeight { get; set; }

        /// <summary>
        /// Das Startmoney von beiden Spielern
        /// </summary>
        public int StartMoney { get; set; }

        /// <summary>
        /// Die Ticks per seconds.
        /// </summary>
        public int Ticks { get; set; }

        /// <summary>
        /// Die maximale Anzahl an Ticks bevor das Spiel zuende ist. 0 für unendlich.
        /// </summary>
        public int MaxTicks { get; set; }

        /// <summary>
        /// Die Anzahl an Punkten die ein Spieler braucht um zu gewinnen.
        /// </summary>
        public int Points { get; set; }
    }
}
