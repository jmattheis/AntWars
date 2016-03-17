using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Reflection;
using AntWars.Exception;
using AntWars.Helper;

namespace AntWars
{
    public class Config
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
        public double StartMoney { get; set; }

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

        /// <summary>
        /// Pfad zur AI von Spieler 1.
        /// </summary>
        public String Player1AIPath { get; set; }

        /// <summary>
        /// Pfad zur AI von Spieler 2.
        /// </summary>
        public String Player2AIPath { get; set; }

        /// <summary>
        /// Pfad zur gesicherten Config
        /// </summary>
        [XmlIgnore]
        public String GamePath { get; set; }

        public Config()
        {
            // set sizes to a quarter of screen resolution
            BoardHeight = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height / 8;
            BoardWidth = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width / 8;
            // set standard values
            SugarMin = 5;
            SugarMax = 20;
            SugarAmountMin = 1;
            SugarAmountMax = 5;
            StartMoney = 20;
            Ticks = 10;
            MaxTicks = 5000;
            Points = 100;
        }

        public static Config loadConfig(String path)
        {
            return Utils.deserializeConfig(path);
        }

        public bool isNeededPathGame()
        {
            return GamePath == null;
        }

        public void saveConfig()
        {
            Utils.saveConfigToFile(this);
        }
    }
}
