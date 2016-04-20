using AntWars.Board;
using AntWars.Board.Ants;
using AntWars.Helper;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace AntWars {

    partial class GamePanel : Form {

        private static readonly Color COLOR_PLAYER1_CARRY = Color.DarkRed;
        private static readonly Color COLOR_PLAYER1_SCOUT = Color.Red;
        private static readonly Color COLOR_PLAYER1_WARRIOR = Color.DeepPink;
        private static readonly Color COLOR_PLAYER1_BASE = Color.OrangeRed;

        private static readonly Color COLOR_PLAYER2_CARRY = Color.DarkCyan;
        private static readonly Color COLOR_PLAYER2_SCOUT = Color.Blue;
        private static readonly Color COLOR_PLAYER2_WARRIOR = Color.DeepSkyBlue;
        private static readonly Color COLOR_PLAYER2_BASE = Color.BlueViolet;

        private static readonly Color COLOR_GAME_SUGAR = Color.Black;


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
            setColorInStatistic();
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

        private void print(BoardObject[] boardObjects) {
            Bitmap tmp = new Bitmap(game.Conf.BoardWidth, game.Conf.BoardHeight);

            for(int i = 0; i < boardObjects.Length;i++) {
                setColor(boardObjects[i], tmp);
            }
            if (pb_Game.Image != null) {
                pb_Game.Image.Dispose();
            }
            Bitmap bitmap = new Bitmap(tmp, tmp.Width, tmp.Height);
            tmp.Dispose();
            pb_Game.Image = bitmap;
        }

        private void setColor(BoardObject obj, Bitmap bitmap) {
            if (obj.isCarry()) {
                setColor(bitmap, obj, COLOR_PLAYER1_CARRY, COLOR_PLAYER2_CARRY, (obj as Ant).Owner);
            } else if (obj.isScout()) {
                setColor(bitmap, obj, COLOR_PLAYER1_SCOUT, COLOR_PLAYER2_SCOUT, (obj as Ant).Owner);
            } else if (obj.isWarrior()) {
                setColor(bitmap, obj, COLOR_PLAYER1_WARRIOR, COLOR_PLAYER2_WARRIOR, (obj as Ant).Owner);
            } else if (obj.isBase()) {
                setColor(bitmap, obj, COLOR_PLAYER1_BASE, COLOR_PLAYER2_BASE, (obj as Base).Player);
            } else if (obj.isSugar()) {
                setColor(bitmap, obj, COLOR_GAME_SUGAR, Color.Transparent, null);
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

            // cloning, the print method get invoked in an other thread, therefore the BoardObject-Array could be change till that.
            BoardObject[] objects = game.Board.BoardObjects.get().Clone() as BoardObject[];
            System.Threading.Tasks.Task.Factory.StartNew(() => { 
                try {
                    this.Invoke((MethodInvoker) delegate {
                        calcGameStatistics();
                        print(objects);
                    });
                } catch (System.Exception) { } // passiert halt, da es in einem anderen thread ausgeführt wird und nicht mitbekommt das die form geschlossen wird.
            });
            checkWinningConditions();
        }

        public void view(Config config) {
            setFormSize(config);
            setColorInStatistic();
            Show();
        }

        public void setFormSize(Config config) {
            this.pb_Game.Width = config.BoardWidth;
            this.pb_Game.Height = config.BoardHeight;
            Point statsLocation = new Point(config.BoardWidth, 0);
            this.grp_stats.Location = statsLocation;
            this.ClientSize = new Size(config.BoardWidth + this.grp_stats.Width, config.BoardHeight);
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
            lbl_player1MoneyValue.Text = Convert.ToString(Math.Round(game.Player1.Money, 2));
            lbl_player1CarriesValue.Text = game.Player1.CarryCount.ToString();
            lbl_player1ScoutsValue.Text = game.Player1.ScoutCount.ToString();
            lbl_player1WarriorsValue.Text = game.Player1.WarriorCount.ToString();
            lbl_player1AntsValue.Text = Convert.ToString(game.Player1.ScoutCount + game.Player1.CarryCount + game.Player1.WarriorCount);
            lbl_player1DeathsValue.Text = game.Player1.DeathCount.ToString();
            lbl_player1KillsValue.Text = game.Player1.KillCount.ToString();

            // update player2
            lbl_player2PointsValue.Text = game.Player2.Points.ToString();
            lbl_player2MoneyValue.Text = Convert.ToString(Math.Round(game.Player2.Money, 2));
            lbl_player2CarriesValue.Text = game.Player2.CarryCount.ToString();
            lbl_player2ScoutsValue.Text = game.Player2.ScoutCount.ToString();
            lbl_player2WarriorsValue.Text = game.Player2.WarriorCount.ToString();
            lbl_player2AntsValue.Text = Convert.ToString(game.Player2.ScoutCount + game.Player2.CarryCount + game.Player2.WarriorCount);
            lbl_player2DeathsValue.Text = game.Player2.DeathCount.ToString();
            lbl_player2KillsValue.Text = game.Player2.KillCount.ToString();

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

        private void setColorInStatistic() {
            lbl_player1Carries.ForeColor = COLOR_PLAYER1_CARRY;
            lbl_player1Scouts.ForeColor = COLOR_PLAYER1_SCOUT;
            lbl_player1Warrior.ForeColor = COLOR_PLAYER1_WARRIOR;
            grp_player1.ForeColor = COLOR_PLAYER1_BASE;

            lbl_player2Carries.ForeColor = COLOR_PLAYER2_CARRY;
            lbl_player2Scouts.ForeColor = COLOR_PLAYER2_SCOUT;
            lbl_player2Warrior.ForeColor = COLOR_PLAYER2_WARRIOR;
            grp_player2.ForeColor = COLOR_PLAYER2_BASE;
        }

        private void GamePanel_FormClosing(object sender, FormClosingEventArgs e) {
            timer.Stop();
        }
    }
}
