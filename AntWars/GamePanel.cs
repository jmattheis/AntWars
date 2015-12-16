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
            timer_GameTick.Start();
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
            Sugar sugar = new Sugar();
            sugar.Coords = new Coordinates(50, 150);
            b.Add(sugar);
            b.Add(ant4);
            print(b);
        }

        public void print()
        {
            print(game.Board.BoardObjects.get());
        }

        private void print(IList<BoardObject> boardObjects)
        {
            // TODO was ist wenn welche übereinander sind
            // TODO signal anzeigen?
            // TODO immer alles neu bauen? --> performance base sugar muss nicht immer neu gemacht werden

            //Graphics gra = pb_Game.CreateGraphics();

            Bitmap bitmap = new Bitmap(this.game.Conf.Game.boardWidth + 1, this.game.Conf.Game.boardHeigth + 1);

            foreach (BoardObject obj in boardObjects)
            {
                Color inferiorElement = bitmap.GetPixel(obj.Coords.X, obj.Coords.Y);
                if (obj.isCarry())
                {
                    if (true)//((Carry)obj).Owner == this.game.Player1) //TODO
                    {
                        if (!string.IsNullOrEmpty(inferiorElement.Name) && inferiorElement.Name == "ff000000") //wenn Sugar drunter ist
                            bitmap.SetPixel(obj.Coords.X, obj.Coords.Y, System.Drawing.Color.DarkGreen);
                        else
                            bitmap.SetPixel(obj.Coords.X, obj.Coords.Y, System.Drawing.Color.Green);
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(inferiorElement.Name) && inferiorElement.Name == "ff000000") //wenn Sugar drunter ist
                            bitmap.SetPixel(obj.Coords.X, obj.Coords.Y, System.Drawing.Color.DarkBlue);
                        else
                            bitmap.SetPixel(obj.Coords.X, obj.Coords.Y, System.Drawing.Color.Blue);
                    }
                }
                else if (obj.isScout())
                {
                    if (true)//((Scout)obj).Owner == this.game.Player1) //TODO
                    {
                        if (!string.IsNullOrEmpty(inferiorElement.Name) && inferiorElement.Name == "ff000000") //wenn Sugar drunter ist
                            bitmap.SetPixel(obj.Coords.X, obj.Coords.Y, System.Drawing.Color.DarkSeaGreen);
                        else
                            bitmap.SetPixel(obj.Coords.X, obj.Coords.Y, System.Drawing.Color.SeaGreen);
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(inferiorElement.Name) && inferiorElement.Name == "ff000000") //wenn Sugar drunter ist
                            bitmap.SetPixel(obj.Coords.X, obj.Coords.Y, System.Drawing.Color.DarkSlateBlue);
                        else
                            bitmap.SetPixel(obj.Coords.X, obj.Coords.Y, System.Drawing.Color.SlateBlue);
                    }
                }
                else if (obj.isSugar())
                {
                    switch (inferiorElement.Name)
                    {
                        case ("ff008000"): //Player1-Carry
                            bitmap.SetPixel(obj.Coords.X, obj.Coords.Y, System.Drawing.Color.DarkGreen);
                            break;
                        case ("ff0000ff"): //Player2-Carry
                            bitmap.SetPixel(obj.Coords.X, obj.Coords.Y, System.Drawing.Color.DarkBlue);
                            break;
                        case ("ff2e8b57"): //Player1-Scout
                            bitmap.SetPixel(obj.Coords.X, obj.Coords.Y, System.Drawing.Color.DarkSeaGreen);
                            break;
                        case ("ff6a5acd"): //Player2-Scout
                            bitmap.SetPixel(obj.Coords.X, obj.Coords.Y, System.Drawing.Color.DarkSlateBlue);
                            break;
                        case ("0"): //nichts
                        case ("ff800080"): //Player2-Signal
                        case ("ffa52a2a"): //Player1-Signal
                            bitmap.SetPixel(obj.Coords.X, obj.Coords.Y, System.Drawing.Color.Black);
                            break;
                    }

                }
                else if (obj.isBase())
                {
                    Base baseObject = (Base)obj;

                    if (baseObject.Player == new Player()) // TODO mit game player austauschen wenn das mit der config alles funtzt
                    {
                        bitmap.SetPixel(obj.Coords.X, obj.Coords.Y, System.Drawing.Color.GreenYellow);
                    }
                    else
                    {
                        bitmap.SetPixel(obj.Coords.X, obj.Coords.Y, System.Drawing.Color.BlueViolet);
                    }
                }
                else if (obj.isSignal())
                {
                    if (true)//((Signal)obj).From == this.game.Player1) //TODO
                    {
                        if (string.IsNullOrEmpty(inferiorElement.Name))
                            bitmap.SetPixel(obj.Coords.X, obj.Coords.Y, System.Drawing.Color.Brown);
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(inferiorElement.Name))
                            bitmap.SetPixel(obj.Coords.X, obj.Coords.Y, System.Drawing.Color.Purple);
                    }
                }
            }
            bitmap = new Bitmap(bitmap, bitmap.Width * 4, bitmap.Height * 4);
            pb_Game.Image = bitmap;
        }

        private void testPrint()
        {
            Color test = ((Bitmap)this.pb_Game.Image).GetPixel(50, 150);
            switch (test.Name)
            {
                case ("ffff0000"):
                    //Sugar
                    break;
                case ("ff808080"):
                    //Scout
                    break;
                case ("ff000000"):
                    //Carry
                    break;
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
