﻿using System;
using System.Windows.Forms;

namespace AntWars {

    public partial class CostCalculator : Form {

        public CostCalculator() {
            InitializeComponent();
            calcCarry();
            calcScout();
            calcWarrior();
        }

        private void numeric_scoutViewRange_ValueChanged(object sender, EventArgs e) {
            calcScout();
        }

        private void numeric_scoutMoveRange_ValueChanged(object sender, EventArgs e) {
            calcScout();
        }

        private void numeric_scoutInventory_ValueChanged(object sender, EventArgs e) {
            calcScout();
        }

        private void numeric_carryViewRange_ValueChanged(object sender, EventArgs e) {
            calcCarry();
        }

        private void numeric_carryMoveRange_ValueChanged(object sender, EventArgs e) {
            calcCarry();
        }

        private void numeric_carryInventory_ValueChanged(object sender, EventArgs e) {
            calcCarry();
        }

        private void calcScout() {
            lbl_scoutCost.Text = Convert.ToString(Helper.CostCalculator.calculateCostScout(Convert.ToInt32(nmc_scoutViewRange.Value),
                                                                                             Convert.ToInt32(nmc_scoutMoveRange.Value),
                                                                                             Convert.ToInt32(nmc_scoutInventory.Value),
                                                                                             Convert.ToInt32(nmc_scoutHealth.Value),
                                                                                             ""));
        }

        private void calcCarry() {
            lbl_carryCost.Text = Convert.ToString(Helper.CostCalculator.calculateCostCarry(Convert.ToInt32(nmc_carryViewRange.Value),
                                                                                             Convert.ToInt32(nmc_carryMoveRange.Value),
                                                                                             Convert.ToInt32(nmc_carryInventory.Value),
                                                                                             Convert.ToInt32(nmc_carryHealth.Value),
                                                                                             ""));
        }

        private void calcWarrior() {
            lbl_warriorCost.Text = Convert.ToString(Helper.CostCalculator.calculateCostWarrior(Convert.ToInt32(nmc_warriorAttackPower.Value), 
                                                                                             Convert.ToInt32(nmc_warriorViewRange.Value),
                                                                                             Convert.ToInt32(nmc_warriorMoveRange.Value),
                                                                                             Convert.ToInt32(nmc_warriorInventory.Value),
                                                                                             Convert.ToInt32(nmc_warriorHealth.Value),
                                                                                             ""));
        }

        private void numeric_scoutHealth_ValueChanged(object sender, EventArgs e) {
            calcScout();
        }

        private void numeric_CarryHealth_ValueChanged(object sender, EventArgs e) {
            calcScout();
        }

        private void numeric_warriorInventory_ValueChanged(object sender, EventArgs e) {
            calcWarrior();
        }

        private void numeric_warriorMoveRange_ValueChanged(object sender, EventArgs e) {
            calcWarrior();
        }

        private void numeric_warriorViewRange_ValueChanged(object sender, EventArgs e) {
            calcWarrior();
        }

        private void numeric_warriorHealth_ValueChanged(object sender, EventArgs e) {
            calcWarrior();
        }
    }
}
