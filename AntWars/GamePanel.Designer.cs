namespace AntWars
{
    partial class GamePanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GamePanel));
            this.pb_Game = new System.Windows.Forms.PictureBox();
            this.grp_stats = new System.Windows.Forms.GroupBox();
            this.grp_player2 = new System.Windows.Forms.GroupBox();
            this.lbl_player2AntsValue = new System.Windows.Forms.Label();
            this.lbl_player2Ants = new System.Windows.Forms.Label();
            this.lbl_player2ScoutsValue = new System.Windows.Forms.Label();
            this.lbl_player2Scouts = new System.Windows.Forms.Label();
            this.lbl_player2CarriesValue = new System.Windows.Forms.Label();
            this.lbl_player2Carries = new System.Windows.Forms.Label();
            this.lbl_player2MoneyValue = new System.Windows.Forms.Label();
            this.lbl_player2Money = new System.Windows.Forms.Label();
            this.lbl_player2PointsValue = new System.Windows.Forms.Label();
            this.lbl_player2Points = new System.Windows.Forms.Label();
            this.grp_player1 = new System.Windows.Forms.GroupBox();
            this.lbl_player1AntsValue = new System.Windows.Forms.Label();
            this.lbl_player1Ants = new System.Windows.Forms.Label();
            this.lbl_player1ScoutsValue = new System.Windows.Forms.Label();
            this.lbl_player1Scouts = new System.Windows.Forms.Label();
            this.lbl_player1CarriesValue = new System.Windows.Forms.Label();
            this.lbl_player1Carries = new System.Windows.Forms.Label();
            this.lbl_player1MoneyValue = new System.Windows.Forms.Label();
            this.lbl_player1Money = new System.Windows.Forms.Label();
            this.lbl_player1PointsValue = new System.Windows.Forms.Label();
            this.lbl_player1Points = new System.Windows.Forms.Label();
            this.grp_gamestats = new System.Windows.Forms.GroupBox();
            this.lbl_sugarValue = new System.Windows.Forms.Label();
            this.lbl_sugar = new System.Windows.Forms.Label();
            this.lbl_ticksValue = new System.Windows.Forms.Label();
            this.lbl_ticks = new System.Windows.Forms.Label();
            this.lbl_player1Warrior = new System.Windows.Forms.Label();
            this.lbl_player1WarriorsValue = new System.Windows.Forms.Label();
            this.lbl_player2Warrior = new System.Windows.Forms.Label();
            this.lbl_player2WarriorsValue = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Game)).BeginInit();
            this.grp_stats.SuspendLayout();
            this.grp_player2.SuspendLayout();
            this.grp_player1.SuspendLayout();
            this.grp_gamestats.SuspendLayout();
            this.SuspendLayout();
            // 
            // pb_Game
            // 
            this.pb_Game.BackColor = System.Drawing.Color.White;
            this.pb_Game.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pb_Game.BackgroundImage")));
            this.pb_Game.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pb_Game.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pb_Game.Location = new System.Drawing.Point(0, 0);
            this.pb_Game.Name = "pb_Game";
            this.pb_Game.Size = new System.Drawing.Size(284, 352);
            this.pb_Game.TabIndex = 0;
            this.pb_Game.TabStop = false;
            // 
            // grp_stats
            // 
            this.grp_stats.Controls.Add(this.grp_player2);
            this.grp_stats.Controls.Add(this.grp_player1);
            this.grp_stats.Controls.Add(this.grp_gamestats);
            this.grp_stats.Location = new System.Drawing.Point(290, 12);
            this.grp_stats.Name = "grp_stats";
            this.grp_stats.Size = new System.Drawing.Size(142, 340);
            this.grp_stats.TabIndex = 1;
            this.grp_stats.TabStop = false;
            this.grp_stats.Text = "Statistics";
            // 
            // grp_player2
            // 
            this.grp_player2.Controls.Add(this.lbl_player2WarriorsValue);
            this.grp_player2.Controls.Add(this.lbl_player2Warrior);
            this.grp_player2.Controls.Add(this.lbl_player2AntsValue);
            this.grp_player2.Controls.Add(this.lbl_player2Ants);
            this.grp_player2.Controls.Add(this.lbl_player2ScoutsValue);
            this.grp_player2.Controls.Add(this.lbl_player2Scouts);
            this.grp_player2.Controls.Add(this.lbl_player2CarriesValue);
            this.grp_player2.Controls.Add(this.lbl_player2Carries);
            this.grp_player2.Controls.Add(this.lbl_player2MoneyValue);
            this.grp_player2.Controls.Add(this.lbl_player2Money);
            this.grp_player2.Controls.Add(this.lbl_player2PointsValue);
            this.grp_player2.Controls.Add(this.lbl_player2Points);
            this.grp_player2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grp_player2.Location = new System.Drawing.Point(7, 192);
            this.grp_player2.Name = "grp_player2";
            this.grp_player2.Size = new System.Drawing.Size(135, 100);
            this.grp_player2.TabIndex = 4;
            this.grp_player2.TabStop = false;
            this.grp_player2.Text = "Player 2";
            // 
            // lbl_player2AntsValue
            // 
            this.lbl_player2AntsValue.AutoSize = true;
            this.lbl_player2AntsValue.Location = new System.Drawing.Point(92, 81);
            this.lbl_player2AntsValue.Name = "lbl_player2AntsValue";
            this.lbl_player2AntsValue.Size = new System.Drawing.Size(37, 13);
            this.lbl_player2AntsValue.TabIndex = 9;
            this.lbl_player2AntsValue.Text = "99999";
            // 
            // lbl_player2Ants
            // 
            this.lbl_player2Ants.AutoSize = true;
            this.lbl_player2Ants.Location = new System.Drawing.Point(7, 81);
            this.lbl_player2Ants.Name = "lbl_player2Ants";
            this.lbl_player2Ants.Size = new System.Drawing.Size(28, 13);
            this.lbl_player2Ants.TabIndex = 8;
            this.lbl_player2Ants.Text = "Ants";
            // 
            // lbl_player2ScoutsValue
            // 
            this.lbl_player2ScoutsValue.AutoSize = true;
            this.lbl_player2ScoutsValue.Location = new System.Drawing.Point(92, 55);
            this.lbl_player2ScoutsValue.Name = "lbl_player2ScoutsValue";
            this.lbl_player2ScoutsValue.Size = new System.Drawing.Size(37, 13);
            this.lbl_player2ScoutsValue.TabIndex = 7;
            this.lbl_player2ScoutsValue.Text = "99999";
            // 
            // lbl_player2Scouts
            // 
            this.lbl_player2Scouts.AutoSize = true;
            this.lbl_player2Scouts.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.lbl_player2Scouts.Location = new System.Drawing.Point(7, 55);
            this.lbl_player2Scouts.Name = "lbl_player2Scouts";
            this.lbl_player2Scouts.Size = new System.Drawing.Size(40, 13);
            this.lbl_player2Scouts.TabIndex = 6;
            this.lbl_player2Scouts.Text = "Scouts";
            // 
            // lbl_player2CarriesValue
            // 
            this.lbl_player2CarriesValue.AutoSize = true;
            this.lbl_player2CarriesValue.Location = new System.Drawing.Point(92, 42);
            this.lbl_player2CarriesValue.Name = "lbl_player2CarriesValue";
            this.lbl_player2CarriesValue.Size = new System.Drawing.Size(37, 13);
            this.lbl_player2CarriesValue.TabIndex = 5;
            this.lbl_player2CarriesValue.Text = "99999";
            // 
            // lbl_player2Carries
            // 
            this.lbl_player2Carries.AutoSize = true;
            this.lbl_player2Carries.ForeColor = System.Drawing.Color.DarkBlue;
            this.lbl_player2Carries.Location = new System.Drawing.Point(7, 42);
            this.lbl_player2Carries.Name = "lbl_player2Carries";
            this.lbl_player2Carries.Size = new System.Drawing.Size(39, 13);
            this.lbl_player2Carries.TabIndex = 4;
            this.lbl_player2Carries.Text = "Carries";
            // 
            // lbl_player2MoneyValue
            // 
            this.lbl_player2MoneyValue.AutoSize = true;
            this.lbl_player2MoneyValue.Location = new System.Drawing.Point(92, 29);
            this.lbl_player2MoneyValue.Name = "lbl_player2MoneyValue";
            this.lbl_player2MoneyValue.Size = new System.Drawing.Size(37, 13);
            this.lbl_player2MoneyValue.TabIndex = 3;
            this.lbl_player2MoneyValue.Text = "99999";
            // 
            // lbl_player2Money
            // 
            this.lbl_player2Money.AutoSize = true;
            this.lbl_player2Money.Location = new System.Drawing.Point(7, 29);
            this.lbl_player2Money.Name = "lbl_player2Money";
            this.lbl_player2Money.Size = new System.Drawing.Size(39, 13);
            this.lbl_player2Money.TabIndex = 2;
            this.lbl_player2Money.Text = "Money";
            // 
            // lbl_player2PointsValue
            // 
            this.lbl_player2PointsValue.AutoSize = true;
            this.lbl_player2PointsValue.Location = new System.Drawing.Point(92, 16);
            this.lbl_player2PointsValue.Name = "lbl_player2PointsValue";
            this.lbl_player2PointsValue.Size = new System.Drawing.Size(37, 13);
            this.lbl_player2PointsValue.TabIndex = 1;
            this.lbl_player2PointsValue.Text = "99999";
            // 
            // lbl_player2Points
            // 
            this.lbl_player2Points.AutoSize = true;
            this.lbl_player2Points.Location = new System.Drawing.Point(7, 16);
            this.lbl_player2Points.Name = "lbl_player2Points";
            this.lbl_player2Points.Size = new System.Drawing.Size(36, 13);
            this.lbl_player2Points.TabIndex = 0;
            this.lbl_player2Points.Text = "Points";
            // 
            // grp_player1
            // 
            this.grp_player1.Controls.Add(this.lbl_player1WarriorsValue);
            this.grp_player1.Controls.Add(this.lbl_player1Warrior);
            this.grp_player1.Controls.Add(this.lbl_player1AntsValue);
            this.grp_player1.Controls.Add(this.lbl_player1Ants);
            this.grp_player1.Controls.Add(this.lbl_player1ScoutsValue);
            this.grp_player1.Controls.Add(this.lbl_player1Scouts);
            this.grp_player1.Controls.Add(this.lbl_player1CarriesValue);
            this.grp_player1.Controls.Add(this.lbl_player1Carries);
            this.grp_player1.Controls.Add(this.lbl_player1MoneyValue);
            this.grp_player1.Controls.Add(this.lbl_player1Money);
            this.grp_player1.Controls.Add(this.lbl_player1PointsValue);
            this.grp_player1.Controls.Add(this.lbl_player1Points);
            this.grp_player1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grp_player1.Location = new System.Drawing.Point(7, 75);
            this.grp_player1.Name = "grp_player1";
            this.grp_player1.Size = new System.Drawing.Size(135, 100);
            this.grp_player1.TabIndex = 1;
            this.grp_player1.TabStop = false;
            this.grp_player1.Text = "Player 1";
            // 
            // lbl_player1AntsValue
            // 
            this.lbl_player1AntsValue.AutoSize = true;
            this.lbl_player1AntsValue.Location = new System.Drawing.Point(92, 81);
            this.lbl_player1AntsValue.Name = "lbl_player1AntsValue";
            this.lbl_player1AntsValue.Size = new System.Drawing.Size(37, 13);
            this.lbl_player1AntsValue.TabIndex = 9;
            this.lbl_player1AntsValue.Text = "99999";
            // 
            // lbl_player1Ants
            // 
            this.lbl_player1Ants.AutoSize = true;
            this.lbl_player1Ants.Location = new System.Drawing.Point(7, 81);
            this.lbl_player1Ants.Name = "lbl_player1Ants";
            this.lbl_player1Ants.Size = new System.Drawing.Size(28, 13);
            this.lbl_player1Ants.TabIndex = 8;
            this.lbl_player1Ants.Text = "Ants";
            // 
            // lbl_player1ScoutsValue
            // 
            this.lbl_player1ScoutsValue.AutoSize = true;
            this.lbl_player1ScoutsValue.Location = new System.Drawing.Point(92, 55);
            this.lbl_player1ScoutsValue.Name = "lbl_player1ScoutsValue";
            this.lbl_player1ScoutsValue.Size = new System.Drawing.Size(37, 13);
            this.lbl_player1ScoutsValue.TabIndex = 7;
            this.lbl_player1ScoutsValue.Text = "99999";
            // 
            // lbl_player1Scouts
            // 
            this.lbl_player1Scouts.AutoSize = true;
            this.lbl_player1Scouts.ForeColor = System.Drawing.Color.DarkSeaGreen;
            this.lbl_player1Scouts.Location = new System.Drawing.Point(7, 55);
            this.lbl_player1Scouts.Name = "lbl_player1Scouts";
            this.lbl_player1Scouts.Size = new System.Drawing.Size(40, 13);
            this.lbl_player1Scouts.TabIndex = 6;
            this.lbl_player1Scouts.Text = "Scouts";
            // 
            // lbl_player1CarriesValue
            // 
            this.lbl_player1CarriesValue.AutoSize = true;
            this.lbl_player1CarriesValue.Location = new System.Drawing.Point(92, 42);
            this.lbl_player1CarriesValue.Name = "lbl_player1CarriesValue";
            this.lbl_player1CarriesValue.Size = new System.Drawing.Size(37, 13);
            this.lbl_player1CarriesValue.TabIndex = 5;
            this.lbl_player1CarriesValue.Text = "99999";
            // 
            // lbl_player1Carries
            // 
            this.lbl_player1Carries.AutoSize = true;
            this.lbl_player1Carries.ForeColor = System.Drawing.Color.DarkGreen;
            this.lbl_player1Carries.Location = new System.Drawing.Point(7, 42);
            this.lbl_player1Carries.Name = "lbl_player1Carries";
            this.lbl_player1Carries.Size = new System.Drawing.Size(39, 13);
            this.lbl_player1Carries.TabIndex = 4;
            this.lbl_player1Carries.Text = "Carries";
            // 
            // lbl_player1MoneyValue
            // 
            this.lbl_player1MoneyValue.AutoSize = true;
            this.lbl_player1MoneyValue.Location = new System.Drawing.Point(92, 29);
            this.lbl_player1MoneyValue.Name = "lbl_player1MoneyValue";
            this.lbl_player1MoneyValue.Size = new System.Drawing.Size(37, 13);
            this.lbl_player1MoneyValue.TabIndex = 3;
            this.lbl_player1MoneyValue.Text = "99999";
            // 
            // lbl_player1Money
            // 
            this.lbl_player1Money.AutoSize = true;
            this.lbl_player1Money.Location = new System.Drawing.Point(7, 29);
            this.lbl_player1Money.Name = "lbl_player1Money";
            this.lbl_player1Money.Size = new System.Drawing.Size(39, 13);
            this.lbl_player1Money.TabIndex = 2;
            this.lbl_player1Money.Text = "Money";
            // 
            // lbl_player1PointsValue
            // 
            this.lbl_player1PointsValue.AutoSize = true;
            this.lbl_player1PointsValue.Location = new System.Drawing.Point(92, 16);
            this.lbl_player1PointsValue.Name = "lbl_player1PointsValue";
            this.lbl_player1PointsValue.Size = new System.Drawing.Size(37, 13);
            this.lbl_player1PointsValue.TabIndex = 1;
            this.lbl_player1PointsValue.Text = "99999";
            // 
            // lbl_player1Points
            // 
            this.lbl_player1Points.AutoSize = true;
            this.lbl_player1Points.Location = new System.Drawing.Point(7, 16);
            this.lbl_player1Points.Name = "lbl_player1Points";
            this.lbl_player1Points.Size = new System.Drawing.Size(36, 13);
            this.lbl_player1Points.TabIndex = 0;
            this.lbl_player1Points.Text = "Points";
            // 
            // grp_gamestats
            // 
            this.grp_gamestats.Controls.Add(this.lbl_sugarValue);
            this.grp_gamestats.Controls.Add(this.lbl_sugar);
            this.grp_gamestats.Controls.Add(this.lbl_ticksValue);
            this.grp_gamestats.Controls.Add(this.lbl_ticks);
            this.grp_gamestats.Location = new System.Drawing.Point(7, 20);
            this.grp_gamestats.Name = "grp_gamestats";
            this.grp_gamestats.Size = new System.Drawing.Size(129, 49);
            this.grp_gamestats.TabIndex = 0;
            this.grp_gamestats.TabStop = false;
            this.grp_gamestats.Text = "Game";
            // 
            // lbl_sugarValue
            // 
            this.lbl_sugarValue.AutoSize = true;
            this.lbl_sugarValue.Location = new System.Drawing.Point(92, 33);
            this.lbl_sugarValue.Name = "lbl_sugarValue";
            this.lbl_sugarValue.Size = new System.Drawing.Size(37, 13);
            this.lbl_sugarValue.TabIndex = 10;
            this.lbl_sugarValue.Text = "99999";
            // 
            // lbl_sugar
            // 
            this.lbl_sugar.AutoSize = true;
            this.lbl_sugar.Location = new System.Drawing.Point(7, 33);
            this.lbl_sugar.Name = "lbl_sugar";
            this.lbl_sugar.Size = new System.Drawing.Size(35, 13);
            this.lbl_sugar.TabIndex = 2;
            this.lbl_sugar.Text = "Sugar";
            // 
            // lbl_ticksValue
            // 
            this.lbl_ticksValue.AutoSize = true;
            this.lbl_ticksValue.Location = new System.Drawing.Point(92, 20);
            this.lbl_ticksValue.Name = "lbl_ticksValue";
            this.lbl_ticksValue.Size = new System.Drawing.Size(37, 13);
            this.lbl_ticksValue.TabIndex = 1;
            this.lbl_ticksValue.Text = "99999";
            // 
            // lbl_ticks
            // 
            this.lbl_ticks.AutoSize = true;
            this.lbl_ticks.Location = new System.Drawing.Point(7, 20);
            this.lbl_ticks.Name = "lbl_ticks";
            this.lbl_ticks.Size = new System.Drawing.Size(33, 13);
            this.lbl_ticks.TabIndex = 0;
            this.lbl_ticks.Text = "Ticks";
            // 
            // lbl_player1Warrior
            // 
            this.lbl_player1Warrior.AutoSize = true;
            this.lbl_player1Warrior.ForeColor = System.Drawing.Color.DarkSeaGreen;
            this.lbl_player1Warrior.Location = new System.Drawing.Point(7, 68);
            this.lbl_player1Warrior.Name = "lbl_player1Warrior";
            this.lbl_player1Warrior.Size = new System.Drawing.Size(46, 13);
            this.lbl_player1Warrior.TabIndex = 10;
            this.lbl_player1Warrior.Text = "Warriors";
            // 
            // lbl_player1WarriorsValue
            // 
            this.lbl_player1WarriorsValue.AutoSize = true;
            this.lbl_player1WarriorsValue.Location = new System.Drawing.Point(92, 68);
            this.lbl_player1WarriorsValue.Name = "lbl_player1WarriorsValue";
            this.lbl_player1WarriorsValue.Size = new System.Drawing.Size(37, 13);
            this.lbl_player1WarriorsValue.TabIndex = 11;
            this.lbl_player1WarriorsValue.Text = "99999";
            // 
            // lbl_player2Warrior
            // 
            this.lbl_player2Warrior.AutoSize = true;
            this.lbl_player2Warrior.Location = new System.Drawing.Point(7, 68);
            this.lbl_player2Warrior.Name = "lbl_player2Warrior";
            this.lbl_player2Warrior.Size = new System.Drawing.Size(41, 13);
            this.lbl_player2Warrior.TabIndex = 10;
            this.lbl_player2Warrior.Text = "Warrior";
            // 
            // lbl_player2WarriorsValue
            // 
            this.lbl_player2WarriorsValue.AutoSize = true;
            this.lbl_player2WarriorsValue.Location = new System.Drawing.Point(92, 68);
            this.lbl_player2WarriorsValue.Name = "lbl_player2WarriorsValue";
            this.lbl_player2WarriorsValue.Size = new System.Drawing.Size(37, 13);
            this.lbl_player2WarriorsValue.TabIndex = 11;
            this.lbl_player2WarriorsValue.Text = "99999";
            // 
            // GamePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 353);
            this.Controls.Add(this.grp_stats);
            this.Controls.Add(this.pb_Game);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GamePanel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AntWars";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GamePanel_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pb_Game)).EndInit();
            this.grp_stats.ResumeLayout(false);
            this.grp_player2.ResumeLayout(false);
            this.grp_player2.PerformLayout();
            this.grp_player1.ResumeLayout(false);
            this.grp_player1.PerformLayout();
            this.grp_gamestats.ResumeLayout(false);
            this.grp_gamestats.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pb_Game;
        private System.Windows.Forms.GroupBox grp_stats;
        private System.Windows.Forms.GroupBox grp_gamestats;
        private System.Windows.Forms.Label lbl_ticks;
        private System.Windows.Forms.Label lbl_ticksValue;
        private System.Windows.Forms.GroupBox grp_player1;
        private System.Windows.Forms.GroupBox grp_player2;
        private System.Windows.Forms.Label lbl_player2MoneyValue;
        private System.Windows.Forms.Label lbl_player2Money;
        private System.Windows.Forms.Label lbl_player2PointsValue;
        private System.Windows.Forms.Label lbl_player2Points;
        private System.Windows.Forms.Label lbl_player1MoneyValue;
        private System.Windows.Forms.Label lbl_player1Money;
        private System.Windows.Forms.Label lbl_player1PointsValue;
        private System.Windows.Forms.Label lbl_player1Points;
        private System.Windows.Forms.Label lbl_player2CarriesValue;
        private System.Windows.Forms.Label lbl_player2Carries;
        private System.Windows.Forms.Label lbl_player1ScoutsValue;
        private System.Windows.Forms.Label lbl_player1Scouts;
        private System.Windows.Forms.Label lbl_player1CarriesValue;
        private System.Windows.Forms.Label lbl_player1Carries;
        private System.Windows.Forms.Label lbl_player2ScoutsValue;
        private System.Windows.Forms.Label lbl_player2Scouts;
        private System.Windows.Forms.Label lbl_player2AntsValue;
        private System.Windows.Forms.Label lbl_player2Ants;
        private System.Windows.Forms.Label lbl_player1AntsValue;
        private System.Windows.Forms.Label lbl_player1Ants;
        private System.Windows.Forms.Label lbl_sugarValue;
        private System.Windows.Forms.Label lbl_sugar;
        private System.Windows.Forms.Label lbl_player1Warrior;
        private System.Windows.Forms.Label lbl_player2WarriorsValue;
        private System.Windows.Forms.Label lbl_player2Warrior;
        private System.Windows.Forms.Label lbl_player1WarriorsValue;
    }
}