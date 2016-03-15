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
            this.Start = new System.Windows.Forms.Button();
            this.GameTick = new System.Windows.Forms.Timer(this.components);
            this.btn_player1loadAI = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ppanel = new System.Windows.Forms.GroupBox();
            this.btn_gameConfigNew = new System.Windows.Forms.Button();
            this.pnl_GameConfig = new System.Windows.Forms.Panel();
            this.MaxTicks = new System.Windows.Forms.Label();
            this.ai_dll = new System.Windows.Forms.Label();
            this.btn_player2loadAI = new System.Windows.Forms.Button();
            this.numeric_gameConfigMaxTicks = new System.Windows.Forms.NumericUpDown();
            this.Points = new System.Windows.Forms.Label();
            this.Ticks = new System.Windows.Forms.Label();
            this.StartMoney = new System.Windows.Forms.Label();
            this.BoardHeigth = new System.Windows.Forms.Label();
            this.BoardWidth = new System.Windows.Forms.Label();
            this.SugarAmountMax = new System.Windows.Forms.Label();
            this.numeric_gameConfigSugarAmountMin = new System.Windows.Forms.NumericUpDown();
            this.numeric_gameConfigSugarAmountMax = new System.Windows.Forms.NumericUpDown();
            this.numeric_gameConfigBoardWidth = new System.Windows.Forms.NumericUpDown();
            this.numeric_gameConfigPoints = new System.Windows.Forms.NumericUpDown();
            this.numeric_gameConfigStartMoney = new System.Windows.Forms.NumericUpDown();
            this.numeric_gameConfigTicks = new System.Windows.Forms.NumericUpDown();
            this.numeric_gameConfigBoardHeigth = new System.Windows.Forms.NumericUpDown();
            this.SugarAmountMin = new System.Windows.Forms.Label();
            this.SugarMax = new System.Windows.Forms.Label();
            this.numeric_gameConfigSugarMin = new System.Windows.Forms.NumericUpDown();
            this.numeric_gameConfigSugarMax = new System.Windows.Forms.NumericUpDown();
            this.SugarMin = new System.Windows.Forms.Label();
            this.btn_gameConfigSave = new System.Windows.Forms.Button();
            this.btn_gameConfigLoad = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.buttonView = new System.Windows.Forms.Button();
            this.buttonCostCalculator = new System.Windows.Forms.Button();
            this.ppanel.SuspendLayout();
            this.pnl_GameConfig.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_gameConfigMaxTicks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_gameConfigSugarAmountMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_gameConfigSugarAmountMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_gameConfigBoardWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_gameConfigPoints)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_gameConfigStartMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_gameConfigTicks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_gameConfigBoardHeigth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_gameConfigSugarMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_gameConfigSugarMax)).BeginInit();
            this.SuspendLayout();
            // 
            // Start
            // 
            this.Start.Location = new System.Drawing.Point(183, 12);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(75, 23);
            this.Start.TabIndex = 41;
            this.Start.Text = "Start";
            this.Start.UseVisualStyleBackColor = true;
            this.Start.Click += new System.EventHandler(this.Start_Click);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 277);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 26;
            this.label1.Text = "DLL für Spieler1-KI";
            // 
            // ppanel
            // 
            this.ppanel.Controls.Add(this.btn_gameConfigNew);
            this.ppanel.Controls.Add(this.pnl_GameConfig);
            this.ppanel.Controls.Add(this.btn_gameConfigSave);
            this.ppanel.Controls.Add(this.btn_gameConfigLoad);
            this.ppanel.Location = new System.Drawing.Point(25, 41);
            this.ppanel.Name = "ppanel";
            this.ppanel.Size = new System.Drawing.Size(215, 408);
            this.ppanel.TabIndex = 43;
            this.ppanel.TabStop = false;
            this.ppanel.Text = "Spielkonfiguration";
            // 
            // btn_gameConfigNew
            // 
            this.btn_gameConfigNew.Location = new System.Drawing.Point(6, 19);
            this.btn_gameConfigNew.Name = "btn_gameConfigNew";
            this.btn_gameConfigNew.Size = new System.Drawing.Size(50, 23);
            this.btn_gameConfigNew.TabIndex = 14;
            this.btn_gameConfigNew.Text = "Neu";
            this.btn_gameConfigNew.UseVisualStyleBackColor = true;
            this.btn_gameConfigNew.Click += new System.EventHandler(this.btn_gameConfigNew_Click);
            // 
            // pnl_GameConfig
            // 
            this.pnl_GameConfig.Controls.Add(this.MaxTicks);
            this.pnl_GameConfig.Controls.Add(this.ai_dll);
            this.pnl_GameConfig.Controls.Add(this.btn_player2loadAI);
            this.pnl_GameConfig.Controls.Add(this.label1);
            this.pnl_GameConfig.Controls.Add(this.btn_player1loadAI);
            this.pnl_GameConfig.Controls.Add(this.numeric_gameConfigMaxTicks);
            this.pnl_GameConfig.Controls.Add(this.Points);
            this.pnl_GameConfig.Controls.Add(this.Ticks);
            this.pnl_GameConfig.Controls.Add(this.StartMoney);
            this.pnl_GameConfig.Controls.Add(this.BoardHeigth);
            this.pnl_GameConfig.Controls.Add(this.BoardWidth);
            this.pnl_GameConfig.Controls.Add(this.SugarAmountMax);
            this.pnl_GameConfig.Controls.Add(this.numeric_gameConfigSugarAmountMin);
            this.pnl_GameConfig.Controls.Add(this.numeric_gameConfigSugarAmountMax);
            this.pnl_GameConfig.Controls.Add(this.numeric_gameConfigBoardWidth);
            this.pnl_GameConfig.Controls.Add(this.numeric_gameConfigPoints);
            this.pnl_GameConfig.Controls.Add(this.numeric_gameConfigStartMoney);
            this.pnl_GameConfig.Controls.Add(this.numeric_gameConfigTicks);
            this.pnl_GameConfig.Controls.Add(this.numeric_gameConfigBoardHeigth);
            this.pnl_GameConfig.Controls.Add(this.SugarAmountMin);
            this.pnl_GameConfig.Controls.Add(this.SugarMax);
            this.pnl_GameConfig.Controls.Add(this.numeric_gameConfigSugarMin);
            this.pnl_GameConfig.Controls.Add(this.numeric_gameConfigSugarMax);
            this.pnl_GameConfig.Controls.Add(this.SugarMin);
            this.pnl_GameConfig.Enabled = false;
            this.pnl_GameConfig.Location = new System.Drawing.Point(4, 48);
            this.pnl_GameConfig.Name = "pnl_GameConfig";
            this.pnl_GameConfig.Size = new System.Drawing.Size(205, 354);
            this.pnl_GameConfig.TabIndex = 46;
            // 
            // MaxTicks
            // 
            this.MaxTicks.AutoSize = true;
            this.MaxTicks.Location = new System.Drawing.Point(6, 222);
            this.MaxTicks.Name = "MaxTicks";
            this.MaxTicks.Size = new System.Drawing.Size(86, 13);
            this.MaxTicks.TabIndex = 24;
            this.MaxTicks.Text = "Spielzeit in Ticks";
            // 
            // ai_dll
            // 
            this.ai_dll.AutoSize = true;
            this.ai_dll.Location = new System.Drawing.Point(6, 306);
            this.ai_dll.Name = "ai_dll";
            this.ai_dll.Size = new System.Drawing.Size(96, 13);
            this.ai_dll.TabIndex = 23;
            this.ai_dll.Text = "DLL für Spieler2-KI";
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
            // numeric_gameConfigMaxTicks
            // 
            this.numeric_gameConfigMaxTicks.Location = new System.Drawing.Point(153, 220);
            this.numeric_gameConfigMaxTicks.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numeric_gameConfigMaxTicks.Name = "numeric_gameConfigMaxTicks";
            this.numeric_gameConfigMaxTicks.Size = new System.Drawing.Size(44, 20);
            this.numeric_gameConfigMaxTicks.TabIndex = 25;
            this.numeric_gameConfigMaxTicks.Value = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numeric_gameConfigMaxTicks.ValueChanged += new System.EventHandler(this.numeric_gameConfigMaxTicks_ValueChanged);
            // 
            // Points
            // 
            this.Points.AutoSize = true;
            this.Points.Location = new System.Drawing.Point(6, 248);
            this.Points.Name = "Points";
            this.Points.Size = new System.Drawing.Size(41, 13);
            this.Points.TabIndex = 22;
            this.Points.Text = "Punkte";
            // 
            // Ticks
            // 
            this.Ticks.AutoSize = true;
            this.Ticks.Location = new System.Drawing.Point(6, 197);
            this.Ticks.Name = "Ticks";
            this.Ticks.Size = new System.Drawing.Size(97, 13);
            this.Ticks.TabIndex = 21;
            this.Ticks.Text = "Ticks pro Sekunde";
            // 
            // StartMoney
            // 
            this.StartMoney.AutoSize = true;
            this.StartMoney.Location = new System.Drawing.Point(6, 171);
            this.StartMoney.Name = "StartMoney";
            this.StartMoney.Size = new System.Drawing.Size(49, 13);
            this.StartMoney.TabIndex = 20;
            this.StartMoney.Text = "Startgeld";
            // 
            // BoardHeigth
            // 
            this.BoardHeigth.AutoSize = true;
            this.BoardHeigth.Location = new System.Drawing.Point(6, 145);
            this.BoardHeigth.Name = "BoardHeigth";
            this.BoardHeigth.Size = new System.Drawing.Size(89, 13);
            this.BoardHeigth.TabIndex = 19;
            this.BoardHeigth.Text = "Spielhöhe in px*4";
            // 
            // BoardWidth
            // 
            this.BoardWidth.AutoSize = true;
            this.BoardWidth.Location = new System.Drawing.Point(6, 119);
            this.BoardWidth.Name = "BoardWidth";
            this.BoardWidth.Size = new System.Drawing.Size(91, 13);
            this.BoardWidth.TabIndex = 18;
            this.BoardWidth.Text = "Spielbreite in px*4";
            // 
            // SugarAmountMax
            // 
            this.SugarAmountMax.AutoSize = true;
            this.SugarAmountMax.Location = new System.Drawing.Point(6, 92);
            this.SugarAmountMax.Name = "SugarAmountMax";
            this.SugarAmountMax.Size = new System.Drawing.Size(118, 13);
            this.SugarAmountMax.TabIndex = 16;
            this.SugarAmountMax.Text = "Max. Zuckeranhäufung";
            // 
            // numeric_gameConfigSugarAmountMin
            // 
            this.numeric_gameConfigSugarAmountMin.Location = new System.Drawing.Point(153, 64);
            this.numeric_gameConfigSugarAmountMin.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numeric_gameConfigSugarAmountMin.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numeric_gameConfigSugarAmountMin.Name = "numeric_gameConfigSugarAmountMin";
            this.numeric_gameConfigSugarAmountMin.Size = new System.Drawing.Size(44, 20);
            this.numeric_gameConfigSugarAmountMin.TabIndex = 19;
            this.numeric_gameConfigSugarAmountMin.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numeric_gameConfigSugarAmountMin.ValueChanged += new System.EventHandler(this.numeric_gameConfigSugarAmountMin_ValueChanged);
            // 
            // numeric_gameConfigSugarAmountMax
            // 
            this.numeric_gameConfigSugarAmountMax.Location = new System.Drawing.Point(153, 90);
            this.numeric_gameConfigSugarAmountMax.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numeric_gameConfigSugarAmountMax.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numeric_gameConfigSugarAmountMax.Name = "numeric_gameConfigSugarAmountMax";
            this.numeric_gameConfigSugarAmountMax.Size = new System.Drawing.Size(44, 20);
            this.numeric_gameConfigSugarAmountMax.TabIndex = 20;
            this.numeric_gameConfigSugarAmountMax.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numeric_gameConfigSugarAmountMax.ValueChanged += new System.EventHandler(this.numeric_gameConfigSugarAmountMax_ValueChanged);
            // 
            // numeric_gameConfigBoardWidth
            // 
            this.numeric_gameConfigBoardWidth.Location = new System.Drawing.Point(153, 117);
            this.numeric_gameConfigBoardWidth.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numeric_gameConfigBoardWidth.Name = "numeric_gameConfigBoardWidth";
            this.numeric_gameConfigBoardWidth.Size = new System.Drawing.Size(44, 20);
            this.numeric_gameConfigBoardWidth.TabIndex = 21;
            this.numeric_gameConfigBoardWidth.ValueChanged += new System.EventHandler(this.numeric_gameConfigBoardWidth_ValueChanged);
            // 
            // numeric_gameConfigPoints
            // 
            this.numeric_gameConfigPoints.Location = new System.Drawing.Point(153, 246);
            this.numeric_gameConfigPoints.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numeric_gameConfigPoints.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numeric_gameConfigPoints.Name = "numeric_gameConfigPoints";
            this.numeric_gameConfigPoints.Size = new System.Drawing.Size(44, 20);
            this.numeric_gameConfigPoints.TabIndex = 26;
            this.numeric_gameConfigPoints.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numeric_gameConfigPoints.ValueChanged += new System.EventHandler(this.numeric_gameConfigPoints_ValueChanged);
            // 
            // numeric_gameConfigStartMoney
            // 
            this.numeric_gameConfigStartMoney.Location = new System.Drawing.Point(153, 169);
            this.numeric_gameConfigStartMoney.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numeric_gameConfigStartMoney.Name = "numeric_gameConfigStartMoney";
            this.numeric_gameConfigStartMoney.Size = new System.Drawing.Size(44, 20);
            this.numeric_gameConfigStartMoney.TabIndex = 23;
            this.numeric_gameConfigStartMoney.ValueChanged += new System.EventHandler(this.numeric_gameConfigStartMoney_ValueChanged);
            // 
            // numeric_gameConfigTicks
            // 
            this.numeric_gameConfigTicks.Location = new System.Drawing.Point(153, 195);
            this.numeric_gameConfigTicks.Maximum = new decimal(new int[] {
            40,
            0,
            0,
            0});
            this.numeric_gameConfigTicks.Name = "numeric_gameConfigTicks";
            this.numeric_gameConfigTicks.Size = new System.Drawing.Size(44, 20);
            this.numeric_gameConfigTicks.TabIndex = 24;
            this.numeric_gameConfigTicks.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numeric_gameConfigTicks.ValueChanged += new System.EventHandler(this.numeric_gameConfigTime_ValueChanged);
            // 
            // numeric_gameConfigBoardHeigth
            // 
            this.numeric_gameConfigBoardHeigth.Location = new System.Drawing.Point(153, 143);
            this.numeric_gameConfigBoardHeigth.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numeric_gameConfigBoardHeigth.Name = "numeric_gameConfigBoardHeigth";
            this.numeric_gameConfigBoardHeigth.Size = new System.Drawing.Size(44, 20);
            this.numeric_gameConfigBoardHeigth.TabIndex = 22;
            this.numeric_gameConfigBoardHeigth.ValueChanged += new System.EventHandler(this.numeric_gameConfigBoardHeigth_ValueChanged);
            // 
            // SugarAmountMin
            // 
            this.SugarAmountMin.AutoSize = true;
            this.SugarAmountMin.Location = new System.Drawing.Point(6, 67);
            this.SugarAmountMin.Name = "SugarAmountMin";
            this.SugarAmountMin.Size = new System.Drawing.Size(121, 13);
            this.SugarAmountMin.TabIndex = 7;
            this.SugarAmountMin.Text = "Mind. Zuckeranhäufung";
            // 
            // SugarMax
            // 
            this.SugarMax.AutoSize = true;
            this.SugarMax.Location = new System.Drawing.Point(6, 41);
            this.SugarMax.Name = "SugarMax";
            this.SugarMax.Size = new System.Drawing.Size(67, 13);
            this.SugarMax.TabIndex = 5;
            this.SugarMax.Text = "Max. Zucker";
            // 
            // numeric_gameConfigSugarMin
            // 
            this.numeric_gameConfigSugarMin.Location = new System.Drawing.Point(153, 11);
            this.numeric_gameConfigSugarMin.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.numeric_gameConfigSugarMin.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numeric_gameConfigSugarMin.Name = "numeric_gameConfigSugarMin";
            this.numeric_gameConfigSugarMin.Size = new System.Drawing.Size(44, 20);
            this.numeric_gameConfigSugarMin.TabIndex = 17;
            this.numeric_gameConfigSugarMin.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numeric_gameConfigSugarMin.ValueChanged += new System.EventHandler(this.numeric_gameConfigSugarMin_ValueChanged);
            // 
            // numeric_gameConfigSugarMax
            // 
            this.numeric_gameConfigSugarMax.Location = new System.Drawing.Point(153, 38);
            this.numeric_gameConfigSugarMax.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.numeric_gameConfigSugarMax.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numeric_gameConfigSugarMax.Name = "numeric_gameConfigSugarMax";
            this.numeric_gameConfigSugarMax.Size = new System.Drawing.Size(44, 20);
            this.numeric_gameConfigSugarMax.TabIndex = 18;
            this.numeric_gameConfigSugarMax.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numeric_gameConfigSugarMax.ValueChanged += new System.EventHandler(this.numeric_gameConfigSugarMax_ValueChanged);
            // 
            // SugarMin
            // 
            this.SugarMin.AutoSize = true;
            this.SugarMin.Location = new System.Drawing.Point(6, 14);
            this.SugarMin.Name = "SugarMin";
            this.SugarMin.Size = new System.Drawing.Size(70, 13);
            this.SugarMin.TabIndex = 3;
            this.SugarMin.Text = "Mind. Zucker";
            // 
            // btn_gameConfigSave
            // 
            this.btn_gameConfigSave.Enabled = false;
            this.btn_gameConfigSave.Location = new System.Drawing.Point(134, 19);
            this.btn_gameConfigSave.Name = "btn_gameConfigSave";
            this.btn_gameConfigSave.Size = new System.Drawing.Size(75, 23);
            this.btn_gameConfigSave.TabIndex = 16;
            this.btn_gameConfigSave.Text = "Sichern";
            this.btn_gameConfigSave.UseVisualStyleBackColor = true;
            this.btn_gameConfigSave.Click += new System.EventHandler(this.btn_gameConfigSave_Click);
            // 
            // btn_gameConfigLoad
            // 
            this.btn_gameConfigLoad.Location = new System.Drawing.Point(62, 19);
            this.btn_gameConfigLoad.Name = "btn_gameConfigLoad";
            this.btn_gameConfigLoad.Size = new System.Drawing.Size(66, 23);
            this.btn_gameConfigLoad.TabIndex = 15;
            this.btn_gameConfigLoad.Text = "Laden";
            this.btn_gameConfigLoad.UseVisualStyleBackColor = true;
            this.btn_gameConfigLoad.Click += new System.EventHandler(this.btn_gameConfigLoad_Click);
            // 
            // buttonView
            // 
            this.buttonView.Enabled = false;
            this.buttonView.Location = new System.Drawing.Point(102, 12);
            this.buttonView.Name = "buttonView";
            this.buttonView.Size = new System.Drawing.Size(75, 23);
            this.buttonView.TabIndex = 40;
            this.buttonView.Text = "Ansicht";
            this.buttonView.UseVisualStyleBackColor = true;
            this.buttonView.Click += new System.EventHandler(this.buttonView_Click);
            // 
            // buttonCostCalculator
            // 
            this.buttonCostCalculator.Location = new System.Drawing.Point(12, 12);
            this.buttonCostCalculator.Name = "buttonCostCalculator";
            this.buttonCostCalculator.Size = new System.Drawing.Size(84, 23);
            this.buttonCostCalculator.TabIndex = 44;
            this.buttonCostCalculator.Text = "Kostenrechner";
            this.buttonCostCalculator.UseVisualStyleBackColor = true;
            this.buttonCostCalculator.Click += new System.EventHandler(this.buttonCostCalculator_Click);
            // 
            // ConfigurationPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(271, 457);
            this.Controls.Add(this.buttonCostCalculator);
            this.Controls.Add(this.buttonView);
            this.Controls.Add(this.ppanel);
            this.Controls.Add(this.Start);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ConfigurationPanel";
            this.Text = "Spielkonfiguration";
            this.ppanel.ResumeLayout(false);
            this.pnl_GameConfig.ResumeLayout(false);
            this.pnl_GameConfig.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_gameConfigMaxTicks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_gameConfigSugarAmountMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_gameConfigSugarAmountMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_gameConfigBoardWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_gameConfigPoints)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_gameConfigStartMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_gameConfigTicks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_gameConfigBoardHeigth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_gameConfigSugarMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_gameConfigSugarMax)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Start;
        private System.Windows.Forms.Timer GameTick;
        private System.Windows.Forms.GroupBox ppanel;
        private System.Windows.Forms.Button btn_gameConfigSave;
        private System.Windows.Forms.Button btn_gameConfigLoad;
        private System.Windows.Forms.Button btn_gameConfigNew;
        private System.Windows.Forms.Panel pnl_GameConfig;
        private System.Windows.Forms.Label SugarMax;
        private System.Windows.Forms.NumericUpDown numeric_gameConfigSugarMin;
        private System.Windows.Forms.NumericUpDown numeric_gameConfigSugarMax;
        private System.Windows.Forms.Label SugarMin;
        private System.Windows.Forms.Label Points;
        private System.Windows.Forms.Label Ticks;
        private System.Windows.Forms.Label StartMoney;
        private System.Windows.Forms.Label BoardHeigth;
        private System.Windows.Forms.Label BoardWidth;
        private System.Windows.Forms.Label SugarAmountMax;
        private System.Windows.Forms.NumericUpDown numeric_gameConfigSugarAmountMin;
        private System.Windows.Forms.NumericUpDown numeric_gameConfigSugarAmountMax;
        private System.Windows.Forms.NumericUpDown numeric_gameConfigBoardWidth;
        private System.Windows.Forms.NumericUpDown numeric_gameConfigPoints;
        private System.Windows.Forms.NumericUpDown numeric_gameConfigStartMoney;
        private System.Windows.Forms.NumericUpDown numeric_gameConfigTicks;
        private System.Windows.Forms.NumericUpDown numeric_gameConfigBoardHeigth;
        private System.Windows.Forms.Label SugarAmountMin;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button buttonView;
        private System.Windows.Forms.Button btn_player2loadAI;
        private System.Windows.Forms.Label ai_dll;
        private System.Windows.Forms.Button btn_player1loadAI;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label MaxTicks;
        private System.Windows.Forms.NumericUpDown numeric_gameConfigMaxTicks;
        private System.Windows.Forms.Button buttonCostCalculator;
    }
}