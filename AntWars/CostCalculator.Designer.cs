namespace AntWars
{
    partial class CostCalculator
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbl_viewrange = new System.Windows.Forms.Label();
            this.lbl_moverange = new System.Windows.Forms.Label();
            this.lbl_inventory = new System.Windows.Forms.Label();
            this.lbl_costs = new System.Windows.Forms.Label();
            this.lbl_carry = new System.Windows.Forms.Label();
            this.lbl_scout = new System.Windows.Forms.Label();
            this.nmc_scoutViewRange = new System.Windows.Forms.NumericUpDown();
            this.nmc_carryViewRange = new System.Windows.Forms.NumericUpDown();
            this.nmc_carryMoveRange = new System.Windows.Forms.NumericUpDown();
            this.nmc_carryInventory = new System.Windows.Forms.NumericUpDown();
            this.nmc_scoutInventory = new System.Windows.Forms.NumericUpDown();
            this.nmc_scoutMoveRange = new System.Windows.Forms.NumericUpDown();
            this.lbl_scoutCost = new System.Windows.Forms.Label();
            this.lbl_carryCost = new System.Windows.Forms.Label();
            this.lbl_health = new System.Windows.Forms.Label();
            this.nmc_scoutHealth = new System.Windows.Forms.NumericUpDown();
            this.nmc_carryHealth = new System.Windows.Forms.NumericUpDown();
            this.lbl_warrior = new System.Windows.Forms.Label();
            this.nmc_warriorHealth = new System.Windows.Forms.NumericUpDown();
            this.nmc_warriorViewRange = new System.Windows.Forms.NumericUpDown();
            this.nmc_warriorMoveRange = new System.Windows.Forms.NumericUpDown();
            this.nmc_warriorInventory = new System.Windows.Forms.NumericUpDown();
            this.lbl_warriorCost = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nmc_scoutViewRange)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmc_carryViewRange)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmc_carryMoveRange)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmc_carryInventory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmc_scoutInventory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmc_scoutMoveRange)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmc_scoutHealth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmc_carryHealth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmc_warriorHealth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmc_warriorViewRange)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmc_warriorMoveRange)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmc_warriorInventory)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_viewrange
            // 
            this.lbl_viewrange.AutoSize = true;
            this.lbl_viewrange.Location = new System.Drawing.Point(4, 60);
            this.lbl_viewrange.Name = "lbl_viewrange";
            this.lbl_viewrange.Size = new System.Drawing.Size(56, 13);
            this.lbl_viewrange.TabIndex = 0;
            this.lbl_viewrange.Text = "Sichtweite";
            // 
            // lbl_moverange
            // 
            this.lbl_moverange.AutoSize = true;
            this.lbl_moverange.Location = new System.Drawing.Point(4, 86);
            this.lbl_moverange.Name = "lbl_moverange";
            this.lbl_moverange.Size = new System.Drawing.Size(60, 13);
            this.lbl_moverange.TabIndex = 1;
            this.lbl_moverange.Text = "Reichweite";
            // 
            // lbl_inventory
            // 
            this.lbl_inventory.AutoSize = true;
            this.lbl_inventory.Location = new System.Drawing.Point(4, 112);
            this.lbl_inventory.Name = "lbl_inventory";
            this.lbl_inventory.Size = new System.Drawing.Size(46, 13);
            this.lbl_inventory.TabIndex = 2;
            this.lbl_inventory.Text = "Inventar";
            // 
            // lbl_costs
            // 
            this.lbl_costs.AutoSize = true;
            this.lbl_costs.Location = new System.Drawing.Point(4, 142);
            this.lbl_costs.Name = "lbl_costs";
            this.lbl_costs.Size = new System.Drawing.Size(40, 13);
            this.lbl_costs.TabIndex = 4;
            this.lbl_costs.Text = "Kosten";
            // 
            // lbl_carry
            // 
            this.lbl_carry.AutoSize = true;
            this.lbl_carry.Location = new System.Drawing.Point(232, 9);
            this.lbl_carry.Name = "lbl_carry";
            this.lbl_carry.Size = new System.Drawing.Size(31, 13);
            this.lbl_carry.TabIndex = 5;
            this.lbl_carry.Text = "Carry";
            // 
            // lbl_scout
            // 
            this.lbl_scout.AutoSize = true;
            this.lbl_scout.Location = new System.Drawing.Point(189, 9);
            this.lbl_scout.Name = "lbl_scout";
            this.lbl_scout.Size = new System.Drawing.Size(35, 13);
            this.lbl_scout.TabIndex = 6;
            this.lbl_scout.Text = "Scout";
            // 
            // nmc_scoutViewRange
            // 
            this.nmc_scoutViewRange.Location = new System.Drawing.Point(192, 58);
            this.nmc_scoutViewRange.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nmc_scoutViewRange.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmc_scoutViewRange.Name = "nmc_scoutViewRange";
            this.nmc_scoutViewRange.Size = new System.Drawing.Size(37, 20);
            this.nmc_scoutViewRange.TabIndex = 7;
            this.nmc_scoutViewRange.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmc_scoutViewRange.ValueChanged += new System.EventHandler(this.numeric_scoutViewRange_ValueChanged);
            // 
            // nmc_carryViewRange
            // 
            this.nmc_carryViewRange.Location = new System.Drawing.Point(235, 58);
            this.nmc_carryViewRange.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nmc_carryViewRange.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmc_carryViewRange.Name = "nmc_carryViewRange";
            this.nmc_carryViewRange.Size = new System.Drawing.Size(37, 20);
            this.nmc_carryViewRange.TabIndex = 8;
            this.nmc_carryViewRange.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmc_carryViewRange.ValueChanged += new System.EventHandler(this.numeric_carryViewRange_ValueChanged);
            // 
            // nmc_carryMoveRange
            // 
            this.nmc_carryMoveRange.Location = new System.Drawing.Point(235, 84);
            this.nmc_carryMoveRange.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nmc_carryMoveRange.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmc_carryMoveRange.Name = "nmc_carryMoveRange";
            this.nmc_carryMoveRange.Size = new System.Drawing.Size(37, 20);
            this.nmc_carryMoveRange.TabIndex = 9;
            this.nmc_carryMoveRange.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmc_carryMoveRange.ValueChanged += new System.EventHandler(this.numeric_carryMoveRange_ValueChanged);
            // 
            // nmc_carryInventory
            // 
            this.nmc_carryInventory.Location = new System.Drawing.Point(235, 110);
            this.nmc_carryInventory.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nmc_carryInventory.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmc_carryInventory.Name = "nmc_carryInventory";
            this.nmc_carryInventory.Size = new System.Drawing.Size(37, 20);
            this.nmc_carryInventory.TabIndex = 10;
            this.nmc_carryInventory.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmc_carryInventory.ValueChanged += new System.EventHandler(this.numeric_carryInventory_ValueChanged);
            // 
            // nmc_scoutInventory
            // 
            this.nmc_scoutInventory.Location = new System.Drawing.Point(192, 110);
            this.nmc_scoutInventory.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nmc_scoutInventory.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmc_scoutInventory.Name = "nmc_scoutInventory";
            this.nmc_scoutInventory.Size = new System.Drawing.Size(37, 20);
            this.nmc_scoutInventory.TabIndex = 13;
            this.nmc_scoutInventory.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmc_scoutInventory.ValueChanged += new System.EventHandler(this.numeric_scoutInventory_ValueChanged);
            // 
            // nmc_scoutMoveRange
            // 
            this.nmc_scoutMoveRange.Location = new System.Drawing.Point(192, 84);
            this.nmc_scoutMoveRange.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nmc_scoutMoveRange.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmc_scoutMoveRange.Name = "nmc_scoutMoveRange";
            this.nmc_scoutMoveRange.Size = new System.Drawing.Size(37, 20);
            this.nmc_scoutMoveRange.TabIndex = 14;
            this.nmc_scoutMoveRange.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmc_scoutMoveRange.ValueChanged += new System.EventHandler(this.numeric_scoutMoveRange_ValueChanged);
            // 
            // lbl_scoutCost
            // 
            this.lbl_scoutCost.AutoSize = true;
            this.lbl_scoutCost.Location = new System.Drawing.Point(216, 142);
            this.lbl_scoutCost.Name = "lbl_scoutCost";
            this.lbl_scoutCost.Size = new System.Drawing.Size(13, 13);
            this.lbl_scoutCost.TabIndex = 27;
            this.lbl_scoutCost.Text = "0";
            // 
            // lbl_carryCost
            // 
            this.lbl_carryCost.AutoSize = true;
            this.lbl_carryCost.Location = new System.Drawing.Point(259, 142);
            this.lbl_carryCost.Name = "lbl_carryCost";
            this.lbl_carryCost.Size = new System.Drawing.Size(13, 13);
            this.lbl_carryCost.TabIndex = 28;
            this.lbl_carryCost.Text = "0";
            // 
            // lbl_health
            // 
            this.lbl_health.AutoSize = true;
            this.lbl_health.Location = new System.Drawing.Point(4, 34);
            this.lbl_health.Name = "lbl_health";
            this.lbl_health.Size = new System.Drawing.Size(75, 13);
            this.lbl_health.TabIndex = 29;
            this.lbl_health.Text = "Lebenspunkte";
            // 
            // nmc_scoutHealth
            // 
            this.nmc_scoutHealth.Location = new System.Drawing.Point(192, 32);
            this.nmc_scoutHealth.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nmc_scoutHealth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmc_scoutHealth.Name = "nmc_scoutHealth";
            this.nmc_scoutHealth.Size = new System.Drawing.Size(37, 20);
            this.nmc_scoutHealth.TabIndex = 30;
            this.nmc_scoutHealth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmc_scoutHealth.ValueChanged += new System.EventHandler(this.numeric_scoutHealth_ValueChanged);
            // 
            // nmc_carryHealth
            // 
            this.nmc_carryHealth.Location = new System.Drawing.Point(235, 32);
            this.nmc_carryHealth.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nmc_carryHealth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmc_carryHealth.Name = "nmc_carryHealth";
            this.nmc_carryHealth.Size = new System.Drawing.Size(37, 20);
            this.nmc_carryHealth.TabIndex = 31;
            this.nmc_carryHealth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmc_carryHealth.ValueChanged += new System.EventHandler(this.numeric_CarryHealth_ValueChanged);
            // 
            // lbl_warrior
            // 
            this.lbl_warrior.AutoSize = true;
            this.lbl_warrior.Location = new System.Drawing.Point(275, 9);
            this.lbl_warrior.Name = "lbl_warrior";
            this.lbl_warrior.Size = new System.Drawing.Size(41, 13);
            this.lbl_warrior.TabIndex = 32;
            this.lbl_warrior.Text = "Warrior";
            // 
            // nmc_warriorHealth
            // 
            this.nmc_warriorHealth.Location = new System.Drawing.Point(278, 32);
            this.nmc_warriorHealth.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nmc_warriorHealth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmc_warriorHealth.Name = "nmc_warriorHealth";
            this.nmc_warriorHealth.Size = new System.Drawing.Size(37, 20);
            this.nmc_warriorHealth.TabIndex = 33;
            this.nmc_warriorHealth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmc_warriorHealth.ValueChanged += new System.EventHandler(this.numeric_warriorHealth_ValueChanged);
            // 
            // nmc_warriorViewRange
            // 
            this.nmc_warriorViewRange.Location = new System.Drawing.Point(278, 58);
            this.nmc_warriorViewRange.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nmc_warriorViewRange.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmc_warriorViewRange.Name = "nmc_warriorViewRange";
            this.nmc_warriorViewRange.Size = new System.Drawing.Size(37, 20);
            this.nmc_warriorViewRange.TabIndex = 34;
            this.nmc_warriorViewRange.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmc_warriorViewRange.ValueChanged += new System.EventHandler(this.numeric_warriorViewRange_ValueChanged);
            // 
            // nmc_warriorMoveRange
            // 
            this.nmc_warriorMoveRange.Location = new System.Drawing.Point(278, 84);
            this.nmc_warriorMoveRange.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nmc_warriorMoveRange.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmc_warriorMoveRange.Name = "nmc_warriorMoveRange";
            this.nmc_warriorMoveRange.Size = new System.Drawing.Size(37, 20);
            this.nmc_warriorMoveRange.TabIndex = 35;
            this.nmc_warriorMoveRange.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmc_warriorMoveRange.ValueChanged += new System.EventHandler(this.numeric_warriorMoveRange_ValueChanged);
            // 
            // nmc_warriorInventory
            // 
            this.nmc_warriorInventory.Location = new System.Drawing.Point(278, 110);
            this.nmc_warriorInventory.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nmc_warriorInventory.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmc_warriorInventory.Name = "nmc_warriorInventory";
            this.nmc_warriorInventory.Size = new System.Drawing.Size(37, 20);
            this.nmc_warriorInventory.TabIndex = 36;
            this.nmc_warriorInventory.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmc_warriorInventory.ValueChanged += new System.EventHandler(this.numeric_warriorInventory_ValueChanged);
            // 
            // lbl_warriorCost
            // 
            this.lbl_warriorCost.AutoSize = true;
            this.lbl_warriorCost.Location = new System.Drawing.Point(302, 142);
            this.lbl_warriorCost.Name = "lbl_warriorCost";
            this.lbl_warriorCost.Size = new System.Drawing.Size(13, 13);
            this.lbl_warriorCost.TabIndex = 37;
            this.lbl_warriorCost.Text = "0";
            // 
            // CostCalculator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(351, 164);
            this.Controls.Add(this.lbl_warriorCost);
            this.Controls.Add(this.nmc_warriorInventory);
            this.Controls.Add(this.nmc_warriorMoveRange);
            this.Controls.Add(this.nmc_warriorViewRange);
            this.Controls.Add(this.nmc_warriorHealth);
            this.Controls.Add(this.lbl_warrior);
            this.Controls.Add(this.nmc_carryHealth);
            this.Controls.Add(this.nmc_scoutHealth);
            this.Controls.Add(this.lbl_health);
            this.Controls.Add(this.lbl_carryCost);
            this.Controls.Add(this.lbl_scoutCost);
            this.Controls.Add(this.nmc_scoutMoveRange);
            this.Controls.Add(this.nmc_scoutInventory);
            this.Controls.Add(this.nmc_carryInventory);
            this.Controls.Add(this.nmc_carryMoveRange);
            this.Controls.Add(this.nmc_carryViewRange);
            this.Controls.Add(this.nmc_scoutViewRange);
            this.Controls.Add(this.lbl_scout);
            this.Controls.Add(this.lbl_carry);
            this.Controls.Add(this.lbl_costs);
            this.Controls.Add(this.lbl_inventory);
            this.Controls.Add(this.lbl_moverange);
            this.Controls.Add(this.lbl_viewrange);
            this.Name = "CostCalculator";
            this.Text = "CostCalculator";
            ((System.ComponentModel.ISupportInitialize)(this.nmc_scoutViewRange)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmc_carryViewRange)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmc_carryMoveRange)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmc_carryInventory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmc_scoutInventory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmc_scoutMoveRange)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmc_scoutHealth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmc_carryHealth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmc_warriorHealth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmc_warriorViewRange)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmc_warriorMoveRange)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmc_warriorInventory)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_viewrange;
        private System.Windows.Forms.Label lbl_moverange;
        private System.Windows.Forms.Label lbl_inventory;
        private System.Windows.Forms.Label lbl_costs;
        private System.Windows.Forms.Label lbl_carry;
        private System.Windows.Forms.Label lbl_scout;
        private System.Windows.Forms.NumericUpDown nmc_scoutViewRange;
        private System.Windows.Forms.NumericUpDown nmc_carryViewRange;
        private System.Windows.Forms.NumericUpDown nmc_carryMoveRange;
        private System.Windows.Forms.NumericUpDown nmc_carryInventory;
        private System.Windows.Forms.NumericUpDown nmc_scoutInventory;
        private System.Windows.Forms.NumericUpDown nmc_scoutMoveRange;
        private System.Windows.Forms.Label lbl_scoutCost;
        private System.Windows.Forms.Label lbl_carryCost;
        private System.Windows.Forms.Label lbl_health;
        private System.Windows.Forms.NumericUpDown nmc_scoutHealth;
        private System.Windows.Forms.NumericUpDown nmc_carryHealth;
        private System.Windows.Forms.Label lbl_warrior;
        private System.Windows.Forms.NumericUpDown nmc_warriorHealth;
        private System.Windows.Forms.NumericUpDown nmc_warriorViewRange;
        private System.Windows.Forms.NumericUpDown nmc_warriorMoveRange;
        private System.Windows.Forms.NumericUpDown nmc_warriorInventory;
        private System.Windows.Forms.Label lbl_warriorCost;
    }
}