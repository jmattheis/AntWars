using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
namespace AntWars
{
    class Game
    {
        public Board Board { get; set; }

        public Game()
        {
            // XML read
            // PLayer set
            Board = new Board();
            Board.nullTick();
        }

        public Player player1 { get; set; }
        public Player player2 { get; set; }
        public Timer timer { get; set; }
    }
}
