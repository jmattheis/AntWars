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

        private Game game { get; set; }
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
                    gamePanel.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.gamePanelCloseEvent);
                    gamePanel.start(configLoader.get());
                    gamePanels.Add(gamePanel);
                    disableControls();
                }
            } else
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
        }

        private void btn_player1ConfigLoad_Click(object sender, EventArgs e)
        {
            String res = openDialog();
            if(res != null)
            {
                try {
                    configLoader.loadPlayer1(res);
                } catch(InvalidConfigurationException exception)
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
            textbox_player1Name.Text = conf.playername;
            numeric_player1CarryInventory.Value = conf.carryInventory;
            numeric_player1CarryMove.Value = conf.carryMoveRange;
            numeric_player1CarrySpeed.Value = conf.carrySpeed;
            numeric_player1CarryView.Value = conf.carryViewRange;
            numeric_player1ScoutInventory.Value = conf.scoutInventory;
            numeric_player1ScoutMove.Value = conf.scoutMoveRange;
            numeric_player1ScoutSpeed.Value = conf.scoutSpeed;
            numeric_player1ScoutView.Value = conf.scoutViewRange;
        }

        private void loadPlayer2(PlayerConfig conf)
        {
            textbox_player2Name.Text = conf.playername;
            numeric_player2CarryInventory.Value = conf.carryInventory;
            numeric_player2CarryMove.Value = conf.carryMoveRange;
            numeric_player2CarrySpeed.Value = conf.carrySpeed;
            numeric_player2CarryView.Value = conf.carryViewRange;
            numeric_player2ScoutInventory.Value = conf.scoutInventory;
            numeric_player2ScoutMove.Value = conf.scoutMoveRange;
            numeric_player2ScoutSpeed.Value = conf.scoutSpeed;
            numeric_player2ScoutView.Value = conf.scoutViewRange;
        }

        private void loadGame(GameConfig conf)
        {
            numeric_gameConfigSugarMin.Value = conf.sugarMin;
            numeric_gameConfigSugarMax.Value = conf.sugarMax;
            numeric_gameConfigSugarAmountMin.Value = conf.sugarAmountMin;
            numeric_gameConfigSugarAmountMax.Value = conf.sugarAmountMax;
            numeric_gameConfigStartAntAmount.Value = conf.startAntAmount;
            numeric_gameConfigBoardWidth.Value = conf.boardWidth;
            numeric_gameConfigBoardHeigth.Value = conf.boardHeigth;
            numeric_gameConfigStartMoney.Value = conf.startMoney;
            numeric_gameConfigTime.Value = conf.time;
            numeric_gameConfigPoints.Value = conf.points;

        }

        private void btn_player1ConfigSave_Click(object sender, EventArgs e)
        {
            if(configLoader.isNeededPathPlayer1())
            {
                String path = openSaveDialog();
                if(path != null)
                {
                    configLoader.player1Path = path;
                } else
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
            configLoader.get().Player1.playername = textbox_player1Name.Text;
        }

        private void numeric_player1CarryView_ValueChanged(object sender, EventArgs e)
        {
            configLoader.get().Player1.carryViewRange = Convert.ToInt32(numeric_player1CarryView.Value);
        }

        private void numeric_player1ScoutView_ValueChanged(object sender, EventArgs e)
        {
            configLoader.get().Player1.scoutViewRange = Convert.ToInt32(numeric_player1ScoutView.Value);
        }

        private void numeric_player1ScoutInventory_ValueChanged(object sender, EventArgs e)
        {
            configLoader.get().Player1.scoutInventory = Convert.ToInt32(numeric_player1ScoutInventory.Value);
        }

        private void numeric_player1ScoutSpeed_ValueChanged(object sender, EventArgs e)
        {
            configLoader.get().Player1.scoutSpeed = Convert.ToInt32(numeric_player1ScoutSpeed.Value);
        }

        private void numeric_player1CarryInventory_ValueChanged(object sender, EventArgs e)
        {
            configLoader.get().Player1.carryInventory = Convert.ToInt32(numeric_player1CarryInventory.Value);
        }

        private void numeric_player1CarrySpeed_ValueChanged(object sender, EventArgs e)
        {
            configLoader.get().Player1.carrySpeed = Convert.ToInt32(numeric_player1CarrySpeed.Value);
        }

        private void numeric_player1ScoutMove_ValueChanged(object sender, EventArgs e)
        {
            configLoader.get().Player1.scoutMoveRange = Convert.ToInt32(numeric_player1ScoutMove.Value);
        }

        private void numeric_player1CarryMove_ValueChanged(object sender, EventArgs e)
        {
            configLoader.get().Player1.carryMoveRange = Convert.ToInt32(numeric_player1CarryMove.Value);
        }

        private void label__player1ScoutCost_Click(object sender, EventArgs e)
        {

        }

        private void numeric_player2ScoutView_ValueChanged(object sender, EventArgs e)
        {
            configLoader.get().Player2.scoutViewRange = Convert.ToInt32(numeric_player2ScoutView.Value);
        }

        private void label__player2CarryCost_Click(object sender, EventArgs e)
        {

        }

        private void numeric_player2ScoutInventory_ValueChanged(object sender, EventArgs e)
        {
            configLoader.get().Player2.scoutInventory = Convert.ToInt32(numeric_player2ScoutInventory.Value);
        }

        private void numeric_player2ScoutSpeed_ValueChanged(object sender, EventArgs e)
        {
            configLoader.get().Player2.scoutSpeed = Convert.ToInt32(numeric_player2ScoutSpeed.Value);
        }

        private void numeric_player2CarryInventory_ValueChanged(object sender, EventArgs e)
        {
            configLoader.get().Player2.carryInventory = Convert.ToInt32(numeric_player2CarryInventory.Value);
        }

        private void numeric_player2CarrySpeed_ValueChanged(object sender, EventArgs e)
        {
            configLoader.get().Player2.carrySpeed = Convert.ToInt32(numeric_player2CarrySpeed.Value);
        }

        private void numeric_player2ScoutMove_ValueChanged(object sender, EventArgs e)
        {
            configLoader.get().Player2.scoutMoveRange = Convert.ToInt32(numeric_player2ScoutMove.Value);
        }

        private void numeric_player2CarryMove_ValueChanged(object sender, EventArgs e)
        {
            configLoader.get().Player2.carryMoveRange = Convert.ToInt32(numeric_player2CarryMove.Value);
        }

        private void numeric_player2CarryView_ValueChanged(object sender, EventArgs e)
        {
            configLoader.get().Player2.carryViewRange = Convert.ToInt32(numeric_player2CarryView.Value);
        }

        private void label__player2ScoutCost_Click(object sender, EventArgs e)
        {

        }

        private void btn_player2ConfigNew_Click(object sender, EventArgs e)
        {
            configLoader.newPlayer2();
            configLoadedOrNewCreatedPlayer2();
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
                    configLoader.player2Path = path;
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
            configLoader.get().Player2.playername = textbox_player2Name.Text;
        }

        private void numeric_gameConfigSugarMin_ValueChanged(object sender, EventArgs e)
        {
            configLoader.get().Game.sugarMin = Convert.ToInt32(numeric_gameConfigSugarMin.Value);
        }

        private void numeric_gameConfigSugarAmountMin_ValueChanged(object sender, EventArgs e)
        {
            configLoader.get().Game.sugarAmountMin = Convert.ToInt32(numeric_gameConfigSugarAmountMin.Value);
        }

        private void numeric_gameConfigStartAntAmount_ValueChanged(object sender, EventArgs e)
        {
            configLoader.get().Game.startAntAmount = Convert.ToInt32(numeric_gameConfigStartAntAmount.Value);
        }

        private void numeric_gameConfigBoardWidth_ValueChanged(object sender, EventArgs e)
        {
            configLoader.get().Game.boardWidth = Convert.ToInt32(numeric_gameConfigBoardWidth.Value);
        }

        private void numeric_gameConfigPoints_ValueChanged(object sender, EventArgs e)
        {
            configLoader.get().Game.points = Convert.ToInt32(numeric_gameConfigPoints.Value);
        }

        private void numeric_gameConfigStartMoney_ValueChanged(object sender, EventArgs e)
        {
            configLoader.get().Game.startMoney = Convert.ToInt32(numeric_gameConfigStartMoney.Value);
        }

        private void numeric_gameConfigTime_ValueChanged(object sender, EventArgs e)
        {
            configLoader.get().Game.time = Convert.ToInt32(numeric_gameConfigTime.Value);
        }

        private void numeric_gameConfigBoardHeigth_ValueChanged(object sender, EventArgs e)
        {
            configLoader.get().Game.boardHeigth = Convert.ToInt32(numeric_gameConfigBoardHeigth.Value);
        }

        private void numeric_gameConfigSugarAmountMax_ValueChanged(object sender, EventArgs e)
        {
            configLoader.get().Game.sugarAmountMax = Convert.ToInt32(numeric_gameConfigSugarAmountMax.Value);
        }

        private void numeric_gameConfigSugarMax_ValueChanged(object sender, EventArgs e)
        {
            configLoader.get().Game.sugarMax = Convert.ToInt32(numeric_gameConfigSugarMax.Value);
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
                    configLoader.gamePath = path;
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
            if (!checkMinMax(conf.sugarMin, conf.sugarMax)) return false;
            if (!checkMinMax(conf.sugarAmountMin, conf.sugarAmountMax)) return false;
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
            if(!isGameRunning(sender))
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
            foreach(GamePanel gamePanel in gamePanels)
            {
                if(!gamePanel.IsDisposed && sender != gamePanel)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
