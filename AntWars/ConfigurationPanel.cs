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

        public ConfigurationPanel()
        {
            InitializeComponent();
        }

        private void Start_Click(object sender, EventArgs e)
        {
            if (configLoader.isAllLoaded())
            {
                game = new Game(configLoader.get());
                game.start();
                GameTick.Start();
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
            configLoadedOrNewCreated();
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
                configLoadedOrNewCreated();
                loadPlayer1(configLoader.get().Player1);
            }
        }

        private void configLoadedOrNewCreated()
        {
            btn_player1ConfigLoad.Enabled = false;
            btn_player1ConfigNew.Enabled = false;
            btn_player1ConfigSave.Enabled = true;
            pnl_player1Config.Enabled = true;
        }

        private void loadPlayer1(PlayerConfig conf)
        {
            textbox_player1Name.Text = conf.playername;
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
    }
}
