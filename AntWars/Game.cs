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
            Player2.AI = new AI.Player2();
        }

        public void start()
        {
            Board = new Board.Board(Conf, GamePanel);
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
            foreach (BoardObject obj in Board.BoardObjects)
            {
                if (obj.isAnt())
                {
                    Graphics gra = GamePanel.CreateGraphics();
                    Pen pen = new Pen(System.Drawing.Color.Black);
                    gra.DrawEllipse(pen, obj.Coords.X, obj.Coords.Y, 1, 1);
                }
                else if (obj.isSugar())
                {
                    Graphics gra = GamePanel.CreateGraphics();
                    Pen pen = new Pen(System.Drawing.Color.Red);
                    gra.DrawEllipse(pen, obj.Coords.X, obj.Coords.Y, 1, 1);
                }
                else if (obj.isBase())
                {
                    Base baseObject = (Base)obj;

                    Graphics gra = GamePanel.CreateGraphics();
                    if (baseObject.Player == Player1)
                    {
                        Pen pen = new Pen(System.Drawing.Color.Blue);
                        gra.DrawEllipse(pen, obj.Coords.X, obj.Coords.Y, 1, 1);
                    }
                    else
                    {
                        Pen pen = new Pen(System.Drawing.Color.Green);
                        gra.DrawEllipse(pen, obj.Coords.X, obj.Coords.Y, 1, 1);
                    }
                }
                else
                {

                }

            }
        }   
        
    }
}
