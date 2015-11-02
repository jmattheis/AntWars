using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AntWars
{
    public partial class Form1 : Form
    {
        private Game game;

        public Form1()
        {
            InitializeComponent();
            this.game = new Game();

        }

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
    }

        
}
