using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Drawing;
using AntWars.Config;
using AntWars.Board;
namespace AntWars
{
    /// <summary>
    /// Das Game startpunkt für alles was nicht visuell ist.
    /// Händelt das Board und enthält die Globale Configuration.
    /// </summary>
    class Game
    {
        public Board.Board Board { get; set; }
        public Player Player1 { get; set; }
        public Player Player2 { get; set; }
        public Configuration Conf { get; set; }
        public PictureBox GamePanel { get; set; }
        private bool started = false;
        private int currentTick = 0;

        public Game(Configuration config)
        {
            Player1 = new Player();
            Player2 = new Player();
            Player1.PlayerConfig = config.Player1;
            Player2.PlayerConfig = config.Player2;
            Player1.AI = new AI.Player1();
            Player1.AI.Game = this;
            Player2.AI = new AI.Player2();
            Conf = config;
            Player2.AI.Game = this;
        }

        public void start()
        {
            Board = new Board.Board(Conf);
            Board.nullTick(Player1, Player2);
            started = true;
        }

        public void nextTick()
        {
            currentTick++;
            Board.nextTick();
        }

        public bool isStarted()
        {
            return started;
        }

        public void print()
        {
            
            
        }   
        
    }
}
