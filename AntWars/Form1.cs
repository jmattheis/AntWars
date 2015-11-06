using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AntWars.Board;

namespace AntWars
{
    public partial class Form1 : Form
    {
        private Game game;

        public Form1()
        {
            InitializeComponent();
            // TODO Config tralala

        }

        // TODO startbutton
        // TODO new Game(conf);
        // TODO game.Start();

        
        public void print()
        {
            List<BoardObject> objects = game.Board.BoardObjects;
            // TODO ya
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            game.Board.nextTick();
            print();
        }

        private void timer1_Tick()
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }

        
}
