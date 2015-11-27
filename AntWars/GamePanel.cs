using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AntWars.Board;
using AntWars.Board.Ants;

namespace AntWars
{
    public partial class GamePanel : Form
    {
        private Game game;
        private bool loaded = false;

        public GamePanel()
        {
            InitializeComponent();
        }

        public void start(Config.Configuration config)
        {
            game = new Game(config);
            game.start();
            Show();
        }

        public void startWithTestData()
        {
            Show();
            List<BoardObject> b = new List<BoardObject>();
            Carry ant = new Carry();
            ant.Coords = new Coordinates(50, 50);
            b.Add(ant);
            Carry ant2 = new Carry();
            ant2.Coords = new Coordinates(150, 50);
            b.Add(ant2);
            Carry ant3 = new Carry();
            ant3.Coords = new Coordinates(50, 150);
            b.Add(ant3);
            Carry ant4 = new Carry();
            ant4.Coords = new Coordinates(100, 50);
            b.Add(ant4);
            print(b);
        }

        public void print()
        {
            print(game.Board.BoardObjects);
        }

        private void print(List<BoardObject> boardObjects)
        {
            // TODO Carrier + scout einfügen "Ant" dafür weg
            // TODO was ist wenn welche übereinander sind
            // TODO signal anzeigen?
            // TODO pen als classen variable --> performance
            // TODO immer alles neu bauen? --> performance base sugar muss nicht immer neu gemacht werden
            Graphics gra = pb_Game.CreateGraphics();
            foreach (BoardObject obj in boardObjects)
            {
                System.Threading.Thread.Sleep(2000);
                if (obj.isAnt())
                {
                    Pen black = new Pen(System.Drawing.Color.Black);
                    gra.DrawRectangle(black, obj.Coords.X, obj.Coords.Y, 1, 1);
                }
                else if (obj.isSugar())
                {

                    Pen pen = new Pen(System.Drawing.Color.Red);
                    gra.DrawRectangle(pen, obj.Coords.X, obj.Coords.Y, 1, 1);
                }
                else if (obj.isBase())
                {
                    Base baseObject = (Base)obj;

                    if (baseObject.Player == new Player()) // TODO mit game player austauschen wenn das mit der config alles funtzt
                    {
                        Pen pen = new Pen(System.Drawing.Color.Blue);
                        gra.DrawRectangle(pen, obj.Coords.X, obj.Coords.Y, 1, 1);
                    }
                    else
                    {
                        Pen pen = new Pen(System.Drawing.Color.Green);
                        gra.DrawRectangle(pen, obj.Coords.X, obj.Coords.Y, 1, 1);
                    }
                }
                else
                {

                }

            }

        }

        private void timer_GameTick_Tick(object sender, EventArgs e)
        {
            game.nextTick();
            print();
        }

        private void GamePanel_Load(object sender, EventArgs e)
        {
            loaded = true;
        }

        private void pb_Game_Click(object sender, EventArgs e)
        {

        }
    }
}
