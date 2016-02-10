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
using AntWars.AI;

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
            int startMoney = config.Game.StartMoney;
                    
            Player1 = new Player(config.Player1, new AILoader(config.Player1.AIPath), startMoney);
            Player2 = new Player(config.Player2, new AILoader(config.Player2.AIPath), startMoney);
            initAI(Player1);
            initAI(Player2);

            Conf = config;
        }

        private void initAI(Player player)
        {
            player.AI = player.AILoader.createAIInstance(this, player);
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

        public int getCurrentTick()
        {
            return currentTick;
        }
        
    }
}
