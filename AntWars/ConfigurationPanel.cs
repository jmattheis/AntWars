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
                // TODO FEHLERMELDUNG
            }
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
                configLoader.loadPlayer1(dia.FileName);
            }
        }

        private void player2ConfigToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dia = new OpenFileDialog();
            dia.ShowDialog();
            if (!string.IsNullOrEmpty(dia.FileName))
            {
                configLoader.loadPlayer2(dia.FileName);
            }
        }

        private void gameConfigToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dia = new OpenFileDialog();
            dia.ShowDialog();
            if (!string.IsNullOrEmpty(dia.FileName))
            {
                configLoader.loadGame(dia.FileName);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            configLoader.save();
        }
    }
}
