using AntWars.Exception;
using AntWars.Helper;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;


namespace AntWars {

    partial class ConfigurationPanel : Form {

        private Config config = new Config();
        private List<GamePanel> gamePanels = new List<GamePanel>();

        public ConfigurationPanel() {
            InitializeComponent();
        }

        private void Start_Click(object sender, EventArgs e) {
            if (checkGameConfig()) {
                GamePanel gamePanel = new GamePanel();
                gamePanel.FormClosed += new FormClosedEventHandler(gamePanelCloseEvent);
                try {
                    gamePanel.start(config);
                    gamePanels.Add(gamePanel);
                    disableControls();
                } catch (InvalidDLLFileException) {
                    MessageBox.Show(Messages.ERROR_INVALID_DLL, Messages.ERROR_INVALID_DLL_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } else {
                MessageBox.Show(Messages.ERROR_COULD_NOT_START, Messages.ERROR_COULD_NOT_START_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void configLoadedOrNewCreatedGame() {
            btn_load.Enabled = false;
            btn_new.Enabled = false;
            btn_save.Enabled = true;
            pnl_config.Enabled = true;
            btn_view.Enabled = true;
        }

        private void loadGame(Config conf) {
            nmc_sugarMin.Value = conf.SugarMin;
            nmc_sugarMax.Value = conf.SugarMax;
            nmc_sugarAmountMin.Value = conf.SugarAmountMin;
            nmc_sugarAmountMax.Value = conf.SugarAmountMax;
            nmc_boardWidth.Value = conf.BoardWidth;
            nmc_boardHeigth.Value = conf.BoardHeight;
            nmc_startMoney.Value = (decimal) conf.StartMoney;
            nmc_ticks.Value = conf.Ticks;
            nmc_maxTicks.Value = conf.MaxTicks;
            nmc_points.Value = conf.Points;
        }

        private String openDialog() {
            OpenFileDialog dia = new OpenFileDialog();
            if (dia.ShowDialog() == DialogResult.OK) {
                return dia.FileName;
            }
            return null;
        }

        private String openSaveDialog() {
            SaveFileDialog dia = new SaveFileDialog();
            dia.Filter = "|*.xml";
            if (dia.ShowDialog() == DialogResult.OK) {
                return dia.FileName;
            }
            return null;
        }

        private void numeric_gameConfigSugarMin_ValueChanged(object sender, EventArgs e) {
            config.SugarMin = Convert.ToInt32(nmc_sugarMin.Value);
        }

        private void numeric_gameConfigSugarAmountMin_ValueChanged(object sender, EventArgs e) {
            config.SugarAmountMin = Convert.ToInt32(nmc_sugarAmountMin.Value);
        }

        private void numeric_gameConfigBoardWidth_ValueChanged(object sender, EventArgs e) {
            config.BoardWidth = Convert.ToInt32(nmc_boardWidth.Value);
        }

        private void numeric_gameConfigPoints_ValueChanged(object sender, EventArgs e) {
            config.Points = Convert.ToInt32(nmc_points.Value);
        }

        private void numeric_gameConfigStartMoney_ValueChanged(object sender, EventArgs e) {
            config.StartMoney = Convert.ToDouble(nmc_startMoney.Value);
        }

        private void numeric_gameConfigTime_ValueChanged(object sender, EventArgs e) {
            config.Ticks = Convert.ToInt32(nmc_ticks.Value);
        }

        private void numeric_gameConfigBoardHeigth_ValueChanged(object sender, EventArgs e) {
            config.BoardHeight = Convert.ToInt32(nmc_boardHeigth.Value);
        }

        private void numeric_gameConfigSugarAmountMax_ValueChanged(object sender, EventArgs e) {
            config.SugarAmountMax = Convert.ToInt32(nmc_sugarAmountMax.Value);
        }

        private void numeric_gameConfigSugarMax_ValueChanged(object sender, EventArgs e) {
            config.SugarMax = Convert.ToInt32(nmc_sugarMax.Value);
        }

        private void btn_gameConfigNew_Click(object sender, EventArgs e) {
            config = new Config();
            configLoadedOrNewCreatedGame();
            loadGame(config);
            checkPlayerKI();
            btn_save.Focus();
        }

        private void btn_gameConfigSave_Click(object sender, EventArgs e) {
            if (config.isNeededPathGame()) {
                String path = openSaveDialog();
                if (path != null) {
                    config.GamePath = path;
                } else {
                    return;
                }
            }
            MessageBox.Show(Messages.SAVED, Messages.SAVED_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Information);
            config.saveConfig();
        }

        private bool checkGameConfig() {
            if (!checkMinMax(config.SugarMin, config.SugarMax))
                return false;
            if (!checkMinMax(config.SugarAmountMin, config.SugarAmountMax))
                return false;
            return true;
        }

        private bool checkMinMax(int min, int max) {
            if (min > max) {
                MessageBox.Show(Messages.ERROR_MIN_HIGHER_MAX, Messages.ERROR_INVALID_VALUE_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void btn_gameConfigLoad_Click(object sender, EventArgs e) {
            String res = openDialog();
            if (res != null) {
                try {
                    config = Config.loadConfig(res);
                } catch (InvalidConfigurationException exception) {
                    MessageBox.Show(Messages.ERROR_INVALID_CONFIG + exception.Message, Messages.ERROR_INVALID_CONFIG_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                configLoadedOrNewCreatedGame();
                checkPlayerKI();
                loadGame(config);
            }
            btn_save.Focus();
        }

        private void buttonView_Click(object sender, EventArgs e) {
            if (checkGameConfig()) {
                GamePanel gamePanel = new GamePanel();
                gamePanel.view(config);
            } else {
                MessageBox.Show(Messages.ERROR_COULD_NOT_START, Messages.ERROR_COULD_NOT_START_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Wird ausgeführt, wenn das Game-Panel geschlossen wird.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gamePanelCloseEvent(object sender, System.EventArgs e) {
            if (!isGameRunning(sender)) {
                enableControls();
            }
        }

        /// <summary>
        /// Eingabefelder aktivieren
        /// </summary>
        private void enableControls() {
            changeControlState(true);
        }

        /// <summary>
        /// Eingabefelder deaktivieren
        /// </summary>
        private void disableControls() {
            changeControlState(false);
        }

        /// <summary>
        /// Eingabefelder des Panels aktivieren/deaktivieren
        /// </summary>
        /// <param name="state">true für aktivieren, false für deaktivieren</param>
        private void changeControlState(bool state) {
            pnl_config.Enabled = state;
        }

        private bool isGameRunning(object sender) {
            foreach (GamePanel gamePanel in gamePanels) {
                if (!gamePanel.IsDisposed && sender != gamePanel) {
                    return true;
                }
            }
            return false;
        }

        private void btn_player2loadAI_Click(object sender, EventArgs e) {
            String res = openDialog();
            if (res != null) {
                config.Player2AIPath = res;
            }
            checkPlayerKI();
        }

        private void btn_player1loadAI_Click(object sender, EventArgs e) {
            String res = openDialog();
            if (res != null) {
                config.Player1AIPath = res;
            }
            checkPlayerKI();
        }

        private void numeric_gameConfigMaxTicks_ValueChanged(object sender, EventArgs e) {
            config.MaxTicks = Convert.ToInt32(nmc_maxTicks.Value);
        }

        private void checkPlayerKI() {
            if (!String.IsNullOrEmpty(config.Player1AIPath)) {
                btn_player1loadAI.BackColor = Color.LightGreen;
            } else {
                btn_player1loadAI.BackColor = Color.Red;
            }

            if (!String.IsNullOrEmpty(config.Player2AIPath)) {
                btn_player2loadAI.BackColor = Color.LightGreen;
            } else {
                btn_player2loadAI.BackColor = Color.Red;
            }
        }

        private void buttonCostCalculator_Click(object sender, EventArgs e) {
            CostCalculator costCalc = new CostCalculator();
            costCalc.Show();
        }
    }
}
