using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using AntWars.Board;
using AntWars.Board.Ants;
using AntWars.Helper;

namespace AntWars
{
    partial class GamePanel : Form
    {
        private Game game;
        private Multimedia.Timer timer = new Multimedia.Timer();

        public GamePanel()
        {
            InitializeComponent();
        }

        public void start(Config.GameConfig config)
        {
            setPlayernameInStatistic(config);
            setFormSize(config);
            game = new Game(config);
            game.start();
            initTimer(config.Ticks);
            Show();
        }

        public void stop()
        {
            timer.Stop();
        }

        private void initTimer(int period)
        {
            timer.Period = Convert.ToInt32(1000 / Convert.ToDecimal(period));
            timer.Resolution = 1;
            timer.Tick += new EventHandler(timer_GameTick_Tick);
            timer.Start();
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

            Bitmap bitmap = new Bitmap(game.Conf.BoardWidth, game.Conf.BoardHeight);

            foreach (BoardObject obj in boardObjects)
            {
                Color inferiorElement = bitmap.GetPixel(obj.Coords.X, obj.Coords.Y);
                if (obj.isCarry())
                {
                    if (((Ant)obj).Owner == game.Player1)
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
                    if (((Scout)obj).Owner == game.Player1)
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

                    if (baseObject.Player == game.Player1)
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
            }
            bitmap = new Bitmap(bitmap, bitmap.Width * 4, bitmap.Height * 4);
            pb_Game.Image = bitmap;
        }

        private void timer_GameTick_Tick(object sender, EventArgs e)
        {
            game.nextTick();
            try
            {
                this.Invoke((MethodInvoker)delegate
                {
                    calcGameStatistics();
                    print();
                });
            }
            catch (System.Exception) { } // passiert halt, da es in einem anderen thread ausgeführt wird und nicht mitbekommt das die form geschlossen wird.
            checkWinningConditions();
        }

        public void view(Config.GameConfig config)
        {
            setPlayernameInStatistic(config);
            setFormSize(config);
            Show();
        }

        public void setFormSize(Config.GameConfig config)
        {
            this.pb_Game.Width = config.BoardWidth * 4;
            this.pb_Game.Height = config.BoardHeight * 4;
            Point statsLocation = new Point(config.BoardWidth * 4, 0);
            this.groupstats.Location = statsLocation;
            this.ClientSize = new Size(config.BoardWidth * 4 + this.groupstats.Width, config.BoardHeight * 4);
        }

        private void calcGameStatistics()
        {
            // update timer
            if (game.Conf.MaxTicks > 0)
            {
                labelticksshow.Text = Convert.ToString(game.Conf.MaxTicks - game.getCurrentTick());
            }
            else
            {
                labelticksshow.Text = Convert.ToString(game.getCurrentTick());
            }

            // update player1
            labelplayer1pointsshow.Text = game.Player1.Points.ToString();
            labelplayer1moneyshow.Text = game.Player1.Money.ToString();
            labelplayer1carriesshow.Text = game.Player1.CarryCount.ToString();
            labelplayer1scoutsshow.Text = game.Player1.ScoutCount.ToString();
            labelplayer1antsshow.Text = Convert.ToString(game.Player1.ScoutCount + game.Player1.CarryCount);

            // update player2
            labelplayer2pointsshow.Text = game.Player2.Points.ToString();
            labelplayer2moneyshow.Text = game.Player2.Money.ToString();
            labelplayer2carriesshow.Text = game.Player2.CarryCount.ToString();
            labelplayer2scoutsshow.Text = game.Player2.ScoutCount.ToString();
            labelplayer2antsshow.Text = Convert.ToString(game.Player2.ScoutCount + game.Player2.CarryCount);

            // update sugar
            labelsugarshow.Text = game.Board.BoardObjects.getSugars().Count.ToString();
        }

        private void checkWinningConditions()
        {
            if (checkTickPlayerPoints()) return;
            if (checkMaxPoints()) return;
            if (checkSugarPlayerPoint()) return;
        }

        private bool checkSugarPlayerPoint()
        {
            if (game.Board.BoardObjects.getSugars().Count == 0)
            {
                if ((game.Player1.Points + game.Player2.Points) == game.Board.SugarAmount)
                {
                    if (!checkPlayerPoints())
                    {
                        this.stop();
                        MessageBox.Show(Messages.OUT_OF_SUGAR, Messages.OUT_OF_SUGAR_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    return true;
                }
            }
            return false;
        }

        private bool checkTickPlayerPoints()
        {
            if ((game.getCurrentTick()) >= game.Conf.MaxTicks)
            {
                this.stop();
                if (!checkPlayerPoints())
                {
                    this.stop();
                    MessageBox.Show(String.Format(Messages.TIME_OUT, game.Conf.MaxTicks), Messages.TIME_OUT_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                return true;
            }
            return false;
        }

        private bool checkPlayerPoints()
        {
            if (game.Player1.Points > game.Player2.Points)
            {
                this.stop();
                MessageBox.Show(String.Format(Messages.PLAYER_WON_TIME_OUT, 
                                "Spieler 1", game.Player1.Points), Messages.PLAYER_WON_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            else if (game.Player1.Points < game.Player2.Points)
            {
                this.stop();
                MessageBox.Show(String.Format(Messages.PLAYER_WON_TIME_OUT, 
                                    "Spieler 2", game.Player2.Points), Messages.PLAYER_WON_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            return false;
        }

        private bool checkMaxPoints()
        {
            if (game.Player1.Points >= game.Conf.Points)
            {
                this.stop();
                MessageBox.Show(String.Format(Messages.PLAYER_WON_MAX_POINTS, "Spieler 1"), Messages.PLAYER_WON_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            else if (game.Player2.Points >= game.Conf.Points)
            {
                this.stop();
                MessageBox.Show(String.Format(Messages.PLAYER_WON_MAX_POINTS, "Spieler 2"), Messages.PLAYER_WON_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            return false;
        }

        private void setPlayernameInStatistic(Config.GameConfig config)
        {
            groupplayer1.Text = "Spieler 1";
            groupplayer2.Text = "Spieler 2";

        }

        private void GamePanel_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer.Stop();
        }
    }
}
