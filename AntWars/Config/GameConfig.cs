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

        /// <summary>
        /// Pfad zur AI von Spieler 1.
        /// </summary>
        public String Player1AIPath { get; set; }

        /// <summary>
        /// Pfad zur AI von Spieler 2.
        /// </summary>
        public String Player2AIPath { get; set; }

        public String GamePath { get; set; }

        public static GameConfig loadConfig(String path)
        {
            return (GameConfig)Utils.deserializeConfig(path);
        }

        public static GameConfig newConfig()
        {
            GameConfig config = new GameConfig();

            // set sizes to a quarter of screen resolution
            config.BoardHeight = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height / 8;
            config.BoardWidth = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width / 8;
            // set standard values
            config.SugarMin = 5;
            config.SugarMax = 20;
            config.SugarAmountMin = 1;
            config.SugarAmountMax = 5;
            config.StartMoney = 20;
            config.Ticks = 10;
            config.MaxTicks = 5000;
            config.Points = 100;

            return config;
        }

        public bool isNeededPathGame()
        {
            return GamePath == null;
        }

        public void saveConfig()
        {
            FileStream file = new FileStream(GamePath, FileMode.Create);
            Utils.xmlSerializer.Serialize(file, this);
            file.Close();
        }
    }
}
