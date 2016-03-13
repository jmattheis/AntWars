using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AntWars;

namespace AntWars
{
    public partial class CostCalculator : Form
    {
        public CostCalculator()
        {
            InitializeComponent();
            calcCarry();
            calcScout();
        }

        private void numeric_scoutViewRange_ValueChanged(object sender, EventArgs e)
        {
            calcScout();
        }

        private void numeric_scoutMoveRange_ValueChanged(object sender, EventArgs e)
        {
            calcScout();
        }

        private void numeric_scoutInventory_ValueChanged(object sender, EventArgs e)
        {
            calcScout();
        }

        private void label_scoutCost_Click(object sender, EventArgs e)
        {

        }

        private void numeric_carryViewRange_ValueChanged(object sender, EventArgs e)
        {
            calcCarry();
        }

        private void numeric_carryMoveRange_ValueChanged(object sender, EventArgs e)
        {
            calcCarry();
        }

        private void numeric_carryInventory_ValueChanged(object sender, EventArgs e)
        {
            calcCarry();
        }

        private void label_carryCost_Click(object sender, EventArgs e)
        {

        }

        private void CostCalculator_Load(object sender, EventArgs e)
        {

        }

        private void calcScout()
        {
            label_scoutCost.Text = Convert.ToString(Helper.CostCalculator.calculateCostScout(Convert.ToInt32(numeric_scoutViewRange.Value),
                                                                                             Convert.ToInt32(numeric_scoutMoveRange.Value),
                                                                                             Convert.ToInt32(numeric_scoutInventory.Value)
                                                                                             ));
        }

        private void calcCarry()
        {
            label_carryCost.Text = Convert.ToString(Helper.CostCalculator.calculateCostCarry(Convert.ToInt32(numeric_carryViewRange.Value),
                                                                                             Convert.ToInt32(numeric_carryMoveRange.Value),
                                                                                             Convert.ToInt32(numeric_carryInventory.Value)
                                                                                             ));
        }
    }
}
