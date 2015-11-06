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



namespace AntWars
{
    public partial class ConfigurationPanel : Form
    {
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
    }
}
