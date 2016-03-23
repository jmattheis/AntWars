using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using AntWars.Board;
using AntWars.Board.Ants;
using AntWars.Helper;
using System.Drawing;

namespace AntWars {

    partial class GamePanel : Form {

        private const string Player1Carry = "ff008000";
        private const string Player2Carry = "ff0000ff";
        private const string Player1Scout = "ff2e8b57";
        private const string Player2Scout = "ff6a5acd";

        private Game game;
        private Multimedia.Timer timer = new Multimedia.Timer();

        public GamePanel() {
            InitializeComponent();
        }

        public void start(Config config) {
            setFormSize(config);
            game = new Game(config);
            game.start();
            initTimer(config.Ticks);
            setPlayernameInStatistic();
            Show();
        }

        public void stop() {
            timer.Stop();
        }

        private void initTimer(int period) {
            timer.Period = Convert.ToInt32(1000 / Convert.ToDecimal(period));
            timer.Resolution = 1;
            timer.Tick += new EventHandler(timer_GameTick_Tick);
            timer.Start();
        }

        public void print() {
            print(game.Board.BoardObjects.get());
        }

        private void print(IList<BoardObject> boardObjects) {
            Bitmap bitmap = new Bitmap(game.Conf.BoardWidth, game.Conf.BoardHeight);

            foreach (BoardObject obj in boardObjects) {
                setColor(obj, bitmap);
            }

            bitmap = new Bitmap(bitmap, bitmap.Width * 4, bitmap.Height * 4);
            pb_Game.Image = bitmap;
        }

        private void setColor(BoardObject obj, Bitmap bitmap) {
            if (obj.isCarry()) {
                setColor(bitmap, obj, Color.DarkGreen, Color.Blue, (obj as Ant).Owner);
            } else if (obj.isScout()) {
                setColor(bitmap, obj, Color.Green, Color.DarkBlue, (obj as Ant).Owner);
            } else if (obj.isWarrior()) {
                setColor(bitmap, obj, Color.Red, Color.DarkViolet, (obj as Ant).Owner);
            } else if (obj.isBase()) {
                setColor(bitmap, obj, Color.GreenYellow, Color.BlueViolet, (obj as Base).Player);
            } else if (obj.isSugar()) {
                setColor(bitmap, obj, Color.Black, Color.Transparent, null);
            }
        }

        private void setColor(Bitmap bitmap, BoardObject obj, Color player1Color, Color player2Color, Player player1) {
            if (player1 == null || player1 == game.Player1) {
                bitmap.SetPixel(obj.Coords.X, obj.Coords.Y, player1Color);
            } else {
                bitmap.SetPixel(obj.Coords.X, obj.Coords.Y, player2Color);
            }
        }

        private void timer_GameTick_Tick(object sender, EventArgs e) {
            game.nextTick();
            try {
                this.Invoke((MethodInvoker) delegate {
                    calcGameStatistics();
                    print();
                });
            } catch (System.Exception) { } // passiert halt, da es in einem anderen thread ausgeführt wird und nicht mitbekommt das die form geschlossen wird.
            checkWinningConditions();
        }

        public void view(Config config) {
            setFormSize(config);
            Show();
        }

        public void setFormSize(Config config) {
            this.pb_Game.Width = config.BoardWidth * 4;
            this.pb_Game.Height = config.BoardHeight * 4;
            Point statsLocation = new Point(config.BoardWidth * 4, 0);
            this.grp_stats.Location = statsLocation;
            this.ClientSize = new Size(config.BoardWidth * 4 + this.grp_stats.Width, config.BoardHeight * 4);
        }

        private void calcGameStatistics() {
            // update timer
            if (game.Conf.MaxTicks > 0) {
                lbl_ticksValue.Text = Convert.ToString(game.Conf.MaxTicks - game.getCurrentTick());
            } else {
                lbl_ticksValue.Text = Convert.ToString(game.getCurrentTick());
            }

            // update player1
            lbl_player1PointsValue.Text = game.Player1.Points.ToString();
            lbl_player1MoneyValue.Text = game.Player1.Money.ToString();
            lbl_player1CarriesValue.Text = game.Player1.CarryCount.ToString();
            lbl_player1ScoutsValue.Text = game.Player1.ScoutCount.ToString();
            lbl_player1WarriorsValue.Text = game.Player1.WarriorCount.ToString();
            lbl_player1AntsValue.Text = Convert.ToString(game.Player1.ScoutCount + game.Player1.CarryCount + game.Player1.WarriorCount);

            // update player2
            lbl_player2PointsValue.Text = game.Player2.Points.ToString();
            lbl_player2MoneyValue.Text = game.Player2.Money.ToString();
            lbl_player2CarriesValue.Text = game.Player2.CarryCount.ToString();
            lbl_player2ScoutsValue.Text = game.Player2.ScoutCount.ToString();
            lbl_player2WarriorsValue.Text = game.Player2.WarriorCount.ToString();
            lbl_player2AntsValue.Text = Convert.ToString(game.Player2.ScoutCount + game.Player2.CarryCount + game.Player2.WarriorCount);

            // update sugar
            lbl_sugarValue.Text = game.Board.BoardObjects.getSugars().Count.ToString();
        }

        private void checkWinningConditions() {
            if (checkTickPlayerPoints())
                return;
            if (checkMaxPoints())
                return;
            if (checkSugarPlayerPoint())
                return;
        }

        private bool checkSugarPlayerPoint() {
            if (game.Board.BoardObjects.getSugars().Count == 0) {
                if ((game.Player1.Points + game.Player2.Points) == game.Board.SugarAmount) {
                    if (!checkPlayerPoints()) {
                        this.stop();
                        MessageBox.Show(Messages.OUT_OF_SUGAR, Messages.OUT_OF_SUGAR_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    return true;
                }
            }
            return false;
        }

        private bool checkTickPlayerPoints() {
            if ((game.getCurrentTick()) >= game.Conf.MaxTicks) {
                this.stop();
                if (!checkPlayerPoints()) {
                    this.stop();
                    MessageBox.Show(String.Format(Messages.TIME_OUT, game.Conf.MaxTicks), Messages.TIME_OUT_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                return true;
            }
            return false;
        }

        private bool checkPlayerPoints() {
            if (game.Player1.Points > game.Player2.Points) {
                this.stop();
                MessageBox.Show(String.Format(Messages.PLAYER_WON_TIME_OUT,
                                game.Player1.AI.Playername, game.Player1.Points), Messages.PLAYER_WON_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            } else if (game.Player1.Points < game.Player2.Points) {
                this.stop();
                MessageBox.Show(String.Format(Messages.PLAYER_WON_TIME_OUT,
                                    game.Player2.AI.Playername, game.Player2.Points), Messages.PLAYER_WON_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            return false;
        }

        private bool checkMaxPoints() {
            if (game.Player1.Points >= game.Conf.Points) {
                this.stop();
                MessageBox.Show(String.Format(Messages.PLAYER_WON_MAX_POINTS, game.Player1.AI.Playername), Messages.PLAYER_WON_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            } else if (game.Player2.Points >= game.Conf.Points) {
                this.stop();
                MessageBox.Show(String.Format(Messages.PLAYER_WON_MAX_POINTS, game.Player2.AI.Playername), Messages.PLAYER_WON_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            return false;
        }

        private void setPlayernameInStatistic() {
            grp_player1.Text = game.Player1.AI.Playername;
            grp_player2.Text = game.Player2.AI.Playername;
        }

        private void GamePanel_FormClosing(object sender, FormClosingEventArgs e) {
            timer.Stop();
        }
    }
}
