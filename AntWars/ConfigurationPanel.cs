using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AntWars.Config;
using System.IO;
using AntWars.Exception;


namespace AntWars
{
    public partial class ConfigurationPanel : Form
    {

        private Game game;
        private ConfigurationLoader configLoader = new ConfigurationLoader();
        private List<GamePanel> gamePanels = new List<GamePanel>();

        public ConfigurationPanel()
        {
            InitializeComponent();
        }

        private void Start_Click(object sender, EventArgs e)
        {
            if (configLoader.isAllLoaded())
            {
                if (checkGameConfig())
                {
                    GamePanel gamePanel = new GamePanel();
                    gamePanel.FormClosed += new FormClosedEventHandler(gamePanelCloseEvent);
                    try
                    {
                        gamePanel.start(configLoader.get());
                        gamePanels.Add(gamePanel);
                        disableControls();
                    }
                    catch (InvalidDLLFileException ex)
                    {
                        MessageBox.Show("The given DLL is not valid, please try another one.", "Error: Could not start.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("There are not all configs loaded/created.", "Error: Could not start.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GameTick_Tick(object sender, EventArgs e)
        {
            game.nextTick();
        }

        private void btn_player1ConfigNew_Click(object sender, EventArgs e)
        {
            configLoader.newPlayer1();
            configLoadedOrNewCreatedPlayer1();
            loadPlayer1(configLoader.get().Player1);
            calculateAntCostsPlayer1();
        }

        private void btn_player1ConfigLoad_Click(object sender, EventArgs e)
        {
            String res = openDialog();
            if (res != null)
            {
                try
                {
                    configLoader.loadPlayer1(res);
                }
                catch (InvalidConfigurationException exception)
                {
                    MessageBox.Show("Cannot load this configuration because of: \n" + exception.Message, "Error: Invalid configuration.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                configLoadedOrNewCreatedPlayer1();
                loadPlayer1(configLoader.get().Player1);
            }
        }

        private void configLoadedOrNewCreatedPlayer1()
        {
            btn_player1ConfigLoad.Enabled = false;
            btn_player1ConfigNew.Enabled = false;
            btn_player1ConfigSave.Enabled = true;
            pnl_player1Config.Enabled = true;
        }

        private void configLoadedOrNewCreatedPlayer2()
        {
            btn_player2ConfigLoad.Enabled = false;
            btn_player2ConfigNew.Enabled = false;
            btn_player2ConfigSave.Enabled = true;
            pnl_player2Config.Enabled = true;
        }

        private void configLoadedOrNewCreatedGame()
        {
            btn_gameConfigLoad.Enabled = false;
            btn_gameConfigNew.Enabled = false;
            btn_gameConfigSave.Enabled = true;
            pnl_GameConfig.Enabled = true;
        }

        private void loadPlayer1(PlayerConfig conf)
        {
            textbox_player1Name.Text = conf.PlayerName;
            numeric_player1CarryInventory.Value = conf.CarryInventory;
            numeric_player1CarryMove.Value = conf.CarryMoveRange;
            numeric_player1CarrySpeed.Value = conf.CarrySpeed;
            numeric_player1CarryView.Value = conf.CarryViewRange;
            numeric_player1ScoutInventory.Value = conf.ScoutInventory;
            numeric_player1ScoutMove.Value = conf.ScoutMoveRange;
            numeric_player1ScoutSpeed.Value = conf.ScoutSpeed;
            numeric_player1ScoutView.Value = conf.ScoutViewRange;
            lbl_player1AIPath.Text = conf.AIPath;
            calculateAntCostsPlayer1();
        }

        private void loadPlayer2(PlayerConfig conf)
        {
            textbox_player2Name.Text = conf.PlayerName;
            numeric_player2CarryInventory.Value = conf.CarryInventory;
            numeric_player2CarryMove.Value = conf.CarryMoveRange;
            numeric_player2CarrySpeed.Value = conf.CarrySpeed;
            numeric_player2CarryView.Value = conf.CarryViewRange;
            numeric_player2ScoutInventory.Value = conf.ScoutInventory;
            numeric_player2ScoutMove.Value = conf.ScoutMoveRange;
            numeric_player2ScoutSpeed.Value = conf.ScoutSpeed;
            numeric_player2ScoutView.Value = conf.ScoutViewRange;
            lbl_player2AIPath.Text = conf.AIPath;
            calculateAntCostsPlayer2();
        }

        private void loadGame(GameConfig conf)
        {
            numeric_gameConfigSugarMin.Value = conf.SugarMin;
            numeric_gameConfigSugarMax.Value = conf.SugarMax;
            numeric_gameConfigSugarAmountMin.Value = conf.SugarAmountMin;
            numeric_gameConfigSugarAmountMax.Value = conf.SugarAmountMax;
            numeric_gameConfigStartAntAmount.Value = conf.StartAntAmount;
            numeric_gameConfigBoardWidth.Value = conf.BoardWidth;
            numeric_gameConfigBoardHeigth.Value = conf.BoardHeigth;
            numeric_gameConfigStartMoney.Value = conf.StartMoney;
            numeric_gameConfigTime.Value = conf.Time;
            numeric_gameConfigPoints.Value = conf.Points;

        }

        private void btn_player1ConfigSave_Click(object sender, EventArgs e)
        {
            if (configLoader.isNeededPathPlayer1())
            {
                String path = openSaveDialog();
                if (path != null)
                {
                    configLoader.Player1Path = path;
                }
                else
                {
                    return;
                }
            }
            MessageBox.Show("Successfully saved.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            configLoader.savePlayer1();
        }

        private void ConfigurationPanel_Load(object sender, EventArgs e)
        {

        }

        private String openDialog()
        {
            OpenFileDialog dia = new OpenFileDialog();
            if (dia.ShowDialog() == DialogResult.OK)
            {
                return dia.FileName;
            }
            return null;
        }

        private String openSaveDialog()
        {
            SaveFileDialog dia = new SaveFileDialog();
            dia.Filter = "|*.xml";
            if (dia.ShowDialog() == DialogResult.OK)
            {
                return dia.FileName;
            }
            return null;
        }

        private void textbox_player1Name_TextChanged(object sender, EventArgs e)
        {
            configLoader.get().Player1.PlayerName = textbox_player1Name.Text;
        }

        private void numeric_player1CarryView_ValueChanged(object sender, EventArgs e)
        {
            configLoader.get().Player1.CarryViewRange = Convert.ToInt32(numeric_player1CarryView.Value);
            calculateAntCostsPlayer1();
        }

        private void numeric_player1ScoutView_ValueChanged(object sender, EventArgs e)
        {
            configLoader.get().Player1.ScoutViewRange = Convert.ToInt32(numeric_player1ScoutView.Value);
            calculateAntCostsPlayer1();
        }

        private void numeric_player1ScoutInventory_ValueChanged(object sender, EventArgs e)
        {
            configLoader.get().Player1.ScoutInventory = Convert.ToInt32(numeric_player1ScoutInventory.Value);
            calculateAntCostsPlayer1();
        }

        private void numeric_player1ScoutSpeed_ValueChanged(object sender, EventArgs e)
        {
            configLoader.get().Player1.ScoutSpeed = Convert.ToInt32(numeric_player1ScoutSpeed.Value);
            calculateAntCostsPlayer1();
        }

        private void numeric_player1CarryInventory_ValueChanged(object sender, EventArgs e)
        {
            configLoader.get().Player1.CarryInventory = Convert.ToInt32(numeric_player1CarryInventory.Value);
            calculateAntCostsPlayer1();
        }

        private void numeric_player1CarrySpeed_ValueChanged(object sender, EventArgs e)
        {
            configLoader.get().Player1.CarrySpeed = Convert.ToInt32(numeric_player1CarrySpeed.Value);
            calculateAntCostsPlayer1();
        }

        private void numeric_player1ScoutMove_ValueChanged(object sender, EventArgs e)
        {
            configLoader.get().Player1.ScoutMoveRange = Convert.ToInt32(numeric_player1ScoutMove.Value);
            calculateAntCostsPlayer1();
        }

        private void numeric_player1CarryMove_ValueChanged(object sender, EventArgs e)
        {
            configLoader.get().Player1.CarryMoveRange = Convert.ToInt32(numeric_player1CarryMove.Value);
            calculateAntCostsPlayer1();
        }

        private void label__player1ScoutCost_Click(object sender, EventArgs e)
        {

        }

        private void numeric_player2ScoutView_ValueChanged(object sender, EventArgs e)
        {
            configLoader.get().Player2.ScoutViewRange = Convert.ToInt32(numeric_player2ScoutView.Value);
            calculateAntCostsPlayer2();
        }

        private void label__player2CarryCost_Click(object sender, EventArgs e)
        {

        }

        private void numeric_player2ScoutInventory_ValueChanged(object sender, EventArgs e)
        {
            configLoader.get().Player2.ScoutInventory = Convert.ToInt32(numeric_player2ScoutInventory.Value);
            calculateAntCostsPlayer2();
        }

        private void numeric_player2ScoutSpeed_ValueChanged(object sender, EventArgs e)
        {
            configLoader.get().Player2.ScoutSpeed = Convert.ToInt32(numeric_player2ScoutSpeed.Value);
            calculateAntCostsPlayer2();
        }

        private void numeric_player2CarryInventory_ValueChanged(object sender, EventArgs e)
        {
            configLoader.get().Player2.CarryInventory = Convert.ToInt32(numeric_player2CarryInventory.Value);
            calculateAntCostsPlayer2();
        }

        private void numeric_player2CarrySpeed_ValueChanged(object sender, EventArgs e)
        {
            configLoader.get().Player2.CarrySpeed = Convert.ToInt32(numeric_player2CarrySpeed.Value);
            calculateAntCostsPlayer2();
        }

        private void numeric_player2ScoutMove_ValueChanged(object sender, EventArgs e)
        {
            configLoader.get().Player2.ScoutMoveRange = Convert.ToInt32(numeric_player2ScoutMove.Value);
            calculateAntCostsPlayer2();
        }

        private void numeric_player2CarryMove_ValueChanged(object sender, EventArgs e)
        {
            configLoader.get().Player2.CarryMoveRange = Convert.ToInt32(numeric_player2CarryMove.Value);
            calculateAntCostsPlayer2();
        }

        private void numeric_player2CarryView_ValueChanged(object sender, EventArgs e)
        {
            configLoader.get().Player2.CarryViewRange = Convert.ToInt32(numeric_player2CarryView.Value);
            calculateAntCostsPlayer2();
        }

        private void label__player2ScoutCost_Click(object sender, EventArgs e)
        {

        }

        private void btn_player2ConfigNew_Click(object sender, EventArgs e)
        {
            configLoader.newPlayer2();
            configLoadedOrNewCreatedPlayer2();
            loadPlayer2(configLoader.get().Player2);
            calculateAntCostsPlayer2();
        }

        private void btn_player2ConfigLoad_Click(object sender, EventArgs e)
        {
            String res = openDialog();
            if (res != null)
            {
                try
                {
                    configLoader.loadPlayer2(res);
                }
                catch (InvalidConfigurationException exception)
                {
                    MessageBox.Show("Cannot load this configuration because of: \n" + exception.Message, "Error: Invalid configuration.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                configLoadedOrNewCreatedPlayer2();
                loadPlayer2(configLoader.get().Player2);
            }
        }

        private void btn_player2ConfigSave_Click(object sender, EventArgs e)
        {
            if (configLoader.isNeededPathPlayer2())
            {
                String path = openSaveDialog();
                if (path != null)
                {
                    configLoader.Player2Path = path;
                }
                else
                {
                    return;
                }
            }
            MessageBox.Show("Successfully saved.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            configLoader.savePlayer2();
        }

        private void textbox_player2Name_TextChanged(object sender, EventArgs e)
        {
            configLoader.get().Player2.PlayerName = textbox_player2Name.Text;
        }

        private void numeric_gameConfigSugarMin_ValueChanged(object sender, EventArgs e)
        {
            configLoader.get().Game.SugarMin = Convert.ToInt32(numeric_gameConfigSugarMin.Value);
        }

        private void numeric_gameConfigSugarAmountMin_ValueChanged(object sender, EventArgs e)
        {
            configLoader.get().Game.SugarAmountMin = Convert.ToInt32(numeric_gameConfigSugarAmountMin.Value);
        }

        private void numeric_gameConfigStartAntAmount_ValueChanged(object sender, EventArgs e)
        {
            configLoader.get().Game.StartAntAmount = Convert.ToInt32(numeric_gameConfigStartAntAmount.Value);
        }

        private void numeric_gameConfigBoardWidth_ValueChanged(object sender, EventArgs e)
        {
            configLoader.get().Game.BoardWidth = Convert.ToInt32(numeric_gameConfigBoardWidth.Value);
        }

        private void numeric_gameConfigPoints_ValueChanged(object sender, EventArgs e)
        {
            configLoader.get().Game.Points = Convert.ToInt32(numeric_gameConfigPoints.Value);
        }

        private void numeric_gameConfigStartMoney_ValueChanged(object sender, EventArgs e)
        {
            configLoader.get().Game.StartMoney = Convert.ToInt32(numeric_gameConfigStartMoney.Value);
        }

        private void numeric_gameConfigTime_ValueChanged(object sender, EventArgs e)
        {
            configLoader.get().Game.Time = Convert.ToInt32(numeric_gameConfigTime.Value);
        }

        private void numeric_gameConfigBoardHeigth_ValueChanged(object sender, EventArgs e)
        {
            configLoader.get().Game.BoardHeigth = Convert.ToInt32(numeric_gameConfigBoardHeigth.Value);
        }

        private void numeric_gameConfigSugarAmountMax_ValueChanged(object sender, EventArgs e)
        {
            configLoader.get().Game.SugarAmountMax = Convert.ToInt32(numeric_gameConfigSugarAmountMax.Value);
        }

        private void numeric_gameConfigSugarMax_ValueChanged(object sender, EventArgs e)
        {
            configLoader.get().Game.SugarMax = Convert.ToInt32(numeric_gameConfigSugarMax.Value);
        }

        private void btn_gameConfigNew_Click(object sender, EventArgs e)
        {
            configLoader.newGame();
            configLoadedOrNewCreatedGame();
            loadGame(configLoader.get().Game);
        }

        private void btn_gameConfigSave_Click(object sender, EventArgs e)
        {
            if (configLoader.isNeededPathGame())
            {
                String path = openSaveDialog();
                if (path != null)
                {
                    configLoader.GamePath = path;
                }
                else
                {
                    return;
                }
            }
            MessageBox.Show("Successfully saved.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            configLoader.saveGame();
        }
        private bool checkGameConfig()
        {
            GameConfig conf = configLoader.get().Game;
            if (!checkMinMax(conf.SugarMin, conf.SugarMax)) return false;
            if (!checkMinMax(conf.SugarAmountMin, conf.SugarAmountMax)) return false;
            return true;
        }

        private bool checkMinMax(int min, int max)
        {
            if (min > max)
            {
                MessageBox.Show("Min can't be higher than Max!", "Error: Invalid Value.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void btn_gameConfigLoad_Click(object sender, EventArgs e)
        {
            String res = openDialog();
            if (res != null)
            {
                try
                {
                    configLoader.loadGame(res);
                }
                catch (InvalidConfigurationException exception)
                {
                    MessageBox.Show("Cannot load this configuration because of: \n" + exception.Message, "Error: Invalid configuration.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                configLoadedOrNewCreatedGame();
                loadGame(configLoader.get().Game);
            }
        }

        private void buttonView_Click(object sender, EventArgs e)
        {
            if (configLoader.isAllLoaded())
            {
                if (checkGameConfig())
                {
                    GamePanel gamePanel = new GamePanel();
                    gamePanel.view(configLoader.get());
                }
            }
            else
            {
                MessageBox.Show("There are not all configs loaded/created.", "Error: Could not start.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Wird ausgeführt, wenn das Game-Panel geschlossen wird.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gamePanelCloseEvent(object sender, System.EventArgs e)
        {
            if (!isGameRunning(sender))
            {
                enableControls();
            }
        }

        /// <summary>
        /// Eingabefelder aktivieren
        /// </summary>
        private void enableControls()
        {
            changeControlState(true);
        }

        /// <summary>
        /// Eingabefelder deaktivieren
        /// </summary>
        private void disableControls()
        {
            changeControlState(false);
        }

        /// <summary>
        /// Eingabefelder des Panels aktivieren/deaktivieren
        /// </summary>
        /// <param name="state">true für aktivieren, false für deaktivieren</param>
        private void changeControlState(bool state)
        {
            pnl_GameConfig.Enabled = state;
            pnl_player1Config.Enabled = state;
            pnl_player2Config.Enabled = state;
        }

        private bool isGameRunning(object sender)
        {
            foreach (GamePanel gamePanel in gamePanels)
            {
                if (!gamePanel.IsDisposed && sender != gamePanel)
                {
                    return true;
                }
            }
            return false;
        }

        private void calculateAntCostsByPlayer(PlayerConfig playerconfig)
        {
            // TODO: Schönere Divisions- und Rundungsfunktion finden
            playerconfig.CarryCost = playerconfig.CarryViewRange + playerconfig.CarryMoveRange + playerconfig.CarryInventory + playerconfig.CarrySpeed;
            playerconfig.CarryCost = Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(playerconfig.CarryCost) / 2));
            playerconfig.ScoutCost = playerconfig.ScoutViewRange + playerconfig.ScoutMoveRange + playerconfig.ScoutInventory + playerconfig.ScoutSpeed;
            playerconfig.ScoutCost = Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(playerconfig.ScoutCost) / 2));
        }

        private void calculateAntCostsPlayer1()
        {
            calculateAntCostsByPlayer(configLoader.get().Player1);
            label__player1CarryCost.Text = configLoader.get().Player1.CarryCost.ToString();
            label__player1ScoutCost.Text = configLoader.get().Player1.ScoutCost.ToString();
        }

        private void calculateAntCostsPlayer2()
        {
            calculateAntCostsByPlayer(configLoader.get().Player2);
            label__player2CarryCost.Text = configLoader.get().Player2.CarryCost.ToString();
            label__player2ScoutCost.Text = configLoader.get().Player2.ScoutCost.ToString();
        }

        private void btn_player2loadAI_Click(object sender, EventArgs e)
        {
            String res = openDialog();
            if (res != null)
            {
                lbl_player2AIPath.Text = res;
                configLoader.get().Player2.AIPath = res;
            }
        }

        private void btn_player1loadAI_Click(object sender, EventArgs e)
        {
            String res = openDialog();
            if (res != null)
            {
                lbl_player1AIPath.Text = res;
                configLoader.get().Player1.AIPath = res;
            }
        }
    }
}
