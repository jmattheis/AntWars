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


namespace AntWars
{
    public partial class ConfigurationPanel : Form
    {


        private string Player1Config_Path { get; set; }
        private string Player2Config_Path { get; set; }
        private string GameConfig_Path { get; set; }

        private Game game { get; set; }
        private Configuration conf { get; set; }
        public ConfigurationPanel()
        {
            InitializeComponent();
        }

        private void Start_Click(object sender, EventArgs e)
        {
            game = new Game(conf);
            game.start();
            GameTick.Start();
        }

        private void GameTick_Tick(object sender, EventArgs e)
        {
            game.nextTick();
        }

        private void player1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dia = new OpenFileDialog();
            dia.ShowDialog();
            if (!string.IsNullOrEmpty(dia.FileName))
            {
                ConfigurationLoader.loadConfig(dia.FileName);
                Player1Config_Path = dia.FileName;
            }
        }

        private void player2ConfigToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dia = new OpenFileDialog();
            dia.ShowDialog();
            if (!string.IsNullOrEmpty(dia.FileName))
            {
                ConfigurationLoader.loadConfig(dia.FileName);
                Player2Config_Path = dia.FileName;
            }
        }

        private void gameConfigToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dia = new OpenFileDialog();
            dia.ShowDialog();
            if (!string.IsNullOrEmpty(dia.FileName))
            {
                ConfigurationLoader.loadConfig(dia.FileName);
                GameConfig_Path = dia.FileName;
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Player1Config_Path) && string.IsNullOrEmpty(Player2Config_Path) && !string.IsNullOrEmpty(GameConfig_Path))
            {
                ConfigurationLoader.writeConfig(conf, GameConfig_Path, Player1Config_Path, Player2Config_Path);
            }
            else
            {
                FolderBrowserDialog dia = new FolderBrowserDialog();
                dia.ShowDialog();
                if(!string.IsNullOrEmpty(dia.SelectedPath))
                {
                    ConfigurationLoader.writeConfig(conf, dia.SelectedPath + "/Player1_Config.xml", dia.SelectedPath + "/Player2_Config.xml", dia.SelectedPath + "/Game_Config.xml");
                }
            }
        }
    }
}
