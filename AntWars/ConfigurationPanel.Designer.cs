namespace AntWars
{
    partial class ConfigurationPanel
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigurationPanel));
            this.btn_start = new System.Windows.Forms.Button();
            this.GameTick = new System.Windows.Forms.Timer(this.components);
            this.btn_player1loadAI = new System.Windows.Forms.Button();
            this.lbl_player1Dll = new System.Windows.Forms.Label();
            this.grp_config = new System.Windows.Forms.GroupBox();
            this.btn_new = new System.Windows.Forms.Button();
            this.pnl_config = new System.Windows.Forms.Panel();
            this.lbl_maxTicks = new System.Windows.Forms.Label();
            this.lbl_player2Dll = new System.Windows.Forms.Label();
            this.btn_player2loadAI = new System.Windows.Forms.Button();
            this.nmc_maxTicks = new System.Windows.Forms.NumericUpDown();
            this.lbl_points = new System.Windows.Forms.Label();
            this.lbl_ticks = new System.Windows.Forms.Label();
            this.lbl_startMoney = new System.Windows.Forms.Label();
            this.lbl_boardHeigth = new System.Windows.Forms.Label();
            this.lbl_boardWidth = new System.Windows.Forms.Label();
            this.lbl_sugarAmountMax = new System.Windows.Forms.Label();
            this.nmc_sugarAmountMin = new System.Windows.Forms.NumericUpDown();
            this.nmc_sugarAmountMax = new System.Windows.Forms.NumericUpDown();
            this.nmc_boardWidth = new System.Windows.Forms.NumericUpDown();
            this.nmc_points = new System.Windows.Forms.NumericUpDown();
            this.nmc_startMoney = new System.Windows.Forms.NumericUpDown();
            this.nmc_ticks = new System.Windows.Forms.NumericUpDown();
            this.nmc_boardHeigth = new System.Windows.Forms.NumericUpDown();
            this.lbl_sugarAmountMin = new System.Windows.Forms.Label();
            this.lbl_sugarMax = new System.Windows.Forms.Label();
            this.nmc_sugarMin = new System.Windows.Forms.NumericUpDown();
            this.nmc_sugarMax = new System.Windows.Forms.NumericUpDown();
            this.lbl_sugarMin = new System.Windows.Forms.Label();
            this.btn_save = new System.Windows.Forms.Button();
            this.btn_load = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.btn_view = new System.Windows.Forms.Button();
            this.btn_costCalculator = new System.Windows.Forms.Button();
            this.grp_config.SuspendLayout();
            this.pnl_config.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmc_maxTicks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmc_sugarAmountMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmc_sugarAmountMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmc_boardWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmc_points)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmc_startMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmc_ticks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmc_boardHeigth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmc_sugarMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmc_sugarMax)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_start
            // 
            this.btn_start.Location = new System.Drawing.Point(183, 12);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(75, 23);
            this.btn_start.TabIndex = 41;
            this.btn_start.Text = "Start";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.Start_Click);
            // 
            // btn_player1loadAI
            // 
            this.btn_player1loadAI.Location = new System.Drawing.Point(122, 272);
            this.btn_player1loadAI.Name = "btn_player1loadAI";
            this.btn_player1loadAI.Size = new System.Drawing.Size(75, 23);
            this.btn_player1loadAI.TabIndex = 13;
            this.btn_player1loadAI.Text = "Lade KI";
            this.btn_player1loadAI.UseVisualStyleBackColor = true;
            this.btn_player1loadAI.Click += new System.EventHandler(this.btn_player1loadAI_Click);
            // 
            // lbl_player1Dll
            // 
            this.lbl_player1Dll.AutoSize = true;
            this.lbl_player1Dll.Location = new System.Drawing.Point(6, 277);
            this.lbl_player1Dll.Name = "lbl_player1Dll";
            this.lbl_player1Dll.Size = new System.Drawing.Size(96, 13);
            this.lbl_player1Dll.TabIndex = 26;
            this.lbl_player1Dll.Text = "DLL für Spieler1-KI";
            // 
            // grp_config
            // 
            this.grp_config.Controls.Add(this.btn_new);
            this.grp_config.Controls.Add(this.pnl_config);
            this.grp_config.Controls.Add(this.btn_save);
            this.grp_config.Controls.Add(this.btn_load);
            this.grp_config.Location = new System.Drawing.Point(25, 41);
            this.grp_config.Name = "grp_config";
            this.grp_config.Size = new System.Drawing.Size(215, 408);
            this.grp_config.TabIndex = 43;
            this.grp_config.TabStop = false;
            this.grp_config.Text = "Spielkonfiguration";
            // 
            // btn_new
            // 
            this.btn_new.Location = new System.Drawing.Point(6, 19);
            this.btn_new.Name = "btn_new";
            this.btn_new.Size = new System.Drawing.Size(50, 23);
            this.btn_new.TabIndex = 14;
            this.btn_new.Text = "Neu";
            this.btn_new.UseVisualStyleBackColor = true;
            this.btn_new.Click += new System.EventHandler(this.btn_gameConfigNew_Click);
            // 
            // pnl_config
            // 
            this.pnl_config.Controls.Add(this.lbl_maxTicks);
            this.pnl_config.Controls.Add(this.lbl_player2Dll);
            this.pnl_config.Controls.Add(this.btn_player2loadAI);
            this.pnl_config.Controls.Add(this.lbl_player1Dll);
            this.pnl_config.Controls.Add(this.btn_player1loadAI);
            this.pnl_config.Controls.Add(this.nmc_maxTicks);
            this.pnl_config.Controls.Add(this.lbl_points);
            this.pnl_config.Controls.Add(this.lbl_ticks);
            this.pnl_config.Controls.Add(this.lbl_startMoney);
            this.pnl_config.Controls.Add(this.lbl_boardHeigth);
            this.pnl_config.Controls.Add(this.lbl_boardWidth);
            this.pnl_config.Controls.Add(this.lbl_sugarAmountMax);
            this.pnl_config.Controls.Add(this.nmc_sugarAmountMin);
            this.pnl_config.Controls.Add(this.nmc_sugarAmountMax);
            this.pnl_config.Controls.Add(this.nmc_boardWidth);
            this.pnl_config.Controls.Add(this.nmc_points);
            this.pnl_config.Controls.Add(this.nmc_startMoney);
            this.pnl_config.Controls.Add(this.nmc_ticks);
            this.pnl_config.Controls.Add(this.nmc_boardHeigth);
            this.pnl_config.Controls.Add(this.lbl_sugarAmountMin);
            this.pnl_config.Controls.Add(this.lbl_sugarMax);
            this.pnl_config.Controls.Add(this.nmc_sugarMin);
            this.pnl_config.Controls.Add(this.nmc_sugarMax);
            this.pnl_config.Controls.Add(this.lbl_sugarMin);
            this.pnl_config.Enabled = false;
            this.pnl_config.Location = new System.Drawing.Point(4, 48);
            this.pnl_config.Name = "pnl_config";
            this.pnl_config.Size = new System.Drawing.Size(205, 354);
            this.pnl_config.TabIndex = 46;
            // 
            // lbl_maxTicks
            // 
            this.lbl_maxTicks.AutoSize = true;
            this.lbl_maxTicks.Location = new System.Drawing.Point(6, 222);
            this.lbl_maxTicks.Name = "lbl_maxTicks";
            this.lbl_maxTicks.Size = new System.Drawing.Size(86, 13);
            this.lbl_maxTicks.TabIndex = 24;
            this.lbl_maxTicks.Text = "Spielzeit in Ticks";
            // 
            // lbl_player2Dll
            // 
            this.lbl_player2Dll.AutoSize = true;
            this.lbl_player2Dll.Location = new System.Drawing.Point(6, 306);
            this.lbl_player2Dll.Name = "lbl_player2Dll";
            this.lbl_player2Dll.Size = new System.Drawing.Size(96, 13);
            this.lbl_player2Dll.TabIndex = 23;
            this.lbl_player2Dll.Text = "DLL für Spieler2-KI";
            // 
            // btn_player2loadAI
            // 
            this.btn_player2loadAI.Location = new System.Drawing.Point(122, 301);
            this.btn_player2loadAI.Name = "btn_player2loadAI";
            this.btn_player2loadAI.Size = new System.Drawing.Size(75, 23);
            this.btn_player2loadAI.TabIndex = 39;
            this.btn_player2loadAI.Text = "Lade KI";
            this.btn_player2loadAI.UseVisualStyleBackColor = true;
            this.btn_player2loadAI.Click += new System.EventHandler(this.btn_player2loadAI_Click);
            // 
            // nmc_maxTicks
            // 
            this.nmc_maxTicks.Location = new System.Drawing.Point(153, 220);
            this.nmc_maxTicks.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nmc_maxTicks.Name = "nmc_maxTicks";
            this.nmc_maxTicks.Size = new System.Drawing.Size(44, 20);
            this.nmc_maxTicks.TabIndex = 25;
            this.nmc_maxTicks.Value = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nmc_maxTicks.ValueChanged += new System.EventHandler(this.numeric_gameConfigMaxTicks_ValueChanged);
            // 
            // lbl_points
            // 
            this.lbl_points.AutoSize = true;
            this.lbl_points.Location = new System.Drawing.Point(6, 248);
            this.lbl_points.Name = "lbl_points";
            this.lbl_points.Size = new System.Drawing.Size(41, 13);
            this.lbl_points.TabIndex = 22;
            this.lbl_points.Text = "Punkte";
            // 
            // lbl_ticks
            // 
            this.lbl_ticks.AutoSize = true;
            this.lbl_ticks.Location = new System.Drawing.Point(6, 197);
            this.lbl_ticks.Name = "lbl_ticks";
            this.lbl_ticks.Size = new System.Drawing.Size(97, 13);
            this.lbl_ticks.TabIndex = 21;
            this.lbl_ticks.Text = "Ticks pro Sekunde";
            // 
            // lbl_startMoney
            // 
            this.lbl_startMoney.AutoSize = true;
            this.lbl_startMoney.Location = new System.Drawing.Point(6, 171);
            this.lbl_startMoney.Name = "lbl_startMoney";
            this.lbl_startMoney.Size = new System.Drawing.Size(49, 13);
            this.lbl_startMoney.TabIndex = 20;
            this.lbl_startMoney.Text = "Startgeld";
            // 
            // lbl_boardHeigth
            // 
            this.lbl_boardHeigth.AutoSize = true;
            this.lbl_boardHeigth.Location = new System.Drawing.Point(6, 145);
            this.lbl_boardHeigth.Name = "lbl_boardHeigth";
            this.lbl_boardHeigth.Size = new System.Drawing.Size(89, 13);
            this.lbl_boardHeigth.TabIndex = 19;
            this.lbl_boardHeigth.Text = "Spielhöhe in px*4";
            // 
            // lbl_boardWidth
            // 
            this.lbl_boardWidth.AutoSize = true;
            this.lbl_boardWidth.Location = new System.Drawing.Point(6, 119);
            this.lbl_boardWidth.Name = "lbl_boardWidth";
            this.lbl_boardWidth.Size = new System.Drawing.Size(91, 13);
            this.lbl_boardWidth.TabIndex = 18;
            this.lbl_boardWidth.Text = "Spielbreite in px*4";
            // 
            // lbl_sugarAmountMax
            // 
            this.lbl_sugarAmountMax.AutoSize = true;
            this.lbl_sugarAmountMax.Location = new System.Drawing.Point(6, 92);
            this.lbl_sugarAmountMax.Name = "lbl_sugarAmountMax";
            this.lbl_sugarAmountMax.Size = new System.Drawing.Size(118, 13);
            this.lbl_sugarAmountMax.TabIndex = 16;
            this.lbl_sugarAmountMax.Text = "Max. Zuckeranhäufung";
            // 
            // nmc_sugarAmountMin
            // 
            this.nmc_sugarAmountMin.Location = new System.Drawing.Point(153, 64);
            this.nmc_sugarAmountMin.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nmc_sugarAmountMin.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmc_sugarAmountMin.Name = "nmc_sugarAmountMin";
            this.nmc_sugarAmountMin.Size = new System.Drawing.Size(44, 20);
            this.nmc_sugarAmountMin.TabIndex = 19;
            this.nmc_sugarAmountMin.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmc_sugarAmountMin.ValueChanged += new System.EventHandler(this.numeric_gameConfigSugarAmountMin_ValueChanged);
            // 
            // nmc_sugarAmountMax
            // 
            this.nmc_sugarAmountMax.Location = new System.Drawing.Point(153, 90);
            this.nmc_sugarAmountMax.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nmc_sugarAmountMax.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmc_sugarAmountMax.Name = "nmc_sugarAmountMax";
            this.nmc_sugarAmountMax.Size = new System.Drawing.Size(44, 20);
            this.nmc_sugarAmountMax.TabIndex = 20;
            this.nmc_sugarAmountMax.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nmc_sugarAmountMax.ValueChanged += new System.EventHandler(this.numeric_gameConfigSugarAmountMax_ValueChanged);
            // 
            // nmc_boardWidth
            // 
            this.nmc_boardWidth.Location = new System.Drawing.Point(153, 117);
            this.nmc_boardWidth.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nmc_boardWidth.Name = "nmc_boardWidth";
            this.nmc_boardWidth.Size = new System.Drawing.Size(44, 20);
            this.nmc_boardWidth.TabIndex = 21;
            this.nmc_boardWidth.ValueChanged += new System.EventHandler(this.numeric_gameConfigBoardWidth_ValueChanged);
            // 
            // nmc_points
            // 
            this.nmc_points.Location = new System.Drawing.Point(153, 246);
            this.nmc_points.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nmc_points.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmc_points.Name = "nmc_points";
            this.nmc_points.Size = new System.Drawing.Size(44, 20);
            this.nmc_points.TabIndex = 26;
            this.nmc_points.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nmc_points.ValueChanged += new System.EventHandler(this.numeric_gameConfigPoints_ValueChanged);
            // 
            // nmc_startMoney
            // 
            this.nmc_startMoney.Location = new System.Drawing.Point(153, 169);
            this.nmc_startMoney.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nmc_startMoney.Name = "nmc_startMoney";
            this.nmc_startMoney.Size = new System.Drawing.Size(44, 20);
            this.nmc_startMoney.TabIndex = 23;
            this.nmc_startMoney.ValueChanged += new System.EventHandler(this.numeric_gameConfigStartMoney_ValueChanged);
            // 
            // nmc_ticks
            // 
            this.nmc_ticks.Location = new System.Drawing.Point(153, 195);
            this.nmc_ticks.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.nmc_ticks.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmc_ticks.Name = "nmc_ticks";
            this.nmc_ticks.Size = new System.Drawing.Size(44, 20);
            this.nmc_ticks.TabIndex = 24;
            this.nmc_ticks.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nmc_ticks.ValueChanged += new System.EventHandler(this.numeric_gameConfigTime_ValueChanged);
            // 
            // nmc_boardHeigth
            // 
            this.nmc_boardHeigth.Location = new System.Drawing.Point(153, 143);
            this.nmc_boardHeigth.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nmc_boardHeigth.Name = "nmc_boardHeigth";
            this.nmc_boardHeigth.Size = new System.Drawing.Size(44, 20);
            this.nmc_boardHeigth.TabIndex = 22;
            this.nmc_boardHeigth.ValueChanged += new System.EventHandler(this.numeric_gameConfigBoardHeigth_ValueChanged);
            // 
            // lbl_sugarAmountMin
            // 
            this.lbl_sugarAmountMin.AutoSize = true;
            this.lbl_sugarAmountMin.Location = new System.Drawing.Point(6, 67);
            this.lbl_sugarAmountMin.Name = "lbl_sugarAmountMin";
            this.lbl_sugarAmountMin.Size = new System.Drawing.Size(121, 13);
            this.lbl_sugarAmountMin.TabIndex = 7;
            this.lbl_sugarAmountMin.Text = "Mind. Zuckeranhäufung";
            // 
            // lbl_sugarMax
            // 
            this.lbl_sugarMax.AutoSize = true;
            this.lbl_sugarMax.Location = new System.Drawing.Point(6, 41);
            this.lbl_sugarMax.Name = "lbl_sugarMax";
            this.lbl_sugarMax.Size = new System.Drawing.Size(117, 13);
            this.lbl_sugarMax.TabIndex = 5;
            this.lbl_sugarMax.Text = "Max. Zucker in Prozent";
            // 
            // nmc_sugarMin
            // 
            this.nmc_sugarMin.Location = new System.Drawing.Point(153, 11);
            this.nmc_sugarMin.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nmc_sugarMin.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmc_sugarMin.Name = "nmc_sugarMin";
            this.nmc_sugarMin.Size = new System.Drawing.Size(44, 20);
            this.nmc_sugarMin.TabIndex = 17;
            this.nmc_sugarMin.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nmc_sugarMin.ValueChanged += new System.EventHandler(this.numeric_gameConfigSugarMin_ValueChanged);
            // 
            // nmc_sugarMax
            // 
            this.nmc_sugarMax.Location = new System.Drawing.Point(153, 38);
            this.nmc_sugarMax.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nmc_sugarMax.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmc_sugarMax.Name = "nmc_sugarMax";
            this.nmc_sugarMax.Size = new System.Drawing.Size(44, 20);
            this.nmc_sugarMax.TabIndex = 18;
            this.nmc_sugarMax.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nmc_sugarMax.ValueChanged += new System.EventHandler(this.numeric_gameConfigSugarMax_ValueChanged);
            // 
            // lbl_sugarMin
            // 
            this.lbl_sugarMin.AutoSize = true;
            this.lbl_sugarMin.Location = new System.Drawing.Point(6, 14);
            this.lbl_sugarMin.Name = "lbl_sugarMin";
            this.lbl_sugarMin.Size = new System.Drawing.Size(120, 13);
            this.lbl_sugarMin.TabIndex = 3;
            this.lbl_sugarMin.Text = "Mind. Zucker in Prozent";
            // 
            // btn_save
            // 
            this.btn_save.Enabled = false;
            this.btn_save.Location = new System.Drawing.Point(134, 19);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(75, 23);
            this.btn_save.TabIndex = 16;
            this.btn_save.Text = "Sichern";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_gameConfigSave_Click);
            // 
            // btn_load
            // 
            this.btn_load.Location = new System.Drawing.Point(62, 19);
            this.btn_load.Name = "btn_load";
            this.btn_load.Size = new System.Drawing.Size(66, 23);
            this.btn_load.TabIndex = 15;
            this.btn_load.Text = "Laden";
            this.btn_load.UseVisualStyleBackColor = true;
            this.btn_load.Click += new System.EventHandler(this.btn_gameConfigLoad_Click);
            // 
            // btn_view
            // 
            this.btn_view.Enabled = false;
            this.btn_view.Location = new System.Drawing.Point(102, 12);
            this.btn_view.Name = "btn_view";
            this.btn_view.Size = new System.Drawing.Size(75, 23);
            this.btn_view.TabIndex = 40;
            this.btn_view.Text = "Ansicht";
            this.btn_view.UseVisualStyleBackColor = true;
            this.btn_view.Click += new System.EventHandler(this.buttonView_Click);
            // 
            // btn_costCalculator
            // 
            this.btn_costCalculator.Location = new System.Drawing.Point(12, 12);
            this.btn_costCalculator.Name = "btn_costCalculator";
            this.btn_costCalculator.Size = new System.Drawing.Size(84, 23);
            this.btn_costCalculator.TabIndex = 44;
            this.btn_costCalculator.Text = "Kostenrechner";
            this.btn_costCalculator.UseVisualStyleBackColor = true;
            this.btn_costCalculator.Click += new System.EventHandler(this.buttonCostCalculator_Click);
            // 
            // ConfigurationPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(271, 457);
            this.Controls.Add(this.btn_costCalculator);
            this.Controls.Add(this.btn_view);
            this.Controls.Add(this.grp_config);
            this.Controls.Add(this.btn_start);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ConfigurationPanel";
            this.Text = "Spielkonfiguration";
            this.grp_config.ResumeLayout(false);
            this.pnl_config.ResumeLayout(false);
            this.pnl_config.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmc_maxTicks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmc_sugarAmountMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmc_sugarAmountMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmc_boardWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmc_points)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmc_startMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmc_ticks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmc_boardHeigth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmc_sugarMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmc_sugarMax)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.Timer GameTick;
        private System.Windows.Forms.GroupBox grp_config;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button btn_load;
        private System.Windows.Forms.Button btn_new;
        private System.Windows.Forms.Panel pnl_config;
        private System.Windows.Forms.Label lbl_sugarMax;
        private System.Windows.Forms.NumericUpDown nmc_sugarMin;
        private System.Windows.Forms.NumericUpDown nmc_sugarMax;
        private System.Windows.Forms.Label lbl_sugarMin;
        private System.Windows.Forms.Label lbl_points;
        private System.Windows.Forms.Label lbl_ticks;
        private System.Windows.Forms.Label lbl_startMoney;
        private System.Windows.Forms.Label lbl_boardHeigth;
        private System.Windows.Forms.Label lbl_boardWidth;
        private System.Windows.Forms.Label lbl_sugarAmountMax;
        private System.Windows.Forms.NumericUpDown nmc_sugarAmountMin;
        private System.Windows.Forms.NumericUpDown nmc_sugarAmountMax;
        private System.Windows.Forms.NumericUpDown nmc_boardWidth;
        private System.Windows.Forms.NumericUpDown nmc_points;
        private System.Windows.Forms.NumericUpDown nmc_startMoney;
        private System.Windows.Forms.NumericUpDown nmc_ticks;
        private System.Windows.Forms.NumericUpDown nmc_boardHeigth;
        private System.Windows.Forms.Label lbl_sugarAmountMin;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button btn_view;
        private System.Windows.Forms.Button btn_player2loadAI;
        private System.Windows.Forms.Label lbl_player2Dll;
        private System.Windows.Forms.Button btn_player1loadAI;
        private System.Windows.Forms.Label lbl_player1Dll;
        private System.Windows.Forms.Label lbl_maxTicks;
        private System.Windows.Forms.NumericUpDown nmc_maxTicks;
        private System.Windows.Forms.Button btn_costCalculator;
    }
}