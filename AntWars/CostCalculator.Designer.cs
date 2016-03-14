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
            this.Sichtweite = new System.Windows.Forms.Label();
            this.Reichweite = new System.Windows.Forms.Label();
            this.Inventar = new System.Windows.Forms.Label();
            this.Kosten = new System.Windows.Forms.Label();
            this.Carry = new System.Windows.Forms.Label();
            this.Scout = new System.Windows.Forms.Label();
            this.numeric_scoutViewRange = new System.Windows.Forms.NumericUpDown();
            this.numeric_carryViewRange = new System.Windows.Forms.NumericUpDown();
            this.numeric_carryMoveRange = new System.Windows.Forms.NumericUpDown();
            this.numeric_carryInventory = new System.Windows.Forms.NumericUpDown();
            this.numeric_scoutInventory = new System.Windows.Forms.NumericUpDown();
            this.numeric_scoutMoveRange = new System.Windows.Forms.NumericUpDown();
            this.label_scoutCost = new System.Windows.Forms.Label();
            this.label_carryCost = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_scoutViewRange)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_carryViewRange)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_carryMoveRange)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_carryInventory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_scoutInventory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_scoutMoveRange)).BeginInit();
            this.SuspendLayout();
            // 
            // Sichtweite
            // 
            this.Sichtweite.AutoSize = true;
            this.Sichtweite.Location = new System.Drawing.Point(4, 27);
            this.Sichtweite.Name = "Sichtweite";
            this.Sichtweite.Size = new System.Drawing.Size(56, 13);
            this.Sichtweite.TabIndex = 0;
            this.Sichtweite.Text = "Sichtweite";
            // 
            // Reichweite
            // 
            this.Reichweite.AutoSize = true;
            this.Reichweite.Location = new System.Drawing.Point(4, 53);
            this.Reichweite.Name = "Reichweite";
            this.Reichweite.Size = new System.Drawing.Size(60, 13);
            this.Reichweite.TabIndex = 1;
            this.Reichweite.Text = "Reichweite";
            // 
            // Inventar
            // 
            this.Inventar.AutoSize = true;
            this.Inventar.Location = new System.Drawing.Point(4, 79);
            this.Inventar.Name = "Inventar";
            this.Inventar.Size = new System.Drawing.Size(46, 13);
            this.Inventar.TabIndex = 2;
            this.Inventar.Text = "Inventar";
            // 
            // Kosten
            // 
            this.Kosten.AutoSize = true;
            this.Kosten.Location = new System.Drawing.Point(4, 100);
            this.Kosten.Name = "Kosten";
            this.Kosten.Size = new System.Drawing.Size(40, 13);
            this.Kosten.TabIndex = 4;
            this.Kosten.Text = "Kosten";
            // 
            // Carry
            // 
            this.Carry.AutoSize = true;
            this.Carry.Location = new System.Drawing.Point(241, 9);
            this.Carry.Name = "Carry";
            this.Carry.Size = new System.Drawing.Size(31, 13);
            this.Carry.TabIndex = 5;
            this.Carry.Text = "Carry";
            // 
            // Scout
            // 
            this.Scout.AutoSize = true;
            this.Scout.Location = new System.Drawing.Point(194, 9);
            this.Scout.Name = "Scout";
            this.Scout.Size = new System.Drawing.Size(35, 13);
            this.Scout.TabIndex = 6;
            this.Scout.Text = "Scout";
            // 
            // numeric_scoutViewRange
            // 
            this.numeric_scoutViewRange.Location = new System.Drawing.Point(192, 25);
            this.numeric_scoutViewRange.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numeric_scoutViewRange.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numeric_scoutViewRange.Name = "numeric_scoutViewRange";
            this.numeric_scoutViewRange.Size = new System.Drawing.Size(37, 20);
            this.numeric_scoutViewRange.TabIndex = 7;
            this.numeric_scoutViewRange.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numeric_scoutViewRange.ValueChanged += new System.EventHandler(this.numeric_scoutViewRange_ValueChanged);
            // 
            // numeric_carryViewRange
            // 
            this.numeric_carryViewRange.Location = new System.Drawing.Point(235, 25);
            this.numeric_carryViewRange.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numeric_carryViewRange.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numeric_carryViewRange.Name = "numeric_carryViewRange";
            this.numeric_carryViewRange.Size = new System.Drawing.Size(37, 20);
            this.numeric_carryViewRange.TabIndex = 8;
            this.numeric_carryViewRange.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numeric_carryViewRange.ValueChanged += new System.EventHandler(this.numeric_carryViewRange_ValueChanged);
            // 
            // numeric_carryMoveRange
            // 
            this.numeric_carryMoveRange.Location = new System.Drawing.Point(235, 51);
            this.numeric_carryMoveRange.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numeric_carryMoveRange.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numeric_carryMoveRange.Name = "numeric_carryMoveRange";
            this.numeric_carryMoveRange.Size = new System.Drawing.Size(37, 20);
            this.numeric_carryMoveRange.TabIndex = 9;
            this.numeric_carryMoveRange.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numeric_carryMoveRange.ValueChanged += new System.EventHandler(this.numeric_carryMoveRange_ValueChanged);
            // 
            // numeric_carryInventory
            // 
            this.numeric_carryInventory.Location = new System.Drawing.Point(235, 77);
            this.numeric_carryInventory.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numeric_carryInventory.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numeric_carryInventory.Name = "numeric_carryInventory";
            this.numeric_carryInventory.Size = new System.Drawing.Size(37, 20);
            this.numeric_carryInventory.TabIndex = 10;
            this.numeric_carryInventory.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numeric_carryInventory.ValueChanged += new System.EventHandler(this.numeric_carryInventory_ValueChanged);
            // 
            // numeric_scoutInventory
            // 
            this.numeric_scoutInventory.Location = new System.Drawing.Point(192, 77);
            this.numeric_scoutInventory.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numeric_scoutInventory.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numeric_scoutInventory.Name = "numeric_scoutInventory";
            this.numeric_scoutInventory.Size = new System.Drawing.Size(37, 20);
            this.numeric_scoutInventory.TabIndex = 13;
            this.numeric_scoutInventory.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numeric_scoutInventory.ValueChanged += new System.EventHandler(this.numeric_scoutInventory_ValueChanged);
            // 
            // numeric_scoutMoveRange
            // 
            this.numeric_scoutMoveRange.Location = new System.Drawing.Point(192, 51);
            this.numeric_scoutMoveRange.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numeric_scoutMoveRange.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numeric_scoutMoveRange.Name = "numeric_scoutMoveRange";
            this.numeric_scoutMoveRange.Size = new System.Drawing.Size(37, 20);
            this.numeric_scoutMoveRange.TabIndex = 14;
            this.numeric_scoutMoveRange.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numeric_scoutMoveRange.ValueChanged += new System.EventHandler(this.numeric_scoutMoveRange_ValueChanged);
            // 
            // label_scoutCost
            // 
            this.label_scoutCost.AutoSize = true;
            this.label_scoutCost.Location = new System.Drawing.Point(216, 100);
            this.label_scoutCost.Name = "label_scoutCost";
            this.label_scoutCost.Size = new System.Drawing.Size(13, 13);
            this.label_scoutCost.TabIndex = 27;
            this.label_scoutCost.Text = "0";
            // 
            // label_carryCost
            // 
            this.label_carryCost.AutoSize = true;
            this.label_carryCost.Location = new System.Drawing.Point(259, 100);
            this.label_carryCost.Name = "label_carryCost";
            this.label_carryCost.Size = new System.Drawing.Size(13, 13);
            this.label_carryCost.TabIndex = 28;
            this.label_carryCost.Text = "0";
            // 
            // CostCalculator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(280, 120);
            this.Controls.Add(this.label_carryCost);
            this.Controls.Add(this.label_scoutCost);
            this.Controls.Add(this.numeric_scoutMoveRange);
            this.Controls.Add(this.numeric_scoutInventory);
            this.Controls.Add(this.numeric_carryInventory);
            this.Controls.Add(this.numeric_carryMoveRange);
            this.Controls.Add(this.numeric_carryViewRange);
            this.Controls.Add(this.numeric_scoutViewRange);
            this.Controls.Add(this.Scout);
            this.Controls.Add(this.Carry);
            this.Controls.Add(this.Kosten);
            this.Controls.Add(this.Inventar);
            this.Controls.Add(this.Reichweite);
            this.Controls.Add(this.Sichtweite);
            this.Name = "CostCalculator";
            this.Text = "CostCalculator";
            ((System.ComponentModel.ISupportInitialize)(this.numeric_scoutViewRange)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_carryViewRange)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_carryMoveRange)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_carryInventory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_scoutInventory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_scoutMoveRange)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Sichtweite;
        private System.Windows.Forms.Label Reichweite;
        private System.Windows.Forms.Label Inventar;
        private System.Windows.Forms.Label Kosten;
        private System.Windows.Forms.Label Carry;
        private System.Windows.Forms.Label Scout;
        private System.Windows.Forms.NumericUpDown numeric_scoutViewRange;
        private System.Windows.Forms.NumericUpDown numeric_carryViewRange;
        private System.Windows.Forms.NumericUpDown numeric_carryMoveRange;
        private System.Windows.Forms.NumericUpDown numeric_carryInventory;
        private System.Windows.Forms.NumericUpDown numeric_scoutInventory;
        private System.Windows.Forms.NumericUpDown numeric_scoutMoveRange;
        private System.Windows.Forms.Label label_scoutCost;
        private System.Windows.Forms.Label label_carryCost;
    }
}