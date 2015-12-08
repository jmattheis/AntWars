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
            this.ppppanel = new System.Windows.Forms.GroupBox();
            this.pnl_player1Config = new System.Windows.Forms.Panel();
            this.textbox_player1Name = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_player1ConfigNew = new System.Windows.Forms.Button();
            this.btn_player1ConfigSave = new System.Windows.Forms.Button();
            this.btn_player1ConfigLoad = new System.Windows.Forms.Button();
            this.ppanel = new System.Windows.Forms.GroupBox();
            this.btn_gameConfigNew = new System.Windows.Forms.Button();
            this.pnl_GameConfig = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.numeric_gameConfigSugarMin = new System.Windows.Forms.NumericUpDown();
            this.numeric_gameConfigSugarMax = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_gameConfigSave = new System.Windows.Forms.Button();
            this.btn_gameConfigLoad = new System.Windows.Forms.Button();
            this.panel = new System.Windows.Forms.GroupBox();
            this.btn_player2ConfigNew = new System.Windows.Forms.Button();
            this.btn_player2ConfigSave = new System.Windows.Forms.Button();
            this.btn_player2ConfigLoad = new System.Windows.Forms.Button();
            this.ppppanel.SuspendLayout();
            this.pnl_player1Config.SuspendLayout();
            this.ppanel.SuspendLayout();
            this.pnl_GameConfig.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_gameConfigSugarMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_gameConfigSugarMax)).BeginInit();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // Start
            // 
            this.Start.Location = new System.Drawing.Point(594, 12);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(75, 23);
            this.Start.TabIndex = 0;
            this.Start.Text = "Start";
            this.Start.UseVisualStyleBackColor = true;
            this.Start.Click += new System.EventHandler(this.Start_Click);
            // 
            // GameTick
            // 
            this.GameTick.Tick += new System.EventHandler(this.GameTick_Tick);
            // 
            // ppppanel
            // 
            this.ppppanel.Controls.Add(this.pnl_player1Config);
            this.ppppanel.Controls.Add(this.btn_player1ConfigNew);
            this.ppppanel.Controls.Add(this.btn_player1ConfigSave);
            this.ppppanel.Controls.Add(this.btn_player1ConfigLoad);
            this.ppppanel.Location = new System.Drawing.Point(12, 42);
            this.ppppanel.Name = "ppppanel";
            this.ppppanel.Size = new System.Drawing.Size(215, 408);
            this.ppppanel.TabIndex = 5;
            this.ppppanel.TabStop = false;
            this.ppppanel.Text = "Player 1 Configuration";
            // 
            // pnl_player1Config
            // 
            this.pnl_player1Config.Controls.Add(this.textbox_player1Name);
            this.pnl_player1Config.Controls.Add(this.label1);
            this.pnl_player1Config.Enabled = false;
            this.pnl_player1Config.Location = new System.Drawing.Point(3, 48);
            this.pnl_player1Config.Name = "pnl_player1Config";
            this.pnl_player1Config.Size = new System.Drawing.Size(209, 354);
            this.pnl_player1Config.TabIndex = 4;
            // 
            // textbox_player1Name
            // 
            this.textbox_player1Name.Location = new System.Drawing.Point(44, 11);
            this.textbox_player1Name.Name = "textbox_player1Name";
            this.textbox_player1Name.Size = new System.Drawing.Size(162, 20);
            this.textbox_player1Name.TabIndex = 2;
            this.textbox_player1Name.TextChanged += new System.EventHandler(this.textbox_player1Name_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Name";
            // 
            // btn_player1ConfigNew
            // 
            this.btn_player1ConfigNew.Location = new System.Drawing.Point(6, 19);
            this.btn_player1ConfigNew.Name = "btn_player1ConfigNew";
            this.btn_player1ConfigNew.Size = new System.Drawing.Size(50, 23);
            this.btn_player1ConfigNew.TabIndex = 3;
            this.btn_player1ConfigNew.Text = "New";
            this.btn_player1ConfigNew.UseVisualStyleBackColor = true;
            this.btn_player1ConfigNew.Click += new System.EventHandler(this.btn_player1ConfigNew_Click);
            // 
            // btn_player1ConfigSave
            // 
            this.btn_player1ConfigSave.Enabled = false;
            this.btn_player1ConfigSave.Location = new System.Drawing.Point(134, 19);
            this.btn_player1ConfigSave.Name = "btn_player1ConfigSave";
            this.btn_player1ConfigSave.Size = new System.Drawing.Size(75, 23);
            this.btn_player1ConfigSave.TabIndex = 2;
            this.btn_player1ConfigSave.Text = "Save";
            this.btn_player1ConfigSave.UseVisualStyleBackColor = true;
            this.btn_player1ConfigSave.Click += new System.EventHandler(this.btn_player1ConfigSave_Click);
            // 
            // btn_player1ConfigLoad
            // 
            this.btn_player1ConfigLoad.Location = new System.Drawing.Point(62, 19);
            this.btn_player1ConfigLoad.Name = "btn_player1ConfigLoad";
            this.btn_player1ConfigLoad.Size = new System.Drawing.Size(66, 23);
            this.btn_player1ConfigLoad.TabIndex = 2;
            this.btn_player1ConfigLoad.Text = "Load";
            this.btn_player1ConfigLoad.UseVisualStyleBackColor = true;
            this.btn_player1ConfigLoad.Click += new System.EventHandler(this.btn_player1ConfigLoad_Click);
            // 
            // ppanel
            // 
            this.ppanel.Controls.Add(this.btn_gameConfigNew);
            this.ppanel.Controls.Add(this.pnl_GameConfig);
            this.ppanel.Controls.Add(this.btn_gameConfigSave);
            this.ppanel.Controls.Add(this.btn_gameConfigLoad);
            this.ppanel.Location = new System.Drawing.Point(233, 42);
            this.ppanel.Name = "ppanel";
            this.ppanel.Size = new System.Drawing.Size(215, 408);
            this.ppanel.TabIndex = 6;
            this.ppanel.TabStop = false;
            this.ppanel.Text = "Game Configuration";
            // 
            // btn_gameConfigNew
            // 
            this.btn_gameConfigNew.Location = new System.Drawing.Point(6, 19);
            this.btn_gameConfigNew.Name = "btn_gameConfigNew";
            this.btn_gameConfigNew.Size = new System.Drawing.Size(50, 23);
            this.btn_gameConfigNew.TabIndex = 5;
            this.btn_gameConfigNew.Text = "New";
            this.btn_gameConfigNew.UseVisualStyleBackColor = true;
            // 
            // pnl_GameConfig
            // 
            this.pnl_GameConfig.Controls.Add(this.label3);
            this.pnl_GameConfig.Controls.Add(this.numeric_gameConfigSugarMin);
            this.pnl_GameConfig.Controls.Add(this.numeric_gameConfigSugarMax);
            this.pnl_GameConfig.Controls.Add(this.label2);
            this.pnl_GameConfig.Enabled = false;
            this.pnl_GameConfig.Location = new System.Drawing.Point(4, 48);
            this.pnl_GameConfig.Name = "pnl_GameConfig";
            this.pnl_GameConfig.Size = new System.Drawing.Size(200, 354);
            this.pnl_GameConfig.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "SugarMax";
            // 
            // numeric_gameConfigSugarMin
            // 
            this.numeric_gameConfigSugarMin.Location = new System.Drawing.Point(64, 12);
            this.numeric_gameConfigSugarMin.Name = "numeric_gameConfigSugarMin";
            this.numeric_gameConfigSugarMin.Size = new System.Drawing.Size(44, 20);
            this.numeric_gameConfigSugarMin.TabIndex = 4;
            // 
            // numeric_gameConfigSugarMax
            // 
            this.numeric_gameConfigSugarMax.Location = new System.Drawing.Point(64, 39);
            this.numeric_gameConfigSugarMax.Name = "numeric_gameConfigSugarMax";
            this.numeric_gameConfigSugarMax.Size = new System.Drawing.Size(44, 20);
            this.numeric_gameConfigSugarMax.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "SugarMin";
            // 
            // btn_gameConfigSave
            // 
            this.btn_gameConfigSave.Location = new System.Drawing.Point(134, 19);
            this.btn_gameConfigSave.Name = "btn_gameConfigSave";
            this.btn_gameConfigSave.Size = new System.Drawing.Size(75, 23);
            this.btn_gameConfigSave.TabIndex = 1;
            this.btn_gameConfigSave.Text = "Save";
            this.btn_gameConfigSave.UseVisualStyleBackColor = true;
            // 
            // btn_gameConfigLoad
            // 
            this.btn_gameConfigLoad.Location = new System.Drawing.Point(62, 19);
            this.btn_gameConfigLoad.Name = "btn_gameConfigLoad";
            this.btn_gameConfigLoad.Size = new System.Drawing.Size(66, 23);
            this.btn_gameConfigLoad.TabIndex = 0;
            this.btn_gameConfigLoad.Text = "Load";
            this.btn_gameConfigLoad.UseVisualStyleBackColor = true;
            // 
            // panel
            // 
            this.panel.Controls.Add(this.btn_player2ConfigNew);
            this.panel.Controls.Add(this.btn_player2ConfigSave);
            this.panel.Controls.Add(this.btn_player2ConfigLoad);
            this.panel.Location = new System.Drawing.Point(454, 42);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(215, 408);
            this.panel.TabIndex = 6;
            this.panel.TabStop = false;
            this.panel.Text = "Player 2 Configuration";
            // 
            // btn_player2ConfigNew
            // 
            this.btn_player2ConfigNew.Location = new System.Drawing.Point(6, 19);
            this.btn_player2ConfigNew.Name = "btn_player2ConfigNew";
            this.btn_player2ConfigNew.Size = new System.Drawing.Size(50, 23);
            this.btn_player2ConfigNew.TabIndex = 8;
            this.btn_player2ConfigNew.Text = "New";
            this.btn_player2ConfigNew.UseVisualStyleBackColor = true;
            // 
            // btn_player2ConfigSave
            // 
            this.btn_player2ConfigSave.Location = new System.Drawing.Point(134, 19);
            this.btn_player2ConfigSave.Name = "btn_player2ConfigSave";
            this.btn_player2ConfigSave.Size = new System.Drawing.Size(75, 23);
            this.btn_player2ConfigSave.TabIndex = 2;
            this.btn_player2ConfigSave.Text = "Save";
            this.btn_player2ConfigSave.UseVisualStyleBackColor = true;
            // 
            // btn_player2ConfigLoad
            // 
            this.btn_player2ConfigLoad.Location = new System.Drawing.Point(62, 19);
            this.btn_player2ConfigLoad.Name = "btn_player2ConfigLoad";
            this.btn_player2ConfigLoad.Size = new System.Drawing.Size(66, 23);
            this.btn_player2ConfigLoad.TabIndex = 2;
            this.btn_player2ConfigLoad.Text = "Load";
            this.btn_player2ConfigLoad.UseVisualStyleBackColor = true;
            // 
            // ConfigurationPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(772, 676);
            this.Controls.Add(this.ppanel);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.ppppanel);
            this.Controls.Add(this.Start);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ConfigurationPanel";
            this.Text = "ConfigurationPanel";
            this.Load += new System.EventHandler(this.ConfigurationPanel_Load);
            this.ppppanel.ResumeLayout(false);
            this.pnl_player1Config.ResumeLayout(false);
            this.pnl_player1Config.PerformLayout();
            this.ppanel.ResumeLayout(false);
            this.pnl_GameConfig.ResumeLayout(false);
            this.pnl_GameConfig.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_gameConfigSugarMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_gameConfigSugarMax)).EndInit();
            this.panel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Start;
        private System.Windows.Forms.Timer GameTick;
        private System.Windows.Forms.GroupBox ppppanel;
        private System.Windows.Forms.Button btn_player1ConfigSave;
        private System.Windows.Forms.Button btn_player1ConfigLoad;
        private System.Windows.Forms.GroupBox ppanel;
        private System.Windows.Forms.Button btn_gameConfigSave;
        private System.Windows.Forms.Button btn_gameConfigLoad;
        private System.Windows.Forms.GroupBox panel;
        private System.Windows.Forms.Button btn_player2ConfigSave;
        private System.Windows.Forms.Button btn_player2ConfigLoad;
        private System.Windows.Forms.Button btn_player1ConfigNew;
        private System.Windows.Forms.Panel pnl_player1Config;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_gameConfigNew;
        private System.Windows.Forms.Panel pnl_GameConfig;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numeric_gameConfigSugarMin;
        private System.Windows.Forms.NumericUpDown numeric_gameConfigSugarMax;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_player2ConfigNew;
        private System.Windows.Forms.TextBox textbox_player1Name;
    }
}