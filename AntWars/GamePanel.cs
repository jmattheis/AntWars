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
            setPlayernameInStatistic(config);
            setFormSize(config);
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
            // TODO sowas wie 'inferiorElement.Name == "ff000000"' kann doch mit 'inferiorElement == Color.Black' ausgetauscht werden
            // Das würde besser im code aussehen.

            Bitmap bitmap = new Bitmap(game.Conf.Game.boardWidth + 1, game.Conf.Game.boardHeigth + 1);

            foreach (BoardObject obj in boardObjects)
            {
                Color inferiorElement = bitmap.GetPixel(obj.Coords.X, obj.Coords.Y);
                setColor(obj, inferiorElement, bitmap);
            }

            bitmap = new Bitmap(bitmap, bitmap.Width * 4, bitmap.Height * 4);
            pb_Game.Image = bitmap;
        }

        private void setColor(BoardObject obj, Color inferiorElement, Bitmap bitmap)
        {
            if (obj.isCarry())
            {
                setColorCarry(obj, inferiorElement, bitmap);
            }
            else if (obj.isScout())
            {
                setColorScout(obj, inferiorElement, bitmap);
            }
            else if (obj.isSugar())
            {
                setColorSugar(obj, inferiorElement, bitmap);
            }
            else if (obj.isBase())
            {
                setColorBase(obj, inferiorElement, bitmap);
            }
            else if (obj.isSignal())
            {
                setColorSignal(obj, inferiorElement, bitmap);
            }
        }

        private void setColorCarry(BoardObject obj, Color inferiorElement, Bitmap bitmap)
        {
            if (((Ant)obj).Owner == game.Player1)
            {
                if (!string.IsNullOrEmpty(inferiorElement.Name) && inferiorElement == Color.Black) //wenn Sugar drunter ist
                    bitmap.SetPixel(obj.Coords.X, obj.Coords.Y, System.Drawing.Color.DarkGreen);
                else
                    bitmap.SetPixel(obj.Coords.X, obj.Coords.Y, System.Drawing.Color.Green);
            }
            else
            {
                if (!string.IsNullOrEmpty(inferiorElement.Name) && inferiorElement == Color.Black) //wenn Sugar drunter ist
                    bitmap.SetPixel(obj.Coords.X, obj.Coords.Y, System.Drawing.Color.DarkBlue);
                else
                    bitmap.SetPixel(obj.Coords.X, obj.Coords.Y, System.Drawing.Color.Blue);
            }
        }

        private void setColorScout(BoardObject obj, Color inferiorElement, Bitmap bitmap)
        {
            if (((Scout)obj).Owner == game.Player1)
            {
                if (!string.IsNullOrEmpty(inferiorElement.Name) && inferiorElement == Color.Black) //wenn Sugar drunter ist
                    bitmap.SetPixel(obj.Coords.X, obj.Coords.Y, System.Drawing.Color.DarkSeaGreen);
                else
                    bitmap.SetPixel(obj.Coords.X, obj.Coords.Y, System.Drawing.Color.SeaGreen);
            }
            else
            {
                if (!string.IsNullOrEmpty(inferiorElement.Name) && inferiorElement == Color.Black) //wenn Sugar drunter ist
                    bitmap.SetPixel(obj.Coords.X, obj.Coords.Y, System.Drawing.Color.DarkSlateBlue);
                else
                    bitmap.SetPixel(obj.Coords.X, obj.Coords.Y, System.Drawing.Color.SlateBlue);
            }
        }

        private void setColorSugar(BoardObject obj, Color inferiorElement, Bitmap bitmap)
        {
            switch (inferiorElement)
            {
                case (Color.Green): //Player1-Carry
                    bitmap.SetPixel(obj.Coords.X, obj.Coords.Y, System.Drawing.Color.DarkGreen);
                    break;
                case (Color.Blue): //Player2-Carry
                    bitmap.SetPixel(obj.Coords.X, obj.Coords.Y, System.Drawing.Color.DarkBlue);
                    break;
                case (Color.SeaGreen): //Player1-Scout
                    bitmap.SetPixel(obj.Coords.X, obj.Coords.Y, System.Drawing.Color.DarkSeaGreen);
                    break;
                case (Color.SlateBlue): //Player2-Scout
                    bitmap.SetPixel(obj.Coords.X, obj.Coords.Y, System.Drawing.Color.DarkSlateBlue);
                    break;
                default:
                    bitmap.SetPixel(obj.Coords.X, obj.Coords.Y, System.Drawing.Color.Black);
                    break;
            }
        }

        private void setColorBase(BoardObject obj, Color inferiorElement, Bitmap bitmap)
        {
            switch (inferiorElement)
            {
                case (Color.Green): //Player1-Carry
                    bitmap.SetPixel(obj.Coords.X, obj.Coords.Y, System.Drawing.Color.DarkGreen);
                    break;
                case (Color.Blue): //Player2-Carry
                    bitmap.SetPixel(obj.Coords.X, obj.Coords.Y, System.Drawing.Color.DarkBlue);
                    break;
                case (Color.SeaGreen): //Player1-Scout
                    bitmap.SetPixel(obj.Coords.X, obj.Coords.Y, System.Drawing.Color.DarkSeaGreen);
                    break;
                case (Color.SlateBlue): //Player2-Scout
                    bitmap.SetPixel(obj.Coords.X, obj.Coords.Y, System.Drawing.Color.DarkSlateBlue);
                    break;
                default:
                    bitmap.SetPixel(obj.Coords.X, obj.Coords.Y, System.Drawing.Color.Black);
                    break;
            }
        }

        private void setColorSignal(BoardObject obj, Color inferiorElement, Bitmap bitmap)
        {
            if (((Signal)obj).From == game.Player1)
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
            calcGameStatistics();
            print();
        }

        private void GamePanel_Load(object sender, EventArgs e)
        {
            loaded = true;
        }

        private void pb_Game_Click(object sender, EventArgs e)
        {

        }

        public void view(Config.Configuration config)
        {
            setPlayernameInStatistic(config);
            setFormSize(config);
            Show();
        }

        public void setFormSize(Config.Configuration config)
        {
            this.pb_Game.Width = config.Game.boardWidth * 4;
            this.pb_Game.Height = config.Game.boardHeigth * 4;
            Point statsLocation = new Point(config.Game.boardWidth * 4, 0);
            this.groupstats.Location = statsLocation;
            this.ClientSize = new Size(config.Game.boardWidth * 4 + this.groupstats.Width, config.Game.boardHeigth * 4);
            
        }

        private void calcGameStatistics()
        {
            // update timer
            if (game.Conf.Game.time > 0)
            {
                labeltimershow.Text = Convert.ToString(game.Conf.Game.time - (game.getCurrentTick() / 10));
            }
            else
            {
                labeltimershow.Text = Convert.ToString(game.getCurrentTick() / 10);
            }
            labeltimershow.Text = labeltimershow.Text + "s";
            
            // update player1
            labelplayer1pointsshow.Text = game.Player1.Points.ToString();
            labelplayer1moneyshow.Text = game.Player1.money.ToString();
            labelplayer1carriesshow.Text = game.Player1.carryCount.ToString();
            labelplayer1scoutsshow.Text = game.Player1.scoutCount.ToString();
            labelplayer1antsshow.Text = Convert.ToString(game.Player1.scoutCount + game.Player1.carryCount);

            // update player2
            labelplayer2pointsshow.Text = game.Player2.Points.ToString();
            labelplayer2moneyshow.Text = game.Player2.money.ToString();
            labelplayer2carriesshow.Text = game.Player2.carryCount.ToString();
            labelplayer2scoutsshow.Text = game.Player2.scoutCount.ToString();
            labelplayer2antsshow.Text = Convert.ToString(game.Player2.scoutCount + game.Player2.carryCount);

            // update sugar
            labelsugarshow.Text = game.Board.BoardObjects.getSugars().Count.ToString();
        }

        private void setPlayernameInStatistic(Config.Configuration config)
        {
            // set playernames in statistic
            if (config.Player1.playername != "")
            {
                groupplayer1.Text = config.Player1.playername;
            }
            if (config.Player2.playername != "")
            {
                groupplayer2.Text = config.Player2.playername;
            }
        }

        private void groupstats_Enter(object sender, EventArgs e)
        {

        }
    }
}
