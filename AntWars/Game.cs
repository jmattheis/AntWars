using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Drawing;
using AntWars;
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
        public Config Conf { get; set; }
        private int currentTick = 0;

        public Game(Config config)
        {
            int startMoney = config.StartMoney;
                    
<<<<<<< HEAD
            Player1 = new Player(config.Player1, new AILoader(config.Player1.AIPath), startMoney);
            Player2 = new Player(config.Player2, new AILoader(config.Player2.AIPath), startMoney);

=======
            Player1 = new Player(new AILoader(config.Player1AIPath), startMoney);
            Player2 = new Player(new AILoader(config.Player2AIPath), startMoney);
>>>>>>> origin/master
            initAI(Player1);
            initAI(Player2);

            Conf = config;
        }

        private void initAI(Player player)
        {
            player.AI = player.AILoader.createAIInstance(this, player);
        }

        /// <summary>
        /// Initialisiert das Board.
        /// </summary>
        public void start()
        {
            Board = new Board.Board(Conf);
            Board.nullTick(Player1, Player2);
        }

        /// <summary>
        /// Ruft Ai auf.
        /// </summary>
        public void nextTick()
        {
            currentTick++;
            Board.nextTick();
        }

        /// <summary>
        /// Der momentane Tick.
        /// </summary>
        /// <returns></returns>
        public int getCurrentTick()
        {
            return currentTick;
        }
    }
}
